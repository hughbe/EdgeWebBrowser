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
        [Guid("1B03A40F-92B7-443A-87E0-B65714B6CB9D")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface ICoreWebView2ZoomFactorChangedEventHandler
        {
            [PreserveSig]
            HRESULT Invoke(
                ICoreWebView2Host sender,
                IntPtr args);
        }
    }
}
