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
        [Guid("7EF09904-8B46-4FE1-87FF-5A28EFAF7723")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface ICoreWebView2DevToolsProtocolEventReceivedEventArgs
        {
            [PreserveSig]
            HRESULT get_ParameterObjectAsJson(
                [MarshalAs(UnmanagedType.LPWStr)] out string parameterAsJson);
        }
    }
}
