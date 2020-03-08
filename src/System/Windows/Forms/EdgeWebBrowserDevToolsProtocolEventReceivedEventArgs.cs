// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Diagnostics;
using static Interop;
using static Interop.WebView2;

namespace System.Windows.Forms
{
    public class EdgeWebBrowserDevToolsProtocolEventReceivedEventArgs : EventArgs
    {
        private readonly ICoreWebView2DevToolsProtocolEventReceivedEventArgs _nativeArgs;

        internal EdgeWebBrowserDevToolsProtocolEventReceivedEventArgs(ICoreWebView2DevToolsProtocolEventReceivedEventArgs nativeArgs)
        {
            _nativeArgs = nativeArgs;
        }

        public string ParameterObjectAsJson
        {
            get
            {
                HRESULT hr = _nativeArgs.get_ParameterObjectAsJson(out string parameterObjectAsJson);
                Debug.Assert(hr == HRESULT.S_OK);
                return parameterObjectAsJson;
            }
        }
    }
}