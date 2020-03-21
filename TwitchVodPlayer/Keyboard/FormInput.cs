using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwitchVodPlayer.Forms;

namespace TwitchVodPlayer.Keyboard {
    static class FormInput {

        private readonly static int formInputKeyCooldownMillisecond = 100;

        public static bool formCanInputKey = true;

        //Methods

        //Shortcut Keys
        public static void Form_KeyDown (object sender, KeyEventArgs e) {
            if (formCanInputKey) {
                Console.WriteLine("Fullscreen 0!");
                if (e.Alt && e.KeyCode == Keys.Return) {
                    MainForm.Instance.IsFullscreen = !MainForm.Instance.IsFullscreen;
                } else if (e.Control) {
                    switch (e.KeyCode) {
                        case Keys.H:
                            MainForm.Instance.ToggleHiddenChatBox();
                            break;
                        case Keys.W:
                            MainForm.Instance.ToggleHiddenChatBoxWindow();
                            break;
                        case Keys.S:
                            MainForm.Instance.ToggleStickyChatBox();
                            break;
                        case Keys.T:
                            MainForm.Instance.ToggleTransparentChatBox();
                            break;
                        case Keys.N:
                            MainForm.Instance.OpenVodFile();
                            break;
                        case Keys.D:
                            MainForm.Instance.ToggleHiddenDraggerBox();
                            break;
                        default:
                            break;
                    }
                } else {
                    switch (e.KeyCode) {
                        case Keys.Escape:
                            MainForm.Instance.IsFullscreen = false;
                            break;
                        case Keys.J:
                            MainForm.Instance.ForwardVideoPlayerTime(Video.Constants.BackwardMilliseconds);
                            break;
                        case Keys.L:
                            MainForm.Instance.ForwardVideoPlayerTime(Video.Constants.ForwardMilliseconds);
                            break;
                        case Keys.P:
                            MainForm.Instance.ChangeChatOffset(MainForm.Instance.OffsetIncreaseValueMilliseconds);
                            break;
                        case Keys.O:
                            MainForm.Instance.ChangeChatOffset(-MainForm.Instance.OffsetIncreaseValueMilliseconds);
                            break;
                        case Keys.Space:
                            MainForm.Instance.ToggleVideoPlayerPlayback();
                            break;
                        case Keys.K:
                            MainForm.Instance.ToggleVideoPlayerPlayback();
                            break;
                        default:
                            break;
                    }
                }

                formCanInputKey = false;

                Task.Delay(new TimeSpan(0, 0, 0, 0, formInputKeyCooldownMillisecond)).ContinueWith(o => { formCanInputKey = true; });
            }
        }

    }
}
