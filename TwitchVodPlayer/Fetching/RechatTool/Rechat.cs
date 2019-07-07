// --------------------------------------------------------------------------------
// Copyright (c) J.D. Purcell
//
// Licensed under the MIT License (see LICENSE.txt)
// --------------------------------------------------------------------------------
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace TwitchVodPlayer.Fetching.RechatTool {

    class Rechat {

        //Events

        public event Fetching.RechatTool.EventHandlers.DownloadingChatLogEventHandler DownloadingChatLog;
        protected virtual void OnDownloadingChatLog(object sender, Fetching.RechatTool.EventHandlers.DownloadingChatLogEventArgs e) {
            DownloadingChatLog?.Invoke(this, e);
        }
        public event Fetching.RechatTool.EventHandlers.NewProgressDownloadingChatLogEventHandler NewProgressDownloadingChatLog;
        protected virtual void OnNewProgressDownloadingChatLog(object sender, Fetching.RechatTool.EventHandlers.NewProgressDownloadingChatLogEventArgs e) {
            NewProgressDownloadingChatLog?.Invoke(this, e);
        }
        public event Fetching.RechatTool.EventHandlers.DownloadedChatLogEventHandler DownloadedChatLog;
        protected virtual void OnDownloadedChatLog(object sender, Fetching.RechatTool.EventHandlers.DownloadedChatLogEventArgs e) {
            DownloadedChatLog?.Invoke(this, e);
        }
        public event Fetching.RechatTool.EventHandlers.ErrorOccuredDownloadingChatLogEventHandler ErrorOccuredDownloadingChatLog;
        protected virtual void OnErrorOccuredDownloadingChatLog(object sender, Fetching.RechatTool.EventHandlers.ErrorOccuredDownloadingChatLogEventArgs e) {
            ErrorOccuredDownloadingChatLog?.Invoke(this, e);
        }

        //Event Broadcasts

        protected void BroadcastDownloadingChatLogEvent(string message) {
            Fetching.RechatTool.EventHandlers.DownloadingChatLogEventArgs e = new Fetching.RechatTool.EventHandlers.DownloadingChatLogEventArgs();
            e.Message = message;
            OnDownloadingChatLog(this, e);
        }
        protected void BroadcastNewProgressDownloadingChatLogEvent(string message, int progress) {
            Fetching.RechatTool.EventHandlers.NewProgressDownloadingChatLogEventArgs e = new Fetching.RechatTool.EventHandlers.NewProgressDownloadingChatLogEventArgs();
            e.Message = message;
            e.Progress = progress;
            OnNewProgressDownloadingChatLog(this, e);
        }
        protected void BroadcastDownloadedChatLogEvent(string message) {
            Fetching.RechatTool.EventHandlers.DownloadedChatLogEventArgs e = new Fetching.RechatTool.EventHandlers.DownloadedChatLogEventArgs();
            e.Message = message;
            OnDownloadedChatLog(this, e);
        }
        protected void BroadcastErrorOccuredDownloadingChatLogEvent(string message) {
            Fetching.RechatTool.EventHandlers.ErrorOccuredDownloadingChatLogEventArgs e = new Fetching.RechatTool.EventHandlers.ErrorOccuredDownloadingChatLogEventArgs();
            e.Message = message;
            OnErrorOccuredDownloadingChatLog(this, e);
        }

        public void DownloadFile(CancellationToken token, long videoId, string path, TimeSpan? beginTime, TimeSpan? endTime) {
            if (File.Exists(path)) {
                File.Delete(path);
            }
            string baseUrl = $"{"https"}://api.twitch.tv/v5/videos/{videoId}/comments";
            string nextCursor = null;
            int segmentCount = 0;
            JObject firstComment = null;
            JObject lastComment = null;
            TimeSpan? totalTime = endTime - beginTime;
            using (var writer = new JsonTextWriter(new StreamWriter(path, false, new UTF8Encoding(true)))) {
                writer.WriteStartArray();
                do {
                    if (token.IsCancellationRequested) {
                        break;
                    }

                    TimeSpan? lastCommentTimespan = TryGetContentOffset(lastComment);

                    bool lastCommentWithinTimeFrame = lastCommentTimespan > beginTime && lastCommentTimespan < endTime;

                    if (lastCommentTimespan != null) {
                        if (beginTime == null || endTime == null) {
                            BroadcastNewProgressDownloadingChatLogEvent("Downloading Chat Log..." +
                            "\nSegments downloaded: " + segmentCount +
                            "\nCurrent time: " + (lastCommentTimespan),
                            (segmentCount % 5) * 20);
                        } else if (lastCommentWithinTimeFrame) {
                            int progress = 
                                (int)Math.Round(((float)(lastCommentTimespan.Value.TotalMilliseconds - (beginTime).Value.TotalMilliseconds) / 
                                (float)totalTime.Value.TotalMilliseconds) * 100.0f);

                            BroadcastNewProgressDownloadingChatLogEvent("Downloading Chat Log..." +
                            "\nSegments downloaded: " + segmentCount +
                            "\nCurrent time: " + (lastCommentTimespan - (beginTime)) + @" / " + totalTime,
                            progress);
                        }
                    }

                    if (beginTime != null && endTime != null && lastCommentTimespan > endTime) {
                        break;
                    }

                    string url = nextCursor == null ?
                        $"{baseUrl}?content_offset_seconds=0" :
                        $"{baseUrl}?cursor={nextCursor}";

                    JObject response = JObject.Parse(DownloadUrlAsString(url, withRequest: AddTwitchApiHeaders));

                    foreach (JObject comment in (JArray)response["comments"]) {
                        if ((beginTime == null || endTime == null) || lastCommentWithinTimeFrame) {
                            comment.WriteTo(writer);
                        }
                        firstComment = firstComment ?? comment;
                        lastComment = comment;
                    }

                    nextCursor = (string)response["_next"];
                    segmentCount++;
                    //progressCallback?.Invoke(segmentCount, lastCommentTimespan);
                }
                while (nextCursor != null);
                
                writer.WriteEndArray();
            }
            if (firstComment != null) {
                try {
                    var firstMessage = new RechatMessage(firstComment);
                    var lastMessage = new RechatMessage(lastComment);
                    File.SetCreationTimeUtc(path, firstMessage.CreatedAt - firstMessage.ContentOffset);
                    File.SetLastWriteTimeUtc(path, lastMessage.CreatedAt);
                }
                catch (Exception ex) {
                    throw new WarningException("Unable to set file created/modified time.", ex);
                }
            }

            Console.WriteLine("BROKEN RECHAT");
        }

        private static string DownloadUrlAsString(string url, Action<HttpWebRequest> withRequest = null) {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            withRequest?.Invoke(request);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (StreamReader responseStream = new StreamReader(response.GetResponseStream())) {
                return responseStream.ReadToEnd();
            }
        }

        private static void AddTwitchApiHeaders(HttpWebRequest request) {
            request.Accept = "application/vnd.twitchtv.v5+json";
            request.Headers.Add("Client-ID", Properties.Settings.Default.ClientId);
        }

        private static TimeSpan? TryGetContentOffset(JObject comment) {
            try {
                return comment == null ? (TimeSpan?)null : new RechatMessage(comment).ContentOffset;
            }
            catch {
                return null;
            }
        }

        public static void ProcessFile(string pathIn, string pathOut = null, bool overwrite = false, bool showBadges = false) {
            if (pathOut == null) {
                bool isAlreadyTxt = pathIn.EndsWith(".txt", StringComparison.OrdinalIgnoreCase);
                pathOut = Path.Combine(
                    Path.GetDirectoryName(pathIn),
                    Path.GetFileNameWithoutExtension(pathIn) + (isAlreadyTxt ? "-p" : "") + ".txt");
            }
            if (File.Exists(pathOut) && !overwrite) {
                throw new Exception("Output file already exists.");
            }
            IEnumerable<string> lines = ParseMessages(pathIn)
                .Select(n => ToReadableString(n, showBadges))
                .Where(n => n != null);
            File.WriteAllLines(pathOut, lines, new UTF8Encoding(true));
            try {
                File.SetCreationTimeUtc(pathOut, File.GetCreationTimeUtc(pathIn));
                File.SetLastWriteTimeUtc(pathOut, File.GetLastWriteTimeUtc(pathIn));
            }
            catch (Exception ex) {
                throw new WarningException("Unable to set file created/modified time.", ex);
            }
        }

        public static IEnumerable<RechatMessage> ParseMessages(string path) {
            using (var reader = new JsonTextReader(File.OpenText(path))) {
                while (reader.Read()) {
                    if (reader.TokenType != JsonToken.StartObject)
                        continue;
                    yield return new RechatMessage(JObject.Load(reader));
                }
            }
        }

        public static string TimestampToString(TimeSpan value, bool showMilliseconds) {
            return $"{(int)value.TotalHours:00}:{value:mm}:{value:ss}{(showMilliseconds ? $".{value:fff}" : "")}";
        }

        private static string ToReadableString(RechatMessage m, bool showBadges) {
            string userBadges = $"{(m.UserIsAdmin || m.UserIsStaff ? "*" : "")}{(m.UserIsBroadcaster ? "#" : "")}{(m.UserIsModerator || m.UserIsGlobalModerator ? "@" : "")}{(m.UserIsSubscriber ? "+" : "")}";
            string userName = m.UserDisplayName.Equals(m.UserName, StringComparison.OrdinalIgnoreCase) ? m.UserDisplayName : $"{m.UserDisplayName} ({m.UserName})";
            return $"[{TimestampToString(m.ContentOffset, true)}] {(showBadges ? userBadges : "")}{userName}{(m.IsAction ? "" : ":")} {m.MessageText}";
        }

        public class RechatMessage {
            public JObject SourceJson {
                get;
            }

            private JsonComment Comment {
                get;
            }
            private JsonCommentCommenter Commenter => Comment.Commenter;
            private JsonCommentMessage Message => Comment.Message;

            public RechatMessage(JObject sourceJson) {
                SourceJson = sourceJson;
                Comment = sourceJson.ToObject<JsonComment>();
            }

            public DateTime CreatedAt => Comment.CreatedAt;

            public TimeSpan ContentOffset => TimeSpan.FromSeconds(Comment.ContentOffsetSeconds);

            // User said something with "/me"
            public bool IsAction => Message.IsAction;

            // Not from the live chat (i.e. user posted a comment on the VOD)
            public bool IsNonChat => !Comment.Source.Equals("chat", StringComparison.OrdinalIgnoreCase);

            public string MessageText => Message.Body;

            public string UserName => Commenter.Name;

            public string UserDisplayName => Commenter.DisplayName.TrimEnd(' ');

            public bool UserIsAdmin => HasBadge("admin");

            public bool UserIsStaff => HasBadge("staff");

            public bool UserIsGlobalModerator => HasBadge("global_mod");

            public bool UserIsBroadcaster => HasBadge("broadcaster");

            public bool UserIsModerator => HasBadge("moderator");

            public bool UserIsSubscriber => HasBadge("subscriber");

            public IEnumerable<UserBadge> UserBadges => Message.UserBadges?.Select(n => n.ToUserBadge()) ?? Enumerable.Empty<UserBadge>();

            private bool HasBadge(string id) => Message.UserBadges?.Any(n => n.Id.Equals(id, StringComparison.OrdinalIgnoreCase)) ?? false;

            private class JsonComment {
                [JsonProperty("created_at")]
                public DateTime CreatedAt {
                    get; set;
                }
                [JsonProperty("content_offset_seconds")]
                public double ContentOffsetSeconds {
                    get; set;
                }
                [JsonProperty("source")]
                public string Source {
                    get; set;
                }
                [JsonProperty("commenter")]
                public JsonCommentCommenter Commenter {
                    get; set;
                }
                [JsonProperty("message")]
                public JsonCommentMessage Message {
                    get; set;
                }
            }

            private class JsonCommentCommenter {
                [JsonProperty("display_name")]
                public string DisplayName {
                    get; set;
                }
                [JsonProperty("name")]
                public string Name {
                    get; set;
                }
            }

            private class JsonCommentMessage {
                [JsonProperty("body")]
                public string Body {
                    get; set;
                }
                [JsonProperty("is_action")]
                public bool IsAction {
                    get; set;
                }
                [JsonProperty("user_badges")]
                public JsonCommentUserBadge[] UserBadges {
                    get; set;
                }
            }

            private class JsonCommentUserBadge {
                [JsonProperty("_id")]
                public string Id {
                    get; set;
                }
                [JsonProperty("version")]
                public int Version {
                    get; set;
                }

                public UserBadge ToUserBadge() {
                    return new UserBadge {
                        Id = Id,
                        Version = Version
                    };
                }
            }

            public class UserBadge {
                internal UserBadge() {
                }

                public string Id {
                    get; internal set;
                }
                public int Version {
                    get; internal set;
                }
            }
        }

        public delegate void DownloadProgressCallback(int segmentCount, TimeSpan? contentOffset);
    }
}