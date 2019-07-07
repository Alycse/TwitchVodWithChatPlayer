namespace TwitchVodPlayer.Forms {
    partial class ChatFileCreatorForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatFileCreatorForm));
            this.setOutputPathButton = new System.Windows.Forms.Button();
            this.outputPathTextBox = new System.Windows.Forms.TextBox();
            this.colonLabel4 = new System.Windows.Forms.Label();
            this.colonLabel3 = new System.Windows.Forms.Label();
            this.colonLabel2 = new System.Windows.Forms.Label();
            this.colonLabel1 = new System.Windows.Forms.Label();
            this.dashLabel = new System.Windows.Forms.Label();
            this.outputPathFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openChatLogFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.outputPathLabel = new System.Windows.Forms.Label();
            this.infoTextBox = new System.Windows.Forms.RichTextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.vodIdTextBox = new System.Windows.Forms.TextBox();
            this.vodIdLabel = new System.Windows.Forms.Label();
            this.useVodIdCheckBox = new System.Windows.Forms.CheckBox();
            this.createChatFileButton = new System.Windows.Forms.Button();
            this.openChatLogFileButton = new System.Windows.Forms.Button();
            this.chatLogFilePathTextBox = new System.Windows.Forms.TextBox();
            this.chatLogFileLabel = new System.Windows.Forms.Label();
            this.openVideoFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.resetTimeButton = new System.Windows.Forms.Button();
            this.endTimeLabel = new System.Windows.Forms.Label();
            this.beginTimeLabel = new System.Windows.Forms.Label();
            this.setTimeCheckBox = new System.Windows.Forms.CheckBox();
            this.endSecondsNumBox = new TwitchVodPlayer.Controls.NumericBox();
            this.endMinutesNumBox = new TwitchVodPlayer.Controls.NumericBox();
            this.endHoursNumBox = new TwitchVodPlayer.Controls.NumericBox();
            this.beginSecondsNumBox = new TwitchVodPlayer.Controls.NumericBox();
            this.beginMinutesNumBox = new TwitchVodPlayer.Controls.NumericBox();
            this.beginHoursNumBox = new TwitchVodPlayer.Controls.NumericBox();
            this.SuspendLayout();
            // 
            // setOutputPathButton
            // 
            this.setOutputPathButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setOutputPathButton.Location = new System.Drawing.Point(26, 54);
            this.setOutputPathButton.Name = "setOutputPathButton";
            this.setOutputPathButton.Size = new System.Drawing.Size(57, 23);
            this.setOutputPathButton.TabIndex = 115;
            this.setOutputPathButton.Text = "Set";
            this.setOutputPathButton.UseVisualStyleBackColor = true;
            this.setOutputPathButton.Click += new System.EventHandler(this.SetOutputPathButton_Click);
            // 
            // outputPathTextBox
            // 
            this.outputPathTextBox.BackColor = System.Drawing.Color.DimGray;
            this.outputPathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outputPathTextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputPathTextBox.ForeColor = System.Drawing.Color.Silver;
            this.outputPathTextBox.Location = new System.Drawing.Point(89, 54);
            this.outputPathTextBox.Name = "outputPathTextBox";
            this.outputPathTextBox.ReadOnly = true;
            this.outputPathTextBox.Size = new System.Drawing.Size(239, 22);
            this.outputPathTextBox.TabIndex = 114;
            // 
            // colonLabel4
            // 
            this.colonLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colonLabel4.ForeColor = System.Drawing.Color.Gainsboro;
            this.colonLabel4.Location = new System.Drawing.Point(220, 245);
            this.colonLabel4.Name = "colonLabel4";
            this.colonLabel4.Size = new System.Drawing.Size(12, 14);
            this.colonLabel4.TabIndex = 112;
            this.colonLabel4.Text = ":";
            // 
            // colonLabel3
            // 
            this.colonLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colonLabel3.ForeColor = System.Drawing.Color.Gainsboro;
            this.colonLabel3.Location = new System.Drawing.Point(181, 245);
            this.colonLabel3.Name = "colonLabel3";
            this.colonLabel3.Size = new System.Drawing.Size(12, 14);
            this.colonLabel3.TabIndex = 111;
            this.colonLabel3.Text = ":";
            // 
            // colonLabel2
            // 
            this.colonLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colonLabel2.ForeColor = System.Drawing.Color.Gainsboro;
            this.colonLabel2.Location = new System.Drawing.Point(91, 245);
            this.colonLabel2.Name = "colonLabel2";
            this.colonLabel2.Size = new System.Drawing.Size(12, 14);
            this.colonLabel2.TabIndex = 110;
            this.colonLabel2.Text = ":";
            // 
            // colonLabel1
            // 
            this.colonLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colonLabel1.ForeColor = System.Drawing.Color.Gainsboro;
            this.colonLabel1.Location = new System.Drawing.Point(52, 245);
            this.colonLabel1.Name = "colonLabel1";
            this.colonLabel1.Size = new System.Drawing.Size(12, 14);
            this.colonLabel1.TabIndex = 109;
            this.colonLabel1.Text = ":";
            // 
            // dashLabel
            // 
            this.dashLabel.AutoSize = true;
            this.dashLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.dashLabel.Location = new System.Drawing.Point(134, 239);
            this.dashLabel.Name = "dashLabel";
            this.dashLabel.Size = new System.Drawing.Size(17, 24);
            this.dashLabel.TabIndex = 101;
            this.dashLabel.Text = "-";
            // 
            // outputPathLabel
            // 
            this.outputPathLabel.AutoSize = true;
            this.outputPathLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputPathLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.outputPathLabel.Location = new System.Drawing.Point(22, 26);
            this.outputPathLabel.Name = "outputPathLabel";
            this.outputPathLabel.Size = new System.Drawing.Size(121, 19);
            this.outputPathLabel.TabIndex = 113;
            this.outputPathLabel.Text = "Output Directory:";
            // 
            // infoTextBox
            // 
            this.infoTextBox.Location = new System.Drawing.Point(26, 304);
            this.infoTextBox.Name = "infoTextBox";
            this.infoTextBox.Size = new System.Drawing.Size(221, 56);
            this.infoTextBox.TabIndex = 96;
            this.infoTextBox.Text = "";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(26, 369);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(302, 10);
            this.progressBar.TabIndex = 95;
            // 
            // vodIdTextBox
            // 
            this.vodIdTextBox.BackColor = System.Drawing.Color.DimGray;
            this.vodIdTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.vodIdTextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vodIdTextBox.ForeColor = System.Drawing.Color.Silver;
            this.vodIdTextBox.Location = new System.Drawing.Point(26, 136);
            this.vodIdTextBox.Name = "vodIdTextBox";
            this.vodIdTextBox.Size = new System.Drawing.Size(150, 22);
            this.vodIdTextBox.TabIndex = 94;
            // 
            // vodIdLabel
            // 
            this.vodIdLabel.AutoSize = true;
            this.vodIdLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vodIdLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.vodIdLabel.Location = new System.Drawing.Point(22, 109);
            this.vodIdLabel.Name = "vodIdLabel";
            this.vodIdLabel.Size = new System.Drawing.Size(61, 19);
            this.vodIdLabel.TabIndex = 93;
            this.vodIdLabel.Text = "VOD ID:";
            // 
            // useVodIdCheckBox
            // 
            this.useVodIdCheckBox.AutoSize = true;
            this.useVodIdCheckBox.Checked = true;
            this.useVodIdCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useVodIdCheckBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.useVodIdCheckBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.useVodIdCheckBox.Location = new System.Drawing.Point(26, 170);
            this.useVodIdCheckBox.Name = "useVodIdCheckBox";
            this.useVodIdCheckBox.Size = new System.Drawing.Size(250, 23);
            this.useVodIdCheckBox.TabIndex = 92;
            this.useVodIdCheckBox.Text = "Use VOD ID to download Chat File";
            this.useVodIdCheckBox.UseVisualStyleBackColor = true;
            this.useVodIdCheckBox.CheckedChanged += new System.EventHandler(this.useVodIdCheckBox_CheckedChanged);
            // 
            // createChatFileButton
            // 
            this.createChatFileButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createChatFileButton.Location = new System.Drawing.Point(253, 304);
            this.createChatFileButton.Name = "createChatFileButton";
            this.createChatFileButton.Size = new System.Drawing.Size(75, 56);
            this.createChatFileButton.TabIndex = 91;
            this.createChatFileButton.Text = "Create Chat File";
            this.createChatFileButton.UseVisualStyleBackColor = true;
            this.createChatFileButton.Click += new System.EventHandler(this.CreateChatFileButton_Click);
            // 
            // openChatLogFileButton
            // 
            this.openChatLogFileButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openChatLogFileButton.Location = new System.Drawing.Point(26, 135);
            this.openChatLogFileButton.Name = "openChatLogFileButton";
            this.openChatLogFileButton.Size = new System.Drawing.Size(57, 23);
            this.openChatLogFileButton.TabIndex = 88;
            this.openChatLogFileButton.Text = "Open";
            this.openChatLogFileButton.UseVisualStyleBackColor = true;
            this.openChatLogFileButton.Click += new System.EventHandler(this.OpenChatLogFileButton_Click);
            // 
            // chatLogFilePathTextBox
            // 
            this.chatLogFilePathTextBox.BackColor = System.Drawing.Color.DimGray;
            this.chatLogFilePathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chatLogFilePathTextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatLogFilePathTextBox.ForeColor = System.Drawing.Color.Silver;
            this.chatLogFilePathTextBox.Location = new System.Drawing.Point(89, 136);
            this.chatLogFilePathTextBox.Name = "chatLogFilePathTextBox";
            this.chatLogFilePathTextBox.ReadOnly = true;
            this.chatLogFilePathTextBox.Size = new System.Drawing.Size(239, 22);
            this.chatLogFilePathTextBox.TabIndex = 87;
            // 
            // chatLogFileLabel
            // 
            this.chatLogFileLabel.AutoSize = true;
            this.chatLogFileLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatLogFileLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.chatLogFileLabel.Location = new System.Drawing.Point(22, 109);
            this.chatLogFileLabel.Name = "chatLogFileLabel";
            this.chatLogFileLabel.Size = new System.Drawing.Size(142, 19);
            this.chatLogFileLabel.TabIndex = 86;
            this.chatLogFileLabel.Text = "Chat Log File (.json):";
            // 
            // resetTimeButton
            // 
            this.resetTimeButton.Location = new System.Drawing.Point(268, 242);
            this.resetTimeButton.Name = "resetTimeButton";
            this.resetTimeButton.Size = new System.Drawing.Size(60, 22);
            this.resetTimeButton.TabIndex = 102;
            this.resetTimeButton.Text = "Reset";
            this.resetTimeButton.UseVisualStyleBackColor = true;
            this.resetTimeButton.Click += new System.EventHandler(this.ResetTimeButton_Click);
            // 
            // endTimeLabel
            // 
            this.endTimeLabel.AutoSize = true;
            this.endTimeLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.endTimeLabel.Location = new System.Drawing.Point(152, 226);
            this.endTimeLabel.Name = "endTimeLabel";
            this.endTimeLabel.Size = new System.Drawing.Size(82, 13);
            this.endTimeLabel.TabIndex = 100;
            this.endTimeLabel.Text = "End chat log at:";
            // 
            // beginTimeLabel
            // 
            this.beginTimeLabel.AutoSize = true;
            this.beginTimeLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.beginTimeLabel.Location = new System.Drawing.Point(23, 226);
            this.beginTimeLabel.Name = "beginTimeLabel";
            this.beginTimeLabel.Size = new System.Drawing.Size(90, 13);
            this.beginTimeLabel.TabIndex = 99;
            this.beginTimeLabel.Text = "Begin chat log at:";
            // 
            // setTimeCheckBox
            // 
            this.setTimeCheckBox.AutoSize = true;
            this.setTimeCheckBox.Checked = true;
            this.setTimeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.setTimeCheckBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setTimeCheckBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.setTimeCheckBox.Location = new System.Drawing.Point(26, 196);
            this.setTimeCheckBox.Name = "setTimeCheckBox";
            this.setTimeCheckBox.Size = new System.Drawing.Size(224, 23);
            this.setTimeCheckBox.TabIndex = 116;
            this.setTimeCheckBox.Text = "Set begin/end time of chat log";
            this.setTimeCheckBox.UseVisualStyleBackColor = true;
            this.setTimeCheckBox.CheckedChanged += new System.EventHandler(this.SetTimeCheckBox_CheckedChanged);
            // 
            // endSecondsNumBox
            // 
            this.endSecondsNumBox.Location = new System.Drawing.Point(233, 243);
            this.endSecondsNumBox.MaxLength = 3;
            this.endSecondsNumBox.Name = "endSecondsNumBox";
            this.endSecondsNumBox.NumericBoxType = TwitchVodPlayer.Controls.NumericBoxType.Seconds;
            this.endSecondsNumBox.Size = new System.Drawing.Size(24, 20);
            this.endSecondsNumBox.TabIndex = 108;
            // 
            // endMinutesNumBox
            // 
            this.endMinutesNumBox.Location = new System.Drawing.Point(194, 243);
            this.endMinutesNumBox.MaxLength = 3;
            this.endMinutesNumBox.Name = "endMinutesNumBox";
            this.endMinutesNumBox.NumericBoxType = TwitchVodPlayer.Controls.NumericBoxType.Minutes;
            this.endMinutesNumBox.Size = new System.Drawing.Size(24, 20);
            this.endMinutesNumBox.TabIndex = 107;
            // 
            // endHoursNumBox
            // 
            this.endHoursNumBox.Location = new System.Drawing.Point(155, 243);
            this.endHoursNumBox.MaxLength = 3;
            this.endHoursNumBox.Name = "endHoursNumBox";
            this.endHoursNumBox.NumericBoxType = TwitchVodPlayer.Controls.NumericBoxType.Hours;
            this.endHoursNumBox.Size = new System.Drawing.Size(24, 20);
            this.endHoursNumBox.TabIndex = 106;
            // 
            // beginSecondsNumBox
            // 
            this.beginSecondsNumBox.Location = new System.Drawing.Point(104, 243);
            this.beginSecondsNumBox.MaxLength = 3;
            this.beginSecondsNumBox.Name = "beginSecondsNumBox";
            this.beginSecondsNumBox.NumericBoxType = TwitchVodPlayer.Controls.NumericBoxType.Seconds;
            this.beginSecondsNumBox.Size = new System.Drawing.Size(24, 20);
            this.beginSecondsNumBox.TabIndex = 105;
            // 
            // beginMinutesNumBox
            // 
            this.beginMinutesNumBox.Location = new System.Drawing.Point(65, 243);
            this.beginMinutesNumBox.MaxLength = 3;
            this.beginMinutesNumBox.Name = "beginMinutesNumBox";
            this.beginMinutesNumBox.NumericBoxType = TwitchVodPlayer.Controls.NumericBoxType.Minutes;
            this.beginMinutesNumBox.Size = new System.Drawing.Size(24, 20);
            this.beginMinutesNumBox.TabIndex = 104;
            // 
            // beginHoursNumBox
            // 
            this.beginHoursNumBox.Location = new System.Drawing.Point(26, 243);
            this.beginHoursNumBox.MaxLength = 3;
            this.beginHoursNumBox.Name = "beginHoursNumBox";
            this.beginHoursNumBox.NumericBoxType = TwitchVodPlayer.Controls.NumericBoxType.Hours;
            this.beginHoursNumBox.Size = new System.Drawing.Size(24, 20);
            this.beginHoursNumBox.TabIndex = 103;
            // 
            // ChatFileCreatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(360, 408);
            this.Controls.Add(this.setTimeCheckBox);
            this.Controls.Add(this.setOutputPathButton);
            this.Controls.Add(this.outputPathTextBox);
            this.Controls.Add(this.colonLabel4);
            this.Controls.Add(this.colonLabel3);
            this.Controls.Add(this.colonLabel2);
            this.Controls.Add(this.colonLabel1);
            this.Controls.Add(this.endSecondsNumBox);
            this.Controls.Add(this.endMinutesNumBox);
            this.Controls.Add(this.endHoursNumBox);
            this.Controls.Add(this.beginSecondsNumBox);
            this.Controls.Add(this.beginMinutesNumBox);
            this.Controls.Add(this.beginHoursNumBox);
            this.Controls.Add(this.resetTimeButton);
            this.Controls.Add(this.dashLabel);
            this.Controls.Add(this.endTimeLabel);
            this.Controls.Add(this.beginTimeLabel);
            this.Controls.Add(this.outputPathLabel);
            this.Controls.Add(this.infoTextBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.vodIdTextBox);
            this.Controls.Add(this.vodIdLabel);
            this.Controls.Add(this.useVodIdCheckBox);
            this.Controls.Add(this.createChatFileButton);
            this.Controls.Add(this.chatLogFileLabel);
            this.Controls.Add(this.openChatLogFileButton);
            this.Controls.Add(this.chatLogFilePathTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChatFileCreatorForm";
            this.Text = "Download / Create Chat File";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatFileCreatorForm_FormClosing);
            this.Load += new System.EventHandler(this.ChatFileCreatorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button setOutputPathButton;
        private System.Windows.Forms.TextBox outputPathTextBox;
        private System.Windows.Forms.Label colonLabel4;
        private System.Windows.Forms.Label colonLabel3;
        private System.Windows.Forms.Label colonLabel2;
        private System.Windows.Forms.Label colonLabel1;
        private System.Windows.Forms.Label dashLabel;
        private System.Windows.Forms.FolderBrowserDialog outputPathFolderDialog;
        private System.Windows.Forms.OpenFileDialog openChatLogFileDialog;
        private System.Windows.Forms.Label outputPathLabel;
        private System.Windows.Forms.RichTextBox infoTextBox;
        public System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox vodIdTextBox;
        private System.Windows.Forms.Label vodIdLabel;
        private System.Windows.Forms.CheckBox useVodIdCheckBox;
        public System.Windows.Forms.Button createChatFileButton;
        private System.Windows.Forms.Button openChatLogFileButton;
        private System.Windows.Forms.TextBox chatLogFilePathTextBox;
        private System.Windows.Forms.Label chatLogFileLabel;
        private System.Windows.Forms.OpenFileDialog openVideoFileDialog;
        private Controls.NumericBox endMinutesNumBox;
        private Controls.NumericBox endHoursNumBox;
        private Controls.NumericBox endSecondsNumBox;
        private Controls.NumericBox beginSecondsNumBox;
        private Controls.NumericBox beginMinutesNumBox;
        private Controls.NumericBox beginHoursNumBox;
        private System.Windows.Forms.Button resetTimeButton;
        private System.Windows.Forms.Label endTimeLabel;
        private System.Windows.Forms.Label beginTimeLabel;
        private System.Windows.Forms.CheckBox setTimeCheckBox;
    }
}