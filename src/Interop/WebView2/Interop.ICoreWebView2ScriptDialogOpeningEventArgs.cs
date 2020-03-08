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
        [Guid("49C08E35-FCE1-4C6A-8DBD-6F58666C0CBE")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public unsafe interface ICoreWebView2ScriptDialogOpeningEventArgs
        {
            [PreserveSig]
            HRESULT get_Uri(
                [MarshalAs(UnmanagedType.LPWStr)] out string uri);

            [PreserveSig]
            HRESULT get_Kind(
               CORE_WEBVIEW2_SCRIPT_DIALOG_KIND* kind);

            [PreserveSig]
            HRESULT get_Message(
                [MarshalAs(UnmanagedType.LPWStr)] out string message);

            [PreserveSig]
            HRESULT Accept();

            [PreserveSig]
            HRESULT get_DefaultText(
                [MarshalAs(UnmanagedType.LPWStr)] out string defaultText);

            [PreserveSig]
            HRESULT get_ResultText(
                [MarshalAs(UnmanagedType.LPWStr)] out string resultText);

            [PreserveSig]
            HRESULT put_ResultText(
                [MarshalAs(UnmanagedType.LPWStr)] string resultText);

            [PreserveSig]
            HRESULT GetDeferral(
                out ICoreWebView2Deferral deferral);
        }
    }
}
