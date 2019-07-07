using System;

namespace TwitchVodPlayer.Chat {
    class EventHandlers {

        public delegate void ParsingMessageEventHandler(object sender, ParsingMessageEventArgs e);
        public delegate void NewProgressParsingMessageEventHandler(object sender, NewProgressParsingMessageEventArgs e);
        public delegate void ParsedMessageEventHandler(object sender, ParsedMessageEventArgs e);
        public delegate void ErrorOccuredParsingMessageEventHandler(object sender, ErrorOccuredParsingMessageEventArgs e);

        public class ParsingMessageEventArgs : EventArgs {
            public string Message {
                get; set;
            }
        }
        public class NewProgressParsingMessageEventArgs : EventArgs {
            public string Message {
                get; set;
            }
            public int Progress {
                get; set;
            }
        }
        public class ParsedMessageEventArgs : EventArgs {
            public string Message {
                get; set;
            }
        }
        public class ErrorOccuredParsingMessageEventArgs : EventArgs {
            public string Message {
                get; set;
            }
        }

        public delegate void ConvertingChatLogEventHandler(object sender, ConvertingChatLogEventArgs e);
        public delegate void NewProgressConvertingChatLogEventHandler(object sender, NewProgressConvertingChatLogEventArgs e);
        public delegate void ConvertedChatLogEventHandler(object sender, ConvertedChatLogEventArgs e);
        public delegate void ErrorOccuredConvertingChatLogEventHandler(object sender, ErrorOccuredConvertingChatLogEventArgs e);

        public class ConvertingChatLogEventArgs : EventArgs {
            public string Message {
                get; set;
            }
        }
        public class NewProgressConvertingChatLogEventArgs : EventArgs {
            public string Message {
                get; set;
            }
            public int Progress {
                get; set;
            }
            public int TaskBarProgress {
                get; set;
            }
        }
        public class ConvertedChatLogEventArgs : EventArgs {
            public string Message {
                get; set;
            }
        }
        public class ErrorOccuredConvertingChatLogEventArgs : EventArgs {
            public string Message {
                get; set;
            }
        }

        public delegate void CreatingChatFileEventHandler(object sender, CreatingChatFileEventArgs e);
        public delegate void NewProgressCreatingChatFileEventHandler(object sender, NewProgressCreatingChatFileEventArgs e);
        public delegate void CreatedChatFileEventHandler(object sender, CreatedChatFileEventArgs e);
        public delegate void ErrorOccuredCreatingChatFileEventHandler(object sender, ErrorOccuredCreatingChatFileEventArgs e);

        public class CreatingChatFileEventArgs : EventArgs {
            public string Message {
                get; set;
            }
        }
        public class NewProgressCreatingChatFileEventArgs : EventArgs {
            public string Message {
                get; set;
            }
            public int Progress {
                get; set;
            }
            public int TaskBarProgress {
                get; set;
            }
        }
        public class CreatedChatFileEventArgs : EventArgs {
            public string Message {
                get; set;
            }
            public string FilePath {
                get; set;
            }
        }
        public class ErrorOccuredCreatingChatFileEventArgs : EventArgs {
            public string Message {
                get; set;
            }
        }

    }
}
