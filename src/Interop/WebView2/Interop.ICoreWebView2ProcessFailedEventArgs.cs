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
        [Guid("9E354785-CFA2-480A-84E0-57837ADD8E36")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public unsafe interface ICoreWebView2ProcessFailedEventArgs
        {
            [PreserveSig]
            HRESULT get_ProcessFailedKind(
                CORE_WEBVIEW2_PROCESS_FAILED_KIND* processFailedKind);
        }
    }
}
