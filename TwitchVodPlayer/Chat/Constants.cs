using System;

namespace TwitchVodPlayer.Chat {
    public static class Constants {

        public static readonly string ChatBoxHtmlPath = AppDomain.CurrentDomain.BaseDirectory + @"\Assets\Chat Box\chatbox.html";

        public static readonly string ChatFileExtension = ".cht";

        public static readonly string DefaultChatMessageUserColor = "#FFFFFF";

        public static readonly string SupportedImageExtensions = "*.jpg,*.gif,*.png,*.bmp,*.jpe,*.jpeg";

        public static readonly string HtmlImageTagBegin = "<img src='file:///";
        public static readonly string HtmlImageTagEnd = "' onerror='imgError(this);'>";
    }
}
