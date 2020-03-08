// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using static Interop;
using static Interop.WebView2;

namespace System.Windows.Forms
{
    public class EdgeWebBrowserResponseHeaders : IEnumerable<KeyValuePair<string, string>>
    {
        private readonly ICoreWebView2HttpResponseHeaders _headers;

        internal EdgeWebBrowserResponseHeaders(ICoreWebView2HttpResponseHeaders headers)
        {
            _headers = headers;
        }

        public string this[string name]
        {
            get
            {
                HRESULT hr = _headers.GetHeader(name, out string value);
                Debug.Assert(hr == HRESULT.S_OK);
                return value;
            }
        }

        public unsafe void AppendHeader(string name, string value)
        {
            HRESULT hr = _headers.AppendHeader(name, value);
            Debug.Assert(hr == HRESULT.S_OK);
        }

        public unsafe bool Contains(string name)
        {
            BOOL contains = BOOL.FALSE;
            HRESULT hr = _headers.Contains(name, &contains);
            Debug.Assert(hr == HRESULT.S_OK);
            return contains.IsTrue();
        }

        public IEnumerator<KeyValuePair<string, string>> GetHeaders(string name)
        {
            HRESULT hr = _headers.GetHeaders(name, out ICoreWebView2HttpHeadersCollectionIterator iterator);
            Debug.Assert(hr == HRESULT.S_OK);
            return new EdgeWebBrowserHeaderEnumerator(iterator);
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            HRESULT hr = _headers.GetIterator(out ICoreWebView2HttpHeadersCollectionIterator iterator);
            Debug.Assert(hr == HRESULT.S_OK);
            return new EdgeWebBrowserHeaderEnumerator(iterator);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}