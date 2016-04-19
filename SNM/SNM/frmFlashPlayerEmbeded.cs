using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SNM
{
    public partial class frmFlashPlayerEmbeded : Form
    {
        private string embedLink;
        private Uri youtubeLink;

        public frmFlashPlayerEmbeded(string videoId, Uri youtubeLink)
        {
            InitializeComponent();
            embedLink = "http://www.youtube.com/v/" + videoId;
            this.youtubeLink = youtubeLink;
            flashPlayerYoutube.Movie = embedLink;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblViewOnYoutube_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(youtubeLink.ToString());
        }
    }
}
