namespace BRRSuiteGUI;

partial class AdvancedSettingsWindow {
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
		Label label1;
		Label label2;
		TheAcceptButton = new Button();
		TheCancelButton = new Button();
		PreviewDurationBox = new RoundedUpDown();
		TrimZerosBox = new RoundedUpDown();
		label1 = new Label();
		label2 = new Label();
		((System.ComponentModel.ISupportInitialize) PreviewDurationBox).BeginInit();
		((System.ComponentModel.ISupportInitialize) TrimZerosBox).BeginInit();
		SuspendLayout();
		// 
		// label1
		// 
		label1.AutoSize = true;
		label1.Location = new Point(21, 9);
		label1.Name = "label1";
		label1.Size = new Size(112, 15);
		label1.TabIndex = 3;
		label1.Text = "Preview duration (s)";
		// 
		// label2
		// 
		label2.AutoSize = true;
		label2.Location = new Point(12, 38);
		label2.Name = "label2";
		label2.Size = new Size(121, 15);
		label2.TabIndex = 4;
		label2.Text = "Zeros when trimming";
		// 
		// TheAcceptButton
		// 
		TheAcceptButton.Anchor =  AnchorStyles.Bottom | AnchorStyles.Right;
		TheAcceptButton.DialogResult = DialogResult.OK;
		TheAcceptButton.Location = new Point(49, 102);
		TheAcceptButton.Name = "TheAcceptButton";
		TheAcceptButton.Size = new Size(75, 23);
		TheAcceptButton.TabIndex = 0;
		TheAcceptButton.Text = "OK";
		TheAcceptButton.UseVisualStyleBackColor = true;
		// 
		// TheCancelButton
		// 
		TheCancelButton.Anchor =  AnchorStyles.Bottom | AnchorStyles.Right;
		TheCancelButton.DialogResult = DialogResult.Cancel;
		TheCancelButton.Location = new Point(126, 102);
		TheCancelButton.Name = "TheCancelButton";
		TheCancelButton.Size = new Size(75, 23);
		TheCancelButton.TabIndex = 1;
		TheCancelButton.Text = "Cancel";
		TheCancelButton.UseVisualStyleBackColor = true;
		// 
		// PreviewDurationBox
		// 
		PreviewDurationBox.DecimalPlaces = 1;
		PreviewDurationBox.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
		PreviewDurationBox.InterceptArrowKeys = false;
		PreviewDurationBox.Location = new Point(146, 7);
		PreviewDurationBox.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
		PreviewDurationBox.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
		PreviewDurationBox.Name = "PreviewDurationBox";
		PreviewDurationBox.Size = new Size(53, 23);
		PreviewDurationBox.TabIndex = 2;
		PreviewDurationBox.TextAlign = HorizontalAlignment.Right;
		PreviewDurationBox.Value = new decimal(new int[] { 1, 0, 0, 65536 });
		// 
		// TrimZerosBox
		// 
		TrimZerosBox.InterceptArrowKeys = false;
		TrimZerosBox.Location = new Point(146, 36);
		TrimZerosBox.Maximum = new decimal(new int[] { 64, 0, 0, 0 });
		TrimZerosBox.Name = "TrimZerosBox";
		TrimZerosBox.Size = new Size(53, 23);
		TrimZerosBox.TabIndex = 5;
		TrimZerosBox.TextAlign = HorizontalAlignment.Right;
		TrimZerosBox.Value = new decimal(new int[] { 1, 0, 0, 0 });
		// 
		// AdvancedSettingsWindow
		// 
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(204, 127);
		ControlBox = false;
		Controls.Add(TrimZerosBox);
		Controls.Add(label2);
		Controls.Add(label1);
		Controls.Add(PreviewDurationBox);
		Controls.Add(TheCancelButton);
		Controls.Add(TheAcceptButton);
		FormBorderStyle = FormBorderStyle.FixedToolWindow;
		Name = "AdvancedSettingsWindow";
		Text = "Advanced settings";
		((System.ComponentModel.ISupportInitialize) PreviewDurationBox).EndInit();
		((System.ComponentModel.ISupportInitialize) TrimZerosBox).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private Button TheAcceptButton;
	private Button TheCancelButton;
	private RoundedUpDown PreviewDurationBox;
	private RoundedUpDown TrimZerosBox;
}
