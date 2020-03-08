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
        [Guid("253D0AA2-6F85-4FB2-9D6B-0DC5FEDBB085")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface ICoreWebView2AcceleratorKeyPressedEventHandler
        {
            [PreserveSig]
            HRESULT Invoke(
                ICoreWebView2Host sender,
                ICoreWebView2AcceleratorKeyPressedEventArgs args);
        }
    }
}
