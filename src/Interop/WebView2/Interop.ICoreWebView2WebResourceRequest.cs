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
        [Guid("7471A125-D5E8-45A8-B119-F9E9230D4D0B")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public unsafe interface ICoreWebView2WebResourceRequest
        {
            [PreserveSig]
            HRESULT get_Uri(
                [MarshalAs(UnmanagedType.LPWStr)] out string uri);

            [PreserveSig]
            HRESULT put_Uri(
                [MarshalAs(UnmanagedType.LPWStr)] string uri);

            [PreserveSig]
            HRESULT get_Method(
                [MarshalAs(UnmanagedType.LPWStr)] out string method);

            [PreserveSig]
            HRESULT put_Method(
                [MarshalAs(UnmanagedType.LPWStr)] string method);

            [PreserveSig]
            HRESULT get_Content(
                out Ole32.IStream content);

            [PreserveSig]
            HRESULT put_Content(
                Ole32.IStream content);

            [PreserveSig]
            HRESULT get_Headers(
                out ICoreWebView2HttpRequestHeaders headers);
        }
    }
}