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
        [Guid("19F31771-9BB5-422B-9A0A-6EDDAF4FFE0F")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface ICoreWebView2FocusChangedEventHandler
        {
            [PreserveSig]
            HRESULT Invoke(
                ICoreWebView2Host sender,
                IntPtr args);
        }
    }
}
