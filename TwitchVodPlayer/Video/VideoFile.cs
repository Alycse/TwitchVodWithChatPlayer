using System;
using WMPLib;

namespace TwitchVodPlayer.Video {
    public class VideoFile {
        private string filePath;
        private TimeSpan endTime;

        public VideoFile(string filePath) {
            this.filePath = filePath;
            WindowsMediaPlayerClass wmp = new WindowsMediaPlayerClass();
            WMPLib.IWMPMedia media = wmp.newMedia(filePath);
            TimeSpan videoLength = TimeSpan.FromSeconds((int)media.duration);
            this.endTime = videoLength;
        }

        public string FilePath {
            get => filePath;
            set => filePath = value;
        }
        public TimeSpan EndTime {
            get => endTime;
            set => endTime = value;
        }
    }
}
