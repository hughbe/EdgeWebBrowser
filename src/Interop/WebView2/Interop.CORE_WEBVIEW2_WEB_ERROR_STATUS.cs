// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

internal static partial class Interop
{
    internal static partial class WebView2
    {
        public enum CORE_WEBVIEW2_WEB_ERROR_STATUS : uint
        {
            UNKNOWN = 0,
            CERTIFICATE_COMMON_NAME_IS_INCORRECT = 1,
            CERTIFICATE_EXPIRED = 2,
            CLIENT_CERTIFICATE_CONTAINS_ERRORS = 3,
            CERTIFICATE_REVOKED = 4,
            CERTIFICATE_IS_INVALID = 5,
            SERVER_UNREACHABLE = 6,
            TIMEOUT = 7,
            ERROR_HTTP_INVALID_SERVER_RESPONSE = 8,
            CONNECTION_ABORTED = 9,
            CONNECTION_RESET = 10,
            DISCONNECTED = 11,
            CANNOT_CONNECT = 12,
            HOST_NAME_NOT_RESOLVED = 13,
            OPERATION_CANCELED = 14,
            REDIRECT_FAILED = 15,
            UNEXPECTED_ERROR = 16,
        }
    }
}
