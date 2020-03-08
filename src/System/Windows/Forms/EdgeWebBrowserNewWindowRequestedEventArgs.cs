// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Diagnostics;
using static Interop;
using static Interop.WebView2;

namespace System.Windows.Forms
{
    public class EdgeWebBrowserNewWindowRequestedEventArgs : EventArgs
    {
        private readonly ICoreWebView2NewWindowRequestedEventArgs _nativeArgs;

        internal EdgeWebBrowserNewWindowRequestedEventArgs(ICoreWebView2NewWindowRequestedEventArgs nativeArgs)
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

        public unsafe bool Handled
        {
            get
            {
                BOOL handled = BOOL.FALSE;
                HRESULT hr = _nativeArgs.get_Handled(&handled);
                Debug.Assert(hr == HRESULT.S_OK);
                return handled.IsTrue();
            }
            set
            {
                HRESULT hr = _nativeArgs.put_Handled(value.ToBOOL());
                Debug.Assert(hr == HRESULT.S_OK);
            }
        }

        public unsafe bool IsUserInitiated
        {
            get
            {
                BOOL isUserInitiated = BOOL.FALSE;
                HRESULT hr = _nativeArgs.get_IsUserInitialized(&isUserInitiated);
                Debug.Assert(hr == HRESULT.S_OK);
                return isUserInitiated.IsTrue();
            }
        }

        internal ICoreWebView2 NewWindow
        {
            get
            {
                HRESULT hr = _nativeArgs.get_newWindow(out ICoreWebView2 window);
                Debug.Assert(hr == HRESULT.S_OK);
                return window;
            }
            set
            {
                HRESULT hr = _nativeArgs.put_newWindow(value);
                Debug.Assert(hr == HRESULT.S_OK);
            }
        }

        public EdgeWebBrowserDeferral GetDeferral()
        {
            HRESULT hr = _nativeArgs.GetDeferral(out ICoreWebView2Deferral nativeDeferral);
            Debug.Assert(hr == HRESULT.S_OK);

            var deferral = new EdgeWebBrowserDeferral(nativeDeferral);
            return deferral;
        }
    }
}