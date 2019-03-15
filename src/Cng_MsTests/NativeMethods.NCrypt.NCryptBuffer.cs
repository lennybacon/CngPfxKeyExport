using System;
using System.Runtime.InteropServices;

namespace Sample
{
  partial class NativeMethods
  {
    partial class NCrypt
    {
      /// <summary>
      /// Struct NCryptBuffer
      /// </summary>
      /// <remarks>
      /// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/ns-bcrypt-_bcryptbuffer
      /// </remarks>
      [StructLayout(LayoutKind.Sequential)]
      internal struct NCryptBuffer
      {
        /// <summary>
        /// The size, in bytes, of the buffer.
        /// </summary>
        public int cbBuffer;

        /// <summary>
        /// The buffer type
        /// </summary>
        public BufferType BufferType;

        /// <summary>
        /// The address of the buffer. The size of this buffer is contained in
        /// the cbBuffer member.
        /// The format and contents of this buffer are identified by the
        /// BufferType member.
        /// </summary>
        public IntPtr pvBuffer;
      }
    }
  }
}