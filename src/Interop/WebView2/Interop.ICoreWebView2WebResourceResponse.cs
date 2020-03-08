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
        [Guid("2B842125-E3B4-40A2-8BB8-C31AABF70E0A")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public unsafe interface ICoreWebView2WebResourceResponse
        {
            [PreserveSig]
            HRESULT get_Content(
                out Ole32.IStream content);

            [PreserveSig]
            HRESULT put_Content(
                Ole32.IStream content);

            [PreserveSig]
            HRESULT get_Headers(
                out ICoreWebView2HttpResponseHeaders content);

            [PreserveSig]
            HRESULT get_StatusCode(
                int* statusCode);

            [PreserveSig]
            HRESULT put_StatusCode(
                int statusCode);

            [PreserveSig]
            HRESULT get_ReasonPhrase(
                [MarshalAs(UnmanagedType.LPWStr)] out string reasonPhrase);

            [PreserveSig]
            HRESULT put_ReasonPhrase(
                [MarshalAs(UnmanagedType.LPWStr)] string reasonPhrase);
        }
    }
}
