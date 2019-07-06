using System;

namespace TwitchVodPlayer.Fetching.RechatTool {
    class EventHandlers {

        public delegate void DownloadingChatLogEventHandler(object sender, DownloadingChatLogEventArgs e);
        public delegate void NewProgressDownloadingChatLogEventHandler(object sender, NewProgressDownloadingChatLogEventArgs e);
        public delegate void DownloadedChatLogEventHandler(object sender, DownloadedChatLogEventArgs e);
        public delegate void ErrorOccuredDownloadingChatLogEventHandler(object sender, ErrorOccuredDownloadingChatLogEventArgs e);

        public class DownloadingChatLogEventArgs : EventArgs {
            public string Message {
                get; set;
            }
        }
        public class NewProgressDownloadingChatLogEventArgs : EventArgs {
            public string Message {
                get; set;
            }
            public int Progress {
                get; set;
            }
        }
        public class DownloadedChatLogEventArgs : EventArgs {
            public string Message {
                get; set;
            }
        }
        public class ErrorOccuredDownloadingChatLogEventArgs : EventArgs {
            public string Message {
                get; set;
            }
        }

    }
}
