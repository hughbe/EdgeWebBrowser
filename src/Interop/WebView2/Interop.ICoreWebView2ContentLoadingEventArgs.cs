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
        [Guid("696ED8C1-4657-4769-928F-10EF8040ED25")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public unsafe interface ICoreWebView2ContentLoadingEventArgs
        {
            [PreserveSig]
            HRESULT get_IsErrorPage(
                BOOL* isErrorPage);

            [PreserveSig]
            HRESULT get_NavigationId(
                ulong* navigationId);
        }
    }
}
