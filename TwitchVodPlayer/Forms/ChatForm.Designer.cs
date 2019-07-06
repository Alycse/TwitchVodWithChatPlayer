namespace TwitchVodPlayer.Forms {
    partial class ChatForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatForm));
            this.chatBoxWebControl = new Gecko.GeckoWebBrowser();
            this.draggerBox = new System.Windows.Forms.PictureBox();
            this.transparentPanel1 = new TwitchVodPlayer.Controls.TransparentPanel();
            ((System.ComponentModel.ISupportInitialize)(this.draggerBox)).BeginInit();
            this.SuspendLayout();
            // 
            // chatBoxWebControl
            // 
            this.chatBoxWebControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatBoxWebControl.FrameEventsPropagateToMainWindow = false;
            this.chatBoxWebControl.Location = new System.Drawing.Point(0, 0);
            this.chatBoxWebControl.Name = "chatBoxWebControl";
            this.chatBoxWebControl.Size = new System.Drawing.Size(434, 470);
            this.chatBoxWebControl.TabIndex = 2;
            this.chatBoxWebControl.UseHttpActivityObserver = false;
            // 
            // draggerBox
            // 
            this.draggerBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.draggerBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.draggerBox.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            this.draggerBox.Image = global::TwitchVodPlayer.Properties.Resources.Dragger;
            this.draggerBox.Location = new System.Drawing.Point(384, 0);
            this.draggerBox.Name = "draggerBox";
            this.draggerBox.Size = new System.Drawing.Size(50, 49);
            this.draggerBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.draggerBox.TabIndex = 1;
            this.draggerBox.TabStop = false;
            this.draggerBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.draggerBox_MouseDown);
            // 
            // transparentPanel1
            // 
            this.transparentPanel1.BackColor = System.Drawing.Color.Transparent;
            this.transparentPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transparentPanel1.Location = new System.Drawing.Point(0, 0);
            this.transparentPanel1.Name = "transparentPanel1";
            this.transparentPanel1.Opacity = 100;
            this.transparentPanel1.Size = new System.Drawing.Size(434, 470);
            this.transparentPanel1.TabIndex = 3;
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(434, 470);
            this.Controls.Add(this.draggerBox);
            this.Controls.Add(this.transparentPanel1);
            this.Controls.Add(this.chatBoxWebControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChatForm";
            this.Text = "Chat";
            this.Load += new System.EventHandler(this.ChatForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.draggerBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox draggerBox;
        private Gecko.GeckoWebBrowser chatBoxWebControl;
        private Controls.TransparentPanel transparentPanel1;
    }
}