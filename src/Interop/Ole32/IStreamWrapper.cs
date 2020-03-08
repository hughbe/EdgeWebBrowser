// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Diagnostics;
using System.IO;

internal static partial class Interop
{
    internal static partial class Ole32
    {
        public class IStreamWrapper : Stream
        {
            private readonly IStream _nativeStream;

            public IStreamWrapper(IStream nativeStream)
            {
                _nativeStream = nativeStream;
            }

            public override bool CanRead => true;

            public override bool CanSeek => true;

            public override bool CanWrite => true;

            public unsafe override long Length
            {
                get
                {
                    STATSTG statstg;
                    HRESULT hr = _nativeStream.Stat(&statstg, STATFLAG.DEFAULT);
                    Debug.Assert(hr == HRESULT.S_OK);
                    return checked((long)statstg.cbSize);
                }
            }

            public unsafe override long Position
            {
                get
                {
                    ulong position = 0;
                    HRESULT hr = _nativeStream.Seek(0, SeekOrigin.Current, &position);
                    Debug.Assert(hr == HRESULT.S_OK);
                    return checked((long)position);
                }
                set
                {
                    HRESULT hr = _nativeStream.Seek(value, SeekOrigin.Begin, null);
                    Debug.Assert(hr == HRESULT.S_OK);
                }
            }

            public override void Flush()
            {
                HRESULT hr = _nativeStream.Commit(STGC.DEFAULT);
                Debug.Assert(hr == HRESULT.S_OK);
            }

            public unsafe override int Read(byte[] buffer, int offset, int count)
            {
                fixed (byte* pBuffer = buffer)
                {
                    uint cbRead = 0;
                    HRESULT hr = _nativeStream.Read(pBuffer + offset, (uint)count, &cbRead);
                    Debug.Assert(hr == HRESULT.S_OK);
                    return checked((int)cbRead);
                }
            }

            public unsafe override long Seek(long offset, SeekOrigin origin)
            {
                ulong newPosition = 0;
                HRESULT hr = _nativeStream.Seek(offset, origin, &newPosition);
                Debug.Assert(hr == HRESULT.S_OK);
                return checked((int)newPosition);
            }

            public override void SetLength(long value)
            {
                HRESULT hr = _nativeStream.SetSize((ulong)value);
                Debug.Assert(hr == HRESULT.S_OK);
            }

            public unsafe override void Write(byte[] buffer, int offset, int count)
            {
                fixed (byte* pBuffer = buffer)
                {
                    HRESULT hr = _nativeStream.Write(pBuffer + offset, (uint)count, null);
                    Debug.Assert(hr == HRESULT.S_OK);
                }
            }
        }
    }
}
