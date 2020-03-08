// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using static Interop.WebView2;

namespace System.Windows.Forms
{
    public enum EdgeWebBrowserWebErrorStatus 
    {
        Unknown = (int)CORE_WEBVIEW2_WEB_ERROR_STATUS.UNKNOWN,
        CertificateCommonNameIsIncorrect = (int)CORE_WEBVIEW2_WEB_ERROR_STATUS.CERTIFICATE_COMMON_NAME_IS_INCORRECT,
        CertificateExpired = (int)CORE_WEBVIEW2_WEB_ERROR_STATUS.CERTIFICATE_EXPIRED,
        CertificateContainsErrors = (int)CORE_WEBVIEW2_WEB_ERROR_STATUS.CLIENT_CERTIFICATE_CONTAINS_ERRORS,
        CertificateRevoked = (int)CORE_WEBVIEW2_WEB_ERROR_STATUS.CERTIFICATE_REVOKED,
        CertificateIsInvalid = (int)CORE_WEBVIEW2_WEB_ERROR_STATUS.CERTIFICATE_IS_INVALID,
        ServerUnreachable = (int)CORE_WEBVIEW2_WEB_ERROR_STATUS.SERVER_UNREACHABLE,
        Timeout = (int)CORE_WEBVIEW2_WEB_ERROR_STATUS.TIMEOUT,
        InvalidServiceResponse = (int)CORE_WEBVIEW2_WEB_ERROR_STATUS.ERROR_HTTP_INVALID_SERVER_RESPONSE,
        ConnectionAborted = (int)CORE_WEBVIEW2_WEB_ERROR_STATUS.CONNECTION_ABORTED,
        ConnectionReset = (int)CORE_WEBVIEW2_WEB_ERROR_STATUS.CONNECTION_RESET,
        Disconnected = (int)CORE_WEBVIEW2_WEB_ERROR_STATUS.DISCONNECTED,
        CannotConnect = (int)CORE_WEBVIEW2_WEB_ERROR_STATUS.CANNOT_CONNECT,
        HostNameNotResolved = (int)CORE_WEBVIEW2_WEB_ERROR_STATUS.HOST_NAME_NOT_RESOLVED,
        Canceled = (int)CORE_WEBVIEW2_WEB_ERROR_STATUS.OPERATION_CANCELED,
        RedirectFailed = (int)CORE_WEBVIEW2_WEB_ERROR_STATUS.REDIRECT_FAILED,
        UnexpectedError = (int)CORE_WEBVIEW2_WEB_ERROR_STATUS.UNEXPECTED_ERROR,
    }
}
