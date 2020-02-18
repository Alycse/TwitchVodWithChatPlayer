using System.IO;

namespace TwitchVodPlayer.Forms {
    partial class MainForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.vODSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openVodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupClientIdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadResourcesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadResourcesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.videoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.fullscreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadCreateChatFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chatToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.increaseChatOffsetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decreaseChatOffsetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chatToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.hideChatBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideChatBoxWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.stickyChatBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transparentChatBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chatToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.recordChatExperimentalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordChat2ExperimentalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordChat3ExperimentalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordChat4ExperimentalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openVodFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.chatOffsetLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.videoPlayerPanel = new System.Windows.Forms.Panel();
            this.videoVolumeBar = new TwitchVodPlayer.Controls.ColoredProgressBar();
            this.videoVolumeIconBox = new System.Windows.Forms.PictureBox();
            this.videoFullscreenButton = new TwitchVodPlayer.Controls.UnfocusableButton();
            this.videoSeekBar = new TwitchVodPlayer.Controls.ColoredProgressBar();
            this.videoPlaybackButton = new TwitchVodPlayer.Controls.UnfocusableButton();
            this.loadingVideoLabel = new System.Windows.Forms.Label();
            this.transparentPanel1 = new TwitchVodPlayer.Controls.TransparentPanel();
            this.transparentPanelCover = new TwitchVodPlayer.Controls.TransparentPanel();
            this.menuStrip.SuspendLayout();
            this.videoPlayerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videoVolumeIconBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vODSetToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.downloadResourcesToolStripMenuItem,
            this.videoToolStripMenuItem,
            this.chatToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(779, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // vODSetToolStripMenuItem
            // 
            this.vODSetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openVodToolStripMenuItem});
            this.vODSetToolStripMenuItem.Name = "vODSetToolStripMenuItem";
            this.vODSetToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.vODSetToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.vODSetToolStripMenuItem.Text = "Media";
            // 
            // openVodToolStripMenuItem
            // 
            this.openVodToolStripMenuItem.Name = "openVodToolStripMenuItem";
            this.openVodToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+N";
            this.openVodToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.openVodToolStripMenuItem.Text = "Open VOD";
            this.openVodToolStripMenuItem.Click += new System.EventHandler(this.OpenVodToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupClientIdToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // setupClientIdToolStripMenuItem
            // 
            this.setupClientIdToolStripMenuItem.Name = "setupClientIdToolStripMenuItem";
            this.setupClientIdToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.setupClientIdToolStripMenuItem.Text = "Set-up Client ID";
            this.setupClientIdToolStripMenuItem.Click += new System.EventHandler(this.SetupClientIdToolStripMenuItem_Click);
            // 
            // downloadResourcesToolStripMenuItem
            // 
            this.downloadResourcesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadResourcesToolStripMenuItem1});
            this.downloadResourcesToolStripMenuItem.Name = "downloadResourcesToolStripMenuItem";
            this.downloadResourcesToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.downloadResourcesToolStripMenuItem.Text = "Resources";
            // 
            // downloadResourcesToolStripMenuItem1
            // 
            this.downloadResourcesToolStripMenuItem1.Name = "downloadResourcesToolStripMenuItem1";
            this.downloadResourcesToolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
            this.downloadResourcesToolStripMenuItem1.Text = "Download Resources";
            this.downloadResourcesToolStripMenuItem1.Click += new System.EventHandler(this.DownloadResourcesToolStripMenuItem1_Click);
            // 
            // videoToolStripMenuItem
            // 
            this.videoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.forwardToolStripMenuItem,
            this.backwardToolStripMenuItem,
            this.videoToolStripSeparator1,
            this.fullscreenToolStripMenuItem});
            this.videoToolStripMenuItem.Name = "videoToolStripMenuItem";
            this.videoToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.videoToolStripMenuItem.Text = "Video";
            // 
            // forwardToolStripMenuItem
            // 
            this.forwardToolStripMenuItem.Name = "forwardToolStripMenuItem";
            this.forwardToolStripMenuItem.ShortcutKeyDisplayString = "J";
            this.forwardToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.forwardToolStripMenuItem.Text = "Forward";
            this.forwardToolStripMenuItem.Click += new System.EventHandler(this.ForwardToolStripMenuItem_Click);
            // 
            // backwardToolStripMenuItem
            // 
            this.backwardToolStripMenuItem.Name = "backwardToolStripMenuItem";
            this.backwardToolStripMenuItem.ShortcutKeyDisplayString = "L";
            this.backwardToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.backwardToolStripMenuItem.Text = "Backward";
            this.backwardToolStripMenuItem.Click += new System.EventHandler(this.BackwardToolStripMenuItem_Click);
            // 
            // videoToolStripSeparator1
            // 
            this.videoToolStripSeparator1.Name = "videoToolStripSeparator1";
            this.videoToolStripSeparator1.Size = new System.Drawing.Size(164, 6);
            // 
            // fullscreenToolStripMenuItem
            // 
            this.fullscreenToolStripMenuItem.Name = "fullscreenToolStripMenuItem";
            this.fullscreenToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+F";
            this.fullscreenToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.fullscreenToolStripMenuItem.Text = "Fullscreen";
            this.fullscreenToolStripMenuItem.Click += new System.EventHandler(this.FullscreenToolStripMenuItem_Click);
            // 
            // chatToolStripMenuItem
            // 
            this.chatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadCreateChatFileToolStripMenuItem,
            this.chatToolStripSeparator1,
            this.increaseChatOffsetToolStripMenuItem,
            this.decreaseChatOffsetToolStripMenuItem,
            this.chatToolStripSeparator2,
            this.hideChatBoxToolStripMenuItem,
            this.hideChatBoxWindowToolStripMenuItem,
            this.toolStripSeparator1,
            this.stickyChatBoxToolStripMenuItem,
            this.transparentChatBoxToolStripMenuItem,
            this.chatToolStripSeparator3,
            this.recordChatExperimentalToolStripMenuItem,
            this.recordChat2ExperimentalToolStripMenuItem,
            this.recordChat3ExperimentalToolStripMenuItem,
            this.recordChat4ExperimentalToolStripMenuItem});
            this.chatToolStripMenuItem.Name = "chatToolStripMenuItem";
            this.chatToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.chatToolStripMenuItem.Text = "Chat";
            // 
            // downloadCreateChatFileToolStripMenuItem
            // 
            this.downloadCreateChatFileToolStripMenuItem.Name = "downloadCreateChatFileToolStripMenuItem";
            this.downloadCreateChatFileToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.downloadCreateChatFileToolStripMenuItem.Text = "Download / Create Chat File";
            this.downloadCreateChatFileToolStripMenuItem.Click += new System.EventHandler(this.DownloadCreateChatFileToolStripMenuItem_Click);
            // 
            // chatToolStripSeparator1
            // 
            this.chatToolStripSeparator1.Name = "chatToolStripSeparator1";
            this.chatToolStripSeparator1.Size = new System.Drawing.Size(261, 6);
            // 
            // increaseChatOffsetToolStripMenuItem
            // 
            this.increaseChatOffsetToolStripMenuItem.Name = "increaseChatOffsetToolStripMenuItem";
            this.increaseChatOffsetToolStripMenuItem.ShortcutKeyDisplayString = "P";
            this.increaseChatOffsetToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.increaseChatOffsetToolStripMenuItem.Text = "Increase Chat Offset";
            this.increaseChatOffsetToolStripMenuItem.Click += new System.EventHandler(this.IncreaseChatOffsetToolStripMenuItem_Click);
            // 
            // decreaseChatOffsetToolStripMenuItem
            // 
            this.decreaseChatOffsetToolStripMenuItem.Name = "decreaseChatOffsetToolStripMenuItem";
            this.decreaseChatOffsetToolStripMenuItem.ShortcutKeyDisplayString = "O";
            this.decreaseChatOffsetToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.decreaseChatOffsetToolStripMenuItem.Text = "Decrease Chat Offset";
            this.decreaseChatOffsetToolStripMenuItem.Click += new System.EventHandler(this.DecreaseChatOffsetToolStripMenuItem_Click);
            // 
            // chatToolStripSeparator2
            // 
            this.chatToolStripSeparator2.Name = "chatToolStripSeparator2";
            this.chatToolStripSeparator2.Size = new System.Drawing.Size(261, 6);
            // 
            // hideChatBoxToolStripMenuItem
            // 
            this.hideChatBoxToolStripMenuItem.Name = "hideChatBoxToolStripMenuItem";
            this.hideChatBoxToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+H";
            this.hideChatBoxToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.hideChatBoxToolStripMenuItem.Text = "Hide Chat Box";
            this.hideChatBoxToolStripMenuItem.Click += new System.EventHandler(this.HideChatBoxToolStripMenuItem_Click);
            // 
            // hideChatBoxWindowToolStripMenuItem
            // 
            this.hideChatBoxWindowToolStripMenuItem.Name = "hideChatBoxWindowToolStripMenuItem";
            this.hideChatBoxWindowToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+W";
            this.hideChatBoxWindowToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.hideChatBoxWindowToolStripMenuItem.Text = "Hide Chat Box Window";
            this.hideChatBoxWindowToolStripMenuItem.Click += new System.EventHandler(this.HideChatBoxWindowToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(261, 6);
            // 
            // stickyChatBoxToolStripMenuItem
            // 
            this.stickyChatBoxToolStripMenuItem.Name = "stickyChatBoxToolStripMenuItem";
            this.stickyChatBoxToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+S";
            this.stickyChatBoxToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.stickyChatBoxToolStripMenuItem.Text = "Enable Sticky Chat Box";
            this.stickyChatBoxToolStripMenuItem.Click += new System.EventHandler(this.StickChatBoxToolStripMenuItem_Click);
            // 
            // transparentChatBoxToolStripMenuItem
            // 
            this.transparentChatBoxToolStripMenuItem.Checked = true;
            this.transparentChatBoxToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.transparentChatBoxToolStripMenuItem.Name = "transparentChatBoxToolStripMenuItem";
            this.transparentChatBoxToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+T";
            this.transparentChatBoxToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.transparentChatBoxToolStripMenuItem.Text = "Enable Transparent Chat Box";
            this.transparentChatBoxToolStripMenuItem.Click += new System.EventHandler(this.TransparentChatBoxToolStripMenuItem_Click);
            // 
            // chatToolStripSeparator3
            // 
            this.chatToolStripSeparator3.Name = "chatToolStripSeparator3";
            this.chatToolStripSeparator3.Size = new System.Drawing.Size(261, 6);
            // 
            // recordChatExperimentalToolStripMenuItem
            // 
            this.recordChatExperimentalToolStripMenuItem.Name = "recordChatExperimentalToolStripMenuItem";
            this.recordChatExperimentalToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.recordChatExperimentalToolStripMenuItem.Text = "Record Chat (Experimental)";
            this.recordChatExperimentalToolStripMenuItem.Click += new System.EventHandler(this.recordChatExperimentalToolStripMenuItem_Click);
            // 
            // recordChat2ExperimentalToolStripMenuItem
            // 
            this.recordChat2ExperimentalToolStripMenuItem.Name = "recordChat2ExperimentalToolStripMenuItem";
            this.recordChat2ExperimentalToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.recordChat2ExperimentalToolStripMenuItem.Text = "Record Chat 2 (Experimental)";
            this.recordChat2ExperimentalToolStripMenuItem.Click += new System.EventHandler(this.recordChat2ExperimentalToolStripMenuItem_Click);
            // 
            // recordChat3ExperimentalToolStripMenuItem
            // 
            this.recordChat3ExperimentalToolStripMenuItem.Name = "recordChat3ExperimentalToolStripMenuItem";
            this.recordChat3ExperimentalToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.recordChat3ExperimentalToolStripMenuItem.Text = "Record Chat 3 (Experimental)";
            this.recordChat3ExperimentalToolStripMenuItem.Click += new System.EventHandler(this.recordChat3ExperimentalToolStripMenuItem_Click);
            // 
            // recordChat4ExperimentalToolStripMenuItem
            // 
            this.recordChat4ExperimentalToolStripMenuItem.Name = "recordChat4ExperimentalToolStripMenuItem";
            this.recordChat4ExperimentalToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.recordChat4ExperimentalToolStripMenuItem.Text = "Record Chat 4 (Experimental)";
            this.recordChat4ExperimentalToolStripMenuItem.Click += new System.EventHandler(this.recordChat4ExperimentalToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualToolStripMenuItem,
            this.helpToolStripSeparator1,
            this.checkForUpdatesToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.manualToolStripMenuItem.Text = "Manual";
            this.manualToolStripMenuItem.Click += new System.EventHandler(this.ManualToolStripMenuItem_Click);
            // 
            // helpToolStripSeparator1
            // 
            this.helpToolStripSeparator1.Name = "helpToolStripSeparator1";
            this.helpToolStripSeparator1.Size = new System.Drawing.Size(170, 6);
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.checkForUpdatesToolStripMenuItem.Text = "Check For Updates";
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.CheckForUpdatesToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // chatOffsetLabel
            // 
            this.chatOffsetLabel.AutoSize = true;
            this.chatOffsetLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.chatOffsetLabel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatOffsetLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chatOffsetLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chatOffsetLabel.Location = new System.Drawing.Point(611, 24);
            this.chatOffsetLabel.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.chatOffsetLabel.Name = "chatOffsetLabel";
            this.chatOffsetLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chatOffsetLabel.Size = new System.Drawing.Size(168, 23);
            this.chatOffsetLabel.TabIndex = 0;
            this.chatOffsetLabel.Text = "Chat Offset: 1000ms";
            this.chatOffsetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timeLabel
            // 
            this.timeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.timeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(163)))), ((int)(((byte)(227)))));
            this.timeLabel.Location = new System.Drawing.Point(516, -1);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.timeLabel.Size = new System.Drawing.Size(124, 38);
            this.timeLabel.TabIndex = 4;
            this.timeLabel.Text = "00:00:00 / 00:00:00";
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // videoPlayerPanel
            // 
            this.videoPlayerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.videoPlayerPanel.Controls.Add(this.videoVolumeBar);
            this.videoPlayerPanel.Controls.Add(this.videoVolumeIconBox);
            this.videoPlayerPanel.Controls.Add(this.videoFullscreenButton);
            this.videoPlayerPanel.Controls.Add(this.videoSeekBar);
            this.videoPlayerPanel.Controls.Add(this.videoPlaybackButton);
            this.videoPlayerPanel.Controls.Add(this.timeLabel);
            this.videoPlayerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.videoPlayerPanel.Location = new System.Drawing.Point(0, 502);
            this.videoPlayerPanel.Name = "videoPlayerPanel";
            this.videoPlayerPanel.Size = new System.Drawing.Size(779, 36);
            this.videoPlayerPanel.TabIndex = 9;
            this.videoPlayerPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.VideoPlayerPanel_MouseMove);
            // 
            // videoVolumeBar
            // 
            this.videoVolumeBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.videoVolumeBar.BarColor = System.Drawing.Color.WhiteSmoke;
            this.videoVolumeBar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.videoVolumeBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.videoVolumeBar.FillStyle = TwitchVodPlayer.Controls.ColoredProgressBar.FillStyles.Solid;
            this.videoVolumeBar.Location = new System.Drawing.Point(715, 14);
            this.videoVolumeBar.Maximum = 100;
            this.videoVolumeBar.Minimum = 0;
            this.videoVolumeBar.Name = "videoVolumeBar";
            this.videoVolumeBar.Size = new System.Drawing.Size(53, 8);
            this.videoVolumeBar.Step = 10;
            this.videoVolumeBar.TabIndex = 13;
            this.videoVolumeBar.Value = 50;
            this.videoVolumeBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VideoVolumeBar_MouseDown);
            this.videoVolumeBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.VideoVolumeBar_MouseMove);
            this.videoVolumeBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.VideoVolumeBar_MouseUp);
            // 
            // videoVolumeIconBox
            // 
            this.videoVolumeIconBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.videoVolumeIconBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.videoVolumeIconBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.videoVolumeIconBox.Image = global::TwitchVodPlayer.Properties.Resources.Volume2;
            this.videoVolumeIconBox.Location = new System.Drawing.Point(688, 5);
            this.videoVolumeIconBox.Name = "videoVolumeIconBox";
            this.videoVolumeIconBox.Size = new System.Drawing.Size(25, 25);
            this.videoVolumeIconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.videoVolumeIconBox.TabIndex = 14;
            this.videoVolumeIconBox.TabStop = false;
            this.videoVolumeIconBox.Click += new System.EventHandler(this.VideoVolumeIconBox_Click);
            // 
            // videoFullscreenButton
            // 
            this.videoFullscreenButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.videoFullscreenButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.videoFullscreenButton.BackgroundImage = global::TwitchVodPlayer.Properties.Resources.FullscreenButton;
            this.videoFullscreenButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.videoFullscreenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.videoFullscreenButton.Location = new System.Drawing.Point(643, 5);
            this.videoFullscreenButton.Name = "videoFullscreenButton";
            this.videoFullscreenButton.Size = new System.Drawing.Size(27, 27);
            this.videoFullscreenButton.TabIndex = 8;
            this.videoFullscreenButton.UseVisualStyleBackColor = false;
            this.videoFullscreenButton.Click += new System.EventHandler(this.VideoFullscreenButton_Click);
            // 
            // videoSeekBar
            // 
            this.videoSeekBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoSeekBar.BackColor = System.Drawing.Color.White;
            this.videoSeekBar.BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(163)))), ((int)(((byte)(227)))));
            this.videoSeekBar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.videoSeekBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.videoSeekBar.FillStyle = TwitchVodPlayer.Controls.ColoredProgressBar.FillStyles.Solid;
            this.videoSeekBar.ForeColor = System.Drawing.Color.White;
            this.videoSeekBar.Location = new System.Drawing.Point(58, 14);
            this.videoSeekBar.Maximum = 100;
            this.videoSeekBar.Minimum = 0;
            this.videoSeekBar.Name = "videoSeekBar";
            this.videoSeekBar.Size = new System.Drawing.Size(448, 8);
            this.videoSeekBar.Step = 10;
            this.videoSeekBar.TabIndex = 12;
            this.videoSeekBar.Value = 0;
            this.videoSeekBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VideoSeekBar_MouseDown);
            this.videoSeekBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.VideoSeekBar_MouseMove);
            this.videoSeekBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.VideoSeekBar_MouseUp);
            // 
            // videoPlaybackButton
            // 
            this.videoPlaybackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.videoPlaybackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.videoPlaybackButton.BackgroundImage = global::TwitchVodPlayer.Properties.Resources.PlayButton;
            this.videoPlaybackButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.videoPlaybackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.videoPlaybackButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.videoPlaybackButton.Location = new System.Drawing.Point(12, 5);
            this.videoPlaybackButton.Name = "videoPlaybackButton";
            this.videoPlaybackButton.Size = new System.Drawing.Size(27, 27);
            this.videoPlaybackButton.TabIndex = 6;
            this.videoPlaybackButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.videoPlaybackButton.UseVisualStyleBackColor = true;
            this.videoPlaybackButton.Click += new System.EventHandler(this.VideoPlaybackButton_Click);
            // 
            // loadingVideoLabel
            // 
            this.loadingVideoLabel.AutoSize = true;
            this.loadingVideoLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.loadingVideoLabel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadingVideoLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.loadingVideoLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.loadingVideoLabel.Location = new System.Drawing.Point(0, 24);
            this.loadingVideoLabel.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.loadingVideoLabel.Name = "loadingVideoLabel";
            this.loadingVideoLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.loadingVideoLabel.Size = new System.Drawing.Size(133, 23);
            this.loadingVideoLabel.TabIndex = 11;
            this.loadingVideoLabel.Text = "Loading Video...";
            this.loadingVideoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // transparentPanel1
            // 
            this.transparentPanel1.AllowDrop = true;
            this.transparentPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.transparentPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.transparentPanel1.BackColor = System.Drawing.Color.Transparent;
            this.transparentPanel1.Location = new System.Drawing.Point(0, 24);
            this.transparentPanel1.Name = "transparentPanel1";
            this.transparentPanel1.Opacity = 100;
            this.transparentPanel1.Size = new System.Drawing.Size(779, 477);
            this.transparentPanel1.TabIndex = 12;
            this.transparentPanel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.transparentPanelCover_DragDrop);
            this.transparentPanel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.transparentPanelCover_DragEnter);
            this.transparentPanel1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.transparentPanelCover_MouseDoubleClick);
            this.transparentPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.transparentPanelCover_MouseMove);
            // 
            // transparentPanelCover
            // 
            this.transparentPanelCover.BackColor = System.Drawing.Color.Transparent;
            this.transparentPanelCover.Location = new System.Drawing.Point(0, 0);
            this.transparentPanelCover.Name = "transparentPanelCover";
            this.transparentPanelCover.Opacity = 100;
            this.transparentPanelCover.Size = new System.Drawing.Size(200, 100);
            this.transparentPanelCover.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 538);
            this.Controls.Add(this.transparentPanel1);
            this.Controls.Add(this.loadingVideoLabel);
            this.Controls.Add(this.chatOffsetLabel);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.videoPlayerPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Twitch VOD Player";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.videoPlayerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.videoVolumeIconBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem vODSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openVodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videoToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openVodFileDialog;
        private System.Windows.Forms.ToolStripMenuItem downloadResourcesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadResourcesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupClientIdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator videoToolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem fullscreenToolStripMenuItem;
        private System.Windows.Forms.Label chatOffsetLabel;
        private System.Windows.Forms.Label timeLabel;
        private Controls.UnfocusableButton videoPlaybackButton;
        private Controls.UnfocusableButton videoFullscreenButton;
        private System.Windows.Forms.Panel videoPlayerPanel;
        private Controls.ColoredProgressBar videoSeekBar;
        private Controls.ColoredProgressBar videoVolumeBar;
        private System.Windows.Forms.PictureBox videoVolumeIconBox;
        private System.Windows.Forms.Label loadingVideoLabel;
        private System.Windows.Forms.ToolStripMenuItem chatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadCreateChatFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator chatToolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem increaseChatOffsetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decreaseChatOffsetToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator chatToolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem hideChatBoxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideChatBoxWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator chatToolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem stickyChatBoxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transparentChatBoxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator helpToolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private AxWMPLib.AxWindowsMediaPlayer videoPlayer;
        private Controls.TransparentPanel transparentPanelCover;
        private Controls.TransparentPanel transparentPanel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem recordChatExperimentalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recordChat2ExperimentalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recordChat3ExperimentalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recordChat4ExperimentalToolStripMenuItem;
    }
}