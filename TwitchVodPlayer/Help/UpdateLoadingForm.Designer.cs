namespace TwitchVodPlayer.Forms {
    partial class UpdateLoadingForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateLoadingForm));
            this.updateLoadingLabel = new System.Windows.Forms.Label();
            this.logoBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // updateLoadingLabel
            // 
            this.updateLoadingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.updateLoadingLabel.AutoSize = true;
            this.updateLoadingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateLoadingLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.updateLoadingLabel.Location = new System.Drawing.Point(113, 45);
            this.updateLoadingLabel.Name = "updateLoadingLabel";
            this.updateLoadingLabel.Size = new System.Drawing.Size(143, 16);
            this.updateLoadingLabel.TabIndex = 0;
            this.updateLoadingLabel.Text = "Checking for updates...";
            this.updateLoadingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // logoBox
            // 
            this.logoBox.Image = global::TwitchVodPlayer.Properties.Resources.TvwcpLogoPng;
            this.logoBox.Location = new System.Drawing.Point(16, 16);
            this.logoBox.Name = "logoBox";
            this.logoBox.Size = new System.Drawing.Size(75, 74);
            this.logoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoBox.TabIndex = 1;
            this.logoBox.TabStop = false;
            // 
            // UpdateLoadingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(302, 106);
            this.Controls.Add(this.logoBox);
            this.Controls.Add(this.updateLoadingLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateLoadingForm";
            this.Text = "Twitch VOD Player";
            this.Load += new System.EventHandler(this.UpdateLoadingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label updateLoadingLabel;
        private System.Windows.Forms.PictureBox logoBox;
    }
}