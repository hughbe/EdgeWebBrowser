// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Diagnostics;
using static Interop;
using static Interop.WebView2;

namespace System.Windows.Forms
{
    public class EdgeWebBrowserContentLoadingEventArgs : EventArgs
    {
        private readonly ICoreWebView2ContentLoadingEventArgs _nativeArgs;

        internal EdgeWebBrowserContentLoadingEventArgs(ICoreWebView2ContentLoadingEventArgs nativeArgs)
        {
            _nativeArgs = nativeArgs;
        }

        public unsafe bool IsErrorPage
        {
            get
            {
                BOOL isErrorPage = BOOL.FALSE;
                HRESULT hr = _nativeArgs.get_IsErrorPage(&isErrorPage);
                Debug.Assert(hr == HRESULT.S_OK);
                return isErrorPage.IsTrue();
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