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
        [Guid("A1A2EC1C-B5C3-4EB2-9BCB-9166AFAA0E85")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface ICoreWebView2CapturePreviewCompletedHandler
        {
            [PreserveSig]
            HRESULT Invoke(
                HRESULT result);
        }
    }
}
