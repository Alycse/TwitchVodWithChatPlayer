using System;
using System.Windows.Forms;

namespace TwitchVodPlayer.Forms {
    public partial class HelpForm : Form {

        private static HelpForm instance;
        public static HelpForm Instance {
            get {
                if (instance == null) {
                    instance = new HelpForm();
                }
                return instance;
            }
        }

        //Fields

        //Initialization

        public HelpForm() {
            InitializeComponent();
        }

        private void HelpForm_Load(object sender, EventArgs e) {
            webBrowser1.Navigate(new Uri(Help.Constants.HelpHtmlPath));
        }

        //Methods

        private void HelpForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
