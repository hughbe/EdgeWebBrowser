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
        private class ExecuteScriptDelegate : ICoreWebView2ExecuteScriptCompletedHandler
        {
            private readonly TaskCompletionSource<(HRESULT, string)> _source; 

            public ExecuteScriptDelegate(TaskCompletionSource<(HRESULT, string)> source)
            {
                _source = source;
            }

            HRESULT ICoreWebView2ExecuteScriptCompletedHandler.Invoke(HRESULT errorCode, string resultObjectAsJson)
            {
                _source.SetResult((errorCode, resultObjectAsJson));
                return HRESULT.S_OK;
            }
        }
    }
}
