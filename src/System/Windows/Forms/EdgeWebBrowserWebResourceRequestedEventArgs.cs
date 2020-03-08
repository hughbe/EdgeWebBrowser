// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.ComponentModel;
using System.Diagnostics;
using static Interop;
using static Interop.WebView2;

namespace System.Windows.Forms
{
    public class EdgeWebBrowserWebResourceRequestedEventArgs : EventArgs
    {
        private readonly ICoreWebView2WebResourceRequestedEventArgs _nativeArgs;
        private EdgeWebBrowserWebResourceRequest _request;
        private EdgeWebBrowserWebResourceResponse _response;

        internal EdgeWebBrowserWebResourceRequestedEventArgs(ICoreWebView2WebResourceRequestedEventArgs nativeArgs)
        {
            _nativeArgs = nativeArgs;
        }

        public EdgeWebBrowserWebResourceRequest Request
        {
            get
            {
                if (_request == null)
                {
                    HRESULT hr = _nativeArgs.get_Request(out ICoreWebView2WebResourceRequest request);
                    Debug.Assert(hr == HRESULT.S_OK);
                    _request = new EdgeWebBrowserWebResourceRequest(request);
                }

                return _request;
            }
        }

        public EdgeWebBrowserWebResourceResponse Response
        {
            get
            {
                if (_response == null)
                {
                    HRESULT hr = _nativeArgs.get_Response(out ICoreWebView2WebResourceResponse response);
                    Debug.Assert(hr == HRESULT.S_OK);
                    _response = new EdgeWebBrowserWebResourceResponse(response);
                }

                return _response;
            }
            set
            {
                HRESULT hr = _nativeArgs.put_Response(value?._nativeResponse);
                Debug.Assert(hr == HRESULT.S_OK);
            }
        }

        public unsafe EdgeWebBrowserWebResourceRequestContext Context
        {
            get
            {
                CORE_WEBVIEW2_WEB_RESOURCE_CONTEXT context = CORE_WEBVIEW2_WEB_RESOURCE_CONTEXT.OTHER;
                HRESULT hr = _nativeArgs.get_ResourceContext(&context);
                Debug.Assert(hr == HRESULT.S_OK);
                return (EdgeWebBrowserWebResourceRequestContext)context;
            }
        }

        public EdgeWebBrowserDeferral GetDeferral()
        {
            HRESULT hr = _nativeArgs.GetDeferral(out ICoreWebView2Deferral nativeDeferral);
            Debug.Assert(hr == HRESULT.S_OK);

            var deferral = new EdgeWebBrowserDeferral(nativeDeferral);
            return deferral;
        }
    }
}