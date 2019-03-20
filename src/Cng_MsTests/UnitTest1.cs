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

            


          }
        }
      }
    }

    public const string MicrosoftSoftwareKeyStorageProvider = "Microsoft Software Key Storage Provider";

    public const string Base64PrivateKey =
      "MIIE+TAbBgoqhkiG9w0BDAEDMA0ECLh1R4milPMaAgEVBIIE2Gj2YaEZ/To1mXg" +
      "Yg2ZM1Q6TOgEQHO0T1dxJaZj2T190c7o+O3r8oL1IGIeXWgomNCpB2jKQl4CO5w" +
      "ybZfuYcSIT2Glq6nSm/rx9DjmSs/IIatM3sB5EN2BwJbO4FViegm4futdyj4ucS" +
      "M1Xl9csW9lZVPPE0K91xy/nAx4fQHB9uLC4hwjtGDOPWe63zmWpvmxdBuRrt2sl" +
      "1/7vKco+GFlDONi0wK0ZkJOueVYFby5ZcC7GCHvqJNEqGzTgJqesFVXbG+KYGK7" +
      "nccUpAH7/ZQj6E+mjidQ2gCmj3hyo7fLbSaNpGhktN70ewyc973F6NuYVBWF/2W" +
      "cvQfSSBJ6x7XuQXsV9ADzkjeJYXlqo7E9CV05sze7eqOhduwZNJeDPNNIo4VOSC" +
      "JD4oeCiHCeQRiNLZE97nzKRcxZiq1kl11MSbOXMWGRKXz0gSW1xknDbLQiONtD5" +
      "KHdplmokOTM2zEFD5o7QA5ZvRMUczLoX8EOUXuk5zTb9RAaIwhSLEBBw1F7l8BS" +
      "rOJw3Kq3BBh/B5fYmqKAHVfS+QaS2o6Q3+WNshVqL50KENQpp6pPzWqIrDslo5h" +
      "UN1DMK26nVRDJLgs3z1w0ppv1VWGKOrx8kTUDH8hUWSo6WJzzOp1QJsW/z/Klxy" +
      "DRqtddOsWDKIEo4/+SkJHRaV/BKD+taGod4eyrHT/9+hcpOshuXsLbuvuEpzzDI" +
      "L7slz7FOxAU8Jd8lGi/C0miMn4uXdQ4e6IatV+Y67Fs7o6H7eoJC1zH7F5IbgnU" +
      "nLx/1ryLyheIGA07Qf6d/jwOaizbZ9Uol0rt6VIWvcDBtN/0ooXDZ6gmCs1kMuJ" +
      "FK2zMuJLdX8qz4K77rNb623wg8cRJleA0OtFchLL2viBFOQDezrLiLgJA/21oTN" +
      "+8gPLd8wteiXDn9VPqDOQNg7EoCM+sswey4QDZpv/+NRsiZt8T8wr0fI6IGsx0S" +
      "3sco9uwgARIzjgbJHhO6iw2LOOrEaafZuTz9BQBDP72aqcYJI5zYx/OoBtx9h4a" +
      "P6eTLe706SkXLrLgRgEkLGwHjCSQ71so9tbmxHOrNB8yuEg+w7bRL+Y1eByT4I8" +
      "qIV2xsH2j/UsEBlPbyFEXTKomiFluxMqtNpcNDlDSNW2dEuNGmgG9vzf+sLG8sw" +
      "0D6H3Jsc5FEcQ1zLXuND/J1ZyGaSJkOh3yzyH4B5fdhb+DgQCNgpNOfvGOlKOy8" +
      "6qI5jEKcGrL8iFFRHDO3yTC7zyvzPP7aNhAuT/w2sbAYYpX+ZkShx4OgGDl8rja" +
      "CxfeDiq2Ghn+qNhcX9aC0depe4p/SO1FwfIPJ8oEidG7itfB1n18HkxWy9OGWrT" +
      "2omzAlXokqDyIObd8ofh64FtHNBCj1shv4YZ5l1dWecdEYbf6DcFXD400IAXzzL" +
      "rEeIVCoQQEzGAdHnS82bfhBwMZY/r8iGjZflg5KfLqevENKBsWlrp5/u2cxR32Y" +
      "y/tgFdSOlPeArG4oYyZvD2XtuzgP85u2Fms/vxg2+ufxDhNyPKSNXaK9B76t5i1" +
      "DUzcMqS975BDtXCBBi3zukVRkBlEl7ksjpw8YZ5a4rTqjrEJw8qh3UX0lxa7UEO" +
      "Wv+oLEwRlHgq+4VgJigMO0bkBpAW69gUddJmZSJR4j+0EmZfjI4cJpdQRrSFYmo" +
      "v0=";

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

        fixed (char* stringPtr = password)
        fixed (byte* oidPtr = s_pkcs12TripleDesOidBytes)
        {
            NativeMethods.NCrypt.NCryptBuffer* buffers =
                stackalloc NativeMethods.NCrypt.NCryptBuffer[3];

            buffers[0] = new NativeMethods.NCrypt.NCryptBuffer
            {
                BufferType = NativeMethods.NCrypt.BufferType.PkcsSecret,
                cbBuffer = checked(2 * (password.Length + 1)),
                pvBuffer = (IntPtr)stringPtr,
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

            result = NativeMethods.NCrypt.NCryptImportKey(
              safeNCryptProviderHandle,
              IntPtr.Zero,
              NCRYPT_PKCS8_PRIVATE_KEY_BLOB,
              ref desc,
              out var safeNCryptKeyHandle,
              exported,
              exported.Length,
              0);

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

            result = NativeMethods.NCrypt.NCryptExportKey(
              keyHandle,
              IntPtr.Zero,
              NCRYPT_PKCS8_PRIVATE_KEY_BLOB,
              IntPtr.Zero,
              null,
              0,
              out int bytesNeeded2,
              0);

            if (result != 0)
            {
              throw new Win32Exception(result);
            }

            byte[] exported2 = new byte[bytesNeeded2];

            result = NativeMethods.NCrypt.NCryptExportKey(
              safeNCryptKeyHandle,
              IntPtr.Zero,
              NCRYPT_PKCS8_PRIVATE_KEY_BLOB,
              IntPtr.Zero,
              exported2,
              exported2.Length,
              out bytesNeeded2,
              0);

            if (result != 0)
            {
              throw new Win32Exception(result);
            }

            return exported2;
        }
    }



  }
}
