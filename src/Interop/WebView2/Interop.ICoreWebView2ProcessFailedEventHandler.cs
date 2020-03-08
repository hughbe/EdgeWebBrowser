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
        [Guid("A85C66A9-DE47-47F7-AD64-ABB32F1CF14D")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface ICoreWebView2ProcessFailedEventHandler
        {
            [PreserveSig]
            HRESULT Invoke(
                ICoreWebView2 sender,
                ICoreWebView2ProcessFailedEventArgs args);
        }
    }
}
