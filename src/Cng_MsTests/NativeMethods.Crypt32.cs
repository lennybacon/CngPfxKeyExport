using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using Microsoft.Win32.SafeHandles;

namespace Sample
{
  partial class NativeMethods
  {
    internal partial class Crypt32
    {
      private const string Crypt32LibraryName = "crypt32.dll";

      [DllImport(Crypt32LibraryName)]
      internal static extern SafeCertContextHandle
        CertDuplicateCertificateContext(
          IntPtr certContext);

      [DllImport(Crypt32LibraryName, SetLastError = true)]
      [return: MarshalAs(UnmanagedType.Bool)]
      internal static extern bool CertGetCertificateContextProperty(
        SafeCertContextHandle pCertContext,
        CertificateProperty dwPropId,
        [Out, MarshalAs(UnmanagedType.LPArray)] byte[] pvData,
        [In, Out] ref int pcbData);

      [DllImport(Crypt32LibraryName, SetLastError = true)]
      [return: MarshalAs(UnmanagedType.Bool)]
      internal static extern bool CryptAcquireCertificatePrivateKey(
        SafeCertContextHandle pCert,
        AcquireCertificateKeyOptions dwFlags,
        IntPtr pvReserved,
        // void *
        [Out] out SafeNCryptKeyHandle phCryptProvOrNCryptKey,
        [Out] out int dwKeySpec,
        [Out, MarshalAs(UnmanagedType.Bool)] out bool
          pfCallerFreeProvOrNCryptKey);

      [return: MarshalAs(UnmanagedType.Bool)]
      [SuppressUnmanagedCodeSecurity]
      [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
      [DllImport(Crypt32LibraryName)]
      internal static extern bool CertFreeCertificateContext(
        IntPtr pCertContext);

    }
  }
}