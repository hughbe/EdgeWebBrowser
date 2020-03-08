// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using static Interop;
using static Interop.WebView2;

namespace System.Windows.Forms
{
    internal class EdgeWebBrowserHeaderEnumerator : IEnumerator<KeyValuePair<string, string>>
    {
        private readonly ICoreWebView2HttpHeadersCollectionIterator _iterator;

        public EdgeWebBrowserHeaderEnumerator(ICoreWebView2HttpHeadersCollectionIterator iterator)
        {
            _iterator = iterator;
        }

        public KeyValuePair<string, string> Current
        {
            get
            {
                HRESULT hr = _iterator.GetCurrentHeader(out string name, out string value);
                Debug.Assert(hr == HRESULT.S_OK);
                return new KeyValuePair<string, string>(name, value);
            }
        }

        object IEnumerator.Current => Current;

        public unsafe bool MoveNext()
        {
            BOOL hasNext;
            HRESULT hr = _iterator.MoveNext(&hasNext);
            Debug.Assert(hr == HRESULT.S_OK);
            return hasNext.IsTrue();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            // Nop.
        }
    }
}