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
        [Guid("CE31A597-E202-49B9-A9BE-825481ED517E")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public unsafe interface ICoreWebView2MoveFocusRequestedEventArgs
        {
            [PreserveSig]
            HRESULT get_Reason(
                CORE_WEBVIEW2_MOVE_FOCUS_REASON* value);

            [PreserveSig]
            HRESULT get_Handled(
                BOOL* value);

            [PreserveSig]
            HRESULT put_Handled(
                BOOL value);
        }
    }
}
