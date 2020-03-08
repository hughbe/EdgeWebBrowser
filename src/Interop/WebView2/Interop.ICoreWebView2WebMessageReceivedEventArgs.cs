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
        [Guid("B21D70E2-942E-44EB-B843-22C156FDE288")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface ICoreWebView2WebMessageReceivedEventArgs
        {
            [PreserveSig]
            HRESULT get_Source(
                [MarshalAs(UnmanagedType.LPWStr)] out string source);

            [PreserveSig]
            HRESULT get_WebMessageAsJson(
                [MarshalAs(UnmanagedType.LPWStr)] out string webMessageAsJson);

            [PreserveSig]
            HRESULT TryGetWebMessageAsString(
                [MarshalAs(UnmanagedType.LPWStr)] out string webMessageAsString);
        }
    }
}
