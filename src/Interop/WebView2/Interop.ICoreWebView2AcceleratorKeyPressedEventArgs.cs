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
        [Guid("AF1587DD-E2FF-4BFF-8C1A-699D6D34C683")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public unsafe interface ICoreWebView2AcceleratorKeyPressedEventArgs
        {
            [PreserveSig]
            HRESULT get_KeyEventKind(
                CORE_WEBVIEW2_KEY_EVENT_KIND* keyEventKind);

            [PreserveSig]
            HRESULT get_VirtualKey(
                uint* virtualKey);

            [PreserveSig]
            HRESULT get_KeyEventLParam(
                int* lParam);

            [PreserveSig]
            HRESULT get_PhysicalKeyStatus(
                CORE_WEBVIEW2_PHYSICAL_KEY_STATUS* physicalKeyStatus);

            [PreserveSig]
            HRESULT get_Handled(
                BOOL* handled);

            [PreserveSig]
            HRESULT put_Handled(
                BOOL handled);
        }
    }
}
