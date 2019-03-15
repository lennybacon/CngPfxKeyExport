using System;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;

namespace Sample
{
  internal static class X509CertificateExtensions
  {
    public static SafeCertContextHandle GetCertificateContext(
      this X509Certificate certificate)
    {
      GC.KeepAlive(certificate);
      var certContext = X509Native.DuplicateCertContext(certificate.Handle);

      return certContext;
    }

    public static bool HasCngKey(
      this X509Certificate certificate)
    {
      using (var certContext = certificate.GetCertificateContext())
      {
        if (!X509Native.HasCertificateProperty(
          certContext,
          NativeMethods.Crypt32.CertificateProperty.KeyProviderInfo))
        {
          return false;
        }

        var keyProvInfo =
          X509Native.GetCertificateProperty<X509Native.CryptKeyProvInfo>(
            certContext,
            NativeMethods.Crypt32.CertificateProperty.KeyProviderInfo
          );

        return keyProvInfo.dwProvType == 0;
      }
    }

    [SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
    public static CngKey GetCngPrivateKey(
      this X509Certificate2 certificate)
    {
      if (certificate == null)
      {
        throw new ArgumentNullException(nameof(certificate));
      }

      if (!certificate.HasPrivateKey ||
          !certificate.HasCngKey())
      {
        return null;
      }

      try
      {
        using (
          var
          certContext = certificate.GetCertificateContext())
        {
          using (
            var privateKeyHandle =
              X509Native.AcquireCngPrivateKey(certContext))
          {
            // We need to assert for full trust when opening the CNG key because
            // CngKey.Open(SafeNCryptKeyHandle) does a full demand for full trust,
            // and we want to allow access to a certificate's private key by
            // anyone who has access to the certificate itself.
            new PermissionSet(PermissionState.Unrestricted).Assert();
            return CngKey.Open(privateKeyHandle, CngKeyHandleOpenOptions.None);
          }
        }
      }
      catch (CryptographicException ex)
      {
        throw new CryptographicException(
          "The private key for the certificate with serial number '" +
          certificate.SerialNumber +
          "' could not be found because it does not exist or" +
          " cannot be accessed due to missing permissions.",
          ex);
      }
    }
  }
}