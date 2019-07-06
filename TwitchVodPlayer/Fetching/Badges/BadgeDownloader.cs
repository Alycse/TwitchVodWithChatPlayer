namespace TwitchVodPlayer.Fetching.Badges {
    class BadgeDownloader {

        //Events

        public event Badges.EventHandlers.DownloadingBadgeEventHandler DownloadingBadge;
        protected virtual void OnDownloadingBadge(object sender, Badges.EventHandlers.DownloadingBadgeEventArgs e) {
            DownloadingBadge?.Invoke(this, e);
        }
        public event Badges.EventHandlers.NewProgressDownloadingBadgeEventHandler NewProgressDownloadingBadge;
        protected virtual void OnNewProgressDownloadingBadge(object sender, Badges.EventHandlers.NewProgressDownloadingBadgeEventArgs e) {
            NewProgressDownloadingBadge?.Invoke(this, e);
        }
        public event Badges.EventHandlers.DownloadedBadgeEventHandler DownloadedBadge;
        protected virtual void OnDownloadedBadge(object sender, Badges.EventHandlers.DownloadedBadgeEventArgs e) {
            DownloadedBadge?.Invoke(this, e);
        }
        public event Badges.EventHandlers.ErrorOccuredDownloadingBadgeEventHandler ErrorOccuredDownloadingBadge;
        protected virtual void OnErrorOccuredDownloadingBadge(object sender, Badges.EventHandlers.ErrorOccuredDownloadingBadgeEventArgs e) {
            ErrorOccuredDownloadingBadge?.Invoke(this, e);
        }

        //Event Broadcasts

        private void BroadcastDownloadingBadgeEvent(string message) {
            Badges.EventHandlers.DownloadingBadgeEventArgs e = new Badges.EventHandlers.DownloadingBadgeEventArgs();
            e.Message = message;
            OnDownloadingBadge(this, e);
        }
        private void BroadcastNewProgressDownloadingBadgeEvent(string message, int progress) {
            Badges.EventHandlers.NewProgressDownloadingBadgeEventArgs e = new Badges.EventHandlers.NewProgressDownloadingBadgeEventArgs();
            e.Message = message;
            e.Progress = progress;
            OnNewProgressDownloadingBadge(this, e);
        }
        public void BroadcastDownloadedBadgeEvent(string message) {
            Badges.EventHandlers.DownloadedBadgeEventArgs e = new Badges.EventHandlers.DownloadedBadgeEventArgs();
            e.Message = message;
            OnDownloadedBadge(this, e);
        }
        private void BroadcastErrorOccuredDownloadingBadgeEvent(string message) {
            Badges.EventHandlers.ErrorOccuredDownloadingBadgeEventArgs e = new Badges.EventHandlers.ErrorOccuredDownloadingBadgeEventArgs();
            e.Message = message;
            OnErrorOccuredDownloadingBadge(this, e);
        }

        //Methods

        public virtual void DownloadBadge(string badgeUrl, string filePath) {
            FileDownloader fileDownloader = new FileDownloader();
            fileDownloader.DownloadFile(badgeUrl, filePath);
        }

    }
}
