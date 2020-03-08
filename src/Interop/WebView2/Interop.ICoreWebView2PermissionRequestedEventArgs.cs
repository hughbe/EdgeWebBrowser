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
        [Guid("DBB6C9C9-FBB5-40FD-8843-5BE65807FD8A")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public unsafe interface ICoreWebView2PermissionRequestedEventArgs
        {
            [PreserveSig]
            HRESULT get_Uri(
                [MarshalAs(UnmanagedType.LPWStr)] out string uri);

            [PreserveSig]
            HRESULT get_PermissionKind(
                CORE_WEBVIEW2_PERMISSION_KIND* value);

            [PreserveSig]
            HRESULT get_IsUserInitiated(
                BOOL* isUserInitiated);

            [PreserveSig]
            HRESULT get_State(
                CORE_WEBVIEW2_PERMISSION_STATE* value);

            [PreserveSig]
            HRESULT put_State(
                CORE_WEBVIEW2_PERMISSION_STATE value);

            [PreserveSig]
            HRESULT GetDeferral(
                out ICoreWebView2Deferral deferral);
        }
    }
}
