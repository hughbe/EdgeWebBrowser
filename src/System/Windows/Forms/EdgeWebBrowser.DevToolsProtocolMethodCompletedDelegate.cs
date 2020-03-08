// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Threading.Tasks;
using static Interop;
using static Interop.WebView2;

namespace System.Windows.Forms
{
    public partial class EdgeWebBrowser
    {
        private class DevToolsProtocolMethodCompletedDelegate : ICoreWebView2CallDevToolsProtocolMethodCompletedHandler
        {
            private readonly TaskCompletionSource<(HRESULT, string)> _source; 

            public DevToolsProtocolMethodCompletedDelegate(TaskCompletionSource<(HRESULT, string)> source)
            {
                _source = source;
            }

            HRESULT ICoreWebView2CallDevToolsProtocolMethodCompletedHandler.Invoke(HRESULT errorCode, string returnObjectAsJson)
            {
                _source.SetResult((errorCode, returnObjectAsJson));
                return HRESULT.S_OK;
            }
        }
    }
}
