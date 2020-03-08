// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

internal static partial class Interop
{
    internal static partial class WebView2
    {
        public enum CORE_WEBVIEW2_PERMISSION_KIND : uint
        {
            UNKNOWN_PERMISSION = 0,
            MICROPHONE = 1,
            CAMERA = 2,
            GEOLOCATION = 3,
            NOTIFICATIONS = 4,
            OTHER_SENSORS = 5,
            CLIPBOARD_READ = 6,
        }
    }
}
