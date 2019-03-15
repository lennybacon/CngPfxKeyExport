using System;
using System.Runtime.InteropServices;

namespace Sample
{
  internal sealed class SafeUnicodeStringHandle : SafeHandle
  {
    public SafeUnicodeStringHandle(string s)
      : base(IntPtr.Zero, true)
    {
      handle = Marshal.StringToHGlobalUni(s);
    }


    public override bool IsInvalid => handle == IntPtr.Zero;

    protected override bool ReleaseHandle()
    {
      Marshal.FreeHGlobal(handle);
      return true;
    }
  }
}