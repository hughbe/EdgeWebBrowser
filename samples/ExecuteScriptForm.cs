using System;
using System.Windows.Forms;

namespace EdgeWebBrowser
{
    public partial class ExecuteScriptForm : Form
    {
        private System.Windows.Forms.EdgeWebBrowser _browser;

        public ExecuteScriptForm(System.Windows.Forms.EdgeWebBrowser browser)
        {
            _browser = browser;
            InitializeComponent();
        }

        private async void executeButton_Click(object sender, EventArgs e)
        {
            string result = await _browser.ExecuteScriptAsync(textBox1.Text);
            MessageBox.Show(result);
        }
    }
}
