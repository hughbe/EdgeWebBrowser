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
        [Guid("1337EED4-BC5B-48FB-9672-80D18733CFD5")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public unsafe interface ICoreWebView2NavigationCompletedEventArgs
        {
            [PreserveSig]
            HRESULT get_IsSuccess(
                BOOL* isSuccess);

            [PreserveSig]
            HRESULT get_WebErrorStatus(
                CORE_WEBVIEW2_WEB_ERROR_STATUS* CORE_WEBVIEW2_WEB_ERROR_STATUS);

            [PreserveSig]
            HRESULT get_NavigationId(
                ulong* navigation_id);
        }
    }
}
