using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Ookii.Dialogs.Wpf;

namespace TwitchVodPlayer.Forms {

    public partial class ChatFileCreatorForm : Form {

        private static ChatFileCreatorForm instance;
        public static ChatFileCreatorForm Instance {
            get {
                if (instance == null) {
                    instance = new ChatFileCreatorForm();
                }
                return instance;
            }
        }

        //Events

        public event Forms.EventHandlers.CreatedChatFileEventHandler CreatedChatFile;
        protected virtual void OnCreatedChatFile(object sender, EventArgs e) {
            CreatedChatFile?.Invoke(this, e);
        }

        //Event Broadcasts

        private void BroadcastCreatedChatFileEvent() {
            OnCreatedChatFile(this, new EventArgs());
        }

        //Public Fields

        private int maxHours = 0;
        public int MaxHours {
            get => maxHours;
        }
        private int maxMinutes = 0;
        public int MaxMinutes {
            get => maxMinutes;
        }
        private int maxSeconds = 0;
        public int MaxSeconds {
            get => maxSeconds;
        }

        //Private Field

        private Point originalInfoTextBoxLocation;
        private Point originalCreateChatFileButtonLocation;
        private Point originalProgressBarButtonLocation;
        private Size originalFormSize;
        private Point unsetTimeInfoTextBoxLocation;
        private Point unsetTimeCreateChatFileButtonLocation;
        private Point unsetTimeProgressBarButtonLocation;
        private Size unsetTimeFormSize;

        //Initialization

        public ChatFileCreatorForm() {
            InitializeComponent();
        }

        private void ChatFileCreatorForm_Load(object sender, EventArgs e) {
            originalInfoTextBoxLocation = infoTextBox.Location;
            originalCreateChatFileButtonLocation = createChatFileButton.Location;
            originalProgressBarButtonLocation = progressBar.Location;
            originalFormSize = Instance.Size;

            int setTimeControlsHeight =  beginHoursNumBox.Height + beginTimeLabel.Height + 7;

            unsetTimeInfoTextBoxLocation = new Point(originalInfoTextBoxLocation.X, originalInfoTextBoxLocation.Y - setTimeControlsHeight);
            unsetTimeCreateChatFileButtonLocation = new Point(originalCreateChatFileButtonLocation.X, originalCreateChatFileButtonLocation.Y - setTimeControlsHeight);
            unsetTimeProgressBarButtonLocation = new Point(originalProgressBarButtonLocation.X, originalProgressBarButtonLocation.Y - setTimeControlsHeight);
            unsetTimeFormSize = new Size(originalFormSize.Width, originalFormSize.Height - setTimeControlsHeight);

            UseVodId(true);
            SetTime(false);
        }

        public new void Show() {
            base.Show();

            infoTextBox.Text = "";
            chatLogFilePathTextBox.Text = "";
            if (MainForm.Instance.CurrentVideo != null) {
                outputPathTextBox.Text = Path.GetDirectoryName(MainForm.Instance.CurrentVideo.FilePath);
            }

            ResetTime(MainForm.Instance.CurrentVideo);
        }

        //Methods

        private void ChatFileCreatorForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }

        private void useVodIdCheckBox_CheckedChanged(object sender, EventArgs e) {
            UseVodId(useVodIdCheckBox.Checked);
        }

        private void SetTimeCheckBox_CheckedChanged(object sender, EventArgs e) {
            SetTime(setTimeCheckBox.Checked);
        }

        private void UseVodId(bool enabled) {
            if (useVodIdCheckBox.Checked != enabled) {
                useVodIdCheckBox.Checked = enabled;
            }

            vodIdTextBox.Visible = enabled;
            vodIdLabel.Visible = enabled;

            chatLogFileLabel.Visible = !enabled;
            chatLogFilePathTextBox.Visible = !enabled;
            openChatLogFileButton.Visible = !enabled;

            setTimeCheckBox.Enabled = enabled;

            if (enabled) {
                SetTime(setTimeCheckBox.Checked);
            } else {
                SetTime(false);
            }
        }

        private void SetTime(bool enabled) {
            if (setTimeCheckBox.Checked != enabled) {
                setTimeCheckBox.Checked = enabled;
            }

            if (enabled) {
                infoTextBox.Location = originalInfoTextBoxLocation;
                createChatFileButton.Location = originalCreateChatFileButtonLocation;
                progressBar.Location = originalProgressBarButtonLocation;
                Instance.Size = originalFormSize;
            } else {
                infoTextBox.Location = unsetTimeInfoTextBoxLocation;
                createChatFileButton.Location = unsetTimeCreateChatFileButtonLocation;
                progressBar.Location = unsetTimeProgressBarButtonLocation;
                Instance.Size = unsetTimeFormSize;
            }

            beginHoursNumBox.Visible = enabled;
            beginMinutesNumBox.Visible = enabled;
            beginSecondsNumBox.Visible = enabled;
            beginTimeLabel.Visible = enabled;
            endHoursNumBox.Visible = enabled;
            endMinutesNumBox.Visible = enabled;
            endSecondsNumBox.Visible = enabled;
            endTimeLabel.Visible = enabled;
            dashLabel.Visible = enabled;
            resetTimeButton.Visible = enabled;
            colonLabel1.Visible = enabled;
            colonLabel2.Visible = enabled;
            colonLabel3.Visible = enabled;
            colonLabel4.Visible = enabled;
            dashLabel.Visible = enabled;
        }

        private void ChatFileCreatorForm_CreatingChatFile(object sender, Chat.EventHandlers.CreatingChatFileEventArgs e) {
            Instance.Invoke(new Action(() => {
                progressBar.Value = 0;

                infoTextBox.Text = e.Message;

                createChatFileButton.Enabled = false;
            }));
        }
        private void ChatFileCreatorForm_NewProgressCreatingChatFile(object sender, Chat.EventHandlers.NewProgressCreatingChatFileEventArgs e) {
            Instance.Invoke(new Action(() => {
                progressBar.Value = Math.Min(e.Progress, 100);
                infoTextBox.Text = e.Message;
            }));
        }
        private void ChatFileCreatorForm_CreatedChatFile(object sender, Chat.EventHandlers.CreatedChatFileEventArgs e) {
            Instance.Invoke(new Action(() => {
                infoTextBox.Text = e.Message;

                ((Chat.ChatFileCreator)sender).CreatingChatFile -= ChatFileCreatorForm_CreatingChatFile;
                ((Chat.ChatFileCreator)sender).NewProgressCreatingChatFile -= ChatFileCreatorForm_NewProgressCreatingChatFile;
                ((Chat.ChatFileCreator)sender).CreatedChatFile -= ChatFileCreatorForm_CreatedChatFile;
                ((Chat.ChatFileCreator)sender).ErrorOccuredCreatingChatFile -= ChatFileCreatorForm_ErrorOccuredCreatingChatFile;
                
                createChatFileButton.Enabled = true;

                BroadcastCreatedChatFileEvent();
            }));
        }
        private void ChatFileCreatorForm_ErrorOccuredCreatingChatFile(object sender, Chat.EventHandlers.ErrorOccuredCreatingChatFileEventArgs e) {
            Instance.Invoke(new Action(() => {
                infoTextBox.Text = e.Message;

                progressBar.Value = 0;

                ((Chat.ChatFileCreator)sender).CreatingChatFile -= ChatFileCreatorForm_CreatingChatFile;
                ((Chat.ChatFileCreator)sender).NewProgressCreatingChatFile -= ChatFileCreatorForm_NewProgressCreatingChatFile;
                ((Chat.ChatFileCreator)sender).CreatedChatFile -= ChatFileCreatorForm_CreatedChatFile;
                ((Chat.ChatFileCreator)sender).ErrorOccuredCreatingChatFile -= ChatFileCreatorForm_ErrorOccuredCreatingChatFile;
                
                createChatFileButton.Enabled = true;
            }));
        }

        private void CreateChatFileButton_Click(object sender, EventArgs e) {
            Chat.ChatFileCreator chatFileCreator = new Chat.ChatFileCreator();

            chatFileCreator.CreatingChatFile += ChatFileCreatorForm_CreatingChatFile;
            chatFileCreator.NewProgressCreatingChatFile += ChatFileCreatorForm_NewProgressCreatingChatFile;
            chatFileCreator.CreatedChatFile += ChatFileCreatorForm_CreatedChatFile;
            chatFileCreator.ErrorOccuredCreatingChatFile += ChatFileCreatorForm_ErrorOccuredCreatingChatFile;

            TimeSpan? beginTime;
            TimeSpan? endTime;

            if (setTimeCheckBox.Checked) {
                beginTime = new TimeSpan(beginHoursNumBox.Value, beginMinutesNumBox.Value, beginSecondsNumBox.Value);
                endTime = new TimeSpan(endHoursNumBox.Value, endMinutesNumBox.Value, endSecondsNumBox.Value);
            } else {
                beginTime = null;
                endTime = null;
            }

            chatFileCreator.CreateChatFile(outputPathTextBox.Text, chatLogFilePathTextBox.Text,
                vodIdTextBox.Text, useVodIdCheckBox.Checked, setTimeCheckBox.Checked, beginTime, endTime, MainForm.Instance.CurrentVideo);
        }

        private void OpenChatLogFileButton_Click(object sender, EventArgs e) {
            openChatLogFileDialog.Filter = "(*.json) | *.json";
            if (openChatLogFileDialog.ShowDialog() == DialogResult.OK) {
                chatLogFilePathTextBox.Text = openChatLogFileDialog.FileName;
            }
        }

        private void ResetTimeButton_Click(object sender, EventArgs e) {
            ResetTime(MainForm.Instance.CurrentVideo);
        }

        private void ResetTime(Video.VideoFile videoReference = null) {
            beginHoursNumBox.Text = "0";
            beginMinutesNumBox.Text = "0";
            beginSecondsNumBox.Text = "0";
            endHoursNumBox.Text = "0";
            endMinutesNumBox.Text = "0";
            endSecondsNumBox.Text = "0";

            if (videoReference != null) {
                TimeSpan videoLengthTime = MainForm.Instance.CurrentVideo.EndTime;
                maxHours = (int)videoLengthTime.TotalHours;
                maxMinutes = videoLengthTime.Minutes;
                maxSeconds = videoLengthTime.Seconds;
                endHoursNumBox.Text = maxHours.ToString();
                endMinutesNumBox.Text = maxMinutes.ToString();
                endSecondsNumBox.Text = maxSeconds.ToString();
            }
        }

        private void SetOutputPathButton_Click(object sender, EventArgs e) {
            VistaFolderBrowserDialog outputPathFolderDialog = new VistaFolderBrowserDialog();
            if (outputPathFolderDialog.ShowDialog().Equals(true)) {
                outputPathTextBox.Text = outputPathFolderDialog.SelectedPath;
            }
        }
    }
}
