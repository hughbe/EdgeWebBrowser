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
        [Guid("6ddf7138-a19b-4e55-8994-8a198b07f492")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public unsafe interface ICoreWebView2Host
        {
            [PreserveSig]
            HRESULT get_IsVisible(
                BOOL* isVisible);

            [PreserveSig]
            HRESULT put_IsVisible(
                BOOL isVisible);

            [PreserveSig]
            HRESULT get_Bounds(
                RECT* bounds);

            [PreserveSig]
            HRESULT put_Bounds(
                RECT bounds);

            [PreserveSig]
            HRESULT get_ZoomFactor(
                double* zoomFactor);

            [PreserveSig]
            HRESULT put_ZoomFactor(
                double zoomFactor);

            [PreserveSig]
            HRESULT add_ZoomFactorChanged(
                ICoreWebView2ZoomFactorChangedEventHandler eventHandler,
                long* token);

            [PreserveSig]
            HRESULT remove_ZoomFactorChanged(
                long token);

            [PreserveSig]
            HRESULT SetBoundsAndZoomFactor(
                RECT bounds,
                double zoomFactor);

            [PreserveSig]
            HRESULT MoveFocus(
                CORE_WEBVIEW2_MOVE_FOCUS_REASON reason);

            [PreserveSig]
            HRESULT add_MoveFocusRequested(
                ICoreWebView2MoveFocusRequestedEventHandler eventHandler,
                long* token);

            [PreserveSig]
            HRESULT remove_MoveFocusRequested(
                long token);

            [PreserveSig]
            HRESULT add_GotFocus(
                ICoreWebView2FocusChangedEventHandler eventHandler,
                long* token);

            [PreserveSig]
            HRESULT remove_GotFocus(
                long token);

            [PreserveSig]
            HRESULT add_LostFocus(
                ICoreWebView2FocusChangedEventHandler eventHandler,
                long* token);

            [PreserveSig]
            HRESULT remove_LostFocus(
                long token);

            [PreserveSig]
            HRESULT add_AcceleratorKeyPressed(
                ICoreWebView2AcceleratorKeyPressedEventHandler eventHandler,
                long* token);

            [PreserveSig]
            HRESULT remove_AcceleratorKeyPressed(
                long token);

            [PreserveSig]
            HRESULT get_ParentWindow(
                IntPtr* topLevelWindow);

            [PreserveSig]
            HRESULT put_ParentWindow(
                IntPtr topLevelWindow);

            [PreserveSig]
            HRESULT NotifyParentWindowPositionChanged();

            [PreserveSig]
            HRESULT Close();

            [PreserveSig]
            HRESULT get_CoreWebView2(
                out ICoreWebView2 coreWebView2);
        }
    }
}
