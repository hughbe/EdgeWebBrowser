﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.ComponentModel;
using System.Diagnostics;
using static Interop;
using static Interop.WebView2;

namespace System.Windows.Forms
{
    public class EdgeWebBrowserDeferral : CancelEventArgs
    {
        private readonly ICoreWebView2Deferral _nativeDeferral;

        internal EdgeWebBrowserDeferral(ICoreWebView2Deferral deferral)
        {
            _nativeDeferral = deferral;
        }

        public void Complete()
        {
            HRESULT hr = _nativeDeferral.Complete();
            Debug.Assert(hr == HRESULT.S_OK);
        }
    }
}