using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace TwitchVodPlayer.Fetching.Channels {
    class ChannelFetcher {

        public ChannelFetcher() {
        }

        public void GetChannelJson(string channelName) {
            if (!Directory.Exists(Fetching.Constants.JsonPath)) {
                Directory.CreateDirectory(Fetching.Constants.JsonPath);
            }

            using (WebClient wc = new WebClient()) {
                string url = Fetching.Constants.ChannelIdUrl.Replace("<channelName>", channelName);
                HttpWebRequest request = (HttpWebRequest)System.Net.HttpWebRequest.Create(url);
                request.Method = "GET";
                request.Accept = Fetching.Constants.Accept;
                request.Headers.Add("Client-ID", Properties.Settings.Default.ClientId);
                using (var response = (HttpWebResponse)request.GetResponse()) {
                    using (Stream streamResponse = response.GetResponseStream()) {
                        long lContentLen = response.ContentLength;
                        byte[] byteArray = null;
                        byteArray = new byte[lContentLen];
                        for (long index = 0; index < lContentLen; index++) {
                            byteArray[index] = (byte)streamResponse.ReadByte();
                        }
                        string filePath = Fetching.Constants.JsonPath + Fetching.Constants.ChannelJsonFileName + ".json";
                        using (Stream strWrite = File.Open(filePath, FileMode.Create)) {
                            using (BinaryWriter binaryWriter = new BinaryWriter(strWrite)) {
                                binaryWriter.Write(byteArray);
                            }
                        }
                    }
                }
            }
        }

        public string GetChannelIdFromJson() {
            string channelId = "";
            using (WebClient client = new WebClient()) {
                string filePath = Fetching.Constants.JsonPath + Fetching.Constants.ChannelJsonFileName + ".json";
                using (Stream stream = client.OpenRead(filePath)) {
                    using (StreamReader streamReader = new StreamReader(stream)) {
                        using (JsonTextReader reader = new JsonTextReader(streamReader)) {
                            reader.SupportMultipleContent = true;

                            var serializer = new JsonSerializer();
                            bool insideArray = false;
                            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                            while (reader.Read()) {
                                if (reader.TokenType == JsonToken.StartArray && !insideArray) {
                                    insideArray = true;
                                    continue;
                                }
                                if (!insideArray || reader.TokenType != JsonToken.StartObject) {
                                    continue;
                                }

                                var channel = serializer.Deserialize<dynamic>(reader);
                                channelId = channel._id;
                            }
                        }
                    }
                }
            }
            return channelId;
        }

    }
}
