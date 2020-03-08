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
        [Guid("5cc5293d-af6f-41d4-9619-44bd31ba4c93")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public unsafe interface ICoreWebView2
        {
            [PreserveSig]
            HRESULT get_Settings(
                out ICoreWebView2Settings settings);

            [PreserveSig]
            HRESULT get_Source(
                [MarshalAs(UnmanagedType.LPWStr)] out string uri);

            [PreserveSig]
            HRESULT Navigate(
                string uri);

            [PreserveSig]
            HRESULT NavigateToString(
                string htmlContent);

            [PreserveSig]
            HRESULT add_NavigationStarting(
                ICoreWebView2NavigationStartingEventHandler eventHandler,
                long* token);

            [PreserveSig]
            HRESULT remove_NavigationStarting(
                long token);

            [PreserveSig]
            HRESULT add_ContentLoading(
                ICoreWebView2ContentLoadingEventHandler eventHandler,
                long* token);

            [PreserveSig]
            HRESULT remove_ContentLoading(
                long token);

            [PreserveSig]
            HRESULT add_SourceChanged(
                ICoreWebView2SourceChangedEventHandler eventHandler,
                long* token);

            [PreserveSig]
            HRESULT remove_SourceChanged(
                long token);

            [PreserveSig]
            HRESULT add_HistoryChanged(
                ICoreWebView2HistoryChangedEventHandler eventHandler,
                long* token);

            [PreserveSig]
            HRESULT remove_HistoryChanged(
                long token);

            [PreserveSig]
            HRESULT add_NavigationCompleted(
                ICoreWebView2NavigationCompletedEventHandler eventHandler,
                long* token);

            [PreserveSig]
            HRESULT remove_NavigationCompleted(
                long token);

            [PreserveSig]
            HRESULT add_FrameNavigationStarting(
                ICoreWebView2NavigationStartingEventHandler eventHandler,
                long* token);

            [PreserveSig]
            HRESULT remove_FrameNavigationStarting(
                long token);

            [PreserveSig]
            HRESULT add_ScriptDialogOpening(
                ICoreWebView2ScriptDialogOpeningEventHandler eventHandler,
                long* token);

            [PreserveSig]
            HRESULT remove_ScriptDialogOpening(
                long token);

            [PreserveSig]
            HRESULT add_PermissionRequested(
                ICoreWebView2PermissionRequestedEventHandler eventHandler,
                long* token);

            [PreserveSig]
            HRESULT remove_PermissionRequested(
                long token);

            [PreserveSig]
            HRESULT add_ProcessFailed(
                ICoreWebView2ProcessFailedEventHandler eventHandler,
                long* token);

            [PreserveSig]
            HRESULT remove_ProcessFailed(
                long token);

            [PreserveSig]
            HRESULT AddScriptToExecuteOnDocumentCreated(
                [MarshalAs(UnmanagedType.LPWStr)] string javaScript,
                ICoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler handler);

            [PreserveSig]
            HRESULT RemoveScriptToExecuteOnDocumentCreated(
                [MarshalAs(UnmanagedType.LPWStr)] string id);

            [PreserveSig]
            HRESULT ExecuteScript(
                [MarshalAs(UnmanagedType.LPWStr)] string javaScript,
                ICoreWebView2ExecuteScriptCompletedHandler handler);

            [PreserveSig]
            HRESULT CapturePreview(
                CORE_WEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT imageFormat,
                Ole32.IStream imageStream,
                ICoreWebView2CapturePreviewCompletedHandler handler);

            [PreserveSig]
            HRESULT Reload();

            [PreserveSig]
            HRESULT PostWebMessageAsJson(
                [MarshalAs(UnmanagedType.LPWStr)] string webMessageAsJson);

            [PreserveSig]
            HRESULT PostWebMessageAsString(
                [MarshalAs(UnmanagedType.LPWStr)] string webMessageAsString);

            [PreserveSig]
            HRESULT add_WebMessageReceived(
                ICoreWebView2WebMessageReceivedEventHandler eventHandler,
                long* token);

            [PreserveSig]
            HRESULT remove_WebMessageReceived(
                long token);

            [PreserveSig]
            HRESULT CallDevToolsProtocolMethod(
                [MarshalAs(UnmanagedType.LPWStr)] string methodName,
                [MarshalAs(UnmanagedType.LPWStr)] string parametersAsJson,
                ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);

            [PreserveSig]
            HRESULT get_BrowserProcessId(
                uint* value);

            [PreserveSig]
            HRESULT get_CanGoBack(
                BOOL* canGoBack);

            [PreserveSig]
            HRESULT get_CanGoForward(
                BOOL* canGoForward);

            [PreserveSig]
            HRESULT GoBack();

            [PreserveSig]
            HRESULT GoForward();

            [PreserveSig]
            HRESULT GetDevToolsProtocolEventReceiver(
                [MarshalAs(UnmanagedType.LPWStr)] string eventName,
                out ICoreWebView2DevToolsProtocolEventReceiver receiver);

            [PreserveSig]
            HRESULT Stop();

            [PreserveSig]
            HRESULT add_NewWindowRequested(
                ICoreWebView2NewWindowRequestedEventHandler eventHandler,
                long* token);

            [PreserveSig]
            HRESULT remove_NewWindowRequested(
                long token);

            [PreserveSig]
            HRESULT add_DocumentTitleChanged(
                ICoreWebView2DocumentTitleChangedEventHandler eventHandler,
                long* token);

            [PreserveSig]
            HRESULT remove_DocumentTitleChanged(
                long token);

            [PreserveSig]
            HRESULT get_DocumentTitle(
                [MarshalAs(UnmanagedType.LPWStr)] out string title);

            [PreserveSig]
            HRESULT AddRemoteObject(
                [MarshalAs(UnmanagedType.LPWStr)] string name,
                IntPtr @object);

            [PreserveSig]
            HRESULT RemoveRemoteObject(
                [MarshalAs(UnmanagedType.LPWStr)] string name);

            [PreserveSig]
            HRESULT OpenDevToolsWindow();

            [PreserveSig]
            HRESULT add_ContainsFullScreenElementChanged(
                ICoreWebView2ContainsFullScreenElementChangedEventHandler eventHandler,
                long* token);

            [PreserveSig]
            HRESULT remove_ContainsFullScreenElementChanged(
                long token);

            [PreserveSig]
            HRESULT get_ContainsFullScreenElement(
                BOOL* containsFullScreenElement);

            [PreserveSig]
            HRESULT add_WebResourceRequested(
                ICoreWebView2WebResourceRequestedEventHandler eventHandler,
                long* token);

            [PreserveSig]
            HRESULT remove_WebResourceRequested(
                long token);

            [PreserveSig]
            HRESULT AddWebResourceRequestedFilter(
                [MarshalAs(UnmanagedType.LPWStr)] string uri,
                CORE_WEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);

            [PreserveSig]
            HRESULT RemoveWebResourceRequestedFilter(
                [MarshalAs(UnmanagedType.LPWStr)] string uri,
                CORE_WEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);

            [PreserveSig]
            HRESULT add_WindowCloseRequested(
                ICoreWebView2WindowCloseRequestedEventHandler eventHandler,
                long* token);

            [PreserveSig]
            HRESULT remove_WindowCloseRequested(
                long token);
        }
    }
}
