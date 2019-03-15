namespace Sample
{
  partial class NativeMethods
  {
    partial class Crypt32
    {
      internal enum AcquireCertificateKeyOptions
      {
        None = 0x00000000,

        /// <summary>The acquire only ncrypt keys</summary>
        /// <remarks>CRYPT_ACQUIRE_ONLY_NCRYPT_KEY_FLAG</remarks>
        AcquireOnlyNCryptKeys = 0x00040000,

        /// <summary>The acquire silent</summary>
        /// <remarks>CRYPT_ACQUIRE_ONLY_NCRYPT_KEY_FLAG</remarks>
        AcquireSilent = 0x00000040
      }
    }
  }
}