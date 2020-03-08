// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using static Interop;
using static Interop.WebView2;

namespace System.Windows.Forms
{
    public partial class EdgeWebBrowser :
        Control,
        ICoreWebView2CreateCoreWebView2EnvironmentCompletedHandler,
        ICoreWebView2CreateCoreWebView2HostCompletedHandler,
        ICoreWebView2NavigationStartingEventHandler,
        ICoreWebView2SourceChangedEventHandler,
        ICoreWebView2ContentLoadingEventHandler,
        ICoreWebView2NavigationCompletedEventHandler,
        ICoreWebView2HistoryChangedEventHandler,
        ICoreWebView2DocumentTitleChangedEventHandler,
        ICoreWebView2ZoomFactorChangedEventHandler,
        ICoreWebView2ScriptDialogOpeningEventHandler,
        ICoreWebView2PermissionRequestedEventHandler,
        ICoreWebView2ProcessFailedEventHandler,
        ICoreWebView2WebMessageReceivedEventHandler,
        ICoreWebView2NewWindowRequestedEventHandler,
        ICoreWebView2ContainsFullScreenElementChangedEventHandler,
        ICoreWebView2WebResourceRequestedEventHandler,
        ICoreWebView2WindowCloseRequestedEventHandler
    {
        private static readonly object s_canGoBackChangedEvent = new object();
        private static readonly object s_canGoForwardChangedEvent = new object();
        private static readonly object s_navigatingEvent = new object();
        private static readonly object s_sourceChangedEvent = new object();
        private static readonly object s_contentLoadingEvent = new object();
        private static readonly object s_navigatedEvent = new object();
        private static readonly object s_documentTitleChangedEvent = new object();
        private static readonly object s_zoomFactorChangedEvent = new object();
        private static readonly object s_scriptDialogOpeningEvent = new object();
        private static readonly object s_permissionRequestedEvent = new object();
        private static readonly object s_processFailedEvent = new object();
        private static readonly object s_webMessageReceivedEvent = new object();
        private static readonly object s_newWindowRequestedEvent = new object();
        private static readonly object s_containsFullScreenElementChangedEvent = new object();
        private static readonly object s_webResourceRequestedEvent = new object();
        private static readonly object s_windowCloseRequestedEvent = new object();

        private const int HookedEventsState = 0x00000001;
        private const int CanGoBackState = 0x00000002;
        private const int CanGoForwardState = 0x00000004;
        private const int IsScriptEnabledState = 0x00000008;
        private const int IsWebMessageEnabledState = 0x00000010;
        private const int AreDefaultScriptDialogsEnabledState = 0x00000020;
        private const int IsStatusBarEnabledState = 0x00000040;
        private const int AreDevToolsEnabledState = 0x00000080;
        private const int AreDefaultContextMenusEnabledState = 0x00000100;
        private const int AreRemoteObjectsAllowedState = 0x00000200;
        private const int IsZoomControlEnabledState = 0x00000400;

        internal ICoreWebView2Environment _environment;
        internal ICoreWebView2Host _host;
        internal ICoreWebView2 _webView;

        private BitVector32 _state = new BitVector32();
        private double _zoomFactor = 1;

        private long _navigationStartingToken;
        private long _historyChangedToken;
        private long _sourceChangedToken;
        private long _contentLoadingToken;
        private long _navigationCompletedToken;
        private long _documentTitleChangedToken;
        private long _zoomFactorChangedToken;
        private long _frameNavigationStartingToken;
        private long _scriptDialogOpeningToken;
        private long _permissionRequestedToken;
        private long _processFailedToken;
        private long _webMessageReceivedToken;
        private long _newWindowRequestedToken;
        private long _containsFullScreenElementChangedToken;
        private long _webResourceRequestedToken;
        private long _windowCloseRequestedToken;

        public EdgeWebBrowser()
        {
            SetStyle(ControlStyles.UserPaint, false);
        }

        public string BrowserVersionInfo
        {
            get
            {
                if (_environment == null)
                {
                    return string.Empty;
                }

                HRESULT hr = _environment.get_BrowserVersionInfo(out string versionInfo);
                Debug.Assert(hr.Succeeded());
                return versionInfo;
            }
        }

        public bool CanGoBack
        {
            get => _state[CanGoBackState];
            private set
            {
                if (_state[CanGoBackState] == value)
                {
                    return;
                }

                _state[CanGoBackState] = value;
                OnCanGoBackChanged(EventArgs.Empty);
            }
        }

        public bool CanGoForward
        {
            get => _state[CanGoForwardState];
            private set
            {
                if (_state[CanGoForwardState] == value)
                {
                    return;
                }

                _state[CanGoForwardState] = value;
                OnCanGoForwardChanged(EventArgs.Empty);
            }
        }

        public unsafe bool ContainsFullScreenElement
        {
            get
            {
                if (_webView == null)
                {
                    return false;
                }

                BOOL containsFullScreenElement = BOOL.FALSE;
                HRESULT hr = _webView.get_ContainsFullScreenElement(&containsFullScreenElement);
                Debug.Assert(hr == HRESULT.S_OK);
                return containsFullScreenElement.IsTrue();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DocumentTitle
        {
            get
            {
                if (_webView == null)
                {
                    return null;
                }

                HRESULT hr = _webView.get_DocumentTitle(out string documentTitle);
                Debug.Assert(hr == HRESULT.S_OK);
                return documentTitle;
            }
        }

        public Uri Url
        {
            get
            {
                if (_webView == null)
                {
                    return null;
                }

                HRESULT hr = _webView.get_Source(out string uri);
                Debug.Assert(hr == HRESULT.S_OK);

                if (string.IsNullOrEmpty(uri))
                {
                    return null;
                }

                try
                {
                    return new Uri(uri);
                }
                catch (UriFormatException)
                {
                    return null;
                }
            }
            set
            {
                if (value != null && value.ToString() == string.Empty)
                {
                    value = null;
                }

                string url;
                if (value == null)
                {
                    url = "about:blank";
                }
                else if (value.IsAbsoluteUri)
                {
                    throw new ArgumentException("Can't navigate to relative url.", nameof(value));
                }
                else if (value.IsFile)
                {
                    url = value.OriginalString;
                }
                else
                {
                    url = value.AbsoluteUri;
                }

                Navigate(url);
            }
        }

        public unsafe double ZoomFactor
        {
            get
            {
                if (_host != null)
                {
                    double currentValue = 0;
                    HRESULT hr = _host.get_ZoomFactor(&currentValue);
                    Debug.Assert(hr == HRESULT.S_OK);
                    _zoomFactor = currentValue;
                }

                return _zoomFactor;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                if (_zoomFactor == value)
                {
                    return;
                }

                _zoomFactor = value;
                if (_host != null)
                {
                    HRESULT hr = _host.put_ZoomFactor(value);
                    Debug.Assert(hr == HRESULT.S_OK);
                }

                OnZoomFactorChanged(EventArgs.Empty);
            }
        }

        public bool IsScriptEnabled
        {
            get => _state[IsScriptEnabledState];
            set
            {
                if (_state[IsScriptEnabledState] == value)
                {
                    return;
                }

                _state[IsScriptEnabledState] = value;
                Settings?.put_IsScriptEnabled(value.ToBOOL());
            }
        }

        public bool IsWebMessageEnabled
        {
            get => _state[IsWebMessageEnabledState];
            set
            {
                if (_state[IsWebMessageEnabledState] == value)
                {
                    return;
                }

                _state[IsWebMessageEnabledState] = value;
                Settings?.put_IsWebMessageEnabled(value.ToBOOL());
            }
        }

        public bool AreDefaultScriptDialogsEnabled
        {
            get => _state[AreDefaultScriptDialogsEnabledState];
            set
            {
                if (_state[AreDefaultScriptDialogsEnabledState] == value)
                {
                    return;
                }

                _state[AreDefaultScriptDialogsEnabledState] = value;
                Settings?.put_AreDefaultScriptDialogsEnabled(value.ToBOOL());
            }
        }

        public bool IsStatusBarEnabled
        {
            get => _state[IsStatusBarEnabledState];
            set
            {
                if (_state[IsStatusBarEnabledState] == value)
                {
                    return;
                }

                _state[IsStatusBarEnabledState] = value;
                Settings?.put_IsStatusBarEnabled(value.ToBOOL());
            }
        }

        public bool AreDevToolsEnabled
        {
            get => _state[AreDevToolsEnabledState];
            set
            {
                if (_state[AreDevToolsEnabledState] == value)
                {
                    return;
                }

                _state[AreDevToolsEnabledState] = value;
                Settings?.put_AreDevToolsEnabled(value.ToBOOL());
            }
        }

        public bool AreDefaultContextMenusEnabled
        {
            get => _state[AreDefaultContextMenusEnabledState];
            set
            {
                if (_state[AreDefaultContextMenusEnabledState] == value)
                {
                    return;
                }

                _state[AreDefaultContextMenusEnabledState] = value;
                Settings?.put_AreDefaultContextMenusEnabled(value.ToBOOL());
            }
        }

        public bool AreRemoteObjectsAllowed
        {
            get => _state[AreRemoteObjectsAllowedState];
            set
            {
                if (_state[AreRemoteObjectsAllowedState] == value)
                {
                    return;
                }

                _state[AreRemoteObjectsAllowedState] = value;
                Settings?.put_AreRemoteObjectsAllowed(value.ToBOOL());
            }
        }

        public bool IsZoomControlEnabled
        {
            get => _state[IsZoomControlEnabledState];
            set
            {
                if (_state[IsZoomControlEnabledState] == value)
                {
                    return;
                }

                _state[IsZoomControlEnabledState] = value;
                Settings?.put_IsZoomControlEnabled(value.ToBOOL());
            }
        }

        private ICoreWebView2Settings Settings
        {
            get
            {
                if (_webView == null)
                {
                    throw new InvalidOperationException("Not Created");;
                }

                HRESULT hr = _webView.get_Settings(out ICoreWebView2Settings settings);
                Debug.Assert(hr == HRESULT.S_OK);
                return settings;
            }
        }

        public void AddRemoteObject(string name, IntPtr @object)
        {
            if (_webView == null)
            {
                throw new InvalidOperationException("Not Created");;
            }

            HRESULT hr = _webView.AddRemoteObject(name, @object);
            Debug.Assert(hr == HRESULT.S_OK);
        }

        public void RemoveRemoteObject(string name)
        {
            if (_webView == null)
            {
                throw new InvalidOperationException("Not Created");;
            }

            HRESULT hr = _webView.RemoveRemoteObject(name);
            Debug.Assert(hr == HRESULT.S_OK);
        }

        public async Task CapturePreviewAsync(Stream stream, EdgeWebBrowserPreviewImageFormat imageFormat)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            CORE_WEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT format;
            switch (imageFormat)
            {
                case EdgeWebBrowserPreviewImageFormat.Png:
                    format = CORE_WEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT.PNG;
                    break;
                case EdgeWebBrowserPreviewImageFormat.Jpeg:
                    format = CORE_WEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT.JPEG;
                    break;
                default:
                    throw new InvalidEnumArgumentException(nameof(imageFormat), (int)imageFormat, typeof(EdgeWebBrowserPreviewImageFormat));
            }

            if (_webView == null)
            {
                throw new InvalidOperationException("Not Created");;
            }

            var gpStream = new Ole32.GPStream(stream);
            var source = new TaskCompletionSource<HRESULT>();
            var captureDelegate = new CapturePreviewDelegate(source);
            HRESULT hr = _webView.CapturePreview(format, gpStream, captureDelegate);
            if (!hr.Succeeded())
            {
                throw Marshal.GetExceptionForHR((int)hr);
            }

            hr = await source.Task;
            Debug.Assert(hr == HRESULT.S_OK);
        }

        public unsafe bool GoBack()
        {
            if (!CanGoBack)
            {
                return false;
            }

            HRESULT hr = _webView.GoBack();
            Debug.Assert(hr == HRESULT.S_OK);
            return true;
        }

        public bool GoForward()
        {
            if (!CanGoForward)
            {
                return false;
            }

            HRESULT hr = _webView.GoForward();
            Debug.Assert(hr == HRESULT.S_OK);
            return true;
        }

        public override void Refresh()
        {
            if (_webView == null)
            {
                throw new InvalidOperationException("Not Created");;
            }

            HRESULT hr = _webView.Reload();
            Debug.Assert(hr == HRESULT.S_OK);
        }

        public async Task<string> CallDevToolsProtocolMethodAsync(string methodName, string parametersAsJson)
        {
            if (_webView == null)
            {
                throw new InvalidOperationException("Not Created");;
            }

            var source = new TaskCompletionSource<(HRESULT, string)>();
            var completedDelegate = new DevToolsProtocolMethodCompletedDelegate(source);
            HRESULT hr = _webView.CallDevToolsProtocolMethod(methodName, parametersAsJson, completedDelegate);
            Debug.Assert(hr == HRESULT.S_OK);

            (HRESULT hr, string resultObjectAsJson) result = await source.Task;
            Debug.Assert(hr == HRESULT.S_OK);

            return result.resultObjectAsJson;
        }

        public EdgeWebBrowserDevToolsProtocolEventReceiver GetDevToolsProtocolEventReceiver(string eventName)
        {
            if (_webView == null)
            {
                throw new InvalidOperationException("Not Created");;
            }

            HRESULT hr = _webView.GetDevToolsProtocolEventReceiver(eventName, out ICoreWebView2DevToolsProtocolEventReceiver nativeReceiver);
            Debug.Assert(hr == HRESULT.S_OK);
            return new EdgeWebBrowserDevToolsProtocolEventReceiver(eventName, nativeReceiver);
        }

        public async Task<string> AddScriptToExecuteOnDocumentCreatedAsync(string javaScript)
        {
            if (_webView == null)
            {
                throw new InvalidOperationException("Not Created");;
            }

            var source = new TaskCompletionSource<(HRESULT, string)>();
            var completedDelegate = new AddScriptToExecuteOnDocumentCreatedDelegate(source);
            HRESULT hr = _webView.AddScriptToExecuteOnDocumentCreated(javaScript, completedDelegate);
            if (!hr.Succeeded())
            {
                throw Marshal.GetExceptionForHR((int)hr);
            }

            (HRESULT hr, string id) result = await source.Task;
            Debug.Assert(hr == HRESULT.S_OK);

            return result.id;
        }

        public void RemoveScriptToExecuteOnDocumentCreated(string id)
        {
            if (_webView == null)
            {
                throw new InvalidOperationException("Not Created");;
            }

            HRESULT hr = _webView.RemoveScriptToExecuteOnDocumentCreated(id);
            Debug.Assert(hr == HRESULT.S_OK);
        }

        public async Task<string> ExecuteScriptAsync(string javascript)
        {
            if (_webView == null)
            {
                throw new InvalidOperationException("Not yet created.");
            }

            var source = new TaskCompletionSource<(HRESULT, string)>();
            var executeScriptDelegate = new ExecuteScriptDelegate(source);
            HRESULT hr = _webView.ExecuteScript(javascript, executeScriptDelegate);
            if (!hr.Succeeded())
            {
                throw Marshal.GetExceptionForHR((int)hr);
            }

            (HRESULT hr, string resultObjectAsJson) result = await source.Task;
            Debug.Assert(hr == HRESULT.S_OK);

            return result.resultObjectAsJson;
        }

        public EdgeWebBrowserWebResourceResponse CreateWebResourceResponse(Stream content, int statusCode, string reasonPhrase, string headers)
        {
            if (_environment == null)
            {
                throw new InvalidOperationException("Not Created");;
            }

            var stream = content != null ? new Ole32.GPStream(content) : null;
            HRESULT hr = _environment.CreateWebResourceResponse(stream, statusCode, reasonPhrase, headers, out ICoreWebView2WebResourceResponse nativeResponse);
            Debug.Assert(hr == HRESULT.S_OK);
            return new EdgeWebBrowserWebResourceResponse(nativeResponse);
        }

        public void AddWebResourceRequestedFilter(string uri, EdgeWebBrowserWebResourceRequestContext resourceContext)
        {
            if (resourceContext < EdgeWebBrowserWebResourceRequestContext.All || resourceContext > EdgeWebBrowserWebResourceRequestContext.Other)
            {
                throw new InvalidEnumArgumentException(nameof(resourceContext), (int)resourceContext, typeof(EdgeWebBrowserWebResourceRequestContext));
            }
            if (_webView == null)
            {
                throw new InvalidOperationException("Not Created");;
            }

            HRESULT hr = _webView.AddWebResourceRequestedFilter(uri, (CORE_WEBVIEW2_WEB_RESOURCE_CONTEXT)resourceContext);
            Debug.Assert(hr == HRESULT.S_OK);
        }

        public void RemoveWebResourceRequestedFilter(string uri, EdgeWebBrowserWebResourceRequestContext resourceContext)
        {
            if (resourceContext < EdgeWebBrowserWebResourceRequestContext.All || resourceContext > EdgeWebBrowserWebResourceRequestContext.Other)
            {
                throw new InvalidEnumArgumentException(nameof(resourceContext), (int)resourceContext, typeof(EdgeWebBrowserWebResourceRequestContext));
            }
            if (_webView == null)
            {
                throw new InvalidOperationException("Not Created");;
            }

            HRESULT hr = _webView.RemoveWebResourceRequestedFilter(uri, (CORE_WEBVIEW2_WEB_RESOURCE_CONTEXT)resourceContext);
            Debug.Assert(hr == HRESULT.S_OK);
        }

        public void Navigate(Uri url) => Url = url;

        public void Navigate(string urlString)
        {
            if (_webView == null)
            {
                return;
            }

            HRESULT hr = _webView.Navigate(urlString);
            Debug.Assert(hr == HRESULT.S_OK);
        }

        public void NavigateToString(string htmlContent)
        {
            if (_webView == null)
            {
                throw new InvalidOperationException("Not Created");;
            }

            HRESULT hr = _webView.NavigateToString(htmlContent);
            Debug.Assert(hr == HRESULT.S_OK);
        }

        public void OpenDevTools()
        {
            if (_webView == null)
            {
                throw new InvalidOperationException("Not Created");;
            }

            HRESULT hr = _webView.OpenDevToolsWindow();
            Debug.Assert(hr == HRESULT.S_OK);
        }

        public void PostWebMessageAsJson(string webMessageAsJson)
        {
            if (_webView == null)
            {
                throw new InvalidOperationException("Not Created");;
            }

            HRESULT hr = _webView.PostWebMessageAsJson(webMessageAsJson);
            Debug.Assert(hr == HRESULT.S_OK);
        }

        public void PostWebMessageAsString(string webMessageAsString)
        {
            if (_webView == null)
            {
                throw new InvalidOperationException("Not Created");;
            }

            HRESULT hr = _webView.PostWebMessageAsString(webMessageAsString);
            Debug.Assert(hr == HRESULT.S_OK);
        }

        public void Stop()
        {
            if (_webView == null)
            {
                throw new InvalidOperationException("Not Created");;
            }

            HRESULT hr = _webView.Stop();
            Debug.Assert(hr == HRESULT.S_OK);
        }

        protected override Size DefaultSize => new Size(250, 250);

        [Browsable(false)]
        public event EventHandler CanGoBackChanged
        {
            add => Events.AddHandler(s_canGoBackChangedEvent, value);
            remove => Events.RemoveHandler(s_canGoBackChangedEvent, value);
        }

        [Browsable(false)]
        public event EventHandler CanGoForwardChanged
        {
            add => Events.AddHandler(s_canGoForwardChangedEvent, value);
            remove => Events.RemoveHandler(s_canGoForwardChangedEvent, value);
        }

        [Browsable(false)]
        public event EventHandler<EdgeWebBrowserNavigatingEventArgs> Navigating
        {
            add => Events.AddHandler(s_navigatingEvent, value);
            remove => Events.RemoveHandler(s_navigatingEvent, value);
        }

        [Browsable(false)]
        public event EventHandler<EdgeWebBrowserSourceChangedEventArgs> SourceChanged
        {
            add => Events.AddHandler(s_sourceChangedEvent, value);
            remove => Events.RemoveHandler(s_sourceChangedEvent, value);
        }

        [Browsable(false)]
        public event EventHandler<EdgeWebBrowserContentLoadingEventArgs> ContentLoading
        {
            add => Events.AddHandler(s_contentLoadingEvent, value);
            remove => Events.RemoveHandler(s_contentLoadingEvent, value);
        }

        [Browsable(false)]
        public event EventHandler<EdgeWebBrowserNavigatedEventArgs> Navigated
        {
            add => Events.AddHandler(s_navigatedEvent, value);
            remove => Events.RemoveHandler(s_navigatedEvent, value);
        }

        [Browsable(false)]
        public event EventHandler DocumentTitleChanged
        {
            add => Events.AddHandler(s_documentTitleChangedEvent, value);
            remove => Events.RemoveHandler(s_documentTitleChangedEvent, value);
        }

        [Browsable(false)]
        public event EventHandler ZoomFactorChanged
        {
            add => Events.AddHandler(s_zoomFactorChangedEvent, value);
            remove => Events.RemoveHandler(s_zoomFactorChangedEvent, value);
        }

        [Browsable(false)]
        public event EventHandler<EdgeWebBrowserScriptDialogOpeningEventArgs> ScriptDialogOpening
        {
            add => Events.AddHandler(s_scriptDialogOpeningEvent, value);
            remove => Events.RemoveHandler(s_scriptDialogOpeningEvent, value);
        }

        [Browsable(false)]
        public event EventHandler<EdgeWebBrowserPermissionRequestedEventArgs> PermissionRequested
        {
            add => Events.AddHandler(s_permissionRequestedEvent, value);
            remove => Events.RemoveHandler(s_permissionRequestedEvent, value);
        }

        [Browsable(false)]
        public event EventHandler<EdgeWebBrowserProcessFailedEventArgs> ProcessFailed
        {
            add => Events.AddHandler(s_processFailedEvent, value);
            remove => Events.RemoveHandler(s_processFailedEvent, value);
        }

        [Browsable(false)]
        public event EventHandler<EdgeWebBrowserWebMessageReceivedEventArgs> WebMessageReceived
        {
            add => Events.AddHandler(s_webMessageReceivedEvent, value);
            remove => Events.RemoveHandler(s_webMessageReceivedEvent, value);
        }

        [Browsable(false)]
        public event EventHandler<EdgeWebBrowserNewWindowRequestedEventArgs> NewWindowRequested
        {
            add => Events.AddHandler(s_newWindowRequestedEvent, value);
            remove => Events.RemoveHandler(s_newWindowRequestedEvent, value);
        }

        [Browsable(false)]
        public event EventHandler ContainsFullScreenElementChanged
        {
            add => Events.AddHandler(s_containsFullScreenElementChangedEvent, value);
            remove => Events.RemoveHandler(s_containsFullScreenElementChangedEvent, value);
        }

        [Browsable(false)]
        public event EventHandler<EdgeWebBrowserWebResourceRequestedEventArgs> WebResourceRequested
        {
            add => Events.AddHandler(s_webResourceRequestedEvent, value);
            remove => Events.RemoveHandler(s_webResourceRequestedEvent, value);
        }

        [Browsable(false)]
        public event EventHandler WindowCloseRequested
        {
            add => Events.AddHandler(s_windowCloseRequestedEvent, value);
            remove => Events.RemoveHandler(s_windowCloseRequestedEvent, value);
        }

        protected virtual void OnCanGoBackChanged(EventArgs e)
            => ((EventHandler)Events[s_canGoBackChangedEvent])?.Invoke(this, e);

        protected virtual void OnCanGoForwardChanged(EventArgs e)
            => ((EventHandler)Events[s_canGoForwardChangedEvent])?.Invoke(this, e);

        protected virtual void OnNavigating(EdgeWebBrowserNavigatingEventArgs e)
            => ((EventHandler<EdgeWebBrowserNavigatingEventArgs>)Events[s_navigatingEvent])?.Invoke(this, e);

        protected virtual void OnSourceChanged(EdgeWebBrowserSourceChangedEventArgs e)
            => ((EventHandler<EdgeWebBrowserSourceChangedEventArgs>)Events[s_sourceChangedEvent])?.Invoke(this, e);

        protected virtual void OnContentLoading(EdgeWebBrowserContentLoadingEventArgs e)
            => ((EventHandler<EdgeWebBrowserContentLoadingEventArgs>)Events[s_contentLoadingEvent])?.Invoke(this, e);

        protected virtual void OnNavigated(EdgeWebBrowserNavigatedEventArgs e)
            => ((EventHandler<EdgeWebBrowserNavigatedEventArgs>)Events[s_navigatedEvent])?.Invoke(this, e);

        protected virtual void OnDocumentTitleChanged(EventArgs e)
            => ((EventHandler)Events[s_documentTitleChangedEvent])?.Invoke(this, e);

        protected virtual void OnZoomFactorChanged(EventArgs e)
            => ((EventHandler)Events[s_zoomFactorChangedEvent])?.Invoke(this, e);

        protected virtual void OnScriptDialogOpening(EdgeWebBrowserScriptDialogOpeningEventArgs e)
            => ((EventHandler<EdgeWebBrowserScriptDialogOpeningEventArgs>)Events[s_scriptDialogOpeningEvent])?.Invoke(this, e);

        protected virtual void OnPermissionRequested(EdgeWebBrowserPermissionRequestedEventArgs e)
            => ((EventHandler<EdgeWebBrowserPermissionRequestedEventArgs>)Events[s_permissionRequestedEvent])?.Invoke(this, e);

        protected virtual void OnProcessFailed(EdgeWebBrowserProcessFailedEventArgs e)
            => ((EventHandler<EdgeWebBrowserProcessFailedEventArgs>)Events[s_processFailedEvent])?.Invoke(this, e);

        protected virtual void OnWebMessageReceived(EdgeWebBrowserWebMessageReceivedEventArgs e)
            => ((EventHandler<EdgeWebBrowserWebMessageReceivedEventArgs>)Events[s_webMessageReceivedEvent])?.Invoke(this, e);

        protected virtual void OnNewWindowRequested(EdgeWebBrowserNewWindowRequestedEventArgs e)
            => ((EventHandler<EdgeWebBrowserNewWindowRequestedEventArgs>)Events[s_newWindowRequestedEvent])?.Invoke(this, e);

        protected virtual void OnContainsFullScreenElementChanged(EventArgs e)
            => ((EventHandler)Events[s_containsFullScreenElementChangedEvent])?.Invoke(this, e);

        protected virtual void OnWebResourceRequested(EdgeWebBrowserWebResourceRequestedEventArgs e)
            => ((EventHandler<EdgeWebBrowserWebResourceRequestedEventArgs>)Events[s_webResourceRequestedEvent])?.Invoke(this, e);

        protected virtual void OnWindowCloseRequested(EventArgs e)
            => ((EventHandler)Events[s_windowCloseRequestedEvent])?.Invoke(this, e);

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            if (!IsHandleCreated)
            {
                return;
            }

            HRESULT hr = CreateCoreWebView2Environment(this);
            if (!hr.Succeeded())
            {
                if (hr == HRESULT.E_FILENOTFOUND)
                {
                    throw new NotSupportedException("Could not find Edge installation");
                }

                throw Marshal.GetExceptionForHR((int)hr);
            }

            Debug.Assert(hr == HRESULT.S_OK);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (_host == null)
            {
                return;
            }

            HRESULT hr = _host.put_Bounds(ClientRectangle);
            Debug.Assert(hr == HRESULT.S_OK);
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);

            UnhookEvents();
            _host?.Close();
            _host = null;
            _webView = null;
            _environment = null;
        }

        protected override void WndProc(ref Message m)
        {
            switch ((User32.WM)m.Msg)
            {
                case User32.WM.MOVE:
                case User32.WM.MOVING:
                    _host?.NotifyParentWindowPositionChanged();
                    break;
            }

            base.WndProc(ref m);
        }

        private unsafe void HookEvents()
        {
            if (_state[HookedEventsState])
            {
                return;
            }

            long navigationStartedToken = 0;
            long sourceChangedToken = 0;
            long contentLoadingToken = 0;
            long historyChangedToken = 0;
            long navigationCompletedToken = 0;
            long documentTitleChangedToken = 0;
            long zoomFactorChangedToken = 0;
            long frameNavigationStartingToken = 0;
            long scriptDialogOpeningToken = 0;
            long permissionRequestedToken = 0;
            long processFailedToken = 0;
            long webMessageReceivedToken = 0;
            long newWindowRequestedToken = 0;
            long containsFullScreenElementChangedToken = 0;
            long webResourceRequestedToken = 0;
            long windowCloseRequestedToken = 0;
            _webView.add_NavigationStarting(this, &navigationStartedToken);
            _webView.add_SourceChanged(this, &sourceChangedToken);
            _webView.add_ContentLoading(this, &contentLoadingToken);
            _webView.add_HistoryChanged(this, &historyChangedToken);
            _webView.add_NavigationCompleted(this, &navigationCompletedToken);
            _webView.add_DocumentTitleChanged(this, &documentTitleChangedToken);
            _host.add_ZoomFactorChanged(this, &zoomFactorChangedToken);
            _webView.add_FrameNavigationStarting(this, &frameNavigationStartingToken);
            _webView.add_ScriptDialogOpening(this, &scriptDialogOpeningToken);
            _webView.add_PermissionRequested(this, &permissionRequestedToken);
            _webView.add_ProcessFailed(this, &processFailedToken);
            _webView.add_WebMessageReceived(this, &webMessageReceivedToken);
            _webView.add_NewWindowRequested(this, &newWindowRequestedToken);
            _webView.add_ContainsFullScreenElementChanged(this, &containsFullScreenElementChangedToken);
            _webView.add_WebResourceRequested(this, &webResourceRequestedToken);
            _webView.add_WindowCloseRequested(this, &windowCloseRequestedToken);

            _navigationStartingToken = navigationStartedToken;
            _sourceChangedToken = sourceChangedToken;
            _contentLoadingToken = contentLoadingToken;
            _historyChangedToken = historyChangedToken;
            _navigationCompletedToken = navigationCompletedToken;
            _documentTitleChangedToken = documentTitleChangedToken;
            _zoomFactorChangedToken = zoomFactorChangedToken;
            _frameNavigationStartingToken = frameNavigationStartingToken;
            _scriptDialogOpeningToken = scriptDialogOpeningToken;
            _permissionRequestedToken = permissionRequestedToken;
            _processFailedToken = processFailedToken;
            _webMessageReceivedToken = webMessageReceivedToken;
            _newWindowRequestedToken = newWindowRequestedToken;
            _containsFullScreenElementChangedToken = containsFullScreenElementChangedToken;
            _webResourceRequestedToken = webResourceRequestedToken;
            _windowCloseRequestedToken = windowCloseRequestedToken;

            _state[HookedEventsState] = true;
        }

        private void UnhookEvents()
        {
            if (!_state[HookedEventsState])
            {
                return;
            }

            _webView.remove_NavigationStarting(_navigationStartingToken);
            _webView.remove_SourceChanged(_sourceChangedToken);
            _webView.remove_ContentLoading(_contentLoadingToken);
            _webView.remove_HistoryChanged(_historyChangedToken);
            _webView.remove_NavigationCompleted(_navigationCompletedToken);
            _webView.remove_DocumentTitleChanged(_documentTitleChangedToken);
            _host.remove_ZoomFactorChanged(_zoomFactorChangedToken);
            _webView.remove_FrameNavigationStarting(_frameNavigationStartingToken);
            _webView.remove_ScriptDialogOpening(_scriptDialogOpeningToken);
            _webView.remove_PermissionRequested(_permissionRequestedToken);
            _webView.remove_ProcessFailed(_processFailedToken);
            _webView.remove_WebMessageReceived(_webMessageReceivedToken);
            _webView.remove_NewWindowRequested(_newWindowRequestedToken);
            _webView.remove_ContainsFullScreenElementChanged(_containsFullScreenElementChangedToken);
            _webView.remove_WebResourceRequested(_webResourceRequestedToken);
            _webView.remove_WindowCloseRequested(_windowCloseRequestedToken);

            _state[HookedEventsState] = false;
        }

        HRESULT ICoreWebView2CreateCoreWebView2EnvironmentCompletedHandler.Invoke(HRESULT result, ICoreWebView2Environment createdEnvironment)
        {
            _environment = createdEnvironment;
            HRESULT hr = _environment.CreateCoreWebView2Host(Handle, this);
            Debug.Assert(hr == HRESULT.S_OK);
            return hr;
        }

        unsafe HRESULT ICoreWebView2CreateCoreWebView2HostCompletedHandler.Invoke(HRESULT result, ICoreWebView2Host created_host)
        {
            _host = created_host;

            HRESULT hr = _host.put_Bounds(ClientRectangle);
            Debug.Assert(hr == HRESULT.S_OK);

            if (_zoomFactor != 1)
            {
                hr = _host.put_ZoomFactor(_zoomFactor);
                Debug.Assert(hr == HRESULT.S_OK);
            }

            hr = _host.get_CoreWebView2(out _webView);
            Debug.Assert(hr == HRESULT.S_OK);

            HookEvents();
            _webView.Navigate("about:blank");
            return HRESULT.S_OK;
        }

        unsafe HRESULT ICoreWebView2NavigationStartingEventHandler.Invoke(ICoreWebView2 sender, ICoreWebView2NavigationStartingEventArgs args)
        {
            var e = new EdgeWebBrowserNavigatingEventArgs(args);
            OnNavigating(e);

            if (e.Cancel)
            {
                HRESULT hr = args.put_Cancel(BOOL.TRUE);
                Debug.Assert(hr == HRESULT.S_OK);
            }

            return HRESULT.S_OK;
        }

        HRESULT ICoreWebView2SourceChangedEventHandler.Invoke(ICoreWebView2 webview, ICoreWebView2SourceChangedEventArgs args)
        {
            var e = new EdgeWebBrowserSourceChangedEventArgs(args);
            OnSourceChanged(e);
            return HRESULT.S_OK;
        }

        HRESULT ICoreWebView2ContentLoadingEventHandler.Invoke(ICoreWebView2 webview, ICoreWebView2ContentLoadingEventArgs args)
        {
            var e = new EdgeWebBrowserContentLoadingEventArgs(args);
            OnContentLoading(e);
            return HRESULT.S_OK;
        }

        HRESULT ICoreWebView2NavigationCompletedEventHandler.Invoke(ICoreWebView2 sender, ICoreWebView2NavigationCompletedEventArgs args)
        {
            var e = new EdgeWebBrowserNavigatedEventArgs(args);
            OnNavigated(e);
            return HRESULT.S_OK;
        }

        unsafe HRESULT ICoreWebView2HistoryChangedEventHandler.Invoke(ICoreWebView2 webview, IntPtr args)
        {
            BOOL canGoBack = BOOL.FALSE;
            BOOL canGoForward = BOOL.FALSE;

            HRESULT hr = webview.get_CanGoBack(&canGoBack);
            Debug.Assert(hr == HRESULT.S_OK);

            hr = webview.get_CanGoForward(&canGoForward);
            Debug.Assert(hr == HRESULT.S_OK);

            CanGoBack = canGoBack.IsTrue();
            CanGoForward = canGoForward.IsTrue();

            return HRESULT.S_OK;
        }

        HRESULT ICoreWebView2DocumentTitleChangedEventHandler.Invoke(ICoreWebView2 sender, IntPtr args)
        {
            OnDocumentTitleChanged(EventArgs.Empty);
            return HRESULT.S_OK;
        }

        HRESULT ICoreWebView2ZoomFactorChangedEventHandler.Invoke(ICoreWebView2Host sender, IntPtr args)
        {
            OnZoomFactorChanged(EventArgs.Empty);
            return HRESULT.S_OK;
        }

        HRESULT ICoreWebView2ScriptDialogOpeningEventHandler.Invoke(ICoreWebView2 sender, ICoreWebView2ScriptDialogOpeningEventArgs args)
        {
            var e = new EdgeWebBrowserScriptDialogOpeningEventArgs(args);
            OnScriptDialogOpening(e);
            return HRESULT.S_OK;
        }

        HRESULT ICoreWebView2PermissionRequestedEventHandler.Invoke(ICoreWebView2 sender, ICoreWebView2PermissionRequestedEventArgs args)
        {
            var e = new EdgeWebBrowserPermissionRequestedEventArgs(args);
            OnPermissionRequested(e);
            return HRESULT.S_OK;
        }

        HRESULT ICoreWebView2ProcessFailedEventHandler.Invoke(ICoreWebView2 sender, ICoreWebView2ProcessFailedEventArgs args)
        {
            var e = new EdgeWebBrowserProcessFailedEventArgs(args);
            OnProcessFailed(e);
            return HRESULT.S_OK;
        }

        HRESULT ICoreWebView2WebMessageReceivedEventHandler.Invoke(ICoreWebView2 sender, ICoreWebView2WebMessageReceivedEventArgs args)
        {
            var e = new EdgeWebBrowserWebMessageReceivedEventArgs(args);
            OnWebMessageReceived(e);
            return HRESULT.S_OK;
        }

        HRESULT ICoreWebView2NewWindowRequestedEventHandler.Invoke(ICoreWebView2 sender, ICoreWebView2NewWindowRequestedEventArgs args)
        {
            var e = new EdgeWebBrowserNewWindowRequestedEventArgs(args);
            OnNewWindowRequested(e);
            return HRESULT.S_OK;
        }

        HRESULT ICoreWebView2ContainsFullScreenElementChangedEventHandler.Invoke(ICoreWebView2 sender, IntPtr args)
        {
            OnContainsFullScreenElementChanged(EventArgs.Empty);
            return HRESULT.S_OK;
        }

        HRESULT ICoreWebView2WebResourceRequestedEventHandler.Invoke(ICoreWebView2 sender, ICoreWebView2WebResourceRequestedEventArgs args)
        {
            var e = new EdgeWebBrowserWebResourceRequestedEventArgs(args);
            OnWebResourceRequested(e);
            return HRESULT.S_OK;
        }

        HRESULT ICoreWebView2WindowCloseRequestedEventHandler.Invoke(ICoreWebView2 sender, IntPtr args)
        {
            OnWindowCloseRequested(EventArgs.Empty);
            return HRESULT.S_OK;
        }
    }
}
