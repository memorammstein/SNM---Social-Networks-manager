namespace SNM
{
    partial class frmFlashPlayerEmbeded
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFlashPlayerEmbeded));
            this.flashPlayerYoutube = new AxShockwaveFlashObjects.AxShockwaveFlash();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblViewOnYoutube = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.flashPlayerYoutube)).BeginInit();
            this.SuspendLayout();
            // 
            // flashPlayerYoutube
            // 
            this.flashPlayerYoutube.Enabled = true;
            this.flashPlayerYoutube.Location = new System.Drawing.Point(0, 30);
            this.flashPlayerYoutube.Name = "flashPlayerYoutube";
            this.flashPlayerYoutube.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("flashPlayerYoutube.OcxState")));
            this.flashPlayerYoutube.Size = new System.Drawing.Size(600, 360);
            this.flashPlayerYoutube.TabIndex = 0;
            // 
            // lblClose
            // 
            this.lblClose.AutoSize = true;
            this.lblClose.BackColor = System.Drawing.Color.Transparent;
            this.lblClose.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.ForeColor = System.Drawing.Color.White;
            this.lblClose.Location = new System.Drawing.Point(581, 6);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(17, 16);
            this.lblClose.TabIndex = 1;
            this.lblClose.Text = "X";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // lblViewOnYoutube
            // 
            this.lblViewOnYoutube.AutoSize = true;
            this.lblViewOnYoutube.BackColor = System.Drawing.Color.Transparent;
            this.lblViewOnYoutube.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblViewOnYoutube.ForeColor = System.Drawing.Color.White;
            this.lblViewOnYoutube.Location = new System.Drawing.Point(4, 6);
            this.lblViewOnYoutube.Name = "lblViewOnYoutube";
            this.lblViewOnYoutube.Size = new System.Drawing.Size(88, 15);
            this.lblViewOnYoutube.TabIndex = 2;
            this.lblViewOnYoutube.Text = "Ver en Youtube";
            this.lblViewOnYoutube.Click += new System.EventHandler(this.lblViewOnYoutube_Click);
            // 
            // frmFlashPlayerEmbeded
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(600, 390);
            this.Controls.Add(this.lblViewOnYoutube);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.flashPlayerYoutube);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmFlashPlayerEmbeded";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmFlashPlayerEmbeded";
            ((System.ComponentModel.ISupportInitialize)(this.flashPlayerYoutube)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxShockwaveFlashObjects.AxShockwaveFlash flashPlayerYoutube;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblViewOnYoutube;
    }
}