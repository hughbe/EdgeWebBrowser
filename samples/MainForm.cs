using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace EdgeWebBrowser
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            webBrowser.CanGoBackChanged += browser_CanGoBackChanged;
            webBrowser.CanGoForwardChanged += browser_CanGoForwardChanged;
            webBrowser.Navigating += browser_Navigating;
            webBrowser.SourceChanged += browser_SourceChanged;
            webBrowser.ContentLoading += browser_ContentLoading;
            webBrowser.Navigated += browser_Navigated;
            webBrowser.DocumentTitleChanged += browser_DocumentTitleChanged;
            webBrowser.ZoomFactorChanged += browser_ZoomFactorChanged;
            webBrowser.ScriptDialogOpening += browser_ScriptDialogOpening;
            webBrowser.PermissionRequested += browser_PermissionRequested;
            webBrowser.ProcessFailed += browser_ProcessFailed;
            webBrowser.WebMessageReceived += browser_WebMessageReceived;
            webBrowser.NewWindowRequested += browser_NewWindowRequested;
            webBrowser.ContainsFullScreenElementChanged += browser_ContainsFullScreenElementChanged;
            webBrowser.WebResourceRequested += browser_WebResourceRequested;
            webBrowser.WindowCloseRequested += browser_WindowCloseRequested;
        }

        private void browser_Navigating(object sender, EdgeWebBrowserNavigatingEventArgs e)
        {
            Debug.WriteLine("Navigating");
            Debug.WriteLine("Uri: " + e.Uri);
            Debug.WriteLine("IsRedirected: " + e.IsRedirected);
            Debug.WriteLine("IsUserInitiated: " + e.IsUserInitiated);
            Debug.WriteLine("NavigationId: " + e.NavigationId);

            KeyValuePair<string, string>[] headers = e.RequestHeaders.ToArray();
            Debug.WriteLine("RequestHeaders: " + headers.Length);
            foreach (KeyValuePair<string, string> header in headers)
            {
                Debug.WriteLine($"\t{header.Key}: {header.Value}");
            }
            Debug.WriteLine(string.Empty);

            stopButton.Enabled = true;
        }

        private void browser_SourceChanged(object sender, EdgeWebBrowserSourceChangedEventArgs e)
        {
            urlTextBox.Text = webBrowser.Url.ToString();
        }

        private void browser_ContentLoading(object sender, EdgeWebBrowserContentLoadingEventArgs e)
        {
            Debug.WriteLine("ContentLoading");
            Debug.WriteLine("IsErrorPage: " + e.IsErrorPage);
            Debug.WriteLine("NavigationId: " + e.NavigationId);
            Debug.WriteLine(string.Empty);
        }

        private void browser_Navigated(object sender, EdgeWebBrowserNavigatedEventArgs e)
        {
            Debug.WriteLine("Navigated");
            Debug.WriteLine("IsSuccess: " + e.IsSuccess);
            Debug.WriteLine("NavigationId: " + e.NavigationId);
            Debug.WriteLine("WebErrorStatus: " + e.WebErrorStatus);
            Debug.WriteLine(string.Empty);

            stopButton.Enabled = false;
        }

        private void browser_WebResourceRequested(object sender, EdgeWebBrowserWebResourceRequestedEventArgs e)
        {
            Debug.WriteLine("WebResourceRequested");
            Debug.WriteLine("Context: " + e.Context);
            Debug.WriteLine("Request:");
            Debug.WriteLine("\tUri: " + e.Request.Uri);
            Debug.WriteLine("\tMethod: " + e.Request.Method);
            Debug.WriteLine("\tContent: " + e.Request.Content.Length);
            KeyValuePair<string, string>[] requestHeaders = e.Request.Headers.ToArray();
            Debug.WriteLine("\tHeaders: " + requestHeaders.Length);
            foreach (KeyValuePair<string, string> header in requestHeaders)
            {
                Debug.WriteLine($"\t\t{header.Key}: {header.Value}");
            }
            Debug.WriteLine("Response:"); ;
            Debug.WriteLine("\tStatusCode: " + e.Response.StatusCode);
            Debug.WriteLine("\tReasonPhrase: " + e.Response.ReasonPhrase);
            Debug.WriteLine("\tContent: " + e.Response.Content.Length);
            KeyValuePair<string, string>[] responseHeaders = e.Response.Headers.ToArray();
            Debug.WriteLine("\tHeaders: " + responseHeaders.Length);
            foreach (KeyValuePair<string, string> header in responseHeaders)
            {
                Debug.WriteLine($"\t\t{header.Key}: {header.Value}");
            }

            Debug.WriteLine(string.Empty);

            stopButton.Enabled = false;
        }

        private void browser_WindowCloseRequested(object sender, EventArgs e)
        {
            Debug.WriteLine("WindoCloseRequested");
            Debug.WriteLine(string.Empty);

            stopButton.Enabled = false;
        }

        private void browser_DocumentTitleChanged(object sender, EventArgs e)
        {
            Text = webBrowser.DocumentTitle;
        }

        private void browser_CanGoBackChanged(object sender, EventArgs e)
        {
            backButton.Enabled = webBrowser.CanGoBack;
        }

        private void browser_CanGoForwardChanged(object sender, EventArgs e)
        {
            forwardButton.Enabled = webBrowser.CanGoForward;
        }

        private void browser_ZoomFactorChanged(object sender, EventArgs e)
        {
            zoomNumericUpDown.Text = webBrowser.ZoomFactor.ToString();
        }

        private void browser_ScriptDialogOpening(object sender, EdgeWebBrowserScriptDialogOpeningEventArgs e)
        {
            Debug.WriteLine("ScriptDialogOpening");
            Debug.WriteLine("DefaultText: " + e.DefaultText);
            Debug.WriteLine("Kind: " + e.Kind);
            Debug.WriteLine("Message: " + e.Message);
            Debug.WriteLine("ResultText: " + e.ResultText);
            Debug.WriteLine("Uri: " + e.Uri);
            Debug.WriteLine(string.Empty);
        }

        private void browser_PermissionRequested(object sender, EdgeWebBrowserPermissionRequestedEventArgs e)
        {
            Debug.WriteLine("PermissionRequested");
            Debug.WriteLine("Uri: " + e.Uri);
            Debug.WriteLine("Kind: " + e.Kind);
            Debug.WriteLine("IsUserInitiated: " + e.IsUserInitiated);
            Debug.WriteLine("State: " + e.State);
            Debug.WriteLine(string.Empty);
        }

        private void browser_ProcessFailed(object sender, EdgeWebBrowserProcessFailedEventArgs e)
        {
            Debug.WriteLine("ProcessFailed");
            Debug.WriteLine("Kind: " + e.Kind);
            Debug.WriteLine(string.Empty);
        }

        private void browser_WebMessageReceived(object sender, EdgeWebBrowserWebMessageReceivedEventArgs e)
        {
            Debug.WriteLine("WebMessageReceived");
            Debug.WriteLine("Source: " + e.Source);
            Debug.WriteLine("WebMessageAsJson: " + e.WebMessageAsJson);
            Debug.WriteLine(string.Empty);
        }

        private void browser_NewWindowRequested(object sender, EdgeWebBrowserNewWindowRequestedEventArgs e)
        {
            Debug.WriteLine("WebMessageReceived");
            Debug.WriteLine("Uri: " + e.Uri);
            Debug.WriteLine("Handled: " + e.Handled);
            Debug.WriteLine("IsUserInitiated: " + e.IsUserInitiated);
            Debug.WriteLine(string.Empty);
        }

        private void browser_ContainsFullScreenElementChanged(object sender, EventArgs e)
        {
            if (webBrowser.ContainsFullScreenElement)
            {
                Text = $"FULLSCREEN - {webBrowser.DocumentTitle}";
            }
            else
            {
                Text = webBrowser.DocumentTitle;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            versionLabel.Text = webBrowser.BrowserVersionInfo;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            webBrowser.GoBack();
        }

        private void forwardButton_Click(object sender, EventArgs e)
        {
            webBrowser.GoForward();
        }

        private void zoomNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            webBrowser.ZoomFactor = (double)zoomNumericUpDown.Value;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            webBrowser.Refresh();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            webBrowser.Stop();
        }

        private async void capturePreviewButton_Click(object sender, EventArgs e)
        {
            using (var stream = new MemoryStream())
            {
                await webBrowser.CapturePreviewAsync(stream, EdgeWebBrowserPreviewImageFormat.Jpeg);

                var image = Image.FromStream(stream);
                new PreviewForm(image).Show();
            }
        }

        private void urlTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
            {
                return;
            }

            string text = urlTextBox.Text;
            if (text.Length == 0)
            {
                return;
            }
            if (!text.StartsWith("about") && !text.StartsWith("http"))
            {
                text = "http://" + text;
            }

            webBrowser.Navigate(text);
        }

        private void openDevToolsButton_Click(object sender, EventArgs e)
        {
            webBrowser.OpenDevTools();
        }

        private void executeScriptButton_Click(object sender, EventArgs e)
        {
            var form = new ExecuteScriptForm(webBrowser);
            form.Show();
        }
    }
}
