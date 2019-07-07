using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace TwitchVodPlayer.Chat {
    class ChatFileCreator {

        //Fields

        private static bool currentlyCreatingChatFile = false;
        public static bool CurrentlyCreatingChatFile {
            get {
                return currentlyCreatingChatFile;
            }
            set {
                currentlyCreatingChatFile = value;
            }
        }

        public static CancellationTokenSource CreateChatFileTokenSource = new CancellationTokenSource();

        //Events

        public event Chat.EventHandlers.CreatingChatFileEventHandler CreatingChatFile;
        protected virtual void OnCreatingChatFile(object sender, Chat.EventHandlers.CreatingChatFileEventArgs e) {
            CreatingChatFile?.Invoke(this, e);
        }
        public event Chat.EventHandlers.NewProgressCreatingChatFileEventHandler NewProgressCreatingChatFile;
        protected virtual void OnNewProgressCreatingChatFile(object sender, Chat.EventHandlers.NewProgressCreatingChatFileEventArgs e) {
            NewProgressCreatingChatFile?.Invoke(this, e);
        }
        public event Chat.EventHandlers.CreatedChatFileEventHandler CreatedChatFile;
        protected virtual void OnCreatedChatFile(object sender, Chat.EventHandlers.CreatedChatFileEventArgs e) {
            CreatedChatFile?.Invoke(this, e);
        }
        public event Chat.EventHandlers.ErrorOccuredCreatingChatFileEventHandler ErrorOccuredCreatingChatFile;
        protected virtual void OnErrorOccuredCreatingChatFile(object sender, Chat.EventHandlers.ErrorOccuredCreatingChatFileEventArgs e) {
            ErrorOccuredCreatingChatFile?.Invoke(this, e);
        }

        //Event Broadcasts

        private void BroadcastCreatingChatFileEvent(string message) {
            Chat.EventHandlers.CreatingChatFileEventArgs e = new Chat.EventHandlers.CreatingChatFileEventArgs();
            e.Message = message;
            OnCreatingChatFile(this, e);
        }
        private void BroadcastNewProgressCreatingChatFileEvent(string message, int progress, int taskBarProgress) {
            Chat.EventHandlers.NewProgressCreatingChatFileEventArgs e = new Chat.EventHandlers.NewProgressCreatingChatFileEventArgs();
            e.Message = message;
            e.Progress = progress;
            e.TaskBarProgress = taskBarProgress;
            OnNewProgressCreatingChatFile(this, e);
        }
        public void BroadcastCreatedChatFileEvent(string message, string filePath) {
            Chat.EventHandlers.CreatedChatFileEventArgs e = new Chat.EventHandlers.CreatedChatFileEventArgs();
            e.Message = message;
            e.FilePath = filePath;
            OnCreatedChatFile(this, e);
        }
        private void BroadcastErrorOccuredCreatingChatFileEvent(string message) {
            Chat.EventHandlers.ErrorOccuredCreatingChatFileEventArgs e = new Chat.EventHandlers.ErrorOccuredCreatingChatFileEventArgs();
            e.Message = message;
            OnErrorOccuredCreatingChatFile(this, e);
        }

        //Methods

        public void Cancel() {
            CreateChatFileTokenSource.Cancel();
        }

        public async void CreateChatFile(string outputPath, string chatLogFilePath, string vodId,
            bool useVodId, bool setTime, TimeSpan? beginTime, TimeSpan? endTime, Video.VideoFile currentVideo = null) {

            CreateChatFileTokenSource = new CancellationTokenSource();

            if (CurrentlyCreatingChatFile) {
                return;
            }
            CurrentlyCreatingChatFile = true;

            BroadcastCreatingChatFileEvent("Creating Chat file...\nPlease wait while the program is connecting.");

            //Input validation
            if (outputPath == "") {
                BroadcastErrorOccuredCreatingChatFileEvent("You must specify the output directory for this VOD Set.");
                CurrentlyCreatingChatFile = false;
                return;
            } else if (chatLogFilePath == "" && !useVodId) {
                BroadcastErrorOccuredCreatingChatFileEvent("You must specify the path of the chat log file.");
                CurrentlyCreatingChatFile = false;
                return;
            } else if (useVodId && vodId == "") {
                BroadcastErrorOccuredCreatingChatFileEvent("VOD ID cannot be empty.");
                CurrentlyCreatingChatFile = false;
                return;
            } else if (Properties.Settings.Default.ClientId == "") {
                BroadcastErrorOccuredCreatingChatFileEvent("Your Twitch Client ID hasn't been set up yet.\nPlease set up your Client ID first before creating a VOD Set.");
                CurrentlyCreatingChatFile = false;
                return;
            } else if (setTime && (beginTime == null || endTime == null)) {
                BroadcastErrorOccuredCreatingChatFileEvent("Invalid Begin Time or End Time.");
                CurrentlyCreatingChatFile = false;
                return;
            }

            if (!setTime && currentVideo != null) {
                beginTime = TimeSpan.FromMilliseconds(0);
                endTime = currentVideo.EndTime;
            }

            if (useVodId) {
                chatLogFilePath = outputPath + @"\" + (vodId + ".json");

                try {
                    await Task.Run(() => DownloadChatLogFileUsingVodId(chatLogFilePath, vodId, beginTime, endTime));
                } catch (Exception e) {
                    BroadcastErrorOccuredCreatingChatFileEvent("Error occured creating VOD Set directory: " + e.Message);
                    CurrentlyCreatingChatFile = false;
                    return;
                }
            }

            if (CreateChatFileTokenSource.IsCancellationRequested) {
                if (File.Exists(chatLogFilePath)) {
                    File.Delete(chatLogFilePath);
                }
                BroadcastErrorOccuredCreatingChatFileEvent("Creation of chat file was cancelled.");
                CurrentlyCreatingChatFile = false;
                return;
            }

            string chatOutputFilePath;
            if (currentVideo != null) {
                chatOutputFilePath = outputPath + @"\" + Path.GetFileNameWithoutExtension(currentVideo.FilePath) + Chat.Constants.ChatFileExtension;
            } else {
                chatOutputFilePath = outputPath + @"\" + Path.GetFileNameWithoutExtension(chatLogFilePath) + Chat.Constants.ChatFileExtension;
            }

            try {
                //This creates the .cht Chat File
                await Task.Run(() => ConvertChatLog(chatLogFilePath, chatOutputFilePath, beginTime, endTime));

                if (useVodId && File.Exists(chatLogFilePath)) {
                    File.Delete(chatLogFilePath);
                }
            } catch (Exception e) {
                BroadcastErrorOccuredCreatingChatFileEvent("Error occured converting chat log: " + e.Message);
                CurrentlyCreatingChatFile = false;
                return;
            }

            if (CreateChatFileTokenSource.IsCancellationRequested) {
                if (File.Exists(chatLogFilePath)) {
                    File.Delete(chatLogFilePath);
                }
                if (File.Exists(chatOutputFilePath)) {
                    File.Delete(chatOutputFilePath);
                }
                BroadcastErrorOccuredCreatingChatFileEvent("Creation of chat file was cancelled.");
                CurrentlyCreatingChatFile = false;
                return;
            }

            BroadcastCreatedChatFileEvent("Successfully created chat file!", chatOutputFilePath);

            CurrentlyCreatingChatFile = false;
        }

        private void ConvertChatLog(string chatLogFilePath, string outputFilePath, TimeSpan? beginTime, TimeSpan? endTime) {
            Chat.ChatLogConverter chatLogConverter = new Chat.ChatLogConverter();

            chatLogConverter.NewProgressConvertingChatLog += chatLogConverter_NewProgress;

            chatLogConverter.ConvertChatLog(CreateChatFileTokenSource.Token, chatLogFilePath, outputFilePath, beginTime, endTime);

            chatLogConverter.NewProgressConvertingChatLog -= chatLogConverter_NewProgress;
        }

        private void rechat_NewProgress(object sender, dynamic e) {
            BroadcastNewProgressCreatingChatFileEvent(e.Message, e.Progress, 0);
        }

        private void chatLogConverter_NewProgress(object sender, dynamic e) {
            BroadcastNewProgressCreatingChatFileEvent(e.Message, e.Progress, e.TaskBarProgress);
        }

        private void DownloadChatLogFileUsingVodId(string chatLogFilePath, string vodId, TimeSpan? beginTime, TimeSpan? endTime) {
            Fetching.RechatTool.Rechat rechat = new Fetching.RechatTool.Rechat();

            rechat.NewProgressDownloadingChatLog += rechat_NewProgress;

            rechat.DownloadFile(CreateChatFileTokenSource.Token, long.Parse(vodId), chatLogFilePath, beginTime, endTime);

            rechat.NewProgressDownloadingChatLog -= rechat_NewProgress;
        }

    }
}
