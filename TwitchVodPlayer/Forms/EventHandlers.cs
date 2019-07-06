using System;

namespace TwitchVodPlayer.Forms {
    public class EventHandlers {

        public delegate void VideoPlayerEndedEventHandler(object sender, EventArgs e);

        public delegate void CreatedChatFileEventHandler(object sender, EventArgs e);

        public delegate void DownloadedResourcesEventHandler(object sender, EventArgs e);

        //

        public delegate void MovingSeekBarEventHandler(object sender, MovingSeekBarEventArgs e);

        public class MovingSeekBarEventArgs : EventArgs {
            public int NewSeekBarValue {
                get; set;
            }
        }

        public delegate void MovedSeekBarEventHandler(object sender, MovedSeekBarEventArgs e);

        public class MovedSeekBarEventArgs : EventArgs {
            public int NewSeekBarValue {
                get; set;
            }
        }

        public delegate void ChangingChatOffsetEventHandler(object sender, ChangingChatOffsetEventArgs e);

        public class ChangingChatOffsetEventArgs : EventArgs {
            public double OffsetChange {
                get; set;
            }
        }

        public delegate void ChangedChatOffsetEventHandler(object sender, ChangedChatOffsetEventArgs e);

        public class ChangedChatOffsetEventArgs : EventArgs {
            public double NewOffset {
                get; set;
            }
        }

        public delegate void EnablingSettingEventHandler(object sender, EnablingSettingEventArgs e);

        public class EnablingSettingEventArgs : EventArgs {
            public bool Enabling {
                get; set;
            }
        }

        public delegate void EnabledSettingEventHandler(object sender, EnabledSettingEventArgs e);

        public class EnabledSettingEventArgs : EventArgs {
            public bool Enabled {
                get; set;
            }
        }

        public delegate void LoadingVideoEventHandler(object sender, LoadingVideoEventArgs e);
        public delegate void NewProgressLoadingVideoEventHandler(object sender, NewProgressLoadingVideoEventArgs e);
        public delegate void LoadedVideoEventHandler(object sender, LoadedVideoEventArgs e);
        public delegate void ErrorOccuredLoadingVideoEventHandler(object sender, ErrorOccuredLoadingVideoEventArgs e);

        public class LoadingVideoEventArgs : EventArgs {
            public Video.VideoFile Video {
                get; set;
            }
        }
        public class NewProgressLoadingVideoEventArgs : EventArgs {
            public string Message {
                get; set;
            }
            public int Progress {
                get; set;
            }
        }
        public class LoadedVideoEventArgs : EventArgs {
            public Video.VideoFile Video {
                get; set;
            }
            public double Time {
                get; set;
            }
        }
        public class ErrorOccuredLoadingVideoEventArgs : EventArgs {
            public string Message {
                get; set;
            }
        }

    }
}
