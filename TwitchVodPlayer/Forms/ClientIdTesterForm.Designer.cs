namespace TwitchVodPlayer.Forms {
    partial class ClientIdTesterForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientIdTesterForm));
            this.clientIdTextBox = new System.Windows.Forms.TextBox();
            this.clientIdLabel = new System.Windows.Forms.Label();
            this.infoTextBox = new System.Windows.Forms.RichTextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.testClientIdButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clientIdTextBox
            // 
            this.clientIdTextBox.BackColor = System.Drawing.Color.DimGray;
            this.clientIdTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clientIdTextBox.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientIdTextBox.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.clientIdTextBox.Location = new System.Drawing.Point(175, 21);
            this.clientIdTextBox.Name = "clientIdTextBox";
            this.clientIdTextBox.Size = new System.Drawing.Size(355, 23);
            this.clientIdTextBox.TabIndex = 84;
            // 
            // clientIdLabel
            // 
            this.clientIdLabel.AutoSize = true;
            this.clientIdLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientIdLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.clientIdLabel.Location = new System.Drawing.Point(22, 21);
            this.clientIdLabel.Name = "clientIdLabel";
            this.clientIdLabel.Size = new System.Drawing.Size(144, 19);
            this.clientIdLabel.TabIndex = 83;
            this.clientIdLabel.Text = "Twitch Dev Client ID:";
            // 
            // infoTextBox
            // 
            this.infoTextBox.Location = new System.Drawing.Point(26, 62);
            this.infoTextBox.Name = "infoTextBox";
            this.infoTextBox.Size = new System.Drawing.Size(370, 56);
            this.infoTextBox.TabIndex = 88;
            this.infoTextBox.Text = "";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(26, 133);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(508, 10);
            this.progressBar.TabIndex = 87;
            // 
            // testClientIdButton
            // 
            this.testClientIdButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testClientIdButton.Location = new System.Drawing.Point(410, 62);
            this.testClientIdButton.Name = "testClientIdButton";
            this.testClientIdButton.Size = new System.Drawing.Size(120, 56);
            this.testClientIdButton.TabIndex = 86;
            this.testClientIdButton.Text = "Test Client ID";
            this.testClientIdButton.UseVisualStyleBackColor = true;
            this.testClientIdButton.Click += new System.EventHandler(this.TestClientIdButton_Click);
            // 
            // ClientIdTesterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(555, 170);
            this.Controls.Add(this.infoTextBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.testClientIdButton);
            this.Controls.Add(this.clientIdTextBox);
            this.Controls.Add(this.clientIdLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClientIdTesterForm";
            this.Text = "Set-up Client ID";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientIdForm_FormClosing);
            this.Load += new System.EventHandler(this.ClientIdForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox clientIdTextBox;
        private System.Windows.Forms.Label clientIdLabel;
        private System.Windows.Forms.RichTextBox infoTextBox;
        public System.Windows.Forms.ProgressBar progressBar;
        public System.Windows.Forms.Button testClientIdButton;
    }
}