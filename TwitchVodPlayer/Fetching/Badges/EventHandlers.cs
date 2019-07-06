using System;

namespace TwitchVodPlayer.Fetching.Badges {
    class EventHandlers {
        public delegate void FetchingBadgeEventHandler(object sender, FetchingBadgeEventArgs e);
        public delegate void NewProgressFetchingBadgeEventHandler(object sender, NewProgressFetchingBadgeEventArgs e);
        public delegate void FetchedBadgeEventHandler(object sender, FetchedBadgeEventArgs e);
        public delegate void ErrorOccuredFetchingBadgeEventHandler(object sender, ErrorOccuredFetchingBadgeEventArgs e);

        public class FetchingBadgeEventArgs : EventArgs {
            public string Message {
                get; set;
            }
            public string ChannelName {
                get; set;
            }
        }
        public class NewProgressFetchingBadgeEventArgs : EventArgs {
            public string Message {
                get; set;
            }
            public int Progress {
                get; set;
            }
        }
        public class FetchedBadgeEventArgs : EventArgs {
            public string Message {
                get; set;
            }
            public string ChannelName {
                get; set;
            }
        }
        public class ErrorOccuredFetchingBadgeEventArgs : EventArgs {
            public string Message {
                get; set;
            }
        }

        public delegate void DownloadingBadgeEventHandler(object sender, DownloadingBadgeEventArgs e);
        public delegate void NewProgressDownloadingBadgeEventHandler(object sender, NewProgressDownloadingBadgeEventArgs e);
        public delegate void DownloadedBadgeEventHandler(object sender, DownloadedBadgeEventArgs e);
        public delegate void ErrorOccuredDownloadingBadgeEventHandler(object sender, ErrorOccuredDownloadingBadgeEventArgs e);

        public class DownloadingBadgeEventArgs : EventArgs {
            public string Message {
                get; set;
            }
            public string ChannelName {
                get; set;
            }
        }
        public class NewProgressDownloadingBadgeEventArgs : EventArgs {
            public string Message {
                get; set;
            }
            public int Progress {
                get; set;
            }
        }
        public class DownloadedBadgeEventArgs : EventArgs {
            public string Message {
                get; set;
            }
            public string ChannelName {
                get; set;
            }
        }
        public class ErrorOccuredDownloadingBadgeEventArgs : EventArgs {
            public string Message {
                get; set;
            }
        }
    }
}
