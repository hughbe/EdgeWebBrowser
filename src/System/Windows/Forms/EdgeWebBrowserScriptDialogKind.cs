// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using static Interop.WebView2;

namespace System.Windows.Forms
{
    public enum EdgeWebBrowserScriptDialogKind
    {
        Png = (int)CORE_WEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT.PNG,
        Jpeg = (int)CORE_WEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT.JPEG
    }
}
