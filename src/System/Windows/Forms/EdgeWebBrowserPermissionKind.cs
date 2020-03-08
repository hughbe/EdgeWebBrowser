// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using static Interop.WebView2;

namespace System.Windows.Forms
{
    public enum EdgeWebBrowserPermissionKind
    {
        Unknown = (int)CORE_WEBVIEW2_PERMISSION_KIND.UNKNOWN_PERMISSION,
        Microphone = (int)CORE_WEBVIEW2_PERMISSION_KIND.MICROPHONE,
        Camera = (int)CORE_WEBVIEW2_PERMISSION_KIND.CAMERA,
        Geolocation = (int)CORE_WEBVIEW2_PERMISSION_KIND.GEOLOCATION,
        Notifications = (int)CORE_WEBVIEW2_PERMISSION_KIND.NOTIFICATIONS,
        OtherSensors = (int)CORE_WEBVIEW2_PERMISSION_KIND.OTHER_SENSORS,
        ClipboardRead = (int)CORE_WEBVIEW2_PERMISSION_KIND.CLIPBOARD_READ
    }
}
