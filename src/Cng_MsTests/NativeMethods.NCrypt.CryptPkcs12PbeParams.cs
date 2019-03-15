using System.Runtime.InteropServices;

namespace Sample
{
  partial class NativeMethods
  {
    partial class NCrypt
    {
      [StructLayout(LayoutKind.Sequential)]
      internal struct CryptPkcs12PbeParams
      {
        internal int iIterations;
        internal int cbSalt;
      }
    }
  }
}