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
        [Guid("26D4B817-9496-4F67-AEAB-24EB38482037")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public unsafe interface ICoreWebView2SourceChangedEventArgs
        {
            [PreserveSig]
            HRESULT get_IsNewDocument(
                BOOL* isNewDocument);
        }
    }
}
