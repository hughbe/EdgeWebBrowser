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
        [Guid("5A86C3E7-511B-4F99-BC20-8A8ED5449C12")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface ICoreWebView2NewBrowserVersionAvailableEventArgs
        {
            [PreserveSig]
            HRESULT get_NewVersion(
                out string newVersion);
        }
    }
}
