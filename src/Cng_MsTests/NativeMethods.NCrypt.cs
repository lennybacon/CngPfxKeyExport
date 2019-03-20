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

      [DllImport(NCryptLibraryName, CharSet = CharSet.Unicode)]
      internal static extern int NCryptOpenStorageProvider(
        [Out] out SafeNCryptProviderHandle phProvider,
        [MarshalAs(UnmanagedType.LPWStr)] string pszProviderName,
        int dwFlags);

      [DllImport(NCryptLibraryName, CharSet = CharSet.Unicode)]
      internal static extern int NCryptImportKey(
        SafeNCryptProviderHandle hProvider,
        IntPtr hImportKey,     // NCRYPT_KEY_HANDLE
        string pszBlobType,
        ref NCryptBufferDesc pParameterList,
        [Out] out SafeNCryptKeyHandle phKey,
        [MarshalAs(UnmanagedType.LPArray)] byte[] pbData,
        int cbData,
        int dwFlags);

      [DllImport(NCryptLibraryName, CharSet = CharSet.Unicode)]
      internal static extern int NCryptImportKey(
        SafeNCryptProviderHandle hProvider,
        IntPtr hImportKey,     // NCRYPT_KEY_HANDLE
        string pszBlobType,
        IntPtr pParameterList, // NCryptBufferDesc *
        [Out] out SafeNCryptKeyHandle phKey,
        [MarshalAs(UnmanagedType.LPArray)] byte[] pbData,
        int cbData,
        int dwFlags);


      [DllImport(NCryptLibraryName, CharSet = CharSet.Unicode)]
      internal static extern int NCryptFinalizeKey(SafeNCryptKeyHandle hKey, int dwFlags);
      [DllImport(NCryptLibraryName, CharSet = CharSet.Unicode)]
      internal static extern int NCryptExportKey(
        SafeNCryptKeyHandle hKey,
        IntPtr hExportKey,
        string pszBlobType,
        IntPtr pParameterList, // NCryptBufferDesc *
        byte[] pbOutput,
        int cbOutput,
        [Out] out int pcbResult,
        int dwFlags);

      [DllImport(NCryptLibraryName, CharSet = CharSet.Unicode)]
      internal static extern int NCryptExportKey(
        SafeNCryptKeyHandle hKey,
        IntPtr hExportKey,
        string pszBlobType,
        ref NCryptBufferDesc pParameterList,
        byte[] pbOutput,
        int cbOutput,
        [Out] out int pcbResult,
        int dwFlags);

      [DllImport(NCryptLibraryName, CharSet = CharSet.Unicode)]
      internal static extern int NCryptSetProperty(
        SafeNCryptHandle hObject,
        string pszProperty,
        [MarshalAs(UnmanagedType.LPArray)] byte[] pbInput,
        int cbInput,
        CngPropertyOptions dwFlags);


      [DllImport(NCryptLibraryName, CharSet = CharSet.Unicode)]
      internal static extern int NCryptSetProperty(
        SafeNCryptHandle hObject,
        string pszProperty,
        string pbInput,
        int cbInput,
        CngPropertyOptions dwFlags);


      [DllImport(NCryptLibraryName, CharSet = CharSet.Unicode)]
      internal static extern int NCryptSetProperty(
        SafeNCryptHandle hObject,
        string pszProperty,
        IntPtr pbInput,
        int cbInput,
        CngPropertyOptions dwFlags);
    }
  }
}