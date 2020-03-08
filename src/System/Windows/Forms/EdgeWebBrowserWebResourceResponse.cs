// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Diagnostics;
using System.IO;
using static Interop;
using static Interop.WebView2;

namespace System.Windows.Forms
{
    public class EdgeWebBrowserWebResourceResponse
    {
        internal readonly ICoreWebView2WebResourceResponse _nativeResponse;
        private EdgeWebBrowserResponseHeaders _headers;

        internal EdgeWebBrowserWebResourceResponse(ICoreWebView2WebResourceResponse request)
        {
            _nativeResponse = request;
        }

        public Stream Content
        {
            get
            {
                HRESULT hr = _nativeResponse.get_Content(out Ole32.IStream stream);
                Debug.Assert(hr == HRESULT.S_OK);
                return new Ole32.IStreamWrapper(stream);
            }
            set
            {
                var stream = new Ole32.GPStream(value);
                HRESULT hr = _nativeResponse.put_Content(stream);
                Debug.Assert(hr == HRESULT.S_OK);
            }
        }

        public EdgeWebBrowserResponseHeaders Headers
        {
            get
            {
                if (_headers == null)
                {
                    HRESULT hr = _nativeResponse.get_Headers(out ICoreWebView2HttpResponseHeaders headers);
                    Debug.Assert(hr == HRESULT.S_OK);
                    _headers = new EdgeWebBrowserResponseHeaders(headers);
                }

                return _headers;
            }
        }

        public unsafe int StatusCode
        {
            get
            {
                int statusCode = 0;
                HRESULT hr = _nativeResponse.get_StatusCode(&statusCode);
                Debug.Assert(hr == HRESULT.S_OK);
                return statusCode;
            }
            set
            {
                HRESULT hr = _nativeResponse.put_StatusCode(value);
                Debug.Assert(hr == HRESULT.S_OK);
            }
        }

        public string ReasonPhrase
        {
            get
            {
                HRESULT hr = _nativeResponse.get_ReasonPhrase(out string reasonPhrase);
                Debug.Assert(hr == HRESULT.S_OK);
                return reasonPhrase;
            }
            set
            {
                HRESULT hr = _nativeResponse.put_ReasonPhrase(value);
                Debug.Assert(hr == HRESULT.S_OK);
            }
        }
    }
}