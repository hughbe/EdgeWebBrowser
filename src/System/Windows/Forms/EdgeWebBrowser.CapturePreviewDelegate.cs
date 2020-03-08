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
        private class CapturePreviewDelegate : ICoreWebView2CapturePreviewCompletedHandler
        {
            private readonly TaskCompletionSource<HRESULT> _source; 

            public CapturePreviewDelegate(TaskCompletionSource<HRESULT> source)
            {
                _source = source;
            }

            HRESULT ICoreWebView2CapturePreviewCompletedHandler.Invoke(HRESULT result)
            {
                _source.SetResult(result);
                return HRESULT.S_OK;
            }
        }
    }
}
