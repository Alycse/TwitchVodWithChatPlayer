using System.IO;

namespace TwitchVodPlayer.Chat {
    public class ChatFile {

        private string filePath;
        private string channelId;

        public ChatFile(string filePath) {
            using (StreamReader reader = new StreamReader(filePath)) {
                try {
                    this.channelId = reader.ReadLine().Split(new char[] { ':' })[1];
                } catch {
                    this.channelId = "";
                }
            }
            this.filePath = filePath;
        }

        public string ChannelId {
            get => channelId;
            set => channelId = value;
        }
        public string FilePath {
            get => filePath;
            set => filePath = value;
        }
    }
}
