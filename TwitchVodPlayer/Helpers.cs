using System;
using System.Linq;

namespace TwitchVodPlayer {
    public static class Helpers {
        public static string ReplaceAllExceptFirstOccurence(this string @string, char @char) {
            var index = @string.IndexOf(@char);
            return String.Concat(String.Concat(@string.TakeWhile(x => @string.IndexOf(x) < index + 1)), String.Concat(@string.SkipWhile(x => @string.IndexOf(x) < index)).Replace(@char.ToString(), ""));
        }
    }
}
