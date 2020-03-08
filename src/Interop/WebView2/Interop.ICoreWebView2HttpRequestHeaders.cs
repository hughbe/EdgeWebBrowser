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
        [Guid("160B895B-D0AF-4A42-A14F-5571CFA68B03")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public unsafe interface ICoreWebView2HttpRequestHeaders
        {
            [PreserveSig]
            HRESULT GetHeader(
                [MarshalAs(UnmanagedType.LPWStr)] string name,
                [MarshalAs(UnmanagedType.LPWStr)] out string value);

            [PreserveSig]
            HRESULT GetHeaders(
                [MarshalAs(UnmanagedType.LPWStr)] string name,
                out ICoreWebView2HttpHeadersCollectionIterator iterator);

            [PreserveSig]
            HRESULT Contains(
                [MarshalAs(UnmanagedType.LPWStr)] string name,
                BOOL* contains);

            [PreserveSig]
            HRESULT SetHeader(
                [MarshalAs(UnmanagedType.LPWStr)] string name,
                [MarshalAs(UnmanagedType.LPWStr)] string value);

            [PreserveSig]
            HRESULT RemoveHeader(
                [MarshalAs(UnmanagedType.LPWStr)] string name);

            [PreserveSig]
            HRESULT GetIterator(
                out ICoreWebView2HttpHeadersCollectionIterator iterator);
        }
    }
}