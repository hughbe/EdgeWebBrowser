// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.IO;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Ole32
    {
        /// <summary>
        ///  COM IStream interface. <see href="https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nn-objidl-istream"/>
        /// </summary>
        /// <remarks>
        ///  The definition in <see cref="System.Runtime.InteropServices.ComTypes"/> does not lend
        ///  itself to efficiently accessing / implementing IStream.
        /// </remarks>
        [ComImport]
        [Guid("0000000C-0000-0000-C000-000000000046")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public unsafe interface IStream
        {
            [PreserveSig]
            HRESULT Read(
                byte* pv,
                uint cb,
                uint* pcbRead);

            [PreserveSig]
            HRESULT Write
                (byte* pv,
                uint cb,
                uint* pcbWritten);

            [PreserveSig]
            HRESULT Seek(
                long dlibMove,
                SeekOrigin dwOrigin,
                ulong* plibNewPosition);

            [PreserveSig]
            HRESULT SetSize(
                ulong libNewSize);

            [PreserveSig]
            HRESULT CopyTo(
                IStream pstm,
                ulong cb,
                ulong* pcbRead,
                ulong* pcbWritten);

            [PreserveSig]
            HRESULT Commit(
                STGC grfCommitFlags);

            [PreserveSig]
            HRESULT Revert();

            [PreserveSig]
            HRESULT LockRegion(
                ulong libOffset,
                ulong cb,
                uint dwLockType);

            [PreserveSig]
            HRESULT UnlockRegion(
                ulong libOffset,
                ulong cb,
                uint dwLockType);

            [PreserveSig]
            HRESULT Stat(
                STATSTG* pstatstg,
                STATFLAG grfStatFlag);

            [PreserveSig]
            HRESULT Clone(out IStream clone);
        }
    }
}
