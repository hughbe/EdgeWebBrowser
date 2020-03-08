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
        [Guid("8889C588-9DC7-4266-9BB3-369AFDDE2A7F")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface ICoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler
        {
            [PreserveSig]
            HRESULT Invoke(
                HRESULT errorCode,
                [MarshalAs(UnmanagedType.LPWStr)] string id);
        }
    }
}