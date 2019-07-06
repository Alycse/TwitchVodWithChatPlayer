using System;
using System.Windows.Forms;

namespace TwitchVodPlayer {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Properties.Settings.Default.ClientId == "") {
                Properties.Settings.Default.ClientId = Fetching.Constants.DefaultClientId;
            }

            Application.Run(Forms.MainForm.Instance);
        }
    }

}
