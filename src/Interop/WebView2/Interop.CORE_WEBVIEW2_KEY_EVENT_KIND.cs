// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

internal static partial class Interop
{
    internal static partial class WebView2
    {
        public enum CORE_WEBVIEW2_KEY_EVENT_KIND : uint
        {
            KEY_DOWN = 0,
            KEY_UP = 1,
            SYSTEM_KEY_DOWN = 2,
            SYSTEM_KEY_UP = 3,
        }
    }
}
