using System.Windows.Forms;
using TwitchVodPlayer.Forms;

namespace TwitchVodPlayer.Keyboard {
    static class FormInput {

        //Methods

        public static void Form_KeyDown(object sender, KeyEventArgs e) {
            if (e.Alt && e.KeyCode == Keys.Return) {
                MainForm.Instance.IsFullscreen = !MainForm.Instance.IsFullscreen;
            } else if (e.KeyCode == Keys.Escape) {
                MainForm.Instance.IsFullscreen = false;
            } else if (e.KeyCode == Keys.J) {
                MainForm.Instance.ForwardVideoPlayerTime(Video.Constants.BackwardMilliseconds);
            } else if (e.KeyCode == Keys.L) {
                MainForm.Instance.ForwardVideoPlayerTime(Video.Constants.ForwardMilliseconds);
            } else if (e.KeyCode == Keys.K || e.KeyCode == Keys.Space) {
                MainForm.Instance.ToggleVideoPlayerPlayback();
            } else if (e.KeyCode == Keys.P) {
                MainForm.Instance.ChangeChatOffset(MainForm.Instance.OffsetIncreaseValueMilliseconds);
            } else if (e.KeyCode == Keys.O) {
                MainForm.Instance.ChangeChatOffset(-MainForm.Instance.OffsetIncreaseValueMilliseconds);
            } else if (e.Control && e.KeyCode == Keys.H) {
                MainForm.Instance.ToggleHiddenChatBox();
            } else if (e.Control && e.KeyCode == Keys.W) {
                MainForm.Instance.ToggleHiddenChatBoxWindow();
            } else if (e.Control && e.KeyCode == Keys.S) {
                MainForm.Instance.ToggleStickyChatBox();
            } else if (e.Control && e.KeyCode == Keys.T) {
                MainForm.Instance.ToggleTransparentChatBox();
            } else if (e.Control && e.KeyCode == Keys.N) {
                MainForm.Instance.OpenVodFile();
            }
        }
    }
}
