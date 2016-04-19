namespace SNM
{
    partial class facebookLoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(facebookLoginForm));
            this.wbFacebookLoginPopup = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // wbFacebookLoginPopup
            // 
            this.wbFacebookLoginPopup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbFacebookLoginPopup.Location = new System.Drawing.Point(0, 0);
            this.wbFacebookLoginPopup.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbFacebookLoginPopup.Name = "wbFacebookLoginPopup";
            this.wbFacebookLoginPopup.Size = new System.Drawing.Size(800, 600);
            this.wbFacebookLoginPopup.TabIndex = 0;
            this.wbFacebookLoginPopup.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.wbFacebookLoginPopup_Navigated);
            // 
            // facebookLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.wbFacebookLoginPopup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "facebookLoginForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SNM";
            this.Load += new System.EventHandler(this.facebookLoginForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbFacebookLoginPopup;
    }
}