using System;
using System.Threading.Tasks;

namespace TwitchVodPlayer.Resources {
    class ResourceDownloader {

        //Fields

        public bool CurrentlyDownloadingResources = false;

        //Events

        public event Resources.EventHandlers.DownloadingResourcesEventHandler DownloadingResources;
        private void OnDownloadingResources(object sender, Resources.EventHandlers.DownloadingResourcesEventArgs e) {
            DownloadingResources?.Invoke(this, e);
        }
        public event Resources.EventHandlers.NewProgressDownloadingResourcesEventHandler NewProgressDownloadingResources;
        private void OnNewProgressDownloadingResources(object sender, Resources.EventHandlers.NewProgressDownloadingResourcesEventArgs e) {
            NewProgressDownloadingResources?.Invoke(this, e);
        }
        public event Resources.EventHandlers.DownloadedResourcesEventHandler DownloadedResources;
        private void OnDownloadedResources(object sender, Resources.EventHandlers.DownloadedResourcesEventArgs e) {
            DownloadedResources?.Invoke(this, e);
        }
        public event Resources.EventHandlers.ErrorOccuredDownloadingResourcesEventHandler ErrorOccuredDownloadingResources;
        private void OnErrorOccuredDownloadingResources(object sender, Resources.EventHandlers.ErrorOccuredDownloadingResourcesEventArgs e) {
            ErrorOccuredDownloadingResources?.Invoke(this, e);
        }

        //Event Broadcasts

        private void BroadcastDownloadingResourcesEvent(string message) {
            Resources.EventHandlers.DownloadingResourcesEventArgs e = new Resources.EventHandlers.DownloadingResourcesEventArgs();
            e.Message = message;
            OnDownloadingResources(this, e);
        }
        private void BroadcastNewProgressDownloadingResourcesEvent(string message, int progress) {
            Resources.EventHandlers.NewProgressDownloadingResourcesEventArgs e = new Resources.EventHandlers.NewProgressDownloadingResourcesEventArgs();
            e.Message = message;
            e.Progress = progress;
            OnNewProgressDownloadingResources(this, e);
        }
        private void BroadcastDownloadedResourcesEvent(string message) {
            BroadcastNewProgressDownloadingResourcesEvent(message, 100);
            Resources.EventHandlers.DownloadedResourcesEventArgs e = new Resources.EventHandlers.DownloadedResourcesEventArgs();
            e.Message = message;
            OnDownloadedResources(this, e);
        }
        private void BroadcastErrorOccuredDownloadingResourcesEvent(string message) {
            Resources.EventHandlers.ErrorOccuredDownloadingResourcesEventArgs e = new Resources.EventHandlers.ErrorOccuredDownloadingResourcesEventArgs();
            e.Message = message;
            OnErrorOccuredDownloadingResources(this, e);
        }

        //Methods

        public async void DownloadResources(string channelName, bool willDownloadBadges, bool willDownloadBttvEmoticons, bool willDownloadFfzEmoticons, bool willForceDownload) {

            if (CurrentlyDownloadingResources) {
                return;
            }
            CurrentlyDownloadingResources = true;

            BroadcastDownloadingResourcesEvent("Downloading selected resources...");

            if (channelName == "") {
                BroadcastErrorOccuredDownloadingResourcesEvent("Channel name must not be empty.");
                CurrentlyDownloadingResources = false;
                return;
            }

            if (Properties.Settings.Default.ClientId == "") {
                BroadcastErrorOccuredDownloadingResourcesEvent("Your Twitch Client ID hasn't been set up yet.\n" +
                    "Please set up your Client ID first before downloading resources!");
                CurrentlyDownloadingResources = false;
                return;
            }

            string channelId;
            try {
                channelId = await GetChannelId(channelName);
            } catch (Exception e) {
                BroadcastErrorOccuredDownloadingResourcesEvent("Error occured getting channel: " + e.Message);
                CurrentlyDownloadingResources = false;
                return;
            }

            if (willDownloadBttvEmoticons) {
                try {
                    await DownloadBttvEmoticonJsons(channelId, willForceDownload);
                } catch (Exception e) {
                    BroadcastErrorOccuredDownloadingResourcesEvent("Error occured downloading emoticons: " + e.Message);
                    CurrentlyDownloadingResources = false;
                    return;
                }
            }

            if (willDownloadFfzEmoticons) {
                try {
                    await DownloadFfzEmoticonJsons(channelId, channelName, willForceDownload);
                } catch (Exception e) {
                    BroadcastErrorOccuredDownloadingResourcesEvent("Error occured downloading emoticons: " + e.Message);
                    CurrentlyDownloadingResources = false;
                    return;
                }
            }

            if (willDownloadBadges) {
                try {
                    await DownloadBadgeJson("", "", willForceDownload);
                    await DownloadBadgeJson(channelId, channelName, willForceDownload);
                } catch (Exception e) {
                    BroadcastErrorOccuredDownloadingResourcesEvent("Error occured downloading badges: " + e.Message);
                    CurrentlyDownloadingResources = false;
                    return;
                }
            }

            BroadcastDownloadedResourcesEvent("Successfully downloaded selected resources!");

            CurrentlyDownloadingResources = false;
        }

        private async Task DownloadFfzEmoticonJsons(string channelId, string channelName, bool forceDownloadJson) {
            BroadcastNewProgressDownloadingResourcesEvent("Downloading Emoticon json files...", 33);

            Fetching.Emoticons.FfzEmoticonJsonFetcher ffzEmoticonJsonFetcher = new Fetching.Emoticons.FfzEmoticonJsonFetcher();

            await Task.Run(() => ffzEmoticonJsonFetcher.GetEmoticonJson(channelId, channelName, forceDownloadJson));

            BroadcastNewProgressDownloadingResourcesEvent("Downloading Emoticon json files...", 66);

            await Task.Run(() => ffzEmoticonJsonFetcher.GetEmoticonJson("", "", forceDownloadJson));

            BroadcastNewProgressDownloadingResourcesEvent("Downloading Emoticon json files...", 100);
        }

        private async Task DownloadBttvEmoticonJsons(string channelId, bool forceDownloadJson) {
            BroadcastNewProgressDownloadingResourcesEvent("Downloading Emoticon json files...", 33);

            Fetching.Emoticons.BttvEmoticonJsonFetcher bttvEmoticonJsonFetcher = new Fetching.Emoticons.BttvEmoticonJsonFetcher();

            await Task.Run(() => bttvEmoticonJsonFetcher.GetEmoticonJson(channelId, forceDownloadJson));

            BroadcastNewProgressDownloadingResourcesEvent("Downloading Emoticon json files...", 66);

            await Task.Run(() => bttvEmoticonJsonFetcher.GetEmoticonJson("", forceDownloadJson));

            BroadcastNewProgressDownloadingResourcesEvent("Downloading Emoticon json files...", 100);
        }

        private async Task<string> GetChannelId(string channelName) {
            BroadcastNewProgressDownloadingResourcesEvent("Getting Channel ID...", 25);

            Fetching.Channels.ChannelFetcher channelFetcher = new Fetching.Channels.ChannelFetcher();

            BroadcastNewProgressDownloadingResourcesEvent("Getting Channel ID...", 50);

            await Task.Run(() => channelFetcher.GetChannelJson(channelName));

            BroadcastNewProgressDownloadingResourcesEvent("Getting Channel ID...", 100);

            return channelFetcher.GetChannelIdFromJson();
        }

        private async Task DownloadBadgeJson(string channelId, string channelName, bool forceDownloadJson) {
            BroadcastNewProgressDownloadingResourcesEvent("Downloading Badge json files...", 50);

            Fetching.Badges.BadgeFetcher badgeFetcher = new Fetching.Badges.BadgeFetcher();
            await Task.Run(() => badgeFetcher.GetBadgesJson(channelId, channelName, forceDownloadJson));

            BroadcastNewProgressDownloadingResourcesEvent("Downloading Badge json files...", 100);
        }

    }
}
