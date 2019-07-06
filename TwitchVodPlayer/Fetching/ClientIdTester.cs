using System;
using System.IO;
using System.Net;

namespace TwitchVodPlayer.Fetching {
    class ClientIdTester {

        public bool CurrentlyTestingClientId = false;

        //Events

        public event Fetching.EventHandlers.TestingClientIdEventHandler TestingClientId;
        protected virtual void OnTestingClientId(object sender, Fetching.EventHandlers.TestingClientIdEventArgs e) {
            TestingClientId?.Invoke(this, e);
        }
        public event Fetching.EventHandlers.NewProgressTestingClientIdEventHandler NewProgressTestingClientId;
        protected virtual void OnNewProgressTestingClientId(object sender, Fetching.EventHandlers.NewProgressTestingClientIdEventArgs e) {
            NewProgressTestingClientId?.Invoke(this, e);
        }
        public event Fetching.EventHandlers.TestedClientIdEventHandler TestedClientId;
        protected virtual void OnTestedClientId(object sender, Fetching.EventHandlers.TestedClientIdEventArgs e) {
            TestedClientId?.Invoke(this, e);
        }
        public event Fetching.EventHandlers.ErrorOccuredTestingClientIdEventHandler ErrorOccuredTestingClientId;
        protected virtual void OnErrorOccuredTestingClientId(object sender, Fetching.EventHandlers.ErrorOccuredTestingClientIdEventArgs e) {
            ErrorOccuredTestingClientId?.Invoke(this, e);
        }

        //Event Broadcasts

        private void BroadcastTestingClientIdEvent(string message) {
            Fetching.EventHandlers.TestingClientIdEventArgs e = new Fetching.EventHandlers.TestingClientIdEventArgs();
            e.Message = message;
            OnTestingClientId(this, e);
        }
        private void BroadcastNewProgressTestingClientIdEvent(string message, int progress) {
            Fetching.EventHandlers.NewProgressTestingClientIdEventArgs e = new Fetching.EventHandlers.NewProgressTestingClientIdEventArgs();
            e.Message = message;
            e.Progress = progress;
            OnNewProgressTestingClientId(this, e);
        }
        public void BroadcastTestedClientIdEvent(string message, string clientId) {
            Fetching.EventHandlers.TestedClientIdEventArgs e = new Fetching.EventHandlers.TestedClientIdEventArgs();
            e.Message = message;
            e.ClientId = clientId;
            OnTestedClientId(this, e);
        }
        private void BroadcastErrorOccuredTestingClientIdEvent(string message) {
            Fetching.EventHandlers.ErrorOccuredTestingClientIdEventArgs e = new Fetching.EventHandlers.ErrorOccuredTestingClientIdEventArgs();
            e.Message = message;
            OnErrorOccuredTestingClientId(this, e);
        }

        //Methods

        public void TestClientId(string clientId) {

            if (CurrentlyTestingClientId) {
                return;
            }
            CurrentlyTestingClientId = true;

            long currentTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            long secondsSinceLastClientIdTested = (currentTime - Properties.Settings.Default.LastClientIdTestTime) / 1000;
            
            if (secondsSinceLastClientIdTested < 30) {
                BroadcastErrorOccuredTestingClientIdEvent("You're doing this too much.\n" +
                    "Please wait another " + (30 - secondsSinceLastClientIdTested) + " seconds before testing your Client ID again");
                CurrentlyTestingClientId = false;
                return;
            }

            Properties.Settings.Default.LastClientIdTestTime = currentTime;
            Properties.Settings.Default.Save();

            try {
                BroadcastTestingClientIdEvent("Testing your Client ID...");
                using (WebClient wc = new WebClient()) {
                    BroadcastNewProgressTestingClientIdEvent("Testing your Client ID...", 0);
                    string url = Fetching.Constants.ClientIdTestingUrl;
                    HttpWebRequest request = (HttpWebRequest)System.Net.HttpWebRequest.Create(url);
                    request.Method = "GET";
                    request.Accept = Fetching.Constants.Accept;
                    request.Headers.Add("Client-ID", clientId);
                    using (var response = (HttpWebResponse)request.GetResponse()) {
                        using (Stream streamResponse = response.GetResponseStream()) {
                        }
                    }
                    BroadcastNewProgressTestingClientIdEvent("Testing your Client ID...", 100);
                }
                BroadcastTestedClientIdEvent("Your Client ID works!\nYou may now create VOD Sets and download resources.", clientId);
            } catch (Exception e) {
                BroadcastErrorOccuredTestingClientIdEvent("An error occured.\nPlease make sure your Client ID is correct.\n\nError info: " + e.Message);
            }

            CurrentlyTestingClientId = false;

        }
    }
}
