// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

internal static partial class Interop
{
    internal static partial class WebView2
    {
        public enum CORE_WEBVIEW2_SCRIPT_DIALOG_KIND : uint
        {
            ALERT = 0,
            CONFIRM = 1,
            PROMPT = 2,
            BEFOREUNLOAD = 3,
        }
    }
}
