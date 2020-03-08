// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.ComponentModel;
using System.Diagnostics;
using static Interop;
using static Interop.WebView2;

namespace System.Windows.Forms
{
    public class EdgeWebBrowserPermissionRequestedEventArgs : EventArgs
    {
        private readonly ICoreWebView2PermissionRequestedEventArgs _nativeArgs;

        internal EdgeWebBrowserPermissionRequestedEventArgs(ICoreWebView2PermissionRequestedEventArgs nativeArgs)
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

        public unsafe EdgeWebBrowserPermissionKind Kind
        {
            get
            {
                CORE_WEBVIEW2_PERMISSION_KIND kind = CORE_WEBVIEW2_PERMISSION_KIND.UNKNOWN_PERMISSION;
                HRESULT hr = _nativeArgs.get_PermissionKind(&kind);
                Debug.Assert(hr == HRESULT.S_OK);
                return (EdgeWebBrowserPermissionKind)kind;
            }
        }

        public unsafe bool IsUserInitiated
        {
            get
            {
                BOOL isUserInitiated = BOOL.FALSE;
                HRESULT hr = _nativeArgs.get_IsUserInitiated(&isUserInitiated);
                Debug.Assert(hr == HRESULT.S_OK);
                return isUserInitiated.IsTrue();
            }
        }

        public unsafe EdgeWebBrowserPermissionState State
        {
            get
            {
                CORE_WEBVIEW2_PERMISSION_STATE state = CORE_WEBVIEW2_PERMISSION_STATE.DEFAULT;
                HRESULT hr = _nativeArgs.get_State(&state);
                Debug.Assert(hr == HRESULT.S_OK);
                return (EdgeWebBrowserPermissionState)state;
            }
            set
            {
                if (value < EdgeWebBrowserPermissionState.Default || value > EdgeWebBrowserPermissionState.Deny)
                {
                    throw new InvalidEnumArgumentException(nameof(value), (int)value, typeof(EdgeWebBrowserPermissionState));
                }

                HRESULT hr = _nativeArgs.put_State((CORE_WEBVIEW2_PERMISSION_STATE)value);
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