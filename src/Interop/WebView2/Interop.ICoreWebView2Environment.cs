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
        [Guid("7dc2ec84-56cb-4fcc-b4c6-a9f85c7b2894")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public unsafe interface ICoreWebView2Environment
        {
            [PreserveSig]
            HRESULT CreateCoreWebView2Host(
                IntPtr parentWindow,
                ICoreWebView2CreateCoreWebView2HostCompletedHandler handler);

            [PreserveSig]
            HRESULT CreateWebResourceResponse(
                Ole32.IStream content,
                int statusCode,
                string reasonPhrase,
                string headers,
                out ICoreWebView2WebResourceResponse response);
            
            [PreserveSig]
            HRESULT get_BrowserVersionInfo(
                [MarshalAs(UnmanagedType.LPWStr)] out string versionInfo);

            [PreserveSig]
            HRESULT add_NewBrowserVersionAvailable(
                ICoreWebView2NewBrowserVersionAvailableEventHandler eventHandler,
                long* token);

            [PreserveSig]
            HRESULT remove_NewBrowserVersionAvailable(
                long token);
        }
    }
}