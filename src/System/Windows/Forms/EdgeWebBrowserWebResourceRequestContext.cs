// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using static Interop.WebView2;

namespace System.Windows.Forms
{
    public enum EdgeWebBrowserWebResourceRequestContext
    {
        All = (int)CORE_WEBVIEW2_WEB_RESOURCE_CONTEXT.ALL,
        Document = (int)CORE_WEBVIEW2_WEB_RESOURCE_CONTEXT.DOCUMENT,
        Stylesheet = (int)CORE_WEBVIEW2_WEB_RESOURCE_CONTEXT.STYLESHEET,
        Image = (int)CORE_WEBVIEW2_WEB_RESOURCE_CONTEXT.IMAGE,
        Media = (int)CORE_WEBVIEW2_WEB_RESOURCE_CONTEXT.MEDIA,
        Font = (int)CORE_WEBVIEW2_WEB_RESOURCE_CONTEXT.FONT,
        Script = (int)CORE_WEBVIEW2_WEB_RESOURCE_CONTEXT.SCRIPT,
        XmlHttpRequest = (int)CORE_WEBVIEW2_WEB_RESOURCE_CONTEXT.XML_HTTP_REQUEST,
        Fetch = (int)CORE_WEBVIEW2_WEB_RESOURCE_CONTEXT.FETCH,
        TextTrack = (int)CORE_WEBVIEW2_WEB_RESOURCE_CONTEXT.TEXT_TRACK,
        EventSource = (int)CORE_WEBVIEW2_WEB_RESOURCE_CONTEXT.EVENT_SOURCE,
        WebSocket = (int)CORE_WEBVIEW2_WEB_RESOURCE_CONTEXT.WEBSOCKET,
        Manifest = (int)CORE_WEBVIEW2_WEB_RESOURCE_CONTEXT.MANIFEST,
        SignedExchange = (int)CORE_WEBVIEW2_WEB_RESOURCE_CONTEXT.SIGNED_EXCHANGE,
        Ping = (int)CORE_WEBVIEW2_WEB_RESOURCE_CONTEXT.PING,
        CspViolationReport = (int)CORE_WEBVIEW2_WEB_RESOURCE_CONTEXT.CSP_VIOLATION_REPORT,
        Other = (int)CORE_WEBVIEW2_WEB_RESOURCE_CONTEXT.OTHER,
    }
}
