// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.ComponentModel;
using System.Diagnostics;
using static Interop;
using static Interop.WebView2;

namespace System.Windows.Forms
{
    public class EdgeWebBrowserNavigatingEventArgs : CancelEventArgs
    {
        private readonly ICoreWebView2NavigationStartingEventArgs _nativeArgs;
        private EdgeWebBrowserRequestHeaders _requestHeaders;

        internal EdgeWebBrowserNavigatingEventArgs(ICoreWebView2NavigationStartingEventArgs nativeArgs)
        {
            _nativeArgs = nativeArgs;
        }

        public string Uri
        {
            get
            {
                HRESULT hr = _nativeArgs.get_Uri(out string uri);
                Debug.Assert(hr == HRESULT.S_OK);
                return uri;
            }
        }

        public unsafe bool IsRedirected
        {
            get
            {
                BOOL isRedirected = BOOL.FALSE;
                HRESULT hr = _nativeArgs.get_IsRedirected(&isRedirected);
                Debug.Assert(hr == HRESULT.S_OK);
                return isRedirected.IsTrue();
            }
        }

        public unsafe bool IsUserInitiated
        {
            get
            {
                BOOL userInitiated = BOOL.FALSE;
                HRESULT hr = _nativeArgs.get_IsUserInitiated(&userInitiated);
                Debug.Assert(hr == HRESULT.S_OK);
                return userInitiated.IsTrue();
            }
        }

        public unsafe ulong NavigationId
        {
            get
            {
                ulong navigationId = 0;
                HRESULT hr = _nativeArgs.get_NavigationId(&navigationId);
                Debug.Assert(hr == HRESULT.S_OK);
                return navigationId;
            }
        }

        public EdgeWebBrowserRequestHeaders RequestHeaders
        {
            get
            {
                if (_requestHeaders == null)
                {
                    HRESULT hr = _nativeArgs.get_RequestHeaders(out ICoreWebView2HttpRequestHeaders headers);
                    Debug.Assert(hr == HRESULT.S_OK);
                    _requestHeaders = new EdgeWebBrowserRequestHeaders(headers);
                }

                return _requestHeaders;
            }
        }
    }
}