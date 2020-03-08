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
        [Guid("E4CDFD7A-AA15-4738-8A8F-4C8C28A9BAC1")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface ICoreWebView2ScriptDialogOpeningEventHandler
        {
            [PreserveSig]
            HRESULT Invoke(
                ICoreWebView2 sender,
                ICoreWebView2ScriptDialogOpeningEventArgs args);
        }
    }
}
