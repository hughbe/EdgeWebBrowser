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
        [Guid("01BA7131-3DBE-4C83-A789-99C467A2C3F5")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface ICoreWebView2MoveFocusRequestedEventHandler
        {
            [PreserveSig]
            HRESULT Invoke(
                ICoreWebView2Host sender,
                ICoreWebView2MoveFocusRequestedEventArgs args);
        }
    }
}
