using System;
using System.Windows.Forms;

namespace TwitchVodPlayer.Forms {
    public partial class ResourceDownloaderForm : Form {

        private static ResourceDownloaderForm instance;
        public static ResourceDownloaderForm Instance {
            get {
                if (instance == null) {
                    instance = new ResourceDownloaderForm();
                }
                return instance;
            }
        }

        //Events

        public event Forms.EventHandlers.DownloadedResourcesEventHandler DownloadedResources;
        protected virtual void OnDownloadedResources(object sender, EventArgs e) {
            DownloadedResources?.Invoke(this, e);
        }

        //Event Broadcasts

        private void BroadcastDownloadedResourcesEvent() {
            OnDownloadedResources(this, new EventArgs());
        }

        //Initialization

        public ResourceDownloaderForm() {
            InitializeComponent();
        }

        private void ResourceDownloaderForm_Load(object sender, EventArgs e) {

        }

        //Methods

        private void ResourceDownloaderForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }

        private void DownloadResourcesButton_Click(object sender, EventArgs e) {
            Resources.ResourceDownloader resourceDownloader = new Resources.ResourceDownloader();

            resourceDownloader.DownloadingResources += ResourceDownloaderForm_DownloadingResources;
            resourceDownloader.NewProgressDownloadingResources += ResourceDownloaderForm_NewProgressDownloadingResources;
            resourceDownloader.DownloadedResources += ResourceDownloaderForm_DownloadedResources;
            resourceDownloader.ErrorOccuredDownloadingResources += ResourceDownloaderForm_ErrorOccuredDownloadingResources;

            resourceDownloader.DownloadResources(channelNameTextBox.Text, downloadBadgesCheckBox.Checked, downloadBttvEmoticonsCheckBox.Checked, 
                downloadFfzEmoticonsCheckBox.Checked, downloadFfzEmoticonsCheckBox.Checked)
            ;
        }

        private void ResourceDownloaderForm_DownloadingResources(object sender, Resources.EventHandlers.DownloadingResourcesEventArgs e) {
            Instance.Invoke(new Action(() => {
                progressBar.Value = 0;

                infoTextBox.Text = e.Message;
            }));
        }
        private void ResourceDownloaderForm_NewProgressDownloadingResources(object sender, Resources.EventHandlers.NewProgressDownloadingResourcesEventArgs e) {
            Instance.Invoke(new Action(() => {
                progressBar.Value = Math.Min(e.Progress, 100);

                infoTextBox.Text = e.Message;
            }));
        }
        private void ResourceDownloaderForm_DownloadedResources(object sender, Resources.EventHandlers.DownloadedResourcesEventArgs e) {
            Instance.Invoke(new Action(() => {
                infoTextBox.Text = e.Message;

                progressBar.Value = 100;

                BroadcastDownloadedResourcesEvent();

                ((Resources.ResourceDownloader)sender).DownloadingResources -= ResourceDownloaderForm_DownloadingResources;
                ((Resources.ResourceDownloader)sender).NewProgressDownloadingResources -= ResourceDownloaderForm_NewProgressDownloadingResources;
                ((Resources.ResourceDownloader)sender).DownloadedResources -= ResourceDownloaderForm_DownloadedResources;
                ((Resources.ResourceDownloader)sender).ErrorOccuredDownloadingResources -= ResourceDownloaderForm_ErrorOccuredDownloadingResources;
            }));
        }
        private void ResourceDownloaderForm_ErrorOccuredDownloadingResources(object sender, Resources.EventHandlers.ErrorOccuredDownloadingResourcesEventArgs e) {
            Instance.Invoke(new Action(() => {
                infoTextBox.Text = e.Message;

                progressBar.Value = 0;

                ((Resources.ResourceDownloader)sender).DownloadingResources -= ResourceDownloaderForm_DownloadingResources;
                ((Resources.ResourceDownloader)sender).NewProgressDownloadingResources -= ResourceDownloaderForm_NewProgressDownloadingResources;
                ((Resources.ResourceDownloader)sender).DownloadedResources -= ResourceDownloaderForm_DownloadedResources;
                ((Resources.ResourceDownloader)sender).ErrorOccuredDownloadingResources -= ResourceDownloaderForm_ErrorOccuredDownloadingResources;
            }));
        }
    }
}
