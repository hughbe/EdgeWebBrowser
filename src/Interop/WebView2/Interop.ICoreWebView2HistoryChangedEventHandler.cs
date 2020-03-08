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
        [Guid("29211B19-F775-48CC-9757-5DA3CA1F626A")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface ICoreWebView2HistoryChangedEventHandler
        {
            [PreserveSig]
            HRESULT Invoke(
                ICoreWebView2 webview,
                IntPtr args);
        }
    }
}
