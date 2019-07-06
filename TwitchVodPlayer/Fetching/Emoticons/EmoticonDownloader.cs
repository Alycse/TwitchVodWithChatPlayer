namespace TwitchVodPlayer.Fetching.Emoticons {
    class EmoticonDownloader {

        //Events

        public event Emoticons.EventHandlers.DownloadingEmoticonEventHandler DownloadingEmoticon;
        protected virtual void OnDownloadingEmoticon(object sender, Emoticons.EventHandlers.DownloadingEmoticonEventArgs e) {
            DownloadingEmoticon?.Invoke(this, e);
        }
        public event Emoticons.EventHandlers.NewProgressDownloadingEmoticonEventHandler NewProgressDownloadingEmoticon;
        protected virtual void OnNewProgressDownloadingEmoticon(object sender, Emoticons.EventHandlers.NewProgressDownloadingEmoticonEventArgs e) {
            NewProgressDownloadingEmoticon?.Invoke(this, e);
        }
        public event Emoticons.EventHandlers.DownloadedEmoticonEventHandler DownloadedEmoticon;
        protected virtual void OnDownloadedEmoticon(object sender, Emoticons.EventHandlers.DownloadedEmoticonEventArgs e) {
            DownloadedEmoticon?.Invoke(this, e);
        }
        public event Emoticons.EventHandlers.ErrorOccuredDownloadingEmoticonEventHandler ErrorOccuredDownloadingEmoticon;
        protected virtual void OnErrorOccuredDownloadingEmoticon(object sender, Emoticons.EventHandlers.ErrorOccuredDownloadingEmoticonEventArgs e) {
            ErrorOccuredDownloadingEmoticon?.Invoke(this, e);
        }

        //Event Broadcasts

        private void BroadcastDownloadingEmoticonEvent(string message, Emoticons.Enumerations.EmoticonSource emoticonSource, string channelName) {
            Emoticons.EventHandlers.DownloadingEmoticonEventArgs e = new Emoticons.EventHandlers.DownloadingEmoticonEventArgs();
            e.Message = message;
            e.EmoticonSource = emoticonSource;
            e.ChannelName = channelName;
            OnDownloadingEmoticon(this, e);
        }
        private void BroadcastNewProgressDownloadingEmoticonEvent(string message, int progress) {
            Emoticons.EventHandlers.NewProgressDownloadingEmoticonEventArgs e = new Emoticons.EventHandlers.NewProgressDownloadingEmoticonEventArgs();
            e.Message = message;
            e.Progress = progress;
            OnNewProgressDownloadingEmoticon(this, e);
        }
        public void BroadcastDownloadedEmoticonEvent(string message, Emoticons.Enumerations.EmoticonSource emoticonSource, string channelName) {
            Emoticons.EventHandlers.DownloadedEmoticonEventArgs e = new Emoticons.EventHandlers.DownloadedEmoticonEventArgs();
            e.Message = message;
            e.EmoticonSource = emoticonSource;
            e.ChannelName = channelName;
            OnDownloadedEmoticon(this, e);
        }
        private void BroadcastErrorOccuredDownloadingEmoticonEvent(string message) {
            Emoticons.EventHandlers.ErrorOccuredDownloadingEmoticonEventArgs e = new Emoticons.EventHandlers.ErrorOccuredDownloadingEmoticonEventArgs();
            e.Message = message;
            OnErrorOccuredDownloadingEmoticon(this, e);
        }

        //Methods

        public virtual void DownloadEmoticon(string emoticonUrl, string filePath) {
            FileDownloader fileDownloader = new FileDownloader();
            fileDownloader.DownloadFile(emoticonUrl, filePath);
        }
    }
}
