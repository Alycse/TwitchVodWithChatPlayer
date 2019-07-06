using System;

namespace TwitchVodPlayer.Fetching {
    class EventHandlers {

        public delegate void DownloadingFileEventHandler(object sender, DownloadingFileEventArgs e);
        public delegate void NewProgressDownloadingFileEventHandler(object sender, NewProgressDownloadingFileEventArgs e);
        public delegate void DownloadedFileEventHandler(object sender, DownloadedFileEventArgs e);
        public delegate void ErrorOccuredDownloadingFileEventHandler(object sender, ErrorOccuredDownloadingFileEventArgs e);

        public class DownloadingFileEventArgs : EventArgs {
            public string Message {
                get; set;
            }
        }
        public class NewProgressDownloadingFileEventArgs : EventArgs {
            public string Message {
                get; set;
            }
            public int Progress {
                get; set;
            }
        }
        public class DownloadedFileEventArgs : EventArgs {
            public string Message {
                get; set;
            }
        }
        public class ErrorOccuredDownloadingFileEventArgs : EventArgs {
            public string Message {
                get; set;
            }
        }

        public delegate void TestingClientIdEventHandler(object sender, TestingClientIdEventArgs e);
        public delegate void NewProgressTestingClientIdEventHandler(object sender, NewProgressTestingClientIdEventArgs e);
        public delegate void TestedClientIdEventHandler(object sender, TestedClientIdEventArgs e);
        public delegate void ErrorOccuredTestingClientIdEventHandler(object sender, ErrorOccuredTestingClientIdEventArgs e);

        public class TestingClientIdEventArgs : EventArgs {
            public string Message {
                get; set;
            }
        }
        public class NewProgressTestingClientIdEventArgs : EventArgs {
            public string Message {
                get; set;
            }
            public int Progress {
                get; set;
            }
        }
        public class TestedClientIdEventArgs : EventArgs {
            public string Message {
                get; set;
            }
            public string ClientId {
                get; set;
            }
        }
        public class ErrorOccuredTestingClientIdEventArgs : EventArgs {
            public string Message {
                get; set;
            }
        }

    }
}
