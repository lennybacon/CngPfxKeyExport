using System;
using System.ComponentModel;
using System.Diagnostics;
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
      using(var certificate = new X509Certificate2(
        ".\\cng-rsa.pfx",
        "1234",
        X509KeyStorageFlags.Exportable)){

        using (var rsa = (RSACng)certificate.GetRSAPrivateKey())
        {

          using (var key = rsa.Key)
          {
            Trace.WriteLine(key.ExportPolicy);

            var exportedKeyBytes = ExportPkcs8KeyBlob(
              key.Handle,
              "4321",
              21);

            Assert.AreEqual(
              Base64PrivateKey, 
              Convert.ToBase64String(exportedKeyBytes));


          }
        }
      }
    }

    public const string MicrosoftSoftwareKeyStorageProvider = 
      "Microsoft Software Key Storage Provider";

    public const string Base64PrivateKey =
      "MIIEzQIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQCu7GSXCiCSkzRcF46k4" +
      "AE64BKwxVmt0/353hqir+JDkhU00Mq+v7KgsKiFjO5jBNh5XcSN6OSDYfOzw9lVzUazNZ" +
      "kOtfuZeShxl9L0mq7AOBPmnqfDDPt683qIdMtuR7V5bmZtHi69kuY8nPi2l7fxVZhwrVo" +
      "AYi/4QrOWb0ZlUUSHbnCZ+aTbt/ad3YktkSS9vaRMvy+M6RIz4NRRvCJEsDXpFbb+qG8h" +
      "0164Lshv86XlppUGRsc/vY4082vamASv/mt0NqhSqY/yEu5v3yCjzV9CXlQ9ZDCZex/zT" +
      "6K5LScZ5bcxkEX/H9cx5JiasMT9ubq/Poxrh49Q6+clfrGxAgMBAAECggEAF+IGyeiEEf" +
      "8vQvOkcjZzdIprgt8vI2CyaI8+q7+/8OHdK1zmkayywuXb3IAlfDeJJuj6kTWfHaEeGQl" +
      "Af0qLwKQsxalrNMUqFHhaQTNtcKk3bmFzHlqDa4Ia1M69h80apf3A1l0snI2WCeiUvLly" +
      "T+0T5y6D/1Foo0jYJE4FGogIOX3XxFnZ6BmgQ+ZVATW4ws1G0zW3N18Ou576USCcklqEq" +
      "OoD3zdYrBi+qJbZQ4j1n/4tMIkXVDa1fZvzoh6XJsn11jJ47DiuFcgusYozFtJmlM0y0E" +
      "wGrGMDZm0UtaIjDphtJFGEyjkR+sS+/E752fm0+9EuJxECE0bVnHoQkQKBgQDY/SqdNmU" +
      "lb/ntq8h4HV6QRvMxTzYFaWMkiIQTrJhnRobNJuhiqqPpqurIBxgKY3g3z50Fs6XVjgij" +
      "sl6V3uXzta9Ho4i2tA3J3lMFqoyIUV9HchkuysXUdqGpeLB2rM3RMGGfItq9K7xaMb9Oj" +
      "zMlHSicE6lrez3L8TWtmgoaSwKBgQDOXy0+yM/xAMFX3WiyF47gNSizSomq2fz/yd5bP8" +
      "b8e0UEaWkLR+jUjsknTfEJ99HMW0dStPsgO8a4QyQT8ynY+kb/MK9Xnz/QMRh4r4298XU" +
      "l6ZFCW6ZJIKB6cXPwWRRbukR5MeFVOJ0o5HzmOVMbGcyLHWMtSn10+ZsxGJFmcwKBgQCv" +
      "ZZ0/rUt/Qo9lBbmrFhptR1ynXB8PqsuAKXWRra8XtBOc2zl3H/YVGJpljA5rv1Ha01Ba3" +
      "odLI19qavE39hAsuozvvInzHYITzkmPx/eG7Te2Oc2PXEsjXa15ntwNYcuQr6oJh5QG28" +
      "aJpbK9HtW5x2MfHmmRPvKJ2vWH2X8XFwKBgQCekVr+huXf1Ci7DpDHZnqNo8rmGDu3X0+" +
      "aas3DZznJ/h2FykjANjycNioxXR37/sLhNrGSxyS+G7ARHOW3vntFEOlEY3AW73Hk0hRv" +
      "htRuQf01aEYIqssWHU+xRUNERe3ynSjHxp/RD3MSXJ3rd9h3Vldn/OibgETtgGzSSIJQK" +
      "QKBgD6t7ixylbM05Z5XomSUA3+/txF4mHKyJLBoIL+9DESkJ1lWxNmytPcZ168cyEV9Q7" +
      "Of01K63a5hObnFt2/9OaIqcTONmb3EbwNyvk8n8fB86Tz54xPqJNFd6FVG/LsacIjsDba" +
      "w05ZExEkIaTRuo8twubjBdL5xTDBIlbOcoIOToA0wCwYDVR0PMQQDAgCQ";

    private static readonly RNGCryptoServiceProvider RandomNumberGenerator =
      new RNGCryptoServiceProvider();

    private static unsafe byte[] ExportPkcs8KeyBlob(
        SafeNCryptKeyHandle keyHandle,
        string password,
        int kdfCount)
    {
        var pbeParams = new NativeMethods.NCrypt.PbeParams();
        NativeMethods.NCrypt.PbeParams* pbeParamsPtr = &pbeParams;

        var salt = new byte[NativeMethods.NCrypt.PbeParams.RgbSaltSize];

        RandomNumberGenerator.GetBytes(salt);
        
        pbeParams.Params.cbSalt = salt.Length;
        Marshal.Copy(salt, 0, (IntPtr)pbeParams.rgbSalt, salt.Length);
        pbeParams.Params.iIterations = kdfCount;
        var keyName = Guid.NewGuid().ToString("D");
        fixed (char* passwordPtr = password)
        fixed (char* keyNamePtr = keyName)
        fixed (byte* oidPtr = s_pkcs12TripleDesOidBytes)
        {
            NativeMethods.NCrypt.NCryptBuffer* buffers =
                stackalloc NativeMethods.NCrypt.NCryptBuffer[3];

            buffers[0] = new NativeMethods.NCrypt.NCryptBuffer
            {
                BufferType = NativeMethods.NCrypt.BufferType.PkcsSecret,
                cbBuffer = checked(2 * (password.Length + 1)),
                pvBuffer = (IntPtr)passwordPtr,
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

            buffers[2] = new NativeMethods.NCrypt.NCryptBuffer
            {
                BufferType = NativeMethods.NCrypt.BufferType.PkcsAlgParam,
                cbBuffer = sizeof(NativeMethods.NCrypt.PbeParams),
                pvBuffer = (IntPtr)pbeParamsPtr,
            };

            var desc = new NativeMethods.NCrypt.NCryptBufferDesc
            {
                cBuffers = 3,
                pBuffers = (IntPtr)buffers,
                ulVersion = 0,
            };

            int result = NativeMethods.NCrypt.NCryptExportKey(
                keyHandle,
                IntPtr.Zero,
                NCRYPT_PKCS8_PRIVATE_KEY_BLOB,
                ref desc,
                null,
                0,
                out int bytesNeeded,
                0);

            if (result != 0)
            {
                throw new Win32Exception(result);
            }

            byte[] exported = new byte[bytesNeeded];

            result = NativeMethods.NCrypt.NCryptExportKey(
                keyHandle,
                IntPtr.Zero,
                NCRYPT_PKCS8_PRIVATE_KEY_BLOB,
                ref desc,
                exported,
                exported.Length,
                out bytesNeeded,
                0);

            if (result != 0)
            {
                throw new Win32Exception(result);
            }

            if (bytesNeeded != exported.Length)
            {
                Array.Resize(ref exported, bytesNeeded);
            }


            NativeMethods.NCrypt.NCryptOpenStorageProvider(
              out var safeNCryptProviderHandle,
              MicrosoftSoftwareKeyStorageProvider,
              0);

            NativeMethods.NCrypt.NCryptBuffer* buffers2 =
              stackalloc NativeMethods.NCrypt.NCryptBuffer[4];

            buffers2[0] = new NativeMethods.NCrypt.NCryptBuffer
            {
              BufferType = NativeMethods.NCrypt.BufferType.PkcsSecret,
              cbBuffer = checked(2 * (password.Length + 1)),
              pvBuffer = (IntPtr)passwordPtr,
            };

            if (buffers2[0].pvBuffer == IntPtr.Zero)
            {
              buffers2[0].cbBuffer = 0;
            }

            buffers2[1] = new NativeMethods.NCrypt.NCryptBuffer
            {
              BufferType = NativeMethods.NCrypt.BufferType.PkcsAlgOid,
              cbBuffer = s_pkcs12TripleDesOidBytes.Length,
              pvBuffer = (IntPtr)oidPtr,
            };

            buffers2[2] = new NativeMethods.NCrypt.NCryptBuffer
            {
              BufferType = NativeMethods.NCrypt.BufferType.PkcsAlgParam,
              cbBuffer = sizeof(NativeMethods.NCrypt.PbeParams),
              pvBuffer = (IntPtr)pbeParamsPtr,
            };

            buffers2[3] = new NativeMethods.NCrypt.NCryptBuffer
            {
              BufferType = NativeMethods.NCrypt.BufferType.PkcsKeyName,
              cbBuffer = checked(2 * (keyName.Length + 1)),
              pvBuffer = (IntPtr)keyNamePtr,
            };

            var desc2 = new NativeMethods.NCrypt.NCryptBufferDesc
            {
              cBuffers = 4,
              pBuffers = (IntPtr)buffers2,
              ulVersion = 0,
            };

            result = NativeMethods.NCrypt.NCryptImportKey(
              safeNCryptProviderHandle,
              IntPtr.Zero,
              NCRYPT_PKCS8_PRIVATE_KEY_BLOB,
              ref desc2,
              out var safeNCryptKeyHandle,
              exported,
              exported.Length,
              NCRYPT_DO_NOT_FINALIZE_FLAG);

            if (result != 0)
            {
              throw new Win32Exception(result);
            }

            var exportPolicyBytes = BitConverter.GetBytes(
              (int)(CngExportPolicies.AllowExport |
                         CngExportPolicies.AllowPlaintextExport | 
                         CngExportPolicies.AllowArchiving | 
                         CngExportPolicies.AllowPlaintextArchiving));

            NativeMethods.NCrypt.NCryptSetProperty(
              safeNCryptKeyHandle,
              "Export Policy",
              exportPolicyBytes,
              exportPolicyBytes.Length,
              CngPropertyOptions.Persist);

            NativeMethods.NCrypt.NCryptFinalizeKey(
              safeNCryptKeyHandle,
              0);

            using (var key2 = CngKey.Open(keyName))
            {
              Trace.WriteLine(key2.ExportPolicy);

              return key2.Export(CngKeyBlobFormat.Pkcs8PrivateBlob);

            }
        }
    }

    private const int NCRYPT_DO_NOT_FINALIZE_FLAG = 0x00000400;


  }
}
