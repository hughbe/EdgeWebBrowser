// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Diagnostics;
using static Interop;
using static Interop.WebView2;

namespace System.Windows.Forms
{
    public class EdgeWebBrowserNavigatedEventArgs : EventArgs
    {
        private readonly ICoreWebView2NavigationCompletedEventArgs _nativeArgs;

        internal EdgeWebBrowserNavigatedEventArgs(ICoreWebView2NavigationCompletedEventArgs nativeArgs)
        {
            _nativeArgs = nativeArgs;
        }

        public unsafe bool IsSuccess
        {
            get
            {
                BOOL isSuccess = BOOL.FALSE;
                HRESULT hr = _nativeArgs.get_IsSuccess(&isSuccess);
                Debug.Assert(hr == HRESULT.S_OK);
                return isSuccess.IsTrue();
            }
        }

        public unsafe EdgeWebBrowserWebErrorStatus WebErrorStatus
        {
            get
            {
                CORE_WEBVIEW2_WEB_ERROR_STATUS webErrorStatus = CORE_WEBVIEW2_WEB_ERROR_STATUS.UNKNOWN;
                HRESULT hr = _nativeArgs.get_WebErrorStatus(&webErrorStatus);
                Debug.Assert(hr == HRESULT.S_OK);
                return (EdgeWebBrowserWebErrorStatus)webErrorStatus;
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
    }
}