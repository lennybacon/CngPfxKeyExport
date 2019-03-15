using Microsoft.Win32.SafeHandles;

namespace Sample
{
  internal sealed class SafeCertContextHandle
    : SafeHandleZeroOrMinusOneIsInvalid
  {
    private SafeCertContextHandle()
      : base(true)
    {
    }
    protected override bool ReleaseHandle()
    {
      return NativeMethods.Crypt32.CertFreeCertificateContext(handle);
    }
  }
}