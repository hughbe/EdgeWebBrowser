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
        [Guid("A8DC0663-3C2C-4190-8129-5F1F598CA7B8")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface ICoreWebView2WebResourceRequestedEventHandler
        {
            [PreserveSig]
            HRESULT Invoke(
                ICoreWebView2 sender,
                ICoreWebView2WebResourceRequestedEventArgs args);
        }
    }
}
