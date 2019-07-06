using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchVodPlayer.Forms {
    public static class Helpers {
        public static string Filter(string[] fileExtensions) {
            string filter = "Video Files |";
            foreach (string videoExtension in fileExtensions) {
                filter += "*" + videoExtension + "; ";
            }
            return filter;
        }
    }
}
