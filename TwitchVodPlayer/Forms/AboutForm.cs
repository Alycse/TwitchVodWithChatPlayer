using System;
using System.Windows.Forms;

namespace TwitchVodPlayer.Forms {
    public partial class AboutForm : Form {

        private static AboutForm instance;
        public static AboutForm Instance {
            get {
                if (instance == null) {
                    instance = new AboutForm();
                }
                return instance;
            }
        }

        //Initialization

        public AboutForm() {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e) {
            versionLabel.Text = "v" + Updates.UpdateChecker.CurrentVersion;
        }

        //Methods

        private void AboutForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }

        private void GitHubLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start(TwitchVodPlayer.Constants.GitHubLink);
        }

        
    }
}
