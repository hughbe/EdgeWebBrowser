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
        [Guid("51457AE2-93FD-404E-A957-3D6034EAD733")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface ICoreWebView2ExecuteScriptCompletedHandler
        {
            [PreserveSig]
            HRESULT Invoke(
                HRESULT errorCode,
                [MarshalAs(UnmanagedType.LPWStr)] string resultObjectAsJson);
        }
    }
}