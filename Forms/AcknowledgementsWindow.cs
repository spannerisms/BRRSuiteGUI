using System.Diagnostics;

namespace BRRSuiteGUI;

public partial class AcknowledgementsWindow : Form {
	public AcknowledgementsWindow() {
		InitializeComponent();
		VersionLabel.Text = $"Version {MainForm.VersionString}";
	}

	private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
		Process.Start("explorer.exe", "https://github.com/Optiroc/BRRtools/");
	}

	private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
		Process.Start("explorer.exe", "https://github.com/tewtal/mITroid/blob/master/mITroid/NSPC/BRR.cs/");
	}

	private void IClickedTheLogo(object sender, EventArgs e) {
		Process.Start("explorer.exe", "https://github.com/spannerisms/BRRSuiteGUI/");
	}
}
