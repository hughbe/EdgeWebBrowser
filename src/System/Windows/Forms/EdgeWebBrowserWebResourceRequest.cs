// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Diagnostics;
using System.IO;
using static Interop;
using static Interop.WebView2;

namespace System.Windows.Forms
{
    public class EdgeWebBrowserWebResourceRequest
    {
        private readonly ICoreWebView2WebResourceRequest _nativeRequest;
        private EdgeWebBrowserRequestHeaders _headers;

        internal EdgeWebBrowserWebResourceRequest(ICoreWebView2WebResourceRequest request)
        {
            _nativeRequest = request;
        }

        public string Uri
        {
            get
            {
                HRESULT hr = _nativeRequest.get_Uri(out string uri);
                Debug.Assert(hr == HRESULT.S_OK);
                return uri;
            }
            set
            {
                HRESULT hr = _nativeRequest.put_Uri(value);
                Debug.Assert(hr == HRESULT.S_OK);
            }
        }

        public string Method
        {
            get
            {
                HRESULT hr = _nativeRequest.get_Method(out string method);
                Debug.Assert(hr == HRESULT.S_OK);
                return method;
            }
            set
            {
                HRESULT hr = _nativeRequest.put_Method(value);
                Debug.Assert(hr == HRESULT.S_OK);
            }
        }

        public Stream Content
        {
            get
            {
                HRESULT hr = _nativeRequest.get_Content(out Ole32.IStream stream);
                Debug.Assert(hr == HRESULT.S_OK);
                return new Ole32.IStreamWrapper(stream);
            }
            set
            {
                var stream = new Ole32.GPStream(value);
                HRESULT hr = _nativeRequest.put_Content(stream);
                Debug.Assert(hr == HRESULT.S_OK);
            }
        }

        public EdgeWebBrowserRequestHeaders Headers
        {
            get
            {
                if (_headers == null)
                {
                    HRESULT hr = _nativeRequest.get_Headers(out ICoreWebView2HttpRequestHeaders headers);
                    Debug.Assert(hr == HRESULT.S_OK);
                    _headers = new EdgeWebBrowserRequestHeaders(headers);
                }

                return _headers;
            }
        }
    }
}