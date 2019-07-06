using System;

namespace TwitchVodPlayer.Resources {
    class EventHandlers {

        public delegate void DownloadingResourcesEventHandler(object sender, DownloadingResourcesEventArgs e);
        public delegate void NewProgressDownloadingResourcesEventHandler(object sender, NewProgressDownloadingResourcesEventArgs e);
        public delegate void DownloadedResourcesEventHandler(object sender, DownloadedResourcesEventArgs e);
        public delegate void ErrorOccuredDownloadingResourcesEventHandler(object sender, ErrorOccuredDownloadingResourcesEventArgs e);

        public class DownloadingResourcesEventArgs : EventArgs {
            public string Message {
                get; set;
            }
        }
        public class NewProgressDownloadingResourcesEventArgs : EventArgs {
            public string Message {
                get; set;
            }
            public int Progress {
                get; set;
            }
        }
        public class DownloadedResourcesEventArgs : EventArgs {
            public string Message {
                get; set;
            }
        }
        public class ErrorOccuredDownloadingResourcesEventArgs : EventArgs {
            public string Message {
                get; set;
            }
        }

    }
}
