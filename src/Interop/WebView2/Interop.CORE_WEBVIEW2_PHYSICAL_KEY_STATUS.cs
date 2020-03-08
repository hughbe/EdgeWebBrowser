// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

internal static partial class Interop
{
    internal static partial class WebView2
    {
        public struct CORE_WEBVIEW2_PHYSICAL_KEY_STATUS
        {
#pragma warning disable CS0649
            public uint RepeatCount;
            public uint ScanCode;
            public BOOL IsExtendedKey;
            public BOOL IsMenuKeyDown;
            public BOOL WasKeyDown;
            public BOOL IsKeyReleased;
#pragma warning restore CS0649
        }
    }
}
