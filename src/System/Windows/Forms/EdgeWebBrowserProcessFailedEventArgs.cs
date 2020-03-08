// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Diagnostics;
using static Interop;
using static Interop.WebView2;

namespace System.Windows.Forms
{
    public class EdgeWebBrowserProcessFailedEventArgs : EventArgs
    {
        private readonly ICoreWebView2ProcessFailedEventArgs _nativeArgs;

        internal EdgeWebBrowserProcessFailedEventArgs(ICoreWebView2ProcessFailedEventArgs nativeArgs)
        {
            _nativeArgs = nativeArgs;
        }

        public unsafe EdgeWebBrowserProcessFailedKind Kind
        {
            get
            {
                CORE_WEBVIEW2_PROCESS_FAILED_KIND kind = CORE_WEBVIEW2_PROCESS_FAILED_KIND.BROWSER_PROCESS_EXITED;
                HRESULT hr = _nativeArgs.get_ProcessFailedKind(&kind);
                Debug.Assert(hr == HRESULT.S_OK);
                return (EdgeWebBrowserProcessFailedKind)kind;
            }
        }
    }
}