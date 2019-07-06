namespace TwitchVodPlayer.Fetching.Emoticons {
    class TwitchEmoticonDownloader : EmoticonDownloader {

        public override void DownloadEmoticon(string emoticonId, string filePath) {
            string emoticonUrl = Fetching.Constants.TwitchEmoticonIdUrl.Replace("<emoticonId>", emoticonId).Replace("<emoticonSize>", Fetching.Constants.TwitchEmoticonSize);
            FileDownloader fileDownloader = new FileDownloader();
            fileDownloader.DownloadFile(emoticonUrl, filePath);
        }

    }
}
