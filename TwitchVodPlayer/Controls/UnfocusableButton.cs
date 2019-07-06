using System.Windows.Forms;

namespace TwitchVodPlayer.Controls {
    public class UnfocusableButton : Button {
        public UnfocusableButton() {
            SetStyle(ControlStyles.Selectable, false);
        }
    }
}
