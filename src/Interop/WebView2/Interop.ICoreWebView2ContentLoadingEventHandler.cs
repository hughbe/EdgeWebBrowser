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
        [Guid("70057D5C-0BAA-4219-97B0-FFF1C088ED32")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface ICoreWebView2ContentLoadingEventHandler
        {
            [PreserveSig]
            HRESULT Invoke(
                ICoreWebView2 webview,
                ICoreWebView2ContentLoadingEventArgs args);
        }
    }
}
