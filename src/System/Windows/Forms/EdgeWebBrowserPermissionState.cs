// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using static Interop.WebView2;

namespace System.Windows.Forms
{
    public enum EdgeWebBrowserPermissionState
    {
        Default = (int)CORE_WEBVIEW2_PERMISSION_STATE.DEFAULT,
        Allow = (int)CORE_WEBVIEW2_PERMISSION_STATE.ALLOW,
        Deny = (int)CORE_WEBVIEW2_PERMISSION_STATE.DENY
    }
}
