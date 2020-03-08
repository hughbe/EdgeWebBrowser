// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Diagnostics;
using static Interop;
using static Interop.WebView2;

namespace System.Windows.Forms
{
    public class EdgeWebBrowserWebMessageReceivedEventArgs : EventArgs
    {
        private readonly ICoreWebView2WebMessageReceivedEventArgs _nativeArgs;

        internal EdgeWebBrowserWebMessageReceivedEventArgs(ICoreWebView2WebMessageReceivedEventArgs nativeArgs)
        {
            _nativeArgs = nativeArgs;
        }

        public string Source
        {
            get
            {
                HRESULT hr = _nativeArgs.get_Source(out string source);
                Debug.Assert(hr == HRESULT.S_OK);
                return source;
            }
        }

        public string WebMessageAsJson
        {
            get
            {
                HRESULT hr = _nativeArgs.get_WebMessageAsJson(out string webMessageAsJson);
                Debug.Assert(hr == HRESULT.S_OK);
                return webMessageAsJson;
            }
        }

        public bool TryGetWebMessageAsString(out string webMessageAsString)
        {
            HRESULT hr = _nativeArgs.TryGetWebMessageAsString(out webMessageAsString);
            Debug.Assert(hr == HRESULT.S_OK);
            return hr == HRESULT.S_OK;
        }
    }
}