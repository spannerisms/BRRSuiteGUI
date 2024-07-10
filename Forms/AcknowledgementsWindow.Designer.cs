namespace BRRSuiteGUI;

partial class AcknowledgementsWindow {
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
		VersionLabel = new Label();
		label2 = new Label();
		label3 = new Label();
		label4 = new Label();
		label5 = new Label();
		linkLabel1 = new LinkLabel();
		label6 = new Label();
		label7 = new Label();
		linkLabel2 = new LinkLabel();
		pictureBox1 = new PictureBox();
		((System.ComponentModel.ISupportInitialize) pictureBox1).BeginInit();
		SuspendLayout();
		// 
		// label1
		// 
		label1.Font = new Font("Segoe UI", 19F);
		label1.Location = new Point(0, 0);
		label1.Name = "label1";
		label1.Size = new Size(236, 39);
		label1.TabIndex = 0;
		label1.Text = "BRR Suite GUI";
		label1.TextAlign = ContentAlignment.MiddleCenter;
		// 
		// VersionLabel
		// 
		VersionLabel.Location = new Point(0, 39);
		VersionLabel.Name = "VersionLabel";
		VersionLabel.Size = new Size(236, 18);
		VersionLabel.TabIndex = 1;
		VersionLabel.Text = "Version";
		VersionLabel.TextAlign = ContentAlignment.TopCenter;
		// 
		// label2
		// 
		label2.AutoSize = true;
		label2.Font = new Font("Segoe UI", 11F);
		label2.Location = new Point(0, 74);
		label2.Name = "label2";
		label2.Size = new Size(113, 20);
		label2.TabIndex = 2;
		label2.Text = "Main developer";
		// 
		// label3
		// 
		label3.AutoSize = true;
		label3.Location = new Point(12, 94);
		label3.Name = "label3";
		label3.Size = new Size(26, 15);
		label3.TabIndex = 3;
		label3.Text = "kan";
		// 
		// label4
		// 
		label4.AutoSize = true;
		label4.Font = new Font("Segoe UI", 11F);
		label4.Location = new Point(0, 119);
		label4.Name = "label4";
		label4.Size = new Size(99, 20);
		label4.TabIndex = 4;
		label4.Text = "Original tools";
		// 
		// label5
		// 
		label5.AutoSize = true;
		label5.Location = new Point(12, 139);
		label5.Name = "label5";
		label5.Size = new Size(70, 60);
		label5.TabIndex = 5;
		label5.Text = "Optiric\r\nBregalad\r\nKode54\r\nnyanpasu64";
		// 
		// linkLabel1
		// 
		linkLabel1.AutoSize = true;
		linkLabel1.Location = new Point(112, 139);
		linkLabel1.Name = "linkLabel1";
		linkLabel1.Size = new Size(166, 15);
		linkLabel1.TabIndex = 6;
		linkLabel1.TabStop = true;
		linkLabel1.Text = "github.com/Optiroc/BRRtools";
		linkLabel1.LinkClicked += LinkLabel1_LinkClicked;
		// 
		// label6
		// 
		label6.AutoSize = true;
		label6.Font = new Font("Segoe UI", 11F);
		label6.Location = new Point(0, 219);
		label6.Name = "label6";
		label6.Size = new Size(116, 20);
		label6.TabIndex = 7;
		label6.Text = "Original C# port";
		// 
		// label7
		// 
		label7.AutoSize = true;
		label7.Location = new Point(12, 239);
		label7.Name = "label7";
		label7.Size = new Size(31, 15);
		label7.TabIndex = 8;
		label7.Text = "total";
		// 
		// linkLabel2
		// 
		linkLabel2.AutoSize = true;
		linkLabel2.Location = new Point(112, 239);
		linkLabel2.Name = "linkLabel2";
		linkLabel2.Size = new Size(205, 15);
		linkLabel2.TabIndex = 9;
		linkLabel2.TabStop = true;
		linkLabel2.Text = "github.com/tewtal/mITroid/.../BRR.cs";
		linkLabel2.LinkClicked += LinkLabel2_LinkClicked;
		// 
		// pictureBox1
		// 
		pictureBox1.Anchor =  AnchorStyles.Top | AnchorStyles.Right;
		pictureBox1.BackColor = Color.Transparent;
		pictureBox1.Image = Properties.Resources.logofull;
		pictureBox1.InitialImage = null;
		pictureBox1.Location = new Point(233, 0);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new Size(130, 130);
		pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 10;
		pictureBox1.TabStop = false;
		pictureBox1.Click += IClickedTheLogo;
		// 
		// AcknowledgementsWindow
		// 
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(363, 298);
		Controls.Add(pictureBox1);
		Controls.Add(linkLabel2);
		Controls.Add(label7);
		Controls.Add(label6);
		Controls.Add(linkLabel1);
		Controls.Add(label5);
		Controls.Add(label4);
		Controls.Add(label3);
		Controls.Add(label2);
		Controls.Add(VersionLabel);
		Controls.Add(label1);
		Cursor = Cursors.Hand;
		FormBorderStyle = FormBorderStyle.FixedToolWindow;
		MaximizeBox = false;
		MinimizeBox = false;
		Name = "AcknowledgementsWindow";
		ShowIcon = false;
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "BRR Suite GUI";
		((System.ComponentModel.ISupportInitialize) pictureBox1).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private Label label1;
	private Label VersionLabel;
	private Label label2;
	private Label label3;
	private Label label4;
	private Label label5;
	private LinkLabel linkLabel1;
	private Label label6;
	private Label label7;
	private LinkLabel linkLabel2;
	private PictureBox pictureBox1;
}