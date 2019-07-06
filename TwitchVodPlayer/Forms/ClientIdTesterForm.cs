using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwitchVodPlayer.Forms {
    public partial class ClientIdTesterForm : Form {

        private static ClientIdTesterForm instance;
        public static ClientIdTesterForm Instance {
            get {
                if (instance == null) {
                    instance = new ClientIdTesterForm();
                }
                return instance;
            }
        }

        //Initialization

        public ClientIdTesterForm() {
            InitializeComponent();
        }

        private void ClientIdForm_Load(object sender, EventArgs e) {

        }

        public new void Show() {
            base.Show();
            
            ResetForm();

            LoadSavedUserSettings();
        }

        private void LoadSavedUserSettings() {
            clientIdTextBox.Text = Properties.Settings.Default.ClientId;
        }

        private void ResetForm() {
            infoTextBox.Text = "";
            progressBar.Value = 0;
        }

        //Methods

        private void ClientIdForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e) {
            Properties.Settings.Default.ClientId = clientIdTextBox.Text;
            Hide();
        }

        private void TestClientIdButton_Click(object sender, EventArgs e) {
            Task.Run(() => TestClientId(clientIdTextBox.Text));
        }

        private void TestClientId(string clientId) {
            Fetching.ClientIdTester clientIdTester = new Fetching.ClientIdTester();

            clientIdTester.TestingClientId += ClientIdForm_TestingClientId;
            clientIdTester.TestedClientId += ClientIdForm_TestedClientId;
            clientIdTester.ErrorOccuredTestingClientId += ClientIdForm_ErrorOccuredTestingClientId;
            clientIdTester.NewProgressTestingClientId += ClientIdForm_NewProgressTestingClientId;

            clientIdTester.TestClientId(clientId);
        }

        private void ClientIdForm_TestingClientId(object sender, Fetching.EventHandlers.TestingClientIdEventArgs e) {
            Instance.Invoke(new Action(() => {
                progressBar.Value = 0;

                infoTextBox.Text = e.Message;
            }));
        }
        private void ClientIdForm_NewProgressTestingClientId(object sender, Fetching.EventHandlers.NewProgressTestingClientIdEventArgs e) {
            Instance.Invoke(new Action(() => {
                progressBar.Value = Math.Min(e.Progress, 100);
                infoTextBox.Text = e.Message;
            }));
        }
        private void ClientIdForm_TestedClientId(object sender, Fetching.EventHandlers.TestedClientIdEventArgs e) {
            Instance.Invoke(new Action(() => {
                infoTextBox.Text = e.Message;

                Properties.Settings.Default.ClientId = e.ClientId;
                Properties.Settings.Default.Save();

                ((Fetching.ClientIdTester)sender).TestingClientId -= ClientIdForm_TestingClientId;
                ((Fetching.ClientIdTester)sender).NewProgressTestingClientId -= ClientIdForm_NewProgressTestingClientId;
                ((Fetching.ClientIdTester)sender).TestedClientId -= ClientIdForm_TestedClientId;
                ((Fetching.ClientIdTester)sender).ErrorOccuredTestingClientId -= ClientIdForm_ErrorOccuredTestingClientId;
            }));
        }
        private void ClientIdForm_ErrorOccuredTestingClientId(object sender, Fetching.EventHandlers.ErrorOccuredTestingClientIdEventArgs e) {
            Instance.Invoke(new Action(() => {
                infoTextBox.Text = e.Message;

                progressBar.Value = 0;

                ((Fetching.ClientIdTester)sender).TestingClientId -= ClientIdForm_TestingClientId;
                ((Fetching.ClientIdTester)sender).NewProgressTestingClientId -= ClientIdForm_NewProgressTestingClientId;
                ((Fetching.ClientIdTester)sender).TestedClientId -= ClientIdForm_TestedClientId;
                ((Fetching.ClientIdTester)sender).ErrorOccuredTestingClientId -= ClientIdForm_ErrorOccuredTestingClientId;
            }));
        }
    }
}
