// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

internal static partial class Interop
{
    internal static partial class WebView2
    {
        public enum CORE_WEBVIEW2_PROCESS_FAILED_KIND : uint
        {
            BROWSER_PROCESS_EXITED = 0,
            RENDER_PROCESS_EXITED = 1,
            RENDER_PROCESS_UNRESPONSIVE = 2,
        }
    }
}
