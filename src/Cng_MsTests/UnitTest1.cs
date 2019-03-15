using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32.SafeHandles;

namespace Sample
{
  [TestClass]
  public class UnitTest1
  {
    internal const string NCRYPT_PKCS8_PRIVATE_KEY_BLOB = "PKCS8_PRIVATEKEY";
    private static readonly byte[] s_pkcs12TripleDesOidBytes =
            System.Text.Encoding.ASCII.GetBytes("1.2.840.113549.1.12.1.3\0");

    [TestMethod]
    public void ShouldExportCngRsaKey()
    {
      var certificate = new X509Certificate2(
        ".\\cng-rsa.pfx",
        "1234",
        X509KeyStorageFlags.Exportable |
        X509KeyStorageFlags.MachineKeySet |
        X509KeyStorageFlags.PersistKeySet);

      using (var certContext = certificate.GetCertificateContext())
      {

        using (var privateKeyHandle =
          X509Native.AcquireCngPrivateKey(certContext))
        {
          ExportPkcs8KeyBlob(
            privateKeyHandle,
            "1234",
            1,
            out var bytesWritten,
            out var allocated);
        }
      }
    }

    private static readonly RNGCryptoServiceProvider RandomNumberGenerator =
      new RNGCryptoServiceProvider();

    internal static unsafe bool ExportPkcs8KeyBlob(
        SafeNCryptKeyHandle keyHandle,
        string password,
        int kdfCount,
        out int bytesWritten,
        out byte[] allocated)
    {
      using (var stringHandle = new SafeUnicodeStringHandle(password))
      {
        var pbrParamsPtr =
          Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NativeMethods.NCrypt.PbeParams)));
        var pbeParams = new NativeMethods.NCrypt.PbeParams();
        fixed (byte* oidPtr = s_pkcs12TripleDesOidBytes)
        {

          var salt = new byte[8];
          RandomNumberGenerator.GetBytes(salt);
          pbeParams.rgbSalt = salt;
          pbeParams.Params.cbSalt = pbeParams.rgbSalt.Length;
          pbeParams.Params.iIterations = kdfCount;

          var buffers = stackalloc NativeMethods.NCrypt.NCryptBuffer[3];
          buffers[0] = new NativeMethods.NCrypt.NCryptBuffer
          {
            BufferType = NativeMethods.NCrypt.BufferType.PkcsSecret,
            cbBuffer = checked(2 * (password.Length + 1)),
            pvBuffer = stringHandle.DangerousGetHandle(),
          };

          if (buffers[0].pvBuffer == IntPtr.Zero)
          {
            buffers[0].cbBuffer = 0;
          }

          buffers[1] = new NativeMethods.NCrypt.NCryptBuffer
          {
            BufferType = NativeMethods.NCrypt.BufferType.PkcsAlgOid,
            cbBuffer = s_pkcs12TripleDesOidBytes.Length,
            pvBuffer = (IntPtr)oidPtr,
          };

          Marshal.StructureToPtr(pbeParams, pbrParamsPtr, true);
          buffers[2] = new NativeMethods.NCrypt.NCryptBuffer
          {
            BufferType = NativeMethods.NCrypt.BufferType.PkcsAlgParam,
            cbBuffer = Marshal.SizeOf(typeof(NativeMethods.NCrypt.PbeParams)),
            pvBuffer = pbrParamsPtr
          };

          var desc = new NativeMethods.NCrypt.NCryptBufferDesc
          {
            cBuffers = 3,
            pBuffers = (IntPtr)buffers,
            ulVersion = 0,
          };


          var pbOutput = Array.Empty<byte>();
          var errorCode = NativeMethods.NCrypt.NCryptExportKey(
              keyHandle,
              IntPtr.Zero,
              NCRYPT_PKCS8_PRIVATE_KEY_BLOB,
              ref desc,
              ref pbOutput,
              0,
              out int numBytesNeeded,
              0);

          if (errorCode != 0)
          {
            throw new Win32Exception(errorCode);
          }

          allocated = null;

            allocated = new byte[numBytesNeeded];
            var destination = allocated;


          errorCode = NativeMethods.NCrypt.NCryptExportKey(
              keyHandle,
              IntPtr.Zero,
              NCRYPT_PKCS8_PRIVATE_KEY_BLOB,
              ref desc,
              ref destination,
              destination.Length,
              out numBytesNeeded,
              0);

          if (errorCode != 0)
          {
            throw new Win32Exception(errorCode);
          }

          if (numBytesNeeded != destination.Length)
          {
            byte[] trimmed = destination.Take(numBytesNeeded).ToArray();
            Array.Clear(allocated, 0, numBytesNeeded);
            allocated = trimmed;
          }

          bytesWritten = numBytesNeeded;
          return true;
        }
      }
    }



  }
}
