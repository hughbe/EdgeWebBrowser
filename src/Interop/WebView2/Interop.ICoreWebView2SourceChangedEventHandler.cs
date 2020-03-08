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
        [Guid("E345159A-B573-41AB-A4F7-F94CB238AF45")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface ICoreWebView2SourceChangedEventHandler
        {
            [PreserveSig]
            HRESULT Invoke(
                ICoreWebView2 webview,
                ICoreWebView2SourceChangedEventArgs args);
        }
    }
}
