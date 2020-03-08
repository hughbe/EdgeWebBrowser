// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class WebView2
    {
        [ComImport]
        [Guid("B0F8A736-CC49-4414-BB9C-FDBC02599622")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public unsafe interface ICoreWebView2HttpHeadersCollectionIterator
        {
            [PreserveSig]
            HRESULT GetCurrentHeader(
                [MarshalAs(UnmanagedType.LPWStr)] out string name,
                [MarshalAs(UnmanagedType.LPWStr)] out string value);

            [PreserveSig]
            HRESULT GetHasCurrentHeader(
                BOOL* hasCurrent);

            [PreserveSig]
            HRESULT MoveNext(
                BOOL* hasNext);
        }
    }
}
