namespace BRRSuiteGUI;

partial class UpdateAnnouncer {
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary>
	/// Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing) {
		if (disposing && (components != null)) {
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	#region Windows Form Designer generated code

	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent() {
		label1 = new Label();
		label2 = new Label();
		CurrentVersionLabel = new Label();
		AvailableVersionLabel = new Label();
		MainMessageLabel = new Label();
		ReleaseLink = new LinkLabel();
		SuspendLayout();
		// 
		// label1
		// 
		label1.AutoSize = true;
		label1.Location = new Point(1, 73);
		label1.Name = "label1";
		label1.Size = new Size(91, 15);
		label1.TabIndex = 2;
		label1.Text = "Current Version:";
		// 
		// label2
		// 
		label2.AutoSize = true;
		label2.Location = new Point(34, 92);
		label2.Name = "label2";
		label2.Size = new Size(58, 15);
		label2.TabIndex = 3;
		label2.Text = "Available:";
		// 
		// CurrentVersionLabel
		// 
		CurrentVersionLabel.AutoSize = true;
		CurrentVersionLabel.Location = new Point(113, 73);
		CurrentVersionLabel.Name = "CurrentVersionLabel";
		CurrentVersionLabel.Size = new Size(12, 15);
		CurrentVersionLabel.TabIndex = 4;
		CurrentVersionLabel.Text = "-";
		// 
		// AvailableVersionLabel
		// 
		AvailableVersionLabel.AutoSize = true;
		AvailableVersionLabel.Location = new Point(113, 92);
		AvailableVersionLabel.Name = "AvailableVersionLabel";
		AvailableVersionLabel.Size = new Size(12, 15);
		AvailableVersionLabel.TabIndex = 5;
		AvailableVersionLabel.Text = "-";
		// 
		// MainMessageLabel
		// 
		MainMessageLabel.Location = new Point(1, 3);
		MainMessageLabel.Name = "MainMessageLabel";
		MainMessageLabel.Size = new Size(266, 64);
		MainMessageLabel.TabIndex = 7;
		MainMessageLabel.Text = "You may or may not have updates.\r\nI don't know.\r\nI'm just placeholder text.\r\n";
		MainMessageLabel.TextAlign = ContentAlignment.MiddleCenter;
		// 
		// ReleaseLink
		// 
		ReleaseLink.LinkBehavior = LinkBehavior.AlwaysUnderline;
		ReleaseLink.LinkColor = Color.DodgerBlue;
		ReleaseLink.Location = new Point(1, 126);
		ReleaseLink.Name = "ReleaseLink";
		ReleaseLink.Size = new Size(266, 23);
		ReleaseLink.TabIndex = 8;
		ReleaseLink.TabStop = true;
		ReleaseLink.Text = "Open releases page in browser";
		ReleaseLink.TextAlign = ContentAlignment.MiddleCenter;
		ReleaseLink.LinkClicked += ReleaseLink_LinkClicked;
		// 
		// UpdateAnnouncer
		// 
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(269, 150);
		Controls.Add(ReleaseLink);
		Controls.Add(MainMessageLabel);
		Controls.Add(AvailableVersionLabel);
		Controls.Add(CurrentVersionLabel);
		Controls.Add(label2);
		Controls.Add(label1);
		FormBorderStyle = FormBorderStyle.FixedDialog;
		MaximizeBox = false;
		MinimizeBox = false;
		Name = "UpdateAnnouncer";
		StartPosition = FormStartPosition.CenterParent;
		Text = "Update your software!";
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion
	private Label label1;
	private Label label2;
	private Label CurrentVersionLabel;
	private Label AvailableVersionLabel;
	private Label MainMessageLabel;
	private LinkLabel ReleaseLink;
}