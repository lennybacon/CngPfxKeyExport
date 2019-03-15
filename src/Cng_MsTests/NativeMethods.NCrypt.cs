using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using Microsoft.Win32.SafeHandles;

namespace Sample
{
  partial class NativeMethods
  {
    internal partial class NCrypt
    {
      private const string NCryptLibraryName = "ncrypt.dll";
      [DllImport(NCryptLibraryName, CharSet = CharSet.Unicode)]
      internal static extern int NCryptCreatePersistedKey(SafeNCryptProviderHandle hProvider,
        [Out] out SafeNCryptKeyHandle phKey,
        string pszAlgId,
        string pszKeyName,
        int dwLegacyKeySpec,
        CngKeyCreationOptions dwFlags);

      [DllImport(NCryptLibraryName)]
      internal static extern int NCryptOpenStorageProvider(
        [Out] out SafeNCryptProviderHandle phProvider,
        [MarshalAs(UnmanagedType.LPWStr)] string pszProviderName,
        int dwFlags);

      [DllImport("ncrypt.dll", CharSet = CharSet.Unicode)]
      internal static extern int NCryptExportKey(
        SafeNCryptKeyHandle hKey,
        IntPtr hExportKey,
        string pszBlobType,
        ref NCryptBufferDesc pParameterList,
        ref byte[] pbOutput,
        int cbOutput,
        [Out] out int pcbResult,
        int dwFlags);

    }
  }
}