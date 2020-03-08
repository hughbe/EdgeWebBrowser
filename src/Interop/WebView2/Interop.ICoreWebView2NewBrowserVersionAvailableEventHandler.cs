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
        [Guid("865E16C4-A24D-4AC1-BC23-2E608CA313F9")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface ICoreWebView2NewBrowserVersionAvailableEventHandler
        {
            [PreserveSig]
            HRESULT Invoke(
                ICoreWebView2Environment webviewEnvironment,
                ICoreWebView2NewBrowserVersionAvailableEventArgs args);
        }
    }
}
