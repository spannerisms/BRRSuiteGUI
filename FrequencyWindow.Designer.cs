namespace BRRSuiteGUI;

partial class FrequencyWindow {
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrequencyWindow));
		CheatSheet = new DataGridView();
		((System.ComponentModel.ISupportInitialize) CheatSheet).BeginInit();
		SuspendLayout();
		// 
		// CheatSheet
		// 
		CheatSheet.AllowUserToAddRows = false;
		CheatSheet.AllowUserToDeleteRows = false;
		CheatSheet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
		CheatSheet.Dock = DockStyle.Fill;
		CheatSheet.Enabled = false;
		CheatSheet.Location = new Point(0, 0);
		CheatSheet.MultiSelect = false;
		CheatSheet.Name = "CheatSheet";
		CheatSheet.ReadOnly = true;
		CheatSheet.RowHeadersVisible = false;
		CheatSheet.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		CheatSheet.ScrollBars = ScrollBars.None;
		CheatSheet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		CheatSheet.ShowCellErrors = false;
		CheatSheet.ShowCellToolTips = false;
		CheatSheet.ShowEditingIcon = false;
		CheatSheet.ShowRowErrors = false;
		CheatSheet.Size = new Size(388, 328);
		CheatSheet.TabIndex = 0;
		// 
		// FrequencyWindow
		// 
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(388, 328);
		Controls.Add(CheatSheet);
		FormBorderStyle = FormBorderStyle.FixedDialog;
		Icon = (Icon) resources.GetObject("$this.Icon");
		MaximizeBox = false;
		Name = "FrequencyWindow";
		StartPosition = FormStartPosition.CenterParent;
		Text = "Frequency cheat sheet";
		((System.ComponentModel.ISupportInitialize) CheatSheet).EndInit();
		ResumeLayout(false);
	}

	#endregion

	private DataGridView CheatSheet;
}