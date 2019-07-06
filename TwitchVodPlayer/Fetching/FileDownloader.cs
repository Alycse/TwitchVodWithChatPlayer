using System;
using System.IO;
using System.Net;

namespace TwitchVodPlayer.Fetching {
    class FileDownloader {

        //Events

        public event Fetching.EventHandlers.DownloadingFileEventHandler DownloadingFile;
        protected virtual void OnDownloadingFile(object sender, Fetching.EventHandlers.DownloadingFileEventArgs e) {
            DownloadingFile?.Invoke(this, e);
        }
        public event Fetching.EventHandlers.NewProgressDownloadingFileEventHandler NewProgressDownloadingFile;
        protected virtual void OnNewProgressDownloadingFile(object sender, Fetching.EventHandlers.NewProgressDownloadingFileEventArgs e) {
            NewProgressDownloadingFile?.Invoke(this, e);
        }
        public event Fetching.EventHandlers.DownloadedFileEventHandler DownloadedFile;
        protected virtual void OnDownloadedFile(object sender, Fetching.EventHandlers.DownloadedFileEventArgs e) {
            DownloadedFile?.Invoke(this, e);
        }
        public event Fetching.EventHandlers.ErrorOccuredDownloadingFileEventHandler ErrorOccuredDownloadingFile;
        protected virtual void OnErrorOccuredDownloadingFile(object sender, Fetching.EventHandlers.ErrorOccuredDownloadingFileEventArgs e) {
            ErrorOccuredDownloadingFile?.Invoke(this, e);
        }

        //Event Broadcasts

        private void BroadcastDownloadingFileEvent(string message) {
            Fetching.EventHandlers.DownloadingFileEventArgs e = new Fetching.EventHandlers.DownloadingFileEventArgs();
            e.Message = message;
            OnDownloadingFile(this, e);
        }
        private void BroadcastNewProgressDownloadingFileEvent(string message, int progress) {
            Fetching.EventHandlers.NewProgressDownloadingFileEventArgs e = new Fetching.EventHandlers.NewProgressDownloadingFileEventArgs();
            e.Message = message;
            e.Progress = progress;
            OnNewProgressDownloadingFile(this, e);
        }
        public void BroadcastDownloadedFileEvent(string message) {
            Fetching.EventHandlers.DownloadedFileEventArgs e = new Fetching.EventHandlers.DownloadedFileEventArgs();
            e.Message = message;
            OnDownloadedFile(this, e);
        }
        private void BroadcastErrorOccuredDownloadingFileEvent(string message) {
            Fetching.EventHandlers.ErrorOccuredDownloadingFileEventArgs e = new Fetching.EventHandlers.ErrorOccuredDownloadingFileEventArgs();
            e.Message = message;
            OnErrorOccuredDownloadingFile(this, e);
        }

        public void DownloadFile(string url, string filePath) {
            if (!File.Exists(filePath)) {
                if (System.Net.ServicePointManager.SecurityProtocol != System.Net.SecurityProtocolType.Tls12) {
                    System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                }
                System.IO.FileInfo file = new System.IO.FileInfo(filePath);
                file.Directory.Create();
                using (WebClient client = new WebClient()) {
                    try {
                        client.DownloadFileAsync(new Uri(url), filePath);
                    } catch (Exception e) {
                        throw e;
                    }
                }
            }
        }

    }
}
