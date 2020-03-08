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
        [Guid("1C81A448-575B-44A1-9ABD-1B93A3DE9E03")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public unsafe interface ICoreWebView2NavigationStartingEventArgs
        {
            [PreserveSig]
            HRESULT get_Uri(
                [MarshalAs(UnmanagedType.LPWStr)] out string uri);

            [PreserveSig]
            HRESULT get_IsUserInitiated(
                BOOL* isUserInitiated);

            [PreserveSig]
            HRESULT get_IsRedirected(
                BOOL* isRedirected);

            [PreserveSig]
            HRESULT get_RequestHeaders(
                out ICoreWebView2HttpRequestHeaders requestHeaders);

            [PreserveSig]
            HRESULT get_Cancel(
                BOOL* cancel);

            [PreserveSig]
            HRESULT put_Cancel(
                BOOL cancel);

            [PreserveSig]
            HRESULT get_NavigationId(
                ulong* navigationId);
        }
    }
}
