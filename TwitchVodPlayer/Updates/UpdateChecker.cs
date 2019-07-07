using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchVodPlayer.Updates {
    public static class UpdateChecker {

        public static string CurrentVersion {
            get {
                return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public static async Task<string> CheckForUpdates() {
            var client = new GitHubClient(new ProductHeaderValue("TwitchVodWithChatPlayer"));
            try {
                var releases = await client.Repository.Release.GetAll("Alycse", "TwitchVodWithChatPlayer");
                if (releases.Count > 0) {
                    var latestRelease = releases[0];

                    double currentVersion = double.Parse(TwitchVodPlayer.Helpers.ReplaceAllExceptFirstOccurence(CurrentVersion, '.'));
                    double latestVersion = double.Parse(TwitchVodPlayer.Helpers.ReplaceAllExceptFirstOccurence(latestRelease.TagName.Remove(0, 1), '.'));

                    if (latestVersion > currentVersion) {
                        return latestRelease.HtmlUrl;
                    } else {
                        return "latest";
                    }
                }
                return "latest";
            } catch {
                Console.WriteLine("Error getting releases.");

                return null;
            }
        }

    }
}
