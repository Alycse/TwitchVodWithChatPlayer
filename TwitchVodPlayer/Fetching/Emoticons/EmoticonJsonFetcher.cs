namespace TwitchVodPlayer.Fetching.Emoticons {
    class EmoticonJsonFetcher {

        //Events

        public event Emoticons.EventHandlers.FetchingEmoticonJsonEventHandler FetchingEmoticonJson;
        protected virtual void OnFetchingEmoticonJson(object sender, Emoticons.EventHandlers.FetchingEmoticonJsonEventArgs e) {
            FetchingEmoticonJson?.Invoke(this, e);
        }
        public event Emoticons.EventHandlers.NewProgressFetchingEmoticonJsonEventHandler NewProgressFetchingEmoticonJson;
        protected virtual void OnNewProgressFetchingEmoticonJson(object sender, Emoticons.EventHandlers.NewProgressFetchingEmoticonJsonEventArgs e) {
            NewProgressFetchingEmoticonJson?.Invoke(this, e);
        }
        public event Emoticons.EventHandlers.FetchedEmoticonJsonEventHandler FetchedEmoticonJson;
        protected virtual void OnFetchedEmoticonJson(object sender, Emoticons.EventHandlers.FetchedEmoticonJsonEventArgs e) {
            FetchedEmoticonJson?.Invoke(this, e);
        }
        public event Emoticons.EventHandlers.ErrorOccuredFetchingEmoticonJsonEventHandler ErrorOccuredFetchingEmoticonJson;
        protected virtual void OnErrorOccuredFetchingEmoticonJson(object sender, Emoticons.EventHandlers.ErrorOccuredFetchingEmoticonJsonEventArgs e) {
            ErrorOccuredFetchingEmoticonJson?.Invoke(this, e);
        }

        //Event Broadcasts

        protected void BroadcastFetchingEmoticonJsonEvent(string message, Emoticons.Enumerations.EmoticonSource emoticonSource, string channelName) {
            Emoticons.EventHandlers.FetchingEmoticonJsonEventArgs e = new Emoticons.EventHandlers.FetchingEmoticonJsonEventArgs();
            e.Message = message;
            e.EmoticonSource = emoticonSource;
            e.ChannelName = channelName;
            OnFetchingEmoticonJson(this, e);
        }
        protected void BroadcastNewProgressFetchingEmoticonJsonEvent(string message, int progress) {
            Emoticons.EventHandlers.NewProgressFetchingEmoticonJsonEventArgs e = new Emoticons.EventHandlers.NewProgressFetchingEmoticonJsonEventArgs();
            e.Message = message;
            e.Progress = progress;
            OnNewProgressFetchingEmoticonJson(this, e);
        }
        protected void BroadcastFetchedEmoticonJsonEvent(string message, Emoticons.Enumerations.EmoticonSource emoticonSource, string channelName) {
            Emoticons.EventHandlers.FetchedEmoticonJsonEventArgs e = new Emoticons.EventHandlers.FetchedEmoticonJsonEventArgs();
            e.Message = message;
            e.EmoticonSource = emoticonSource;
            e.ChannelName = channelName;
            OnFetchedEmoticonJson(this, e);
        }
        protected void BroadcastErrorOccuredFetchingEmoticonJsonEvent(string message) {
            Emoticons.EventHandlers.ErrorOccuredFetchingEmoticonJsonEventArgs e = new Emoticons.EventHandlers.ErrorOccuredFetchingEmoticonJsonEventArgs();
            e.Message = message;
            OnErrorOccuredFetchingEmoticonJson(this, e);
        }

    }
}
