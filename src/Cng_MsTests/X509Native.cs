using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using Microsoft.Win32.SafeHandles;

namespace Sample
{
  internal class X509Native
  {
    [StructLayout(LayoutKind.Sequential)]
    internal struct CryptKeyProvInfo
    {
      [MarshalAs(UnmanagedType.LPWStr)]
      internal string pwszContainerName;

      [MarshalAs(UnmanagedType.LPWStr)]
      internal string pwszProvName;

      internal int dwProvType;
      internal int dwFlags;
      internal int cProvParam;
      internal IntPtr rgProvParam;
      internal int dwKeySpec;
    }

    [SecurityCritical]
    internal static unsafe T GetCertificateProperty<T>(
      SafeCertContextHandle certificateContext,
      NativeMethods.Crypt32.CertificateProperty property
    ) where T : struct
    {
      fixed (byte* numRef =
        GetCertificateProperty(certificateContext, property))
      {
        return (T) Marshal.PtrToStructure(new IntPtr(numRef), typeof(T));
      }
    }
    internal enum ErrorCode
    {
      MoreData = 0xea,
      Success = 0
    }

    [SecurityCritical]
    public static byte[] GetCertificateProperty(
      SafeCertContextHandle certificateContext,
      NativeMethods.Crypt32.CertificateProperty property)
    {
      var pcbData = 0;
      if (!NativeMethods.Crypt32.CertGetCertificateContextProperty(
        certificateContext,
        property,
        null,
        ref pcbData)
      )
      {
        var code = (ErrorCode) Marshal.GetLastWin32Error();
        if (code != ErrorCode.MoreData)
        {
          throw new CryptographicException((int) code);
        }
      }
      var pvData = new byte[pcbData];
      if (!NativeMethods.Crypt32.CertGetCertificateContextProperty(
        certificateContext,
        property,
        pvData,
        ref pcbData)
      )
      {
        throw new CryptographicException(Marshal.GetLastWin32Error());
      }
      return pvData;
    }

    [SecurityCritical]

    internal static bool HasCertificateProperty(
      SafeCertContextHandle certificateContext,
      NativeMethods.Crypt32.CertificateProperty property)
    {
      var pcbData = 0;
      if (!NativeMethods.Crypt32.CertGetCertificateContextProperty(
        certificateContext,
        property,
        null,
        ref pcbData)
      )
      {
        return Marshal.GetLastWin32Error() == (int)ErrorCode.MoreData;
      }
      return true;
    }

    [SecurityCritical]
    internal static SafeCertContextHandle DuplicateCertContext(
      IntPtr context)
    {
      return NativeMethods.Crypt32.CertDuplicateCertificateContext(context);
    }

    [SecurityCritical]
    [SuppressMessage(
      "Microsoft.Security",
      "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands",
      Justification = "Safe use of LinkDemands")]
    public static SafeNCryptKeyHandle AcquireCngPrivateKey(
      SafeCertContextHandle certificateContext)
    {
      var freeKey = true;
      SafeNCryptKeyHandle privateKey = null;

      RuntimeHelpers.PrepareConstrainedRegions();
      try
      {
        if (!NativeMethods.Crypt32.CryptAcquireCertificatePrivateKey(
          certificateContext,
          NativeMethods.Crypt32.AcquireCertificateKeyOptions.AcquireOnlyNCryptKeys,
          IntPtr.Zero,
          out privateKey,
          out _,
          out freeKey))
        {
          throw new CryptographicException(Marshal.GetLastWin32Error());
        }

        return privateKey;
      }
      finally
      {
        // If we're not supposed to release they key handle, then we need to
        // bump the reference count on the safe handle to correspond to the
        // reference that Windows is holding on to.

        // This will prevent the CLR from freeing the object handle.
        //
        // This is certainly not the ideal way to solve this problem - it
        // would be better for SafeNCryptKeyHandle to maintain an internal
        // bool field that we could toggle here and have that suppress the
        // release when the CLR calls the ReleaseHandle override.
        // However, that field does not currently exist, so we'll use this
        // hack instead.
        if (privateKey != null
            &&
            !freeKey)
        {
          var addedRef = false;
          privateKey.DangerousAddRef(ref addedRef);
        }
      }
    }
  }
}