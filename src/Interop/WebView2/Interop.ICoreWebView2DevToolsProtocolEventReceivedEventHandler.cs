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
        [Guid("8B0DF849-2D94-47FB-8072-FE7A4D5FBA6A")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface ICoreWebView2DevToolsProtocolEventReceivedEventHandler
        {
            [PreserveSig]
            HRESULT Invoke(
                ICoreWebView2 sender,
                ICoreWebView2DevToolsProtocolEventReceivedEventArgs args);
        }
    }
}
