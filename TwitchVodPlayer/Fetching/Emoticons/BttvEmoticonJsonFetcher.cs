using System.IO;
using System.Net;

namespace TwitchVodPlayer.Fetching.Emoticons {
    class BttvEmoticonJsonFetcher : EmoticonJsonFetcher {

        public void GetEmoticonJson(string channelId, string channelName, bool forceDownloadJson) {
            if (!Directory.Exists(Fetching.Constants.JsonPath)) {
                Directory.CreateDirectory(Fetching.Constants.JsonPath);
            }

            using (WebClient wc = new WebClient()) {
                string url;
                string jsonFileName;
                if (channelName == "") {
                    url = Fetching.Constants.BttvGlobalEmoticonUrl;
                    jsonFileName = Fetching.Constants.BttvEmoticonJsonFileName;
                } else {
                    url = Fetching.Constants.BttvChannelEmoticonUrl.Replace("<channelName>", channelName);
                    jsonFileName = Fetching.Constants.BttvEmoticonJsonFileName + "_" + channelId;
                }

                string filePath = Fetching.Constants.JsonPath + jsonFileName + ".json";
                if (!forceDownloadJson && File.Exists(filePath)) {
                    return;
                }

                byte[] byteArray = wc.DownloadData(url);
                string webData = System.Text.Encoding.UTF8.GetString(byteArray);
                using (System.IO.FileStream fileStream = new System.IO.FileStream(filePath, System.IO.FileMode.Create)) {
                    fileStream.Write(byteArray, 0, byteArray.Length);
                }
            }
        }
    }
}
