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
        [Guid("6EF9912F-5A9D-42A9-8C17-9BB53E1D5C63")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public unsafe interface ICoreWebView2WebResourceRequestedEventArgs
        {
            [PreserveSig]
            HRESULT get_Request(
                out ICoreWebView2WebResourceRequest request);

            [PreserveSig]
            HRESULT get_Response(
                out ICoreWebView2WebResourceResponse request);

            [PreserveSig]
            HRESULT put_Response(
                ICoreWebView2WebResourceResponse request);

            [PreserveSig]
            HRESULT GetDeferral(
                out ICoreWebView2Deferral deferral);

            [PreserveSig]
            HRESULT get_ResourceContext(
                CORE_WEBVIEW2_WEB_RESOURCE_CONTEXT* context);
        }
    }
}
