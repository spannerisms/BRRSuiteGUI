namespace BRRSuiteGUI;

partial class WaveformWindow {
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaveformWindow));
		WavePanel = new PictureBox();
		((System.ComponentModel.ISupportInitialize) WavePanel).BeginInit();
		SuspendLayout();
		// 
		// WavePanel
		// 
		WavePanel.BackColor = SystemColors.ActiveCaptionText;
		WavePanel.Dock = DockStyle.Top;
		WavePanel.Location = new Point(0, 0);
		WavePanel.MinimumSize = new Size(800, 360);
		WavePanel.Name = "WavePanel";
		WavePanel.Padding = new Padding(5);
		WavePanel.Size = new Size(800, 360);
		WavePanel.SizeMode = PictureBoxSizeMode.StretchImage;
		WavePanel.TabIndex = 0;
		WavePanel.TabStop = false;
		// 
		// WaveformWindow
		// 
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(800, 450);
		Controls.Add(WavePanel);
		Icon = (Icon) resources.GetObject("$this.Icon");
		MinimumSize = new Size(816, 489);
		Name = "WaveformWindow";
		Text = "Waveform viewer";
		VisibleChanged += WaveformWindow_VisibleChanged;
		((System.ComponentModel.ISupportInitialize) WavePanel).EndInit();
		ResumeLayout(false);
	}

	#endregion

	private PictureBox WavePanel;
}
