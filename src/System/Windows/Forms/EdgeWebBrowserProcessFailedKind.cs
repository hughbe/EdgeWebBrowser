﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using static Interop.WebView2;

namespace System.Windows.Forms
{
    public enum EdgeWebBrowserProcessFailedKind
    {
        BrowserProcessExited = (int)CORE_WEBVIEW2_PROCESS_FAILED_KIND.BROWSER_PROCESS_EXITED,
        RenderProcessExited = (int)CORE_WEBVIEW2_PROCESS_FAILED_KIND.RENDER_PROCESS_EXITED,
        RenderProcessUnresponsive = (int)CORE_WEBVIEW2_PROCESS_FAILED_KIND.RENDER_PROCESS_UNRESPONSIVE
    }
}
