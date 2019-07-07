using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwitchVodPlayer.Forms {
    public partial class ChatForm : Form {

        private static ChatForm instance;
        public static ChatForm Instance {
            get {
                if (instance == null) {
                    instance = new ChatForm();
                }
                return instance;
            }
        }

        //Events

        public event Forms.EventHandlers.MovedSeekBarEventHandler MovedSeekBar;
        protected virtual void OnMovedSeekBar(object sender, Forms.EventHandlers.MovedSeekBarEventArgs e) {
            MovedSeekBar?.Invoke(this, e);
        }

        public event Forms.EventHandlers.ChangedChatOffsetEventHandler ChangedChatOffset;
        protected virtual void OnChangedChatOffset(object sender, Forms.EventHandlers.ChangedChatOffsetEventArgs e) {
            ChangedChatOffset?.Invoke(this, e);
        }

        public event Forms.EventHandlers.EnabledSettingEventHandler EnabledHiddenChatBoxWindow;
        protected virtual void OnEnabledHiddenChatBoxWindow(object sender, Forms.EventHandlers.EnabledSettingEventArgs e) {
            EnabledHiddenChatBoxWindow?.Invoke(this, e);
        }
        public event Forms.EventHandlers.EnabledSettingEventHandler EnabledHiddenChatBox;
        protected virtual void OnEnabledHiddenChatBox(object sender, Forms.EventHandlers.EnabledSettingEventArgs e) {
            EnabledHiddenChatBox?.Invoke(this, e);
        }
        public event Forms.EventHandlers.EnabledSettingEventHandler EnabledTransparentChatBox;
        protected virtual void OnEnabledTransparentChatBox(object sender, Forms.EventHandlers.EnabledSettingEventArgs e) {
            EnabledTransparentChatBox?.Invoke(this, e);
        }
        public event Forms.EventHandlers.EnabledSettingEventHandler EnabledStickyChatBox;
        protected virtual void OnEnabledStickyChatBox(object sender, Forms.EventHandlers.EnabledSettingEventArgs e) {
            EnabledStickyChatBox?.Invoke(this, e);
        }
        public event Forms.EventHandlers.EnabledSettingEventHandler EnabledFullscreen;
        protected virtual void OnEnabledFullscreen(object sender, Forms.EventHandlers.EnabledSettingEventArgs e) {
            EnabledFullscreen?.Invoke(this, e);
        }

        //Event Broadcasts

        private void BroadcastMovedSeekBarEvent(int newSeekBarValue) {
            Forms.EventHandlers.MovedSeekBarEventArgs e = new Forms.EventHandlers.MovedSeekBarEventArgs();
            e.NewSeekBarValue = newSeekBarValue;
            OnMovedSeekBar(this, e);
        }

        private void BroadcastChangedChatOffsetEvent(double newOffset) {
            Forms.EventHandlers.ChangedChatOffsetEventArgs e = new Forms.EventHandlers.ChangedChatOffsetEventArgs();
            e.NewOffset = newOffset;
            OnChangedChatOffset(this, e);
        }

        private void BroadcastEnabledHiddenChatBoxWindow(bool enabled) {
            Forms.EventHandlers.EnabledSettingEventArgs e = new Forms.EventHandlers.EnabledSettingEventArgs();
            e.Enabled = enabled;
            OnEnabledHiddenChatBoxWindow(this, e);
        }
        private void BroadcastEnabledHiddenChatBox(bool enabled) {
            Forms.EventHandlers.EnabledSettingEventArgs e = new Forms.EventHandlers.EnabledSettingEventArgs();
            e.Enabled = enabled;
            OnEnabledHiddenChatBox(this, e);
        }
        private void BroadcastEnabledTransparentChatBox(bool enabled) {
            Forms.EventHandlers.EnabledSettingEventArgs e = new Forms.EventHandlers.EnabledSettingEventArgs();
            e.Enabled = enabled;
            OnEnabledTransparentChatBox(this, e);
        }
        private void BroadcastEnabledStickyChatBox(bool enabled) {
            Forms.EventHandlers.EnabledSettingEventArgs e = new Forms.EventHandlers.EnabledSettingEventArgs();
            e.Enabled = enabled;
            OnEnabledStickyChatBox(this, e);
        }
        private void BroadcastEnabledFullscreen(bool enabled) {
            Forms.EventHandlers.EnabledSettingEventArgs e = new Forms.EventHandlers.EnabledSettingEventArgs();
            e.Enabled = enabled;
            OnEnabledFullscreen(this, e);
        }

        //Private Fields

        private readonly int chatBoxUpdateTimerIntervalMilliseconds = 10;

        private readonly int maxSavedOffsetsCount = 20;

        private readonly int chatBoxDistance = -15;

        private readonly FormBorderStyle defaultBorderStyle;

        private readonly Color transparencyKeyColor = Color.FromArgb(35, 35, 35);
        private readonly Color nonTransparentColor = Color.FromArgb(25, 25, 25);

        private double currentChatOffset;

        OrderedDictionary savedOffsets = new OrderedDictionary();

        Chat.MessageParser messageParser = new Chat.MessageParser();

        private bool isWindowShown;
        private bool isStickyChatBoxEnabling;
        private bool isFullscreen;

        System.Windows.Forms.Timer chatBoxUpdateTimer;

        private List<Tuple<double, string>> chatLogLines;
        private bool isChatBoxLoaded;
        private bool isChatFileLoaded;
        private double previousVideoPlayerTime;
        private int currentChatLogLinesIndex;

        Dictionary<string, string> ffzEmoticonChannelDictionary;
        Dictionary<string, string> ffzEmoticonDictionary;
        Dictionary<string, string> bttvEmoticonChannelDictionary;
        Dictionary<string, string> bttvEmoticonDictionary;
        dynamic badgeChannelSet;
        dynamic badgeSet;
        dynamic deserializedBadgeSet;
        dynamic deserializedBadgeChannelSet;

        string currentChannelId;

        static string previousChatLogLineId = "";

        private Gecko.AutoJSContext geckoJs;

        //Public Fields

        public Chat.ChatFile CurrentChat;

        //Dragging

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void draggerBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        //Initialization

        public ChatForm() {
            InitializeComponent();

            defaultBorderStyle = FormBorderStyle;
        }

        private void ChatForm_Load(object sender, EventArgs e) {
            MainForm.Instance.EnablingFullscreen += MainForm_EnablingFullscreen;
            MainForm.Instance.EnablingStickyChatBox += MainForm_EnablingStickyChatBox;
            MainForm.Instance.Move += MainForm_MoveMainForm;
            MainForm.Instance.EnablingHideChatBoxWindow += MainForm_EnablingHideChatBoxWindow;
            MainForm.Instance.EnablingHideChatBox += MainForm_EnablingHideChatBox;
            MainForm.Instance.ChangingChatOffset += MainForm_ChangingChatOffset;
            MainForm.Instance.EnablingTransparentChatBox += MainForm_EnablingTransparentChatBox;
            MainForm.Instance.LoadedVideo += MainForm_LoadedVideo;
            MainForm.Instance.FormClosing += MainForm_MainFormClosing;
            MainForm.Instance.MovingSeekBar += MainForm_MovingSeekBar;
            MainForm.Instance.LoadingVideo += MainForm_LoadingVideo;

            ControlBox = false;

            SetChatLogUpdateTimerTick();

            SubscribeFormInputToForm();

            LoadChatBoxWebControl();

            StickToVideoForm();

            LoadSavedUserSettings();
        }

        private void SubscribeFormInputToForm() {
            KeyPreview = true;
            KeyDown += Keyboard.FormInput.Form_KeyDown;
        }

        private void LoadChatBoxWebControl() {
            isChatBoxLoaded = false;

            chatBoxWebControl.Navigate(Chat.Constants.ChatBoxHtmlPath);

            geckoJs = new Gecko.AutoJSContext(chatBoxWebControl.Window);

            chatBoxWebControl.Document.Body.Style.CssText = "overflow:hidden";

            if (isWindowShown) {
                ShowScrollbars();
            } else {
                HideScrollbars();
            }

            isChatBoxLoaded = true;
        }

        private void LoadSavedUserSettings() {
            try {
                savedOffsets = JsonConvert.DeserializeObject<OrderedDictionary>(Properties.Settings.Default.SavedOffsets);
            } catch {
                savedOffsets = null;
            }
            if (savedOffsets == null) {
                savedOffsets = new OrderedDictionary();
            }

            if (Properties.Settings.Default.ChatFormSize.Width != -1) {
                ChatForm.Instance.Size = Properties.Settings.Default.ChatFormSize;
            }
            if (Properties.Settings.Default.ChatFormLocation.X != -1) {
                ChatForm.Instance.Location = Properties.Settings.Default.ChatFormLocation;
            }
        }

        private void ChatForm_FormClosing(object sender, FormClosingEventArgs e) {
            Application.Exit();
        }

        //Methods

        private void MainForm_MovingSeekBar(object sender, Forms.EventHandlers.MovingSeekBarEventArgs e) {
            ClearChatBox();
        }

        private void StickToVideoForm() {
            Location = new Point(MainForm.Instance.Location.X + MainForm.Instance.Width + chatBoxDistance, MainForm.Instance.Location.Y);
            Size = new Size(new Point(Width, MainForm.Instance.Height));
        }

        private void MainForm_EnablingHideChatBoxWindow(object sender, Forms.EventHandlers.EnablingSettingEventArgs e) {
            EnableWindow(!e.Enabling);

            BroadcastEnabledHiddenChatBoxWindow(e.Enabling);
        }

        private void MainForm_EnablingTransparentChatBox(object sender, Forms.EventHandlers.EnablingSettingEventArgs e) {
            if (e.Enabling) {
                TransparencyKey = transparencyKeyColor;
            } else {
                TransparencyKey = Color.FromArgb(1, 1, 1);
            }

            BroadcastEnabledTransparentChatBox(e.Enabling);
        }

        private void MainForm_EnablingHideChatBox(object sender, Forms.EventHandlers.EnablingSettingEventArgs e) {
            if (e.Enabling) {
                Hide();
            } else {
                Show();
            }

            BroadcastEnabledHiddenChatBox(e.Enabling);
        }

        private void MainForm_MoveMainForm(object sender, EventArgs e) {
            if (isStickyChatBoxEnabling) {
                StickToVideoForm();
            }
        }

        private void MainForm_ChangingChatOffset(object sender, Forms.EventHandlers.ChangingChatOffsetEventArgs e) {
            if (CurrentChat != null) {
                currentChatOffset += e.OffsetChange;
                BroadcastChangedChatOffsetEvent(currentChatOffset);
            }
        }

        private void MainForm_EnablingStickyChatBox(object sender, Forms.EventHandlers.EnablingSettingEventArgs e) {
            isStickyChatBoxEnabling = e.Enabling;

            if (isStickyChatBoxEnabling) {
                StickToVideoForm();
            }

            BroadcastEnabledStickyChatBox(e.Enabling);
        }

        private void EnableWindow(bool enable) {
            isWindowShown = enable;

            if (isWindowShown) {
                FormBorderStyle = defaultBorderStyle;
                draggerBox.Visible = false;
                if (isChatBoxLoaded) {
                    ShowScrollbars();
                }
            } else {
                FormBorderStyle = FormBorderStyle.None;
                draggerBox.Visible = true;
                if (isChatBoxLoaded) {
                    HideScrollbars();
                }
            }
        }

        void ShowScrollbars() {
            ExecuteJavascriptCommand("showScrollbars()");
        }

        void HideScrollbars() {
            ExecuteJavascriptCommand("hideScrollbars()");
        }

        private void MainForm_EnablingFullscreen(object sender, Forms.EventHandlers.EnablingSettingEventArgs e) {
            isFullscreen = e.Enabling;

            if (isStickyChatBoxEnabling) {
                if (isFullscreen) {
                    Location = new Point(Screen.PrimaryScreen.Bounds.Width - Width, 0);
                    Size = new Size(new Point(Width, MainForm.Instance.Height));
                } else {
                    StickToVideoForm();
                }
            }

            BroadcastEnabledFullscreen(e.Enabling);
        }

        private void SetChatBackgroundColor(Color color) {
            ExecuteJavascriptCommand("setChatBackgroundColor('rgb(" + color.R + ", " + color.G + ", " + color.B + ")')");
        }

        private void ExecuteJavascriptCommand(string command) {
            Instance.Invoke(new Action(() => {
                try {
                    geckoJs.EvaluateScript(command);
                } catch (Exception e) {
                    Console.WriteLine("Error executing javascript command: " + command + ", Reason: " + e.Message);
                }
            }));
        }

        private void SaveCurrentChatOffset() {
            if (CurrentChat != null) {
                if (savedOffsets.Contains(CurrentChat.FilePath)) { 
                    savedOffsets[CurrentChat.FilePath] = currentChatOffset;
                } else {
                    savedOffsets.Add(CurrentChat.FilePath, currentChatOffset);
                    if (savedOffsets.Count > maxSavedOffsetsCount) {
                        savedOffsets.RemoveAt(savedOffsets.Count - 1);
                    }
                }
                Properties.Settings.Default.SavedOffsets = JsonConvert.SerializeObject(savedOffsets);
                Properties.Settings.Default.Save();
            }
        }

        private void MainForm_MainFormClosing(object sender, EventArgs e) {
            SaveCurrentChatOffset();
        }

        private void MainForm_LoadedVideo(object sender, Forms.EventHandlers.LoadedVideoEventArgs e) {
            SaveCurrentChatOffset();

            string chatFilePath = GetChatFilePath(e.Video.FilePath);

            if (chatFilePath != null) {
                LoadChat(chatFilePath);
            } else {
                LoadChat(null);
            }
        }

        private string GetChatFilePath(string videoFilePath) {
            string chatFilePath = Path.GetDirectoryName(videoFilePath) + @"\" +
                Path.GetFileNameWithoutExtension(videoFilePath) + Chat.Constants.ChatFileExtension;
            if (File.Exists(chatFilePath)) {
                return chatFilePath;
            } else {
                return null;
            }
        }

        private void ShowChatLoadingDisplay() {
            ExecuteJavascriptCommand("showLoadingDisplay()");
        }

        private void MainForm_LoadingVideo(object sender, Forms.EventHandlers.LoadingVideoEventArgs e) {
            getChatLogLinesListTokenSource.Cancel();
            getChatLogLinesListTokenSource = new CancellationTokenSource();
            chatLogLines = null;
            ClearChatBox();
            ShowChatLoadingDisplay();
        }

        CancellationTokenSource getChatLogLinesListTokenSource = new CancellationTokenSource();

        public void LoadChat(string chatFilePath) {
            isChatFileLoaded = false;
            chatBoxUpdateTimer.Stop();
            if (chatFilePath != null) {
                Chat.ChatFile chatFile = new Chat.ChatFile(chatFilePath);
                Instance.Invoke(new Action(async () => {
                    Chat.MessageParser messageParser = new Chat.MessageParser();
                    ffzEmoticonChannelDictionary = messageParser.GetFfzEmoticonDictionary(chatFile.ChannelId);
                    ffzEmoticonDictionary = messageParser.GetFfzEmoticonDictionary("");
                    bttvEmoticonChannelDictionary = messageParser.GetBttvEmoticonDictionary(chatFile.ChannelId);
                    bttvEmoticonDictionary = messageParser.GetBttvEmoticonDictionary("");

                    badgeChannelSet = messageParser.GetBadgeSet(chatFile.ChannelId);
                    badgeSet = messageParser.GetBadgeSet("");
                    if (badgeSet != null) {
                        deserializedBadgeSet = JsonConvert.DeserializeObject<dynamic>(badgeSet.ToString());
                    }
                    if (badgeChannelSet != null) {
                        deserializedBadgeChannelSet = JsonConvert.DeserializeObject<dynamic>(badgeChannelSet.ToString());
                    }
                    currentChannelId = chatFile.ChannelId;

                    await Task.Run(() => GetChatLogLinesList(chatFilePath, getChatLogLinesListTokenSource.Token));

                    CurrentChat = chatFile;

                    if (savedOffsets.Contains(CurrentChat.FilePath)) {
                        currentChatOffset = (double)savedOffsets[CurrentChat.FilePath];
                    }

                    ClearChatBox();

                    chatBoxUpdateTimer.Start();
                }));
            } else {
                currentChannelId = null;
                chatLogLines = null;
                CurrentChat = null;

                ClearChatBox();
            }
            isChatFileLoaded = true;
        }

        private void GetChatLogLinesList(string chatFilePath, CancellationToken token) {
            chatLogLines = new List<Tuple<double, string>>();
            string[] separatedChatLogLine;
            char[] separators = new char[] { ':' };
            string chatLogLine;
            using (StreamReader streamReader = new StreamReader(chatFilePath)) {
                while ((chatLogLine = streamReader.ReadLine()) != null) {
                    if (token.IsCancellationRequested) {
                        return;
                    }
                    if (chatLogLine != "" && chatLogLine[0] != '~') {
                        try {
                            separatedChatLogLine = chatLogLine.Split(separators, 2);
                            chatLogLines.Add(new Tuple<double, string>(double.Parse(separatedChatLogLine[0]), separatedChatLogLine[1]));
                        } catch (Exception e) {
                            Console.WriteLine("Error reading chat line: " + chatLogLine + ", Reason: " + e.Message);
                        }
                    }
                }
            }
        }

        private void SetChatLogUpdateTimerTick() {
            previousVideoPlayerTime = 0;

            if (chatBoxUpdateTimer == null) {
                chatBoxUpdateTimer = new System.Windows.Forms.Timer();
                chatBoxUpdateTimer.Tick += new EventHandler(chatBoxUpdateTimer_Tick);
                chatBoxUpdateTimer.Interval = chatBoxUpdateTimerIntervalMilliseconds;
            }
        }

        private void chatBoxUpdateTimer_Tick(object sender, EventArgs e) {
            if (isChatBoxLoaded && isChatFileLoaded) {
                UpdateChatBox();
            }
        }

        CancellationTokenSource parseChatLogLineTokenSource = new CancellationTokenSource();
        private async void UpdateChatBox() {
            if (chatLogLines != null && chatLogLines.Count > 0 && !MainForm.Instance.IsVideoSeekBarClicked) {
                if (currentChatLogLinesIndex < chatLogLines.Count &&
                    chatLogLines[currentChatLogLinesIndex].Item1 <= (MainForm.Instance.VideoPlayerTime * 1000) + currentChatOffset) {

                    Func<string> parseChatLogLineFunction = new Func<string>(() => ParseChatLogLine(chatLogLines[currentChatLogLinesIndex].Item2, currentChannelId, parseChatLogLineTokenSource.Token));
                    string chatLogLine = await Task.Run<string>(parseChatLogLineFunction);

                    if (chatLogLine != null && chatLogLine != "") {
                        AddChatLine(chatLogLine);
                        currentChatLogLinesIndex++;
                    }
                }

                previousVideoPlayerTime = MainForm.Instance.VideoPlayerTime;
            }
        }

        public async void ClearChatBox() {
            if (chatLogLines != null && chatLogLines.Count > 0) {
                findCurrentChatLogLinesIndexTokenSource.Cancel();
                findCurrentChatLogLinesIndexTokenSource = new CancellationTokenSource();

                await Task.Run(() => FindCurrentChatLogLinesIndex(findCurrentChatLogLinesIndexTokenSource.Token, MainForm.Instance.VideoPlayerTime * 1000));
            }

            parseChatLogLineTokenSource.Cancel();
            parseChatLogLineTokenSource = new CancellationTokenSource();

            ExecuteJavascriptCommand("clearChatBox()");
        }

        CancellationTokenSource findCurrentChatLogLinesIndexTokenSource = new CancellationTokenSource();
        private void FindCurrentChatLogLinesIndex(CancellationToken token, double videoTime = 0) {
            if (chatLogLines != null) {
                for (int i = 0; i < chatLogLines.Count; i++) {
                    if (token.IsCancellationRequested) {
                        break;
                    } else if (chatLogLines[i].Item1 >= videoTime) {
                        currentChatLogLinesIndex = Math.Max(0, i - 10);
                        break;
                    }
                }
            }
        }

        private void AddChatLine(string chatLine) {
            ExecuteJavascriptCommand("addChatLine(\"" + chatLine + "\", true)");
        }

        private string ParseChatLogLine(string chatLogLine, string channelId, CancellationToken token) {
            dynamic deserializedChatLogLine = JsonConvert.DeserializeObject<JObject>(chatLogLine);

            if (deserializedChatLogLine._id.ToString() == previousChatLogLineId) {
                return "";
            }
            previousChatLogLineId = deserializedChatLogLine._id.ToString();

            if (deserializedChatLogLine.message == null) {
                return chatLogLine;
            }

            string convertedMessageBody = deserializedChatLogLine.message.body;
            string convertedBadgeBody = "";

            convertedMessageBody = convertedMessageBody.Replace("\"", "\\\"");

            //Parse Twitch Emoticons
            if (deserializedChatLogLine.message.emoticons != null) {
                convertedMessageBody = messageParser.ParseTwitchEmoticons(deserializedChatLogLine.message.emoticons, channelId, convertedMessageBody);
            }

            //Parse FFZ Emoticons
            convertedMessageBody = messageParser.ParseDictionaryEmoticons(ffzEmoticonDictionary, 
                new Fetching.Emoticons.FfzEmoticonDownloader(), Fetching.Constants.FfzEmoticonsDirectoryName, "", convertedMessageBody);
            convertedMessageBody = messageParser.ParseDictionaryEmoticons(ffzEmoticonChannelDictionary,
                new Fetching.Emoticons.FfzEmoticonDownloader(), Fetching.Constants.FfzEmoticonsDirectoryName, channelId, convertedMessageBody);

            //Parse BTTV Emoticons
            convertedMessageBody = messageParser.ParseDictionaryEmoticons(bttvEmoticonDictionary,
                new Fetching.Emoticons.BttvEmoticonDownloader(), Fetching.Constants.BttvEmoticonsDirectoryName, "", convertedMessageBody);
            convertedMessageBody = messageParser.ParseDictionaryEmoticons(bttvEmoticonChannelDictionary,
                new Fetching.Emoticons.BttvEmoticonDownloader(), Fetching.Constants.BttvEmoticonsDirectoryName, channelId, convertedMessageBody);

            //Parse Badges
            if (deserializedChatLogLine.message.user_badges != null) {
                convertedBadgeBody = messageParser.ParseBadgeSet(deserializedBadgeSet, deserializedChatLogLine.message.user_badges, "", convertedBadgeBody);
                convertedBadgeBody = messageParser.ParseBadgeSet(deserializedBadgeChannelSet, deserializedChatLogLine.message.user_badges, channelId, convertedBadgeBody);
            }

            convertedMessageBody = "&nbsp;" + convertedMessageBody + "&nbsp;";
            convertedBadgeBody = "&nbsp; " + convertedBadgeBody + "&nbsp;";

            if (token.IsCancellationRequested) {
                return null;
            }

            return (convertedBadgeBody + "<span style='color:" + deserializedChatLogLine.message.user_color + "'><b>" + deserializedChatLogLine.commenter.name + "</b> </span>:  " + convertedMessageBody + " <br><br>");
        }
    }
}
