namespace EdgeWebBrowser
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.versionLabel = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.forwardButton = new System.Windows.Forms.Button();
            this.zoomNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.capturePreviewButton = new System.Windows.Forms.Button();
            this.webBrowser = new System.Windows.Forms.EdgeWebBrowser();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.openDevToolsButton = new System.Windows.Forms.Button();
            this.executeScriptButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.zoomNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(12, 531);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(42, 13);
            this.versionLabel.TabIndex = 0;
            this.versionLabel.Text = "Version";
            // 
            // backButton
            // 
            this.backButton.Enabled = false;
            this.backButton.Location = new System.Drawing.Point(13, 12);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // forwardButton
            // 
            this.forwardButton.Enabled = false;
            this.forwardButton.Location = new System.Drawing.Point(94, 12);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(75, 23);
            this.forwardButton.TabIndex = 2;
            this.forwardButton.Text = "Forward";
            this.forwardButton.UseVisualStyleBackColor = true;
            this.forwardButton.Click += new System.EventHandler(this.forwardButton_Click);
            // 
            // zoomNumericUpDown
            // 
            this.zoomNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.zoomNumericUpDown.Location = new System.Drawing.Point(752, 529);
            this.zoomNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.zoomNumericUpDown.Name = "zoomNumericUpDown";
            this.zoomNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.zoomNumericUpDown.TabIndex = 3;
            this.zoomNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.zoomNumericUpDown.ValueChanged += new System.EventHandler(this.zoomNumericUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(709, 531);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Zoom:";
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(464, 12);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 5;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(545, 12);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 6;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // capturePreviewButton
            // 
            this.capturePreviewButton.Location = new System.Drawing.Point(626, 12);
            this.capturePreviewButton.Name = "capturePreviewButton";
            this.capturePreviewButton.Size = new System.Drawing.Size(75, 23);
            this.capturePreviewButton.TabIndex = 7;
            this.capturePreviewButton.Text = "Capture Preview";
            this.capturePreviewButton.UseVisualStyleBackColor = true;
            this.capturePreviewButton.Click += new System.EventHandler(this.capturePreviewButton_Click);
            // 
            // webBrowser
            // 
            this.webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser.AreDefaultContextMenusEnabled = false;
            this.webBrowser.AreDefaultScriptDialogsEnabled = false;
            this.webBrowser.AreDevToolsEnabled = false;
            this.webBrowser.AreRemoteObjectsAllowed = false;
            this.webBrowser.IsScriptEnabled = false;
            this.webBrowser.IsStatusBarEnabled = false;
            this.webBrowser.IsWebMessageEnabled = false;
            this.webBrowser.IsZoomControlEnabled = false;
            this.webBrowser.Location = new System.Drawing.Point(13, 41);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(859, 482);
            this.webBrowser.TabIndex = 9;
            this.webBrowser.TabStop = false;
            this.webBrowser.Url = null;
            this.webBrowser.ZoomFactor = 1D;
            // 
            // urlTextBox
            // 
            this.urlTextBox.Location = new System.Drawing.Point(175, 14);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(283, 20);
            this.urlTextBox.TabIndex = 10;
            this.urlTextBox.Text = "about:blank";
            this.urlTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.urlTextBox_KeyUp);
            // 
            // openDevToolsButton
            // 
            this.openDevToolsButton.Location = new System.Drawing.Point(707, 12);
            this.openDevToolsButton.Name = "openDevToolsButton";
            this.openDevToolsButton.Size = new System.Drawing.Size(75, 23);
            this.openDevToolsButton.TabIndex = 11;
            this.openDevToolsButton.Text = "Open Dev Tools";
            this.openDevToolsButton.UseVisualStyleBackColor = true;
            this.openDevToolsButton.Click += new System.EventHandler(this.openDevToolsButton_Click);
            // 
            // executeScriptButton
            // 
            this.executeScriptButton.Location = new System.Drawing.Point(788, 11);
            this.executeScriptButton.Name = "executeScriptButton";
            this.executeScriptButton.Size = new System.Drawing.Size(75, 23);
            this.executeScriptButton.TabIndex = 12;
            this.executeScriptButton.Text = "Execute";
            this.executeScriptButton.UseVisualStyleBackColor = true;
            this.executeScriptButton.Click += new System.EventHandler(this.executeScriptButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.executeScriptButton);
            this.Controls.Add(this.openDevToolsButton);
            this.Controls.Add(this.urlTextBox);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.capturePreviewButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zoomNumericUpDown);
            this.Controls.Add(this.forwardButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.versionLabel);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.zoomNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button forwardButton;
        private System.Windows.Forms.NumericUpDown zoomNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button capturePreviewButton;
        private System.Windows.Forms.EdgeWebBrowser webBrowser;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Button openDevToolsButton;
        private System.Windows.Forms.Button executeScriptButton;
    }
}

