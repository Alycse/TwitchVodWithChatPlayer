using System;

namespace TwitchVodPlayer.Fetching.Emoticons {
    class EventHandlers {

        public delegate void FetchingEmoticonJsonEventHandler(object sender, FetchingEmoticonJsonEventArgs e);
        public delegate void NewProgressFetchingEmoticonJsonEventHandler(object sender, NewProgressFetchingEmoticonJsonEventArgs e);
        public delegate void FetchedEmoticonJsonEventHandler(object sender, FetchedEmoticonJsonEventArgs e);
        public delegate void ErrorOccuredFetchingEmoticonJsonEventHandler(object sender, ErrorOccuredFetchingEmoticonJsonEventArgs e);

        public class FetchingEmoticonJsonEventArgs : EventArgs {
            public string Message {
                get; set;
            }
            public Emoticons.Enumerations.EmoticonSource EmoticonSource {
                get; set;
            }
            public string ChannelName {
                get; set;
            }
        }
        public class NewProgressFetchingEmoticonJsonEventArgs : EventArgs {
            public string Message {
                get; set;
            }
            public int Progress {
                get; set;
            }
        }
        public class FetchedEmoticonJsonEventArgs : EventArgs {
            public string Message {
                get; set;
            }
            public Emoticons.Enumerations.EmoticonSource EmoticonSource {
                get; set;
            }
            public string ChannelName {
                get; set;
            }
        }
        public class ErrorOccuredFetchingEmoticonJsonEventArgs : EventArgs {
            public string Message {
                get; set;
            }
        }

        public delegate void DownloadingEmoticonEventHandler(object sender, DownloadingEmoticonEventArgs e);
        public delegate void NewProgressDownloadingEmoticonEventHandler(object sender, NewProgressDownloadingEmoticonEventArgs e);
        public delegate void DownloadedEmoticonEventHandler(object sender, DownloadedEmoticonEventArgs e);
        public delegate void ErrorOccuredDownloadingEmoticonEventHandler(object sender, ErrorOccuredDownloadingEmoticonEventArgs e);

        public class DownloadingEmoticonEventArgs : EventArgs {
            public string Message {
                get; set;
            }
            public Emoticons.Enumerations.EmoticonSource EmoticonSource {
                get; set;
            }
            public string ChannelName {
                get; set;
            }
        }
        public class NewProgressDownloadingEmoticonEventArgs : EventArgs {
            public string Message {
                get; set;
            }
            public int Progress {
                get; set;
            }
        }
        public class DownloadedEmoticonEventArgs : EventArgs {
            public string Message {
                get; set;
            }
            public Emoticons.Enumerations.EmoticonSource EmoticonSource {
                get; set;
            }
            public string ChannelName {
                get; set;
            }
        }
        public class ErrorOccuredDownloadingEmoticonEventArgs : EventArgs {
            public string Message {
                get; set;
            }
        }

    }
}
