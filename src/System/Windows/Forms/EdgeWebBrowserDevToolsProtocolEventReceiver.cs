// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using static Interop;
using static Interop.WebView2;

namespace System.Windows.Forms
{
    public class EdgeWebBrowserDevToolsProtocolEventReceiver : IDisposable, ICoreWebView2DevToolsProtocolEventReceivedEventHandler
    {
        private EventHandler<EdgeWebBrowserDevToolsProtocolEventReceivedEventArgs> _receivedEvent;

        private ICoreWebView2DevToolsProtocolEventReceiver _nativeReceiver;
        private readonly long _devToolsProtocolEventReceivedToken;

        internal unsafe EdgeWebBrowserDevToolsProtocolEventReceiver(string eventName, ICoreWebView2DevToolsProtocolEventReceiver deferral)
        {
            EventName = eventName;
            _nativeReceiver = deferral;

            long devToolsProtocolEventReceivedToken = 0;
            _nativeReceiver.add_DevToolsProtocolEventReceived(this, &devToolsProtocolEventReceivedToken);
            _devToolsProtocolEventReceivedToken = devToolsProtocolEventReceivedToken;
        }

        public string EventName { get; }

        public event EventHandler<EdgeWebBrowserDevToolsProtocolEventReceivedEventArgs> Received
        {
            add => _receivedEvent += value;
            remove => _receivedEvent -= value;
        }

        public void Dispose()
        {
            if (_nativeReceiver != null)
            {
                _nativeReceiver.remove_DevToolsProtocolEventReceived(_devToolsProtocolEventReceivedToken);
                _nativeReceiver = null;
            }
        }

        HRESULT ICoreWebView2DevToolsProtocolEventReceivedEventHandler.Invoke(ICoreWebView2 sender, ICoreWebView2DevToolsProtocolEventReceivedEventArgs args)
        {
            var e = new EdgeWebBrowserDevToolsProtocolEventReceivedEventArgs(args);
            _receivedEvent?.Invoke(this, e);
            return HRESULT.S_OK;
        }
    }
}