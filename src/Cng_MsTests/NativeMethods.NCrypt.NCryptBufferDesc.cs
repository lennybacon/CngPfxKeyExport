using System;
using System.Runtime.InteropServices;

namespace Sample
{
  partial class NativeMethods
  {
    /// <summary>
    /// Class NCrypt.
    /// </summary>
    partial class NCrypt
    {
      /// <summary>
      /// Struct NCryptBufferDesc
      /// </summary>
      /// <remarks>
      /// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/ns-bcrypt-_bcryptbufferdesc
      /// </remarks>
      [StructLayout(LayoutKind.Sequential)]
      internal struct NCryptBufferDesc
      {
        /// <summary>
        /// The version number of the structure. Currently, this member must
        /// be the following value.
        /// </summary>
        public int ulVersion;

        /// <summary>
        /// The number of elements in the pBuffers array. You can test the
        /// value received against NCRYPTBUFFER_EMPTY (0) to determine whether the array pointed to by the pBuffers parameter contains any members.
        /// </summary>
        public int cBuffers;

        /// <summary>
        /// An array of NCryptBuffer structures that contain the buffer
        /// information. The cBuffers member contains the number of elements
        /// in this array.
        /// </summary>
        public IntPtr pBuffers;
      }
    }
  }
}