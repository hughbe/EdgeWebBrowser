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
        [Guid("D58A964A-13C4-44FB-81AD-64AE242E9ADC")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public unsafe interface ICoreWebView2Settings
        {
            [PreserveSig]
            HRESULT get_IsScriptEnabled(
                BOOL* isScriptEnabled);

            [PreserveSig]
            HRESULT put_IsScriptEnabled(
                BOOL isScriptEnabled);

            [PreserveSig]
            HRESULT get_IsWebMessageEnabled(
                BOOL* isWebMessageEnabled);

            [PreserveSig]
            HRESULT put_IsWebMessageEnabled(
                BOOL isWebMessageEnabled);

            [PreserveSig]
            HRESULT get_AreDefaultScriptDialogsEnabled(
                BOOL* areDefaultScriptDialogsEnabled);

            [PreserveSig]
            HRESULT put_AreDefaultScriptDialogsEnabled(
                BOOL areDefaultScriptDialogsEnabled);

            [PreserveSig]
            HRESULT get_IsStatusBarEnabled(
                BOOL* isStatusBarEnabled);

            [PreserveSig]
            HRESULT put_IsStatusBarEnabled(
                BOOL isStatusBarEnabled);

            [PreserveSig]
            HRESULT get_AreDevToolsEnabled(
                BOOL* areDevToolsEnabled);

            [PreserveSig]
            HRESULT put_AreDevToolsEnabled(
                BOOL areDevToolsEnabled);

            [PreserveSig]
            HRESULT get_AreDefaultContextMenusEnabled(
                BOOL* enabled);

            [PreserveSig]
            HRESULT put_AreDefaultContextMenusEnabled(
                BOOL enabled);

            [PreserveSig]
            HRESULT get_AreRemoteObjectsAllowed(
                BOOL* allowed);

            [PreserveSig]
            HRESULT put_AreRemoteObjectsAllowed(
                BOOL allowed);

            [PreserveSig]
            HRESULT get_IsZoomControlEnabled(
                BOOL* enabled);

            [PreserveSig]
            HRESULT put_IsZoomControlEnabled(
                BOOL enabled);
        }
    }
}