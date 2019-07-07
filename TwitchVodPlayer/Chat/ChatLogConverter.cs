using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace TwitchVodPlayer.Chat {
    class ChatLogConverter {

        //Events

        public event Chat.EventHandlers.ConvertingChatLogEventHandler ConvertingChatLog;
        protected virtual void OnConvertingChatLog(object sender, Chat.EventHandlers.ConvertingChatLogEventArgs e) {
            ConvertingChatLog?.Invoke(this, e);
        }
        public event Chat.EventHandlers.NewProgressConvertingChatLogEventHandler NewProgressConvertingChatLog;
        protected virtual void OnNewProgressConvertingChatLog(object sender, Chat.EventHandlers.NewProgressConvertingChatLogEventArgs e) {
            NewProgressConvertingChatLog?.Invoke(this, e);
        }
        public event Chat.EventHandlers.ConvertedChatLogEventHandler ConvertedChatLog;
        protected virtual void OnConvertedChatLog(object sender, Chat.EventHandlers.ConvertedChatLogEventArgs e) {
            ConvertedChatLog?.Invoke(this, e);
        }
        public event Chat.EventHandlers.ErrorOccuredConvertingChatLogEventHandler ErrorOccuredConvertingChatLog;
        protected virtual void OnErrorOccuredConvertingChatLog(object sender, Chat.EventHandlers.ErrorOccuredConvertingChatLogEventArgs e) {
            ErrorOccuredConvertingChatLog?.Invoke(this, e);
        }

        //Event Broadcasts

        private void BroadcastConvertingChatLogEvent(string message) {
            Chat.EventHandlers.ConvertingChatLogEventArgs e = new Chat.EventHandlers.ConvertingChatLogEventArgs();
            e.Message = message;
            OnConvertingChatLog(this, e);
        }
        private void BroadcastNewProgressConvertingChatLogEvent(string message, int progress) {
            Chat.EventHandlers.NewProgressConvertingChatLogEventArgs e = new Chat.EventHandlers.NewProgressConvertingChatLogEventArgs();
            e.Message = message;
            e.Progress = progress;
            OnNewProgressConvertingChatLog(this, e);
        }
        public void BroadcastConvertedChatLogEvent(string message) {
            Chat.EventHandlers.ConvertedChatLogEventArgs e = new Chat.EventHandlers.ConvertedChatLogEventArgs();
            e.Message = message;
            OnConvertedChatLog(this, e);
        }
        private void BroadcastErrorOccuredConvertingChatLogEvent(string message) {
            Chat.EventHandlers.ErrorOccuredConvertingChatLogEventArgs e = new Chat.EventHandlers.ErrorOccuredConvertingChatLogEventArgs();
            e.Message = message;
            OnErrorOccuredConvertingChatLog(this, e);
        }

        //Methods

        public void ConvertChatLog(CancellationToken token, string chatLogFilePath, string outputFilePath, TimeSpan? beginTime, TimeSpan? endTime) {
            using (WebClient client = new WebClient()) {
                using (Stream stream = client.OpenRead(chatLogFilePath)) {
                    using (StreamReader streamReader = new StreamReader(stream)) {
                        using (JsonTextReader jsonTextReader = new JsonTextReader(streamReader)) {
                            var serializer = new JsonSerializer();

                            jsonTextReader.SupportMultipleContent = true;

                            Stream baseStream = streamReader.BaseStream;
                            long length = baseStream.Length;

                            if (File.Exists(outputFilePath)) {
                                File.Delete(outputFilePath);
                            }
                            using (StreamWriter streamWriter = new System.IO.StreamWriter(outputFilePath, true, Encoding.Unicode)) {

                                bool writtenChannelId = false;

                                bool insideArray = false;

                                int lineCount = 0;

                                int progress = 0;

                                JObject fullChatLineJObject;
                                dynamic tempChatLine;

                                while (jsonTextReader.Read()) {
                                    if (token.IsCancellationRequested) {
                                        break;
                                    }

                                    //Go to the first array in the json file
                                    if (jsonTextReader.TokenType == JsonToken.StartArray && !insideArray) {
                                        insideArray = true;
                                        continue;
                                    }
                                    if (!insideArray || jsonTextReader.TokenType != JsonToken.StartObject) {
                                        continue;
                                    }

                                    var fullChatLine = serializer.Deserialize<dynamic>(jsonTextReader);

                                    if (!writtenChannelId) {
                                        streamWriter.WriteLine("~channelId:" + fullChatLine.channel_id);
                                        writtenChannelId = true;
                                    }

                                    fullChatLineJObject = JObject.FromObject(fullChatLine);
                                    tempChatLine = new JObject();
                                    tempChatLine.Add("_id", fullChatLineJObject.Property("_id").Value);
                                    tempChatLine.Add("content_offset_seconds", fullChatLineJObject.Property("content_offset_seconds").Value);
                                    tempChatLine.Add("commenter", fullChatLineJObject.Property("commenter").Value);
                                    tempChatLine.commenter.Property("logo").Remove();
                                    tempChatLine.Add("message", fullChatLineJObject.Property("message").Value);

                                    var chatLine = JObject.Parse(tempChatLine.ToString());

                                    lineCount++;
                                    if (chatLine.content_offset_seconds != null) {
                                        if (beginTime == null || endTime == null) {

                                            progress = ((int)Math.Round((float)((double)chatLine.content_offset_seconds * 1000.0)) % 10) * 10;

                                            BroadcastNewProgressConvertingChatLogEvent("Converting Chat Log..." +
                                                "\nCurrent time: " + TimeSpan.FromMilliseconds((double)chatLine.content_offset_seconds * 1000.0),
                                                progress);

                                        } else if ((double)chatLine.content_offset_seconds * 1000.0 < endTime.Value.TotalMilliseconds) {

                                            progress = (int)Math.Round((float)((double)chatLine.content_offset_seconds * 1000.0) / (float)endTime.Value.TotalMilliseconds * 100.0f);

                                            BroadcastNewProgressConvertingChatLogEvent("Converting Chat Log..." +
                                                "\nCurrent time: " + TimeSpan.FromMilliseconds((double)chatLine.content_offset_seconds * 1000.0) + @" / " + endTime,
                                                progress);

                                        }
                                    }

                                    if (chatLine.message == null) {
                                        break;
                                    }

                                    double contentOffset = ((double)chatLine.content_offset_seconds * 1000.0) - (beginTime != null ? beginTime.Value.TotalMilliseconds : 0);

                                    streamWriter.WriteLine(contentOffset + ":" + Regex.Replace(chatLine.ToString(), @"\t|\n|\r", ""));
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}
