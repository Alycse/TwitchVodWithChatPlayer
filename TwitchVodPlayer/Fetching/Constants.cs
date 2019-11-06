namespace TwitchVodPlayer.Fetching {
    public static class Constants {

        public static readonly string DefaultClientId = "ak868fnag19gm7wlnpsxjqah6772v3";

        public static readonly string ClientIdTestingUrl = "https://api.twitch.tv/kraken/channels/44322889";

        public static readonly string TwitchChannelEmoticonUrl = "https://api.twitch.tv/kraken/chat/<channelName>/emoticons";
        public static readonly string TwitchEmoticonIdUrl = "https://static-cdn.jtvnw.net/emoticons/v1/<emoticonId>/<emoticonSize>";
        public static readonly string TwitchEmoticonSize = "1.0";

        public static readonly string BttvChannelEmoticonUrl = "https://api.betterttv.net/2/channels/<channelName>";
        public static readonly string BttvGlobalEmoticonUrl = "https://api.betterttv.net/2/emotes";
        public static readonly string BttvEmoticonSize = "1x";

        public static readonly string FfzChannelEmoticonUrl = "https://api.frankerfacez.com/v1/room/<channelName>";
        public static readonly string FfzGlobalEmoticonUrl = "https://api.frankerfacez.com/v1/emoticons?per_page=1000";

        public static readonly string ChannelIdUrl = "https://api.twitch.tv/kraken/users?login=<channelName>";
        public static readonly string BadgesChannelUrl = "https://badges.twitch.tv/v1/badges/channels/<channelId>/display?language=en";
        public static readonly string BadgesUrl = "https://badges.twitch.tv/v1/badges/global/display";

        public static readonly string Accept = "application/vnd.twitchtv.v5+json";

        public static readonly string EmoticonsPath = TwitchVodPlayer.Constants.UserAppDataPath + @"/Storage/Emoticons/";
        public static readonly string TwitchEmoticonsDirectoryName = "Twitch";
        public static readonly string BttvEmoticonsDirectoryName = "BTTV";
        public static readonly string FfzEmoticonsDirectoryName = "FFZ";
        public static readonly string BadgesPath = TwitchVodPlayer.Constants.UserAppDataPath + @"/Storage/Badges/";
        public static readonly string JsonPath = TwitchVodPlayer.Constants.UserAppDataPath + @"/Storage/Jsons/";

        public static readonly string FfzEmoticonJsonFileName = "FfzEmoticon";
        public static readonly string BttvEmoticonJsonFileName = "BttvEmoticon";
        public static readonly string BadgeJsonFileName = "Badge";
        public static readonly string ChannelJsonFileName = "Channel";

        public static readonly string EmoticonFileExtension = ".png";
        public static readonly string GifEmoticonFileExtension = ".gif";
        public static readonly string BadgeFileExtension = ".png";
    }
}
