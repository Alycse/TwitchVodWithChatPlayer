using System.IO;
using System.Net;

namespace TwitchVodPlayer.Fetching.Badges {
    class BadgeFetcher {

        //Events

        public event Badges.EventHandlers.FetchingBadgeEventHandler FetchingBadge;
        protected virtual void OnFetchingBadge(object sender, Badges.EventHandlers.FetchingBadgeEventArgs e) {
            FetchingBadge?.Invoke(this, e);
        }
        public event Badges.EventHandlers.NewProgressFetchingBadgeEventHandler NewProgressFetchingBadge;
        protected virtual void OnNewProgressFetchingBadge(object sender, Badges.EventHandlers.NewProgressFetchingBadgeEventArgs e) {
            NewProgressFetchingBadge?.Invoke(this, e);
        }
        public event Badges.EventHandlers.FetchedBadgeEventHandler FetchedBadge;
        protected virtual void OnFetchedBadge(object sender, Badges.EventHandlers.FetchedBadgeEventArgs e) {
            FetchedBadge?.Invoke(this, e);
        }
        public event Badges.EventHandlers.ErrorOccuredFetchingBadgeEventHandler ErrorOccuredFetchingBadge;
        protected virtual void OnErrorOccuredFetchingBadge(object sender, Badges.EventHandlers.ErrorOccuredFetchingBadgeEventArgs e) {
            ErrorOccuredFetchingBadge?.Invoke(this, e);
        }

        //Event Broadcasts

        private void BroadcastFetchingBadgeEvent(string message) {
            Badges.EventHandlers.FetchingBadgeEventArgs e = new Badges.EventHandlers.FetchingBadgeEventArgs();
            e.Message = message;
            OnFetchingBadge(this, e);
        }
        private void BroadcastNewProgressFetchingBadgeEvent(string message, int progress) {
            Badges.EventHandlers.NewProgressFetchingBadgeEventArgs e = new Badges.EventHandlers.NewProgressFetchingBadgeEventArgs();
            e.Message = message;
            e.Progress = progress;
            OnNewProgressFetchingBadge(this, e);
        }
        public void BroadcastFetchedBadgeEvent(string message) {
            Badges.EventHandlers.FetchedBadgeEventArgs e = new Badges.EventHandlers.FetchedBadgeEventArgs();
            e.Message = message;
            OnFetchedBadge(this, e);
        }
        private void BroadcastErrorOccuredFetchingBadgeEvent(string message) {
            Badges.EventHandlers.ErrorOccuredFetchingBadgeEventArgs e = new Badges.EventHandlers.ErrorOccuredFetchingBadgeEventArgs();
            e.Message = message;
            OnErrorOccuredFetchingBadge(this, e);
        }

        //Methods

        public void GetBadgesJson(string channelId, string channelName, bool forceDownloadJson) {
            if (!Directory.Exists(Fetching.Constants.JsonPath)) {
                Directory.CreateDirectory(Fetching.Constants.JsonPath);
            }

            using (WebClient wc = new WebClient()) {
                string url;
                string jsonFileName;
                if (channelId == "") {
                    url = Fetching.Constants.BadgesUrl;
                    jsonFileName = Fetching.Constants.BadgeJsonFileName;
                } else {
                    url = Fetching.Constants.BadgesChannelUrl.Replace("<channelId>", channelId);
                    jsonFileName = Fetching.Constants.BadgeJsonFileName + "_" + channelId;
                }

                string filePath = Fetching.Constants.JsonPath + jsonFileName + ".json";
                if (!forceDownloadJson && File.Exists(filePath)) {
                    return;
                }

                HttpWebRequest request = (HttpWebRequest)System.Net.HttpWebRequest.Create(url);
                request.Method = "GET";
                using (var response = (HttpWebResponse)request.GetResponse()) {
                    using (Stream streamResponse = response.GetResponseStream()) {
                        long lContentLen = response.ContentLength;
                        byte[] byteArray = null;
                        byteArray = new byte[lContentLen];
                        for (long index = 0; index < lContentLen; index++) {
                            byteArray[index] = (byte)streamResponse.ReadByte();
                        }
                        using (Stream strWrite = File.Open(filePath, FileMode.Create)) {
                            using (BinaryWriter binaryWriter = new BinaryWriter(strWrite)) {
                                binaryWriter.Write(byteArray);
                            }
                        }
                    }
                }
            }
        }

    }
}
