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
        [Guid("E09F5D38-91E3-49D1-8182-70A616AA06B9")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface ICoreWebView2CreateCoreWebView2HostCompletedHandler
        {
            [PreserveSig]
            HRESULT Invoke(
                HRESULT result,
                ICoreWebView2Host created_host);
        }
    }
}
