using System;
using System.Drawing;
using System.Windows.Forms;

namespace EdgeWebBrowser
{
    public partial class PreviewForm : Form
    {
        public Image Image { get; }

        public PreviewForm(Image image)
        {
            Image = image;
            InitializeComponent();
        }

        private void PreviewForm_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image;
        }
    }
}
