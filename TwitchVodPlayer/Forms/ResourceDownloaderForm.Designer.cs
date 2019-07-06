namespace TwitchVodPlayer.Forms {
    partial class ResourceDownloaderForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResourceDownloaderForm));
            this.clientIdRequiredLabel4 = new System.Windows.Forms.Label();
            this.clientIdRequiredLabel3 = new System.Windows.Forms.Label();
            this.clientIdRequiredLabel2 = new System.Windows.Forms.Label();
            this.forceDownloadCheckBox = new System.Windows.Forms.CheckBox();
            this.downloadBadgesCheckBox = new System.Windows.Forms.CheckBox();
            this.downloadFfzEmoticonsCheckBox = new System.Windows.Forms.CheckBox();
            this.downloadBttvEmoticonsCheckBox = new System.Windows.Forms.CheckBox();
            this.channelNameTextBox = new System.Windows.Forms.TextBox();
            this.channelNameLabel = new System.Windows.Forms.Label();
            this.infoTextBox = new System.Windows.Forms.RichTextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.downloadResourcesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clientIdRequiredLabel4
            // 
            this.clientIdRequiredLabel4.AutoSize = true;
            this.clientIdRequiredLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientIdRequiredLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.clientIdRequiredLabel4.Location = new System.Drawing.Point(438, 96);
            this.clientIdRequiredLabel4.Name = "clientIdRequiredLabel4";
            this.clientIdRequiredLabel4.Size = new System.Drawing.Size(87, 12);
            this.clientIdRequiredLabel4.TabIndex = 79;
            this.clientIdRequiredLabel4.Text = "(Client-ID Required)";
            // 
            // clientIdRequiredLabel3
            // 
            this.clientIdRequiredLabel3.AutoSize = true;
            this.clientIdRequiredLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientIdRequiredLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.clientIdRequiredLabel3.Location = new System.Drawing.Point(438, 154);
            this.clientIdRequiredLabel3.Name = "clientIdRequiredLabel3";
            this.clientIdRequiredLabel3.Size = new System.Drawing.Size(87, 12);
            this.clientIdRequiredLabel3.TabIndex = 78;
            this.clientIdRequiredLabel3.Text = "(Client-ID Required)";
            // 
            // clientIdRequiredLabel2
            // 
            this.clientIdRequiredLabel2.AutoSize = true;
            this.clientIdRequiredLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientIdRequiredLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.clientIdRequiredLabel2.Location = new System.Drawing.Point(438, 125);
            this.clientIdRequiredLabel2.Name = "clientIdRequiredLabel2";
            this.clientIdRequiredLabel2.Size = new System.Drawing.Size(87, 12);
            this.clientIdRequiredLabel2.TabIndex = 77;
            this.clientIdRequiredLabel2.Text = "(Client-ID Required)";
            // 
            // forceDownloadCheckBox
            // 
            this.forceDownloadCheckBox.AutoSize = true;
            this.forceDownloadCheckBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forceDownloadCheckBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.forceDownloadCheckBox.Location = new System.Drawing.Point(24, 177);
            this.forceDownloadCheckBox.Name = "forceDownloadCheckBox";
            this.forceDownloadCheckBox.Size = new System.Drawing.Size(328, 23);
            this.forceDownloadCheckBox.TabIndex = 76;
            this.forceDownloadCheckBox.Text = "Force download files even if they already exist";
            this.forceDownloadCheckBox.UseVisualStyleBackColor = true;
            // 
            // downloadBadgesCheckBox
            // 
            this.downloadBadgesCheckBox.AutoSize = true;
            this.downloadBadgesCheckBox.Checked = true;
            this.downloadBadgesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.downloadBadgesCheckBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadBadgesCheckBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.downloadBadgesCheckBox.Location = new System.Drawing.Point(24, 90);
            this.downloadBadgesCheckBox.Name = "downloadBadgesCheckBox";
            this.downloadBadgesCheckBox.Size = new System.Drawing.Size(250, 23);
            this.downloadBadgesCheckBox.TabIndex = 75;
            this.downloadBadgesCheckBox.Text = "Download Badges for this channel";
            this.downloadBadgesCheckBox.UseVisualStyleBackColor = true;
            // 
            // downloadFfzEmoticonsCheckBox
            // 
            this.downloadFfzEmoticonsCheckBox.AutoSize = true;
            this.downloadFfzEmoticonsCheckBox.Checked = true;
            this.downloadFfzEmoticonsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.downloadFfzEmoticonsCheckBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadFfzEmoticonsCheckBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.downloadFfzEmoticonsCheckBox.Location = new System.Drawing.Point(24, 148);
            this.downloadFfzEmoticonsCheckBox.Name = "downloadFfzEmoticonsCheckBox";
            this.downloadFfzEmoticonsCheckBox.Size = new System.Drawing.Size(295, 23);
            this.downloadFfzEmoticonsCheckBox.TabIndex = 74;
            this.downloadFfzEmoticonsCheckBox.Text = "Download FFZ Emoticons for this channel";
            this.downloadFfzEmoticonsCheckBox.UseVisualStyleBackColor = true;
            // 
            // downloadBttvEmoticonsCheckBox
            // 
            this.downloadBttvEmoticonsCheckBox.AutoSize = true;
            this.downloadBttvEmoticonsCheckBox.Checked = true;
            this.downloadBttvEmoticonsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.downloadBttvEmoticonsCheckBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadBttvEmoticonsCheckBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.downloadBttvEmoticonsCheckBox.Location = new System.Drawing.Point(24, 119);
            this.downloadBttvEmoticonsCheckBox.Name = "downloadBttvEmoticonsCheckBox";
            this.downloadBttvEmoticonsCheckBox.Size = new System.Drawing.Size(307, 23);
            this.downloadBttvEmoticonsCheckBox.TabIndex = 73;
            this.downloadBttvEmoticonsCheckBox.Text = "Download BTTV Emoticons for this channel";
            this.downloadBttvEmoticonsCheckBox.UseVisualStyleBackColor = true;
            // 
            // channelNameTextBox
            // 
            this.channelNameTextBox.BackColor = System.Drawing.Color.DimGray;
            this.channelNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.channelNameTextBox.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channelNameTextBox.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.channelNameTextBox.Location = new System.Drawing.Point(131, 32);
            this.channelNameTextBox.Name = "channelNameTextBox";
            this.channelNameTextBox.Size = new System.Drawing.Size(197, 23);
            this.channelNameTextBox.TabIndex = 82;
            // 
            // channelNameLabel
            // 
            this.channelNameLabel.AutoSize = true;
            this.channelNameLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channelNameLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.channelNameLabel.Location = new System.Drawing.Point(19, 32);
            this.channelNameLabel.Name = "channelNameLabel";
            this.channelNameLabel.Size = new System.Drawing.Size(108, 19);
            this.channelNameLabel.TabIndex = 81;
            this.channelNameLabel.Text = "Channel Name:";
            // 
            // infoTextBox
            // 
            this.infoTextBox.Location = new System.Drawing.Point(23, 236);
            this.infoTextBox.Name = "infoTextBox";
            this.infoTextBox.Size = new System.Drawing.Size(378, 56);
            this.infoTextBox.TabIndex = 85;
            this.infoTextBox.Text = "";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(23, 301);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(508, 10);
            this.progressBar.TabIndex = 84;
            // 
            // downloadResourcesButton
            // 
            this.downloadResourcesButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadResourcesButton.Location = new System.Drawing.Point(407, 236);
            this.downloadResourcesButton.Name = "downloadResourcesButton";
            this.downloadResourcesButton.Size = new System.Drawing.Size(120, 56);
            this.downloadResourcesButton.TabIndex = 83;
            this.downloadResourcesButton.Text = "Download Resources";
            this.downloadResourcesButton.UseVisualStyleBackColor = true;
            this.downloadResourcesButton.Click += new System.EventHandler(this.DownloadResourcesButton_Click);
            // 
            // ResourceDownloaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(543, 333);
            this.Controls.Add(this.infoTextBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.downloadResourcesButton);
            this.Controls.Add(this.channelNameTextBox);
            this.Controls.Add(this.channelNameLabel);
            this.Controls.Add(this.clientIdRequiredLabel4);
            this.Controls.Add(this.clientIdRequiredLabel3);
            this.Controls.Add(this.clientIdRequiredLabel2);
            this.Controls.Add(this.forceDownloadCheckBox);
            this.Controls.Add(this.downloadBadgesCheckBox);
            this.Controls.Add(this.downloadFfzEmoticonsCheckBox);
            this.Controls.Add(this.downloadBttvEmoticonsCheckBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ResourceDownloaderForm";
            this.Text = "Download Resources";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ResourceDownloaderForm_FormClosing);
            this.Load += new System.EventHandler(this.ResourceDownloaderForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label clientIdRequiredLabel4;
        private System.Windows.Forms.Label clientIdRequiredLabel3;
        private System.Windows.Forms.Label clientIdRequiredLabel2;
        private System.Windows.Forms.CheckBox forceDownloadCheckBox;
        private System.Windows.Forms.CheckBox downloadBadgesCheckBox;
        private System.Windows.Forms.CheckBox downloadFfzEmoticonsCheckBox;
        private System.Windows.Forms.CheckBox downloadBttvEmoticonsCheckBox;
        private System.Windows.Forms.TextBox channelNameTextBox;
        private System.Windows.Forms.Label channelNameLabel;
        private System.Windows.Forms.RichTextBox infoTextBox;
        public System.Windows.Forms.ProgressBar progressBar;
        public System.Windows.Forms.Button downloadResourcesButton;
    }
}