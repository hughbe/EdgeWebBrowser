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
        [Guid("B7627F5F-8723-4ED3-AC20-F93104CDEA51")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface ICoreWebView2CallDevToolsProtocolMethodCompletedHandler
        {
            [PreserveSig]
            HRESULT Invoke(
                HRESULT errorCode,
                [MarshalAs(UnmanagedType.LPWStr)] string returnObjectAsJson);
        }
    }
}
