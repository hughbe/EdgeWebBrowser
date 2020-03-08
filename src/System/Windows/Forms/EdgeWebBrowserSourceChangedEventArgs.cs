// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.ComponentModel;
using System.Diagnostics;
using static Interop;
using static Interop.WebView2;

namespace System.Windows.Forms
{
    public class EdgeWebBrowserSourceChangedEventArgs : CancelEventArgs
    {
        private readonly ICoreWebView2SourceChangedEventArgs _nativeArgs;

        internal EdgeWebBrowserSourceChangedEventArgs(ICoreWebView2SourceChangedEventArgs nativeArgs)
        {
            _nativeArgs = nativeArgs;
        }

        public unsafe bool IsRedirected
        {
            get
            {
                BOOL isNewDocument = BOOL.FALSE;
                HRESULT hr = _nativeArgs.get_IsNewDocument(&isNewDocument);
                Debug.Assert(hr == HRESULT.S_OK);
                return isNewDocument.IsTrue();
            }
        }
    }
}