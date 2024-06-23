using System.Diagnostics;

namespace BRRSuiteGUI;

public partial class UpdateAnnouncer : Form {

	public string Message {
		set => MainMessageLabel.Text = value;
	}

	public string VersionCurrent {
		set => CurrentVersionLabel.Text = value;
	}
	public string VersionNew {
		set => AvailableVersionLabel.Text = value;
	}

	public UpdateAnnouncer() {
		InitializeComponent();
		ReleaseLink.VisitedLinkColor = ReleaseLink.LinkColor;
	}

	private void ReleaseLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
		Process.Start("explorer.exe", "https://github.com/spannerisms/BRRSuiteGUI/releases/latest/");
	}
}
