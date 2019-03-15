using System.Runtime.InteropServices;

namespace Sample
{
  partial class NativeMethods
  {
    partial class NCrypt
    {
      [StructLayout(LayoutKind.Sequential)]
      internal struct PbeParams
      {
        internal const int RgbSaltSize = 8;

        internal CryptPkcs12PbeParams Params;
        internal byte[] rgbSalt;
      }
    }
  }
}