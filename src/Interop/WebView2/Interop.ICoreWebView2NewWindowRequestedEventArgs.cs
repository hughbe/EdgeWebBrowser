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
        [Guid("DDBF77B3-3411-44AB-AA15-FDFC93AFFCF8")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public unsafe interface ICoreWebView2NewWindowRequestedEventArgs
        {
            [PreserveSig]
            HRESULT get_Uri(
                [MarshalAs(UnmanagedType.LPWStr)] out string uri);

            [PreserveSig]
            HRESULT put_newWindow(
                ICoreWebView2 newWindow);

            [PreserveSig]
            HRESULT get_newWindow(
                out ICoreWebView2 newWindow);

            [PreserveSig]
            HRESULT put_Handled(
                BOOL handled);

            [PreserveSig]
            HRESULT get_Handled(
                BOOL* handled);

            [PreserveSig]
            HRESULT get_IsUserInitialized(
                BOOL* isUserInitialized);

            [PreserveSig]
            HRESULT GetDeferral(
                out ICoreWebView2Deferral deferral);
        }
    }
}
