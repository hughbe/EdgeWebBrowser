// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Runtime.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

internal static partial class Interop
{
    internal static partial class Ole32
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public unsafe struct STATSTG
        {
            private IntPtr pwcsName;
            public STGTY type;
            public ulong cbSize;
            public FILETIME mtime;
            public FILETIME ctime;
            public FILETIME atime;
            public STGM grfMode;
            public uint grfLocksSupported;
            public Guid clsid;
            public uint grfStateBits;
            public uint reserved;

            public string GetName() => Marshal.PtrToStringUni(pwcsName);

            /// <summary>
            ///  Caller is responsible for freeing the name memory.
            /// </summary>
            public void FreeName()
            {
                if (pwcsName != IntPtr.Zero)
                    Marshal.FreeCoTaskMem(pwcsName);

                pwcsName = IntPtr.Zero;
            }

            /// <summary>
            ///  Callee is repsonsible for allocating the name memory.
            /// </summary>
            public void AllocName(string name)
            {
                pwcsName = Marshal.StringToCoTaskMemUni(name);
            }
        }
    }
}
