// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

internal static partial class Interop
{
    internal static partial class WebView2
    {
        public enum CORE_WEBVIEW2_WEB_RESOURCE_CONTEXT : uint
        {
            ALL = 0,
            DOCUMENT = 1,
            STYLESHEET = 2,
            IMAGE = 3,
            MEDIA = 4,
            FONT = 5,
            SCRIPT = 6,
            XML_HTTP_REQUEST = 7,
            FETCH = 8,
            TEXT_TRACK = 9,
            EVENT_SOURCE = 10,
            WEBSOCKET = 12,
            MANIFEST = 13,
            SIGNED_EXCHANGE = 14,
            PING = 15,
            CSP_VIOLATION_REPORT = 16,
            OTHER = 17,
        }
    }
}
