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
        [Guid("715E10DD-2323-4F03-B6B3-AB34006B96D5")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface ICoreWebView2NewWindowRequestedEventHandler
        {
            [PreserveSig]
            HRESULT Invoke(
                ICoreWebView2 sender,
                ICoreWebView2NewWindowRequestedEventArgs args);
        }
    }
}
