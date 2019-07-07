using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gecko;
using System.IO;
using System.Collections.Specialized;
using Newtonsoft.Json;
using System.Drawing;

namespace TwitchVodPlayer.Forms {
    public partial class MainForm : Form {

        private static MainForm instance;
        public static MainForm Instance {
            get {
                if (instance == null) {
                    instance = new MainForm();
                }
                return instance;
            }
        }

        //Events

        public event Forms.EventHandlers.VideoPlayerEndedEventHandler VideoPlayerEnded;
        protected virtual void OnVideoPlayerEnded(object sender, EventArgs e) {
            VideoPlayerEnded?.Invoke(this, e);
        }

        public event Forms.EventHandlers.MovingSeekBarEventHandler MovingSeekBar;
        protected virtual void OnMovingSeekBar(object sender, Forms.EventHandlers.MovingSeekBarEventArgs e) {
            MovingSeekBar?.Invoke(this, e);
        }

        public event Forms.EventHandlers.ChangingChatOffsetEventHandler ChangingChatOffset;
        protected virtual void OnChangingChatOffset(object sender, Forms.EventHandlers.ChangingChatOffsetEventArgs e) {
            ChangingChatOffset?.Invoke(this, e);
        }

        public event Forms.EventHandlers.EnablingSettingEventHandler EnablingFullscreen;
        protected virtual void OnEnablingFullscreen(object sender, Forms.EventHandlers.EnablingSettingEventArgs e) {
            EnablingFullscreen?.Invoke(this, e);
        }
        public event Forms.EventHandlers.EnablingSettingEventHandler EnablingStickyChatBox;
        protected virtual void OnEnablingStickyChatBox(object sender, Forms.EventHandlers.EnablingSettingEventArgs e) {
            EnablingStickyChatBox?.Invoke(this, e);
        }
        public event Forms.EventHandlers.EnablingSettingEventHandler EnablingHideChatBoxWindow;
        protected virtual void OnEnablingHideChatBoxWindow(object sender, Forms.EventHandlers.EnablingSettingEventArgs e) {
            EnablingHideChatBoxWindow?.Invoke(this, e);
        }
        public event Forms.EventHandlers.EnablingSettingEventHandler EnablingHideChatBox;
        protected virtual void OnEnablingHideChatBox(object sender, Forms.EventHandlers.EnablingSettingEventArgs e) {
            EnablingHideChatBox?.Invoke(this, e);
        }
        public event Forms.EventHandlers.EnablingSettingEventHandler EnablingTransparentChatBox;
        protected virtual void OnEnablingTransparentChatBox(object sender, Forms.EventHandlers.EnablingSettingEventArgs e) {
            EnablingTransparentChatBox?.Invoke(this, e);
        }

        public event Forms.EventHandlers.LoadingVideoEventHandler LoadingVideo;
        private void OnLoadingVideo(object sender, Forms.EventHandlers.LoadingVideoEventArgs e) {
            LoadingVideo?.Invoke(this, e);
        }
        public event Forms.EventHandlers.NewProgressLoadingVideoEventHandler NewProgressLoadingVideo;
        private void OnNewProgressLoadingVideo(object sender, Forms.EventHandlers.NewProgressLoadingVideoEventArgs e) {
            NewProgressLoadingVideo?.Invoke(this, e);
        }
        public event Forms.EventHandlers.LoadedVideoEventHandler LoadedVideo;
        private void OnLoadedVideo(object sender, Forms.EventHandlers.LoadedVideoEventArgs e) {
            LoadedVideo?.Invoke(this, e);
        }
        public event Forms.EventHandlers.ErrorOccuredLoadingVideoEventHandler ErrorOccuredLoadingVideo;
        private void OnErrorOccuredLoadingVideo(object sender, Forms.EventHandlers.ErrorOccuredLoadingVideoEventArgs e) {
            ErrorOccuredLoadingVideo?.Invoke(this, e);
        }

        //Event Broadcasts

        private void BroadcastVideoPlayerEnded() {
            OnVideoPlayerEnded(this, new EventArgs());
        }

        private void BroadcastMovingSeekBarEvent(int newSeekBarValue) {
            Forms.EventHandlers.MovingSeekBarEventArgs e = new Forms.EventHandlers.MovingSeekBarEventArgs();
            e.NewSeekBarValue = newSeekBarValue;
            OnMovingSeekBar(this, e);
        }

        private void BroadcastLoadingVideoEvent(Video.VideoFile video) {
            Forms.EventHandlers.LoadingVideoEventArgs e = new Forms.EventHandlers.LoadingVideoEventArgs();
            e.Video = video;
            OnLoadingVideo(this, e);
        }
        private void BroadcastNewProgressLoadingVideoEvent(string message, int progress) {
            Forms.EventHandlers.NewProgressLoadingVideoEventArgs e = new Forms.EventHandlers.NewProgressLoadingVideoEventArgs();
            e.Message = message;
            e.Progress = progress;
            OnNewProgressLoadingVideo(this, e);
        }
        private void BroadcastLoadedVideoEvent(Video.VideoFile video, double time) {
            Forms.EventHandlers.LoadedVideoEventArgs e = new Forms.EventHandlers.LoadedVideoEventArgs();
            e.Video = video;
            e.Time = time;
            OnLoadedVideo(this, e);
        }
        private void BroadcastErrorOccuredLoadingVideoEvent(string message) {
            Forms.EventHandlers.ErrorOccuredLoadingVideoEventArgs e = new Forms.EventHandlers.ErrorOccuredLoadingVideoEventArgs();
            e.Message = message;
            OnErrorOccuredLoadingVideo(this, e);
        }

        private void BroadcastEnablingTransparentChatBoxEvent(bool enabling) {
            Forms.EventHandlers.EnablingSettingEventArgs e = new Forms.EventHandlers.EnablingSettingEventArgs();
            e.Enabling = enabling;
            OnEnablingTransparentChatBox(this, e);
        }

        private void BroadcastChangingChatOffsetEvent(double offsetChange) {
            Forms.EventHandlers.ChangingChatOffsetEventArgs e = new Forms.EventHandlers.ChangingChatOffsetEventArgs();
            e.OffsetChange = offsetChange;
            OnChangingChatOffset(this, e);
        }

        private void BroadcastEnablingFullscreenEvent(bool enabling) {
            Forms.EventHandlers.EnablingSettingEventArgs e = new Forms.EventHandlers.EnablingSettingEventArgs();
            e.Enabling = enabling;
            OnEnablingFullscreen(this, e);
        }
        private void BroadcastEnablingStickyChatBoxEvent(bool enabling) {
            Forms.EventHandlers.EnablingSettingEventArgs e = new Forms.EventHandlers.EnablingSettingEventArgs();
            e.Enabling = enabling;
            OnEnablingStickyChatBox(this, e);
        }
        private void BroadcastEnablingHideChatBoxWindowEvent(bool enabling) {
            Forms.EventHandlers.EnablingSettingEventArgs e = new Forms.EventHandlers.EnablingSettingEventArgs();
            e.Enabling = enabling;
            OnEnablingHideChatBoxWindow(this, e);
        }
        private void BroadcastEnablingHideChatBoxEvent(bool enabling) {
            Forms.EventHandlers.EnablingSettingEventArgs e = new Forms.EventHandlers.EnablingSettingEventArgs();
            e.Enabling = enabling;
            OnEnablingHideChatBox(this, e);
        }

        //Private Fields

        private readonly int maxSavedPositionsCount = 50;

        private readonly FormWindowState defaultWindowState;
        private readonly FormBorderStyle defaultBorderStyle;
        private readonly DockStyle defaultDockStyle;

        private readonly int displayOffsetLengthSeconds = 2;

        private readonly int displayVideoPlayerPanelLengthSeconds = 3;

        OrderedDictionary savedPositions = new OrderedDictionary();

        private Point previousVideoPlayerTransparentCoverMousePosition;

        bool isLoadingVideo = false;

        System.Windows.Forms.Timer videoPlayerUpdateTimer;

        private string videoExtensionFilter = Forms.Helpers.Filter(VideoExtensions);

        //Public Fields

        public static readonly string[] VideoExtensions = new string[] { ".dat",  ".wmv",  ".3g2",  ".3gp",  ".3gp2",  ".3gpp",  ".amv",  ".asf",   ".avi",  ".bin",  ".cue",  ".divx",  ".dv",  ".flv",  ".gxf",  ".iso",  ".m1v",  ".m2v",  ".m2t",  ".m2ts",  ".m4v",
              ".mkv",  ".mov",  ".mp2",  ".mp2v",  ".mp4",  ".mp4v",  ".mpa",  ".mpe",  ".mpeg",  ".mpeg1",  ".mpeg2",  ".mpeg4",  ".mpg",  ".mpv2",  ".mts",  ".nsv",  ".nuv",  ".ogg",  ".ogm",  ".ogv",  ".ogx",  ".ps",  ".rec",  ".rm",  ".rmvb",  ".tod",  ".ts",  ".tts",  ".vob",  ".vro",  ".webm"};

        public readonly long OffsetIncreaseValueMilliseconds = 100;
        public readonly long OffsetDecreaseValueMilliseconds = 100;

        public Video.VideoFile CurrentVideo;

        private bool isFullScreen = false;
        public bool IsFullscreen {
            get {
                return isFullScreen;
            }
            set {
                isFullScreen = value;

                fullscreenToolStripMenuItem.Checked = isFullScreen;

                if (isFullScreen && CurrentVideo != null) {
                    menuStrip.Hide();
                    FormBorderStyle = FormBorderStyle.None;
                    WindowState = FormWindowState.Maximized;

                    try {
                        videoFullscreenButton.BackgroundImage = Properties.Resources.WindowedButton;
                    } catch (FileNotFoundException e) {
                        Console.WriteLine("Windowed Button image file not found.");
                    }
                } else {
                    menuStrip.Show();
                    WindowState = defaultWindowState;
                    FormBorderStyle = defaultBorderStyle;

                    try {
                        videoFullscreenButton.BackgroundImage = Properties.Resources.FullscreenButton;
                    } catch (FileNotFoundException e) {
                        Console.WriteLine("Fullscreen Button image file not found.");
                    }
                }

                videoPlayer.Focus();

                BroadcastEnablingFullscreenEvent(isFullScreen);
            }
        }

        private bool isVideoPlayerPlaying;
        public bool IsVideoPlayerPlaying {
            get {
                isVideoPlayerPlaying = videoPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying;
                return isVideoPlayerPlaying;
            }
            set {
                isVideoPlayerPlaying = value;

                //

                if (isVideoPlayerPlaying) {
                    try {
                        videoPlaybackButton.BackgroundImage = Properties.Resources.PauseButton;
                    } catch (FileNotFoundException e) {
                        Console.WriteLine("Pause Button image file not found.");
                    }

                    videoPlayer.Ctlcontrols.play();
                } else {
                    try {
                        videoPlaybackButton.BackgroundImage = Properties.Resources.PlayButton;
                    } catch (FileNotFoundException e) {
                        Console.WriteLine("Play Button image file not found.");
                    }

                    videoPlayer.Ctlcontrols.pause();
                }
            }
        }

        private double videoPlayerTime;
        public double VideoPlayerTime {
            get {
                try {
                    videoPlayerTime = videoPlayer.Ctlcontrols.currentPosition;
                    return videoPlayerTime;
                } catch {
                    return 0;
                }
            }
            set {
                if (CurrentVideo == null) {
                    return;
                }

                videoPlayerTime = value;

                if (videoPlayerTime >= CurrentVideo.EndTime.TotalSeconds) {
                    videoPlayerTime = 0;
                    BroadcastVideoPlayerEnded();
                }

                if (videoPlayer.Ctlcontrols.currentPosition != videoPlayerTime) {
                    videoPlayer.Ctlcontrols.currentPosition = videoPlayerTime;
                }
            }
        }

        private int videoPlayerVolume;
        public int VideoPlayerVolume {
            get {
                videoPlayerVolume = videoPlayer.settings.volume;
                return videoPlayerVolume;
            }
            set {
                videoPlayerVolume = value;

                if (videoPlayer.settings.volume != videoPlayerVolume) {
                    videoPlayer.settings.volume = videoPlayerVolume;
                }

                //

                IsMuted = false;

                UpdateVolumeIconBox();

                videoVolumeBar.Value = videoPlayer.settings.volume;
            }
        }

        private bool isMuted;
        public bool IsMuted {
            get {
                isMuted = videoPlayer.settings.mute;
                return isMuted;
            }
            set {
                isMuted = value;

                if (videoPlayer.settings.mute != isMuted) {
                    videoPlayer.settings.mute = isMuted;
                }

                //

                if (isMuted) {
                    videoVolumeIconBox.Image = Properties.Resources.VolumeMuted;
                } else {
                    UpdateVolumeIconBox();
                }
            }
        }

        private bool isStickyChatBoxEnabled;
        public bool IsStickyChatBoxEnabled {
            get {
                return isStickyChatBoxEnabled;
            }
            set {
                isStickyChatBoxEnabled = value;

                //

                stickyChatBoxToolStripMenuItem.Checked = isStickyChatBoxEnabled;

                hideChatBoxWindowToolStripMenuItem.Enabled = !isStickyChatBoxEnabled;

                IsHiddenChatBoxWindowEnabled = true;

                BroadcastEnablingStickyChatBoxEvent(isStickyChatBoxEnabled);
            }
        }

        private bool isHiddenChatBoxEnabled;
        public bool IsHiddenChatBoxEnabled {
            get {
                return isHiddenChatBoxEnabled;
            }
            set {
                isHiddenChatBoxEnabled = value;

                //

                hideChatBoxToolStripMenuItem.Checked = isHiddenChatBoxEnabled;

                BroadcastEnablingHideChatBoxEvent(isHiddenChatBoxEnabled);
            }
        }

        private bool isHiddenChatBoxWindowEnabled;
        public bool IsHiddenChatBoxWindowEnabled {
            get {
                return isHiddenChatBoxWindowEnabled;
            }
            set {
                isHiddenChatBoxWindowEnabled = value;

                //

                hideChatBoxWindowToolStripMenuItem.Checked = isHiddenChatBoxWindowEnabled;

                BroadcastEnablingHideChatBoxWindowEvent(isHiddenChatBoxWindowEnabled);
            }
        }

        private bool isTransparentChatBoxEnabled;
        public bool IsTransparentChatBoxEnabled {
            get {
                return isTransparentChatBoxEnabled;
            }
            set {
                isTransparentChatBoxEnabled = value;

                //

                transparentChatBoxToolStripMenuItem.Checked = isTransparentChatBoxEnabled;

                BroadcastEnablingTransparentChatBoxEvent(isTransparentChatBoxEnabled);
            }
        }

        private bool isVideoVolumeBarClicked = false;
        public bool IsVideoVolumeBarClicked {
            get {
                return isVideoVolumeBarClicked;
            }
        }

        private bool isVideoSeekBarClicked = false;
        public bool IsVideoSeekBarClicked {
            get {
                return isVideoSeekBarClicked;
            }
        }

        //Initialization

        public MainForm() {
            InitializeComponent();

            if (IntPtr.Size == 8) {
                Xpcom.Initialize("Firefox64");
            } else if (IntPtr.Size == 4) {
                Xpcom.Initialize("Firefox");
            }

            videoPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            videoPlayer.Parent = this;

            defaultWindowState = WindowState;
            defaultBorderStyle = FormBorderStyle;
            defaultDockStyle = videoPlayer.Dock;
        }

        private void MainForm_Load(object sender, EventArgs e) {
            GotFocus += MainForm_GotFocus;

            ChatForm.Instance.Owner = this;
            ChatForm.Instance.Show();

            videoPlayer.Dock = DockStyle.Fill;
            videoPlayer.stretchToFit = true;
            videoPlayer.uiMode = "none";
            videoPlayer.windowlessVideo = true;
            videoPlayer.fullScreen = false;
            videoPlayer.Ctlenabled = false;

            VideoPlayerEnded += MainForm_VideoPlayerEnded;

            ResourceDownloaderForm.Instance.DownloadedResources += ResourceDownloaderForm_DownloadedResources;
            ChatFileCreatorForm.Instance.CreatedChatFile += ChatFileCreatorForm_CreatedChatFile;

            ChatForm.Instance.ChangedChatOffset += ChatForm_OnChangedChatOffset;

            videoSeekBar.Maximum = 0;

            videoFullscreenButton.Enabled = false;

            SetVideoPlayerUpdateTimerTick();
            videoPlayerUpdateTimer.Start();

            SubscribeFormInput();

            HideLoadingVideoDisplay();

            HideVideoPlayerPanel();
            HideOffset();

            LoadSavedUserSettings();

            IsVideoPlayerPlaying = false;
        }

        private void SubscribeFormInput() {
            KeyPreview = true;
            KeyDown += Keyboard.FormInput.Form_KeyDown;
        }

        private void LoadSavedUserSettings() {
            IsStickyChatBoxEnabled = Properties.Settings.Default.StickyChatBox;
            isHiddenChatBoxEnabled = Properties.Settings.Default.HiddenChatBox;
            IsHiddenChatBoxWindowEnabled = Properties.Settings.Default.HiddenChatBoxWindow;
            IsTransparentChatBoxEnabled = Properties.Settings.Default.TransparentChatBox;
            VideoPlayerVolume = Properties.Settings.Default.Volume;
            IsMuted = Properties.Settings.Default.VolumeMuted;

            try {
                savedPositions = JsonConvert.DeserializeObject<OrderedDictionary>(Properties.Settings.Default.SavedPositions);
            } catch {
                savedPositions = null;
            }
            if (savedPositions == null) {
                savedPositions = new OrderedDictionary();
            }

            if (Properties.Settings.Default.Volume == -1) {
                Properties.Settings.Default.Volume = 100;
            }

            if (Properties.Settings.Default.MainFormSize.Width != -1) {
                MainForm.Instance.Size = Properties.Settings.Default.MainFormSize;
            }
            if (Properties.Settings.Default.MainFormLocation.X != -1) {
                MainForm.Instance.Location = Properties.Settings.Default.MainFormLocation;
            }
        }

        //Methods

        private void SetVideoPlayerUpdateTimerTick() {
            if (videoPlayerUpdateTimer == null) {
                videoPlayerUpdateTimer = new System.Windows.Forms.Timer();
                videoPlayerUpdateTimer.Tick += new EventHandler(videoPlayerUpdateTimer_Tick);
                videoPlayerUpdateTimer.Interval = 1;
            }
        }

        private void videoPlayerUpdateTimer_Tick(object sender, EventArgs e) {
            UpdateVideoSeekBarFromVideoPlayerCurrentPosition();
        }

        private void UpdateVideoSeekBarFromVideoPlayerCurrentPosition() {
            if (!IsVideoSeekBarClicked && videoSeekBar.Value != (int)(videoPlayer.Ctlcontrols.currentPosition)) {
                TimeSpan videoPlayerTimeSpan = TimeSpan.FromSeconds((int)videoPlayerTime);
                if (videoPlayerTime >= 0 && videoPlayerTimeSpan <= CurrentVideo.EndTime) {
                    timeLabel.Text = videoPlayerTimeSpan + " / " + CurrentVideo.EndTime;
                }
                videoSeekBar.Value = (int)(videoPlayer.Ctlcontrols.currentPosition);
            }
        }

        private async void CheckForUpdates() {
            UpdateLoadingForm updateLoadingForm = new UpdateLoadingForm();
            updateLoadingForm.Show();

            string updateUrl = await Updates.UpdateChecker.CheckForUpdates();

            updateLoadingForm.Close();

            if (updateUrl == "latest") {
                MessageBox.Show("You have the latest version of Twitch VOD Player!", "Twitch VOD Player", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else if (updateUrl == null) {
                MessageBox.Show("There was a problem checking for updates.", "Twitch VOD Player", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                DialogResult dialogResult = MessageBox.Show("There is a new update available.\nWould you like to download it?", "Twitch VOD Player", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes) {
                    System.Diagnostics.Process.Start(updateUrl);
                }
            }
        }

        private void ResourceDownloaderForm_DownloadedResources(object sender, EventArgs e) {
            if (CurrentVideo != null) {
                Task.Run(() => LoadVideo(CurrentVideo));
            }
        }

        private void ChatFileCreatorForm_CreatedChatFile(object sender, EventArgs e) {
            if (CurrentVideo != null) {
                Task.Run(() => LoadVideo(CurrentVideo));
            }
        }

        private void MainForm_VideoPlayerEnded(object sender, EventArgs e) {
            if (CurrentVideo != null) {
                IsVideoPlayerPlaying = false;
                Task.Run(() => LoadVideo(CurrentVideo, true));
            }
        }

        private void UpdateVolumeIconBox() {
            if (VideoPlayerVolume >= 100) {
                videoVolumeIconBox.Image = Properties.Resources.Volume3;
            } else if (VideoPlayerVolume >= 66) {
                videoVolumeIconBox.Image = Properties.Resources.Volume2;
            } else if (VideoPlayerVolume >= 33) {
                videoVolumeIconBox.Image = Properties.Resources.Volume1;
            } else {
                videoVolumeIconBox.Image = Properties.Resources.Volume0;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            SaveCurrentVideoPosition();
            SaveAudioVolume();
            SaveMuted();
            if (!IsFullscreen) {
                SaveMainFormSize();
                SaveMainFormLocation();
                SaveChatFormSize();
                SaveChatFormLocation();
            }
            SaveSettings();

            Properties.Settings.Default.Save();
        }

        private void SaveMainFormSize() {
            Properties.Settings.Default.MainFormSize = MainForm.Instance.Size;
        }
        private void SaveMainFormLocation() {
            Properties.Settings.Default.MainFormLocation = MainForm.Instance.Location;
        }
        private void SaveChatFormSize() {
            Properties.Settings.Default.ChatFormSize = ChatForm.Instance.Size;
        }
        private void SaveChatFormLocation() {
            Properties.Settings.Default.ChatFormLocation = ChatForm.Instance.Location;
        }
        private void SaveSettings() {
            Properties.Settings.Default.StickyChatBox = IsStickyChatBoxEnabled;
            Properties.Settings.Default.HiddenChatBox = IsHiddenChatBoxEnabled;
            Properties.Settings.Default.HiddenChatBoxWindow = IsHiddenChatBoxWindowEnabled;
            Properties.Settings.Default.TransparentChatBox = IsTransparentChatBoxEnabled;
        }

        private void MainForm_GotFocus(object sender, EventArgs e) {
            videoPlayer.Focus();
        }

        private void SaveCurrentVideoPosition() {
            if(CurrentVideo != null){
                if (savedPositions.Contains(CurrentVideo.FilePath)) {
                    savedPositions[CurrentVideo.FilePath] = videoPlayerTime;
                } else {
                    savedPositions.Add(CurrentVideo.FilePath, videoPlayerTime);
                    if (savedPositions.Count > maxSavedPositionsCount) {
                        savedPositions.RemoveAt(savedPositions.Count - 1);
                    }
                }
                Properties.Settings.Default.SavedPositions = JsonConvert.SerializeObject(savedPositions);
            }
        }

        private void SaveAudioVolume() {
            Properties.Settings.Default.Volume = videoVolumeBar.Value;
        }

        private void SaveMuted() {
            Properties.Settings.Default.VolumeMuted = IsMuted;
        }

        private void DownloadResourcesToolStripMenuItem1_Click(object sender, EventArgs e) {
            ResourceDownloaderForm.Instance.Show();
        }

        private void SetupClientIdToolStripMenuItem_Click(object sender, EventArgs e) {
            ClientIdTesterForm.Instance.Show();
        }

        private void ForwardToolStripMenuItem_Click(object sender, EventArgs e) {
            ForwardVideoPlayerTime(Video.Constants.ForwardMilliseconds);
        }

        private void BackwardToolStripMenuItem_Click(object sender, EventArgs e) {
            ForwardVideoPlayerTime(Video.Constants.BackwardMilliseconds);
        }

        public void ForwardVideoPlayerTime(long timeAdded) {
            VideoPlayerTime += timeAdded;
            BroadcastMovingSeekBarEvent(videoSeekBar.Value);
        }
        public void ToggleVideoPlayerPlayback() {
            MainForm.instance.Focus();
            if (CurrentVideo != null) {
                IsVideoPlayerPlaying = !IsVideoPlayerPlaying;
            } else {
                IsVideoPlayerPlaying = false;
            }
        }

        private void FullscreenToolStripMenuItem_Click(object sender, EventArgs e) {
            ToggleFullscreen();
        }
        private void HideChatBoxToolStripMenuItem_Click(object sender, EventArgs e) {
            ToggleHiddenChatBox();
        }
        private void HideChatBoxWindowToolStripMenuItem_Click(object sender, EventArgs e) {
            ToggleHiddenChatBoxWindow();
        }
        private void StickChatBoxToolStripMenuItem_Click(object sender, EventArgs e) {
            ToggleStickyChatBox();
        }
        private void TransparentChatBoxToolStripMenuItem_Click(object sender, EventArgs e) {
            ToggleTransparentChatBox();
        }
        private void ToggleFullscreen() {
            IsFullscreen = !IsFullscreen;
        }
        public void ToggleHiddenChatBox() {
            IsHiddenChatBoxEnabled = !IsHiddenChatBoxEnabled;
        }
        public void ToggleHiddenChatBoxWindow() {
            IsHiddenChatBoxWindowEnabled = !IsHiddenChatBoxWindowEnabled;
        }
        public void ToggleStickyChatBox() {
            IsStickyChatBoxEnabled = !IsStickyChatBoxEnabled;
        }
        public void ToggleTransparentChatBox() {
            IsTransparentChatBoxEnabled = !IsTransparentChatBoxEnabled;
        }

        CancellationTokenSource hideOffsetTokenSource = new CancellationTokenSource();
        public void DisplayOffset(double offset) {
            chatOffsetLabel.Visible = true;
            chatOffsetLabel.Text = "Chat Offset: " + offset;

            hideOffsetTokenSource.Cancel();
            hideOffsetTokenSource = new CancellationTokenSource();

            Task.Delay(new TimeSpan(0, 0, displayOffsetLengthSeconds)).ContinueWith(o => { HideOffset(); }, hideOffsetTokenSource.Token);
        }
        private void HideOffset() {
            try {
                MainForm.Instance.Invoke(new Action(() => {
                    chatOffsetLabel.Visible = false;
                }));
            } catch { }
        }

        private void CheckMouseMovementForVideoPlayerPanel(Point mousePosition) {
            int videoPlayerTransparentCoverMousePositionXDelta =
                Math.Abs(mousePosition.X - previousVideoPlayerTransparentCoverMousePosition.X);
            int videoPlayerTransparentCoverMousePositionYDelta =
                Math.Abs(mousePosition.Y - previousVideoPlayerTransparentCoverMousePosition.Y);
            previousVideoPlayerTransparentCoverMousePosition = mousePosition;
            if (videoPlayerTransparentCoverMousePositionXDelta > 0 || videoPlayerTransparentCoverMousePositionYDelta > 0) {
                DisplayVideoPlayerPanel();
            }
        }

        CancellationTokenSource hideVideoPlayerPanelTokenSource = new CancellationTokenSource();
        public void DisplayVideoPlayerPanel() {
            videoPlayerPanel.Visible = true;
            videoSeekBar.Visible = true;
            videoPlaybackButton.Visible = true;
            timeLabel.Visible = true;
            videoFullscreenButton.Visible = true;
            videoVolumeBar.Visible = true;

            hideVideoPlayerPanelTokenSource.Cancel();
            hideVideoPlayerPanelTokenSource = new CancellationTokenSource();

            Task.Delay(new TimeSpan(0, 0, displayVideoPlayerPanelLengthSeconds)).ContinueWith(o => { HideVideoPlayerPanel(); }, hideVideoPlayerPanelTokenSource.Token);
        }
        private void HideVideoPlayerPanel() {
            try {
                MainForm.Instance.Invoke(new Action(() => {
                    videoPlayerPanel.Visible = false;
                    videoSeekBar.Visible = false;
                    videoPlaybackButton.Visible = false;
                    timeLabel.Visible = false;
                    videoFullscreenButton.Visible = false;
                    videoVolumeBar.Visible = false;
                }));
            } catch (Exception e) {
                Console.WriteLine("Error hiding video player panel. Reason: " + e.Message);
            }
        }

        public void ChangeChatOffset(double offsetChange) {
            BroadcastChangingChatOffsetEvent(offsetChange);
        }

        private void ChatForm_OnChangedChatOffset(object sender, Forms.EventHandlers.ChangedChatOffsetEventArgs e) {
            DisplayOffset(e.NewOffset);
        }

        private void IncreaseChatOffsetToolStripMenuItem_Click(object sender, EventArgs e) {
            ChangeChatOffset(OffsetIncreaseValueMilliseconds);
        }

        private void DecreaseChatOffsetToolStripMenuItem_Click(object sender, EventArgs e) {
            ChangeChatOffset(-OffsetDecreaseValueMilliseconds);
        }

        private void ShowLoadingVideoDisplay() {
            MainForm.Instance.Invoke(new Action(() => {
                loadingVideoLabel.Visible = true;
            }));
        }
        private void HideLoadingVideoDisplay() {
            MainForm.Instance.Invoke(new Action(() => {
                loadingVideoLabel.Visible = false;
            }));
        }

        private void LoadVideo(Video.VideoFile video, bool startAtBeginning = false) {
            if (!isLoadingVideo) {
                isLoadingVideo = true;

                MainForm.Instance.Invoke(new Action(() => {
                    openVodToolStripMenuItem.Enabled = false;
                }));

                ShowLoadingVideoDisplay();

                BroadcastLoadingVideoEvent(video);

                SaveCurrentVideoPosition();

                CurrentVideo = video;

                videoPlayer.Ctlcontrols.stop();
                videoPlayer.URL = video.FilePath;
                    
                IsVideoPlayerPlaying = true;

                videoSeekBar.Maximum = (int)CurrentVideo.EndTime.TotalSeconds;

                if (!startAtBeginning) {
                    if (savedPositions.Contains(CurrentVideo.FilePath)) {
                        double savedPosition = 0;
                        try {
                            savedPosition = (double)savedPositions[CurrentVideo.FilePath];
                        } catch {}
                        if (CurrentVideo.EndTime.TotalMilliseconds - 5000 > (savedPosition)) {
                            MainForm.Instance.Invoke(new Action(() => {
                                VideoPlayerTime = savedPosition;
                            }));
                        } else {
                            savedPositions.Remove(CurrentVideo.FilePath);
                        }
                    }
                } else {
                    MainForm.Instance.Invoke(new Action(() => {
                        VideoPlayerTime = 0;
                    }));
                }

                BroadcastLoadedVideoEvent(CurrentVideo, VideoPlayerTime);

                MainForm.Instance.Invoke(new Action(() => {
                    if (!videoFullscreenButton.Enabled) {
                        videoFullscreenButton.Enabled = true;
                    }

                    MainForm.Instance.Text = TwitchVodPlayer.Constants.Title + " - " + Path.GetFileNameWithoutExtension(video.FilePath);
                }));

                HideLoadingVideoDisplay();

                MainForm.Instance.Invoke(new Action(() => {
                    openVodToolStripMenuItem.Enabled = true;
                }));

                isLoadingVideo = false;
            }
        }

        private void OpenVodToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenVodFile();
        }
        public void OpenVodFile() {
            openVodFileDialog.Filter = videoExtensionFilter;
            if (openVodFileDialog.ShowDialog() == DialogResult.OK) {
                Video.VideoFile video = new Video.VideoFile(openVodFileDialog.FileName);
                Task.Run(() => LoadVideo(video));
            }
        }

        private void DownloadCreateChatFileToolStripMenuItem_Click(object sender, EventArgs e) {
            ChatFileCreatorForm.Instance.Show();
        }

        private void VideoPlaybackButton_Click(object sender, EventArgs e) {
            ToggleVideoPlayerPlayback();
        }

        private void VideoFullscreenButton_Click(object sender, EventArgs e) {
            ToggleFullscreen();
        }
        private void VideoVolumeIconBox_Click(object sender, EventArgs e) {
            ToggleMute();
        }
        private void ToggleMute() {
            IsMuted = !IsMuted;
        }

        private void VideoVolumeBar_MouseMove(object sender, MouseEventArgs e) {
            if (IsVideoVolumeBarClicked) {
                UpdateVideoPlayerVolumeFromMousePosition();
            }
            CheckMouseMovementForVideoPlayerPanel(e.Location);
        }

        private void VideoVolumeBar_MouseDown(object sender, MouseEventArgs e) {
            isVideoVolumeBarClicked = true;
            UpdateVideoPlayerVolumeFromMousePosition();
        }

        private void UpdateVideoPlayerVolumeFromMousePosition() {
            Point currentVolumeBarMousePosition = videoVolumeBar.PointToClient(Cursor.Position);

            int value = videoVolumeBar.Minimum + (videoVolumeBar.Maximum - videoVolumeBar.Minimum) *
                currentVolumeBarMousePosition.X / videoVolumeBar.Width;

            VideoPlayerVolume = value;
        }

        private void VideoVolumeBar_MouseUp(object sender, MouseEventArgs e) {
            isVideoVolumeBarClicked = false;
        }

        private void VideoSeekBar_MouseDown(object sender, MouseEventArgs e) {
            isVideoSeekBarClicked = true;
            UpdateVideoPlayerTimeFromMousePosition();
        }
        private void UpdateVideoPlayerTimeFromMousePosition() {
            if (CurrentVideo != null) {
                Point CP = videoSeekBar.PointToClient(Cursor.Position);
                VideoPlayerTime = (videoSeekBar.Minimum + (videoSeekBar.Maximum - videoSeekBar.Minimum) *
                    CP.X / videoSeekBar.Width);
            }
        }

        private void UpdateVideoSeekBarValueFromMousePosition() {
            if (CurrentVideo != null) {
                Point CP = videoSeekBar.PointToClient(Cursor.Position);
                videoSeekBar.Value = (videoSeekBar.Minimum + (videoSeekBar.Maximum - videoSeekBar.Minimum) *
                    CP.X / videoSeekBar.Width);
            }
        }

        private void VideoSeekBar_MouseUp(object sender, MouseEventArgs e) {
            if (IsVideoSeekBarClicked) {
                UpdateVideoPlayerTimeFromMousePosition();
                isVideoSeekBarClicked = false;
                BroadcastMovingSeekBarEvent(videoSeekBar.Value);
            }
        }

        private void VideoSeekBar_MouseMove(object sender, MouseEventArgs e) {
            if (IsVideoSeekBarClicked) {
                UpdateVideoSeekBarValueFromMousePosition();
            }
            CheckMouseMovementForVideoPlayerPanel(e.Location);
        }

        private void VideoPlayerPanel_MouseMove(object sender, MouseEventArgs e) {
            CheckMouseMovementForVideoPlayerPanel(e.Location);
        }

        private void ManualToolStripMenuItem_Click(object sender, EventArgs e) {
            HelpForm.Instance.Show();
        }

        private void CheckForUpdatesToolStripMenuItem_Click(object sender, EventArgs e) {
            CheckForUpdates();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e) {
            AboutForm.Instance.Show();
        }

        private void transparentPanelCover_DragDrop(object sender, DragEventArgs e) {
            string filePath = ((string[]) e.Data.GetData(DataFormats.FileDrop, false))[0];

            if (!File.Exists(filePath)) {
                MessageBox.Show("This file doesn't exist!", "Twitch VOD Player", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool fileFormatSupported = false;
            string fileExtension = Path.GetExtension(filePath);
            foreach (string videoExtension in VideoExtensions) {
                if (fileExtension == videoExtension) {
                    fileFormatSupported = true;
                    break;
                }
            }
            if (!fileFormatSupported) {
                MessageBox.Show("This video cannot be played because the file format is unsupported.", "Twitch VOD Player", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Video.VideoFile video = new Video.VideoFile(filePath);
            Task.Run(() => LoadVideo(video));
        }

        private void transparentPanelCover_DragEnter(object sender, System.Windows.Forms.DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void transparentPanelCover_MouseMove(object sender, MouseEventArgs e) {
            CheckMouseMovementForVideoPlayerPanel(e.Location);
        }

        private void transparentPanelCover_MouseDoubleClick(object sender, MouseEventArgs e) {
            ToggleFullscreen();
        }
    }
}
