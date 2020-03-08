// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Diagnostics;
using static Interop;
using static Interop.WebView2;

namespace System.Windows.Forms
{
    public class EdgeWebBrowserScriptDialogOpeningEventArgs : EventArgs
    {
        private readonly ICoreWebView2ScriptDialogOpeningEventArgs _nativeArgs;

        internal EdgeWebBrowserScriptDialogOpeningEventArgs(ICoreWebView2ScriptDialogOpeningEventArgs nativeArgs)
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

        public unsafe EdgeWebBrowserScriptDialogKind Kind
        {
            get
            {
                CORE_WEBVIEW2_SCRIPT_DIALOG_KIND kind = CORE_WEBVIEW2_SCRIPT_DIALOG_KIND.ALERT;
                HRESULT hr = _nativeArgs.get_Kind(&kind);
                Debug.Assert(hr == HRESULT.S_OK);
                return (EdgeWebBrowserScriptDialogKind)kind;
            }
        }

        public string Message
        {
            get
            {
                HRESULT hr = _nativeArgs.get_Message(out string message);
                Debug.Assert(hr == HRESULT.S_OK);
                return message;
            }
        }

        public string DefaultText
        {
            get
            {
                HRESULT hr = _nativeArgs.get_DefaultText(out string defaultText);
                Debug.Assert(hr == HRESULT.S_OK);
                return defaultText;
            }
        }

        public string ResultText
        {
            get
            {
                HRESULT hr = _nativeArgs.get_ResultText(out string defaultText);
                Debug.Assert(hr == HRESULT.S_OK);
                return defaultText;
            }
            set
            {
                HRESULT hr = _nativeArgs.put_ResultText(value);
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

        public void Accept()
        {
            HRESULT hr = _nativeArgs.Accept();
            Debug.Assert(hr == HRESULT.S_OK);
        }
    }
}