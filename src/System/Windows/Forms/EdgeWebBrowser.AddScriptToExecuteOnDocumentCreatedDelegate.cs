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
        private class AddScriptToExecuteOnDocumentCreatedDelegate : ICoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler
        {
            private readonly TaskCompletionSource<(HRESULT, string)> _source; 

            public AddScriptToExecuteOnDocumentCreatedDelegate(TaskCompletionSource<(HRESULT, string)> source)
            {
                _source = source;
            }

            HRESULT ICoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler.Invoke(HRESULT errorCode, string id)
            {
                _source.SetResult((errorCode, id));
                return HRESULT.S_OK;
            }
        }
    }
}
