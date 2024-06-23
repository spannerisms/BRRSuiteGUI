namespace BRRSuiteGUI;

partial class MainForm {
	/// <summary>
	///  Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary>
	///  Clean up any resources being used.
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
	///  Required method for Designer support - do not modify
	///  the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent() {
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
		FileNameBox = new TextBox();
		label1 = new Label();
		label2 = new Label();
		OutputGroupBox = new GroupBox();
		label21 = new Label();
		TrebleBoostFilterBox = new ComboBox();
		FilterSilenceBox = new CheckBox();
		groupBox1 = new GroupBox();
		LoopFindRangeBox = new NumericUpDown();
		FindLoopsButton = new Button();
		label9 = new Label();
		label14 = new Label();
		LoopAttemptsBox = new NumericUpDown();
		label15 = new Label();
		LoopIncrementBox = new NumericUpDown();
		LoopStartBox = new NumericUpDown();
		label8 = new Label();
		CreateUnloopedButton = new Button();
		label12 = new Label();
		OutputInterpolationBox = new ComboBox();
		ResampleBox = new ComboBox();
		groupBox3 = new GroupBox();
		AdjustButton = new Button();
		label7 = new Label();
		AdjustRangeBox = new NumericUpDown();
		SampleAdjustAtBox = new NumericUpDown();
		label6 = new Label();
		BRRBlocksBox = new TextBox();
		label11 = new Label();
		label13 = new Label();
		ExportNameBox = new TextBox();
		InputGroupBox = new GroupBox();
		TrimZerosBox = new CheckBox();
		ScratchBox = new TextBox();
		label10 = new Label();
		TrimPointBox = new NumericUpDown();
		FindZeroesButton = new Button();
		ZeroCrossingBox = new TextBox();
		label5 = new Label();
		label4 = new Label();
		label3 = new Label();
		SampleCountBox = new TextBox();
		FidelityBox = new TextBox();
		SampleRateBox = new TextBox();
		TaskProgress = new ProgressBar();
		panel2 = new Panel();
		RefreshFileButton = new Button();
		menuStrip1 = new MenuStrip();
		windowToolStripMenuItem = new ToolStripMenuItem();
		frequencyCheatsheetToolStripMenuItem = new ToolStripMenuItem();
		helpToolStripMenuItem = new ToolStripMenuItem();
		acknowledgementsToolStripMenuItem = new ToolStripMenuItem();
		UpdateAvailableToolStripMenuItem = new ToolStripMenuItem();
		LoopsFolderPanel = new Panel();
		OutputDirectoryBox = new TextBox();
		label17 = new Label();
		CancelTaskButton = new Button();
		ListenGroupBox = new GroupBox();
		BrrExportTypeBox = new ComboBox();
		LoopStartInputLabel = new Label();
		label20 = new Label();
		ExportWAVButton = new CheckBox();
		ExportBRRBox = new CheckBox();
		label19 = new Label();
		label18 = new Label();
		AutoPlayCheckBox = new CheckBox();
		SizeLabel = new Label();
		LoopPointLabel = new Label();
		StopButton = new Button();
		PlayButton = new Button();
		BRRTestBox = new ListBox();
		panel3 = new Panel();
		ExportFinalNameBox = new TextBox();
		ExportThisButton = new Button();
		panel1 = new Panel();
		OutputGroupBox.SuspendLayout();
		groupBox1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize) LoopFindRangeBox).BeginInit();
		((System.ComponentModel.ISupportInitialize) LoopAttemptsBox).BeginInit();
		((System.ComponentModel.ISupportInitialize) LoopIncrementBox).BeginInit();
		((System.ComponentModel.ISupportInitialize) LoopStartBox).BeginInit();
		groupBox3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize) AdjustRangeBox).BeginInit();
		((System.ComponentModel.ISupportInitialize) SampleAdjustAtBox).BeginInit();
		InputGroupBox.SuspendLayout();
		((System.ComponentModel.ISupportInitialize) TrimPointBox).BeginInit();
		panel2.SuspendLayout();
		menuStrip1.SuspendLayout();
		LoopsFolderPanel.SuspendLayout();
		ListenGroupBox.SuspendLayout();
		panel3.SuspendLayout();
		panel1.SuspendLayout();
		SuspendLayout();
		// 
		// FileNameBox
		// 
		FileNameBox.Anchor =  AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		FileNameBox.Cursor = Cursors.Hand;
		FileNameBox.Location = new Point(55, 6);
		FileNameBox.Name = "FileNameBox";
		FileNameBox.ReadOnly = true;
		FileNameBox.Size = new Size(600, 23);
		FileNameBox.TabIndex = 0;
		FileNameBox.Click += FileNameBox_Click;
		// 
		// label1
		// 
		label1.AutoSize = true;
		label1.Location = new Point(4, 9);
		label1.Name = "label1";
		label1.Size = new Size(51, 15);
		label1.TabIndex = 1;
		label1.Text = "WAV file";
		// 
		// label2
		// 
		label2.Anchor =  AnchorStyles.Top | AnchorStyles.Right;
		label2.AutoSize = true;
		label2.Location = new Point(34, 48);
		label2.Name = "label2";
		label2.Size = new Size(72, 15);
		label2.TabIndex = 2;
		label2.Text = "Resample to";
		// 
		// OutputGroupBox
		// 
		OutputGroupBox.Anchor =  AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		OutputGroupBox.BackColor = Color.Transparent;
		OutputGroupBox.Controls.Add(label21);
		OutputGroupBox.Controls.Add(TrebleBoostFilterBox);
		OutputGroupBox.Controls.Add(FilterSilenceBox);
		OutputGroupBox.Controls.Add(groupBox1);
		OutputGroupBox.Controls.Add(CreateUnloopedButton);
		OutputGroupBox.Controls.Add(label12);
		OutputGroupBox.Controls.Add(OutputInterpolationBox);
		OutputGroupBox.Controls.Add(ResampleBox);
		OutputGroupBox.Controls.Add(label2);
		OutputGroupBox.Controls.Add(groupBox3);
		OutputGroupBox.Controls.Add(BRRBlocksBox);
		OutputGroupBox.Controls.Add(label11);
		OutputGroupBox.Location = new Point(275, 64);
		OutputGroupBox.Name = "OutputGroupBox";
		OutputGroupBox.Size = new Size(269, 466);
		OutputGroupBox.TabIndex = 16;
		OutputGroupBox.TabStop = false;
		OutputGroupBox.Text = "Output";
		// 
		// label21
		// 
		label21.Anchor =  AnchorStyles.Top | AnchorStyles.Right;
		label21.AutoSize = true;
		label21.Location = new Point(35, 105);
		label21.Name = "label21";
		label21.Size = new Size(71, 15);
		label21.TabIndex = 28;
		label21.Text = "Treble boost";
		// 
		// TrebleBoostFilterBox
		// 
		TrebleBoostFilterBox.Anchor =  AnchorStyles.Top | AnchorStyles.Right;
		TrebleBoostFilterBox.DropDownStyle = ComboBoxStyle.DropDownList;
		TrebleBoostFilterBox.FormattingEnabled = true;
		TrebleBoostFilterBox.Location = new Point(112, 102);
		TrebleBoostFilterBox.Name = "TrebleBoostFilterBox";
		TrebleBoostFilterBox.Size = new Size(151, 23);
		TrebleBoostFilterBox.TabIndex = 27;
		// 
		// FilterSilenceBox
		// 
		FilterSilenceBox.Anchor =  AnchorStyles.Top | AnchorStyles.Right;
		FilterSilenceBox.AutoSize = true;
		FilterSilenceBox.Location = new Point(112, 131);
		FilterSilenceBox.Name = "FilterSilenceBox";
		FilterSilenceBox.Size = new Size(120, 19);
		FilterSilenceBox.TabIndex = 26;
		FilterSilenceBox.Text = "Force silence start";
		FilterSilenceBox.UseVisualStyleBackColor = true;
		// 
		// groupBox1
		// 
		groupBox1.Anchor =  AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		groupBox1.Controls.Add(LoopFindRangeBox);
		groupBox1.Controls.Add(FindLoopsButton);
		groupBox1.Controls.Add(label9);
		groupBox1.Controls.Add(label14);
		groupBox1.Controls.Add(LoopAttemptsBox);
		groupBox1.Controls.Add(label15);
		groupBox1.Controls.Add(LoopIncrementBox);
		groupBox1.Controls.Add(LoopStartBox);
		groupBox1.Controls.Add(label8);
		groupBox1.Location = new Point(0, 206);
		groupBox1.Name = "groupBox1";
		groupBox1.Size = new Size(269, 170);
		groupBox1.TabIndex = 0;
		groupBox1.TabStop = false;
		groupBox1.Text = "Loop search";
		// 
		// LoopFindRangeBox
		// 
		LoopFindRangeBox.Anchor =  AnchorStyles.Top | AnchorStyles.Right;
		LoopFindRangeBox.InterceptArrowKeys = false;
		LoopFindRangeBox.Location = new Point(114, 109);
		LoopFindRangeBox.Name = "LoopFindRangeBox";
		LoopFindRangeBox.Size = new Size(151, 23);
		LoopFindRangeBox.TabIndex = 0;
		LoopFindRangeBox.TextAlign = HorizontalAlignment.Right;
		// 
		// FindLoopsButton
		// 
		FindLoopsButton.Anchor =  AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		FindLoopsButton.Location = new Point(3, 141);
		FindLoopsButton.Name = "FindLoopsButton";
		FindLoopsButton.Size = new Size(263, 23);
		FindLoopsButton.TabIndex = 1;
		FindLoopsButton.Text = "Create loop candidates";
		FindLoopsButton.UseVisualStyleBackColor = true;
		FindLoopsButton.Click += FindLoopsButton_Click;
		// 
		// label9
		// 
		label9.Anchor =  AnchorStyles.Top | AnchorStyles.Right;
		label9.AutoSize = true;
		label9.Location = new Point(21, 53);
		label9.Name = "label9";
		label9.Size = new Size(85, 15);
		label9.TabIndex = 22;
		label9.Text = "Attempt count";
		// 
		// label14
		// 
		label14.Anchor =  AnchorStyles.Top | AnchorStyles.Right;
		label14.AutoSize = true;
		label14.Location = new Point(47, 82);
		label14.Name = "label14";
		label14.Size = new Size(61, 15);
		label14.TabIndex = 24;
		label14.Text = "Increment";
		// 
		// LoopAttemptsBox
		// 
		LoopAttemptsBox.Anchor =  AnchorStyles.Top | AnchorStyles.Right;
		LoopAttemptsBox.InterceptArrowKeys = false;
		LoopAttemptsBox.Location = new Point(114, 51);
		LoopAttemptsBox.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
		LoopAttemptsBox.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
		LoopAttemptsBox.Name = "LoopAttemptsBox";
		LoopAttemptsBox.Size = new Size(151, 23);
		LoopAttemptsBox.TabIndex = 25;
		LoopAttemptsBox.TextAlign = HorizontalAlignment.Right;
		LoopAttemptsBox.Value = new decimal(new int[] { 20, 0, 0, 0 });
		// 
		// label15
		// 
		label15.Anchor =  AnchorStyles.Top | AnchorStyles.Right;
		label15.AutoSize = true;
		label15.Location = new Point(68, 111);
		label15.Name = "label15";
		label15.Size = new Size(40, 15);
		label15.TabIndex = 26;
		label15.Text = "Range";
		// 
		// LoopIncrementBox
		// 
		LoopIncrementBox.Anchor =  AnchorStyles.Top | AnchorStyles.Right;
		LoopIncrementBox.InterceptArrowKeys = false;
		LoopIncrementBox.Location = new Point(114, 80);
		LoopIncrementBox.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
		LoopIncrementBox.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
		LoopIncrementBox.Name = "LoopIncrementBox";
		LoopIncrementBox.Size = new Size(151, 23);
		LoopIncrementBox.TabIndex = 27;
		LoopIncrementBox.TextAlign = HorizontalAlignment.Right;
		LoopIncrementBox.Value = new decimal(new int[] { 1, 0, 0, 0 });
		// 
		// LoopStartBox
		// 
		LoopStartBox.Anchor =  AnchorStyles.Top | AnchorStyles.Right;
		LoopStartBox.InterceptArrowKeys = false;
		LoopStartBox.Location = new Point(114, 22);
		LoopStartBox.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
		LoopStartBox.Name = "LoopStartBox";
		LoopStartBox.Size = new Size(151, 23);
		LoopStartBox.TabIndex = 28;
		LoopStartBox.TextAlign = HorizontalAlignment.Right;
		// 
		// label8
		// 
		label8.Anchor =  AnchorStyles.Top | AnchorStyles.Right;
		label8.AutoSize = true;
		label8.Location = new Point(11, 24);
		label8.Name = "label8";
		label8.Size = new Size(97, 15);
		label8.TabIndex = 13;
		label8.Text = "First loop sample";
		// 
		// CreateUnloopedButton
		// 
		CreateUnloopedButton.Location = new Point(3, 172);
		CreateUnloopedButton.Name = "CreateUnloopedButton";
		CreateUnloopedButton.Size = new Size(263, 23);
		CreateUnloopedButton.TabIndex = 1;
		CreateUnloopedButton.Text = "Create unlooped";
		CreateUnloopedButton.UseVisualStyleBackColor = true;
		CreateUnloopedButton.Click += CreateUnloopedButton_Click;
		// 
		// label12
		// 
		label12.Anchor =  AnchorStyles.Top | AnchorStyles.Right;
		label12.AutoSize = true;
		label12.Location = new Point(31, 77);
		label12.Name = "label12";
		label12.Size = new Size(75, 15);
		label12.TabIndex = 18;
		label12.Text = "Interpolation";
		// 
		// OutputInterpolationBox
		// 
		OutputInterpolationBox.Anchor =  AnchorStyles.Top | AnchorStyles.Right;
		OutputInterpolationBox.DropDownStyle = ComboBoxStyle.DropDownList;
		OutputInterpolationBox.FormattingEnabled = true;
		OutputInterpolationBox.Location = new Point(112, 74);
		OutputInterpolationBox.Name = "OutputInterpolationBox";
		OutputInterpolationBox.Size = new Size(151, 23);
		OutputInterpolationBox.TabIndex = 22;
		// 
		// ResampleBox
		// 
		ResampleBox.Anchor =  AnchorStyles.Top | AnchorStyles.Right;
		ResampleBox.DropDownStyle = ComboBoxStyle.DropDownList;
		ResampleBox.FormattingEnabled = true;
		ResampleBox.Location = new Point(112, 45);
		ResampleBox.Name = "ResampleBox";
		ResampleBox.Size = new Size(151, 23);
		ResampleBox.TabIndex = 23;
		ResampleBox.SelectedIndexChanged += SampleBox_SelectedIndexChanged;
		// 
		// groupBox3
		// 
		groupBox3.Anchor =  AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		groupBox3.Controls.Add(AdjustButton);
		groupBox3.Controls.Add(label7);
		groupBox3.Controls.Add(AdjustRangeBox);
		groupBox3.Controls.Add(SampleAdjustAtBox);
		groupBox3.Controls.Add(label6);
		groupBox3.Location = new Point(0, 382);
		groupBox3.Name = "groupBox3";
		groupBox3.Size = new Size(269, 84);
		groupBox3.TabIndex = 24;
		groupBox3.TabStop = false;
		groupBox3.Text = "Fine adjustments";
		// 
		// AdjustButton
		// 
		AdjustButton.Anchor =  AnchorStyles.Bottom | AnchorStyles.Right;
		AdjustButton.Location = new Point(193, 20);
		AdjustButton.Name = "AdjustButton";
		AdjustButton.Size = new Size(72, 23);
		AdjustButton.TabIndex = 0;
		AdjustButton.Text = "Adjust";
		AdjustButton.UseVisualStyleBackColor = true;
		AdjustButton.Click += AdjustButton_Click;
		// 
		// label7
		// 
		label7.AutoSize = true;
		label7.Location = new Point(84, 53);
		label7.Name = "label7";
		label7.Size = new Size(40, 15);
		label7.TabIndex = 14;
		label7.Text = "Range";
		// 
		// AdjustRangeBox
		// 
		AdjustRangeBox.Anchor =  AnchorStyles.Top | AnchorStyles.Right;
		AdjustRangeBox.InterceptArrowKeys = false;
		AdjustRangeBox.Location = new Point(130, 51);
		AdjustRangeBox.Maximum = new decimal(new int[] { 600, 0, 0, 0 });
		AdjustRangeBox.Name = "AdjustRangeBox";
		AdjustRangeBox.Size = new Size(55, 23);
		AdjustRangeBox.TabIndex = 15;
		AdjustRangeBox.TextAlign = HorizontalAlignment.Right;
		AdjustRangeBox.Value = new decimal(new int[] { 16, 0, 0, 0 });
		// 
		// SampleAdjustAtBox
		// 
		SampleAdjustAtBox.Anchor =  AnchorStyles.Top | AnchorStyles.Right;
		SampleAdjustAtBox.InterceptArrowKeys = false;
		SampleAdjustAtBox.Location = new Point(130, 22);
		SampleAdjustAtBox.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
		SampleAdjustAtBox.Name = "SampleAdjustAtBox";
		SampleAdjustAtBox.Size = new Size(55, 23);
		SampleAdjustAtBox.TabIndex = 16;
		SampleAdjustAtBox.TextAlign = HorizontalAlignment.Right;
		// 
		// label6
		// 
		label6.Anchor =  AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		label6.AutoSize = true;
		label6.Location = new Point(49, 24);
		label6.Name = "label6";
		label6.Size = new Size(75, 15);
		label6.TabIndex = 12;
		label6.Text = "Loop sample";
		// 
		// BRRBlocksBox
		// 
		BRRBlocksBox.Anchor =  AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		BRRBlocksBox.Enabled = false;
		BRRBlocksBox.Location = new Point(64, 16);
		BRRBlocksBox.Name = "BRRBlocksBox";
		BRRBlocksBox.PlaceholderText = "-";
		BRRBlocksBox.ReadOnly = true;
		BRRBlocksBox.Size = new Size(199, 23);
		BRRBlocksBox.TabIndex = 25;
		// 
		// label11
		// 
		label11.Anchor =  AnchorStyles.Bottom | AnchorStyles.Left;
		label11.AutoSize = true;
		label11.Location = new Point(11, 19);
		label11.Name = "label11";
		label11.Size = new Size(47, 15);
		label11.TabIndex = 16;
		label11.Text = "Est. size";
		// 
		// label13
		// 
		label13.Anchor =  AnchorStyles.Top | AnchorStyles.Right;
		label13.AutoSize = true;
		label13.Location = new Point(697, 10);
		label13.Name = "label13";
		label13.Size = new Size(39, 15);
		label13.TabIndex = 20;
		label13.Text = "Name";
		// 
		// ExportNameBox
		// 
		ExportNameBox.Anchor =  AnchorStyles.Top | AnchorStyles.Right;
		ExportNameBox.Location = new Point(738, 6);
		ExportNameBox.Name = "ExportNameBox";
		ExportNameBox.PlaceholderText = "wav name";
		ExportNameBox.Size = new Size(223, 23);
		ExportNameBox.TabIndex = 21;
		ExportNameBox.TextChanged += ExportNameBox_TextChanged;
		ExportNameBox.KeyDown += ExportNames_KeyDown;
		ExportNameBox.Leave += ExportNames_Leave;
		// 
		// InputGroupBox
		// 
		InputGroupBox.Anchor =  AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		InputGroupBox.Controls.Add(TrimZerosBox);
		InputGroupBox.Controls.Add(ScratchBox);
		InputGroupBox.Controls.Add(label10);
		InputGroupBox.Controls.Add(TrimPointBox);
		InputGroupBox.Controls.Add(FindZeroesButton);
		InputGroupBox.Controls.Add(ZeroCrossingBox);
		InputGroupBox.Controls.Add(label5);
		InputGroupBox.Controls.Add(label4);
		InputGroupBox.Controls.Add(label3);
		InputGroupBox.Controls.Add(SampleCountBox);
		InputGroupBox.Controls.Add(FidelityBox);
		InputGroupBox.Controls.Add(SampleRateBox);
		InputGroupBox.Location = new Point(4, 64);
		InputGroupBox.Name = "InputGroupBox";
		InputGroupBox.Size = new Size(266, 466);
		InputGroupBox.TabIndex = 15;
		InputGroupBox.TabStop = false;
		InputGroupBox.Text = "Input";
		// 
		// TrimZerosBox
		// 
		TrimZerosBox.Anchor =  AnchorStyles.Bottom | AnchorStyles.Left;
		TrimZerosBox.AutoSize = true;
		TrimZerosBox.Location = new Point(101, 131);
		TrimZerosBox.Name = "TrimZerosBox";
		TrimZerosBox.Size = new Size(121, 19);
		TrimZerosBox.TabIndex = 0;
		TrimZerosBox.Text = "Trim leading zeros";
		TrimZerosBox.UseVisualStyleBackColor = true;
		// 
		// ScratchBox
		// 
		ScratchBox.Anchor =  AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		ScratchBox.Location = new Point(3, 338);
		ScratchBox.Multiline = true;
		ScratchBox.Name = "ScratchBox";
		ScratchBox.PlaceholderText = "Scratch space";
		ScratchBox.ScrollBars = ScrollBars.Vertical;
		ScratchBox.Size = new Size(257, 122);
		ScratchBox.TabIndex = 15;
		// 
		// label10
		// 
		label10.Anchor =  AnchorStyles.Top | AnchorStyles.Right;
		label10.AutoSize = true;
		label10.Location = new Point(51, 105);
		label10.Name = "label10";
		label10.Size = new Size(44, 15);
		label10.TabIndex = 12;
		label10.Text = "Trim to";
		// 
		// TrimPointBox
		// 
		TrimPointBox.Anchor =  AnchorStyles.Top | AnchorStyles.Right;
		TrimPointBox.InterceptArrowKeys = false;
		TrimPointBox.Location = new Point(101, 103);
		TrimPointBox.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
		TrimPointBox.Name = "TrimPointBox";
		TrimPointBox.Size = new Size(159, 23);
		TrimPointBox.TabIndex = 16;
		TrimPointBox.TextAlign = HorizontalAlignment.Right;
		TrimPointBox.ValueChanged += TrimPointBox_ValueChanged;
		// 
		// FindZeroesButton
		// 
		FindZeroesButton.Anchor =  AnchorStyles.Bottom | AnchorStyles.Left;
		FindZeroesButton.Location = new Point(132, 156);
		FindZeroesButton.Name = "FindZeroesButton";
		FindZeroesButton.Size = new Size(128, 23);
		FindZeroesButton.TabIndex = 17;
		FindZeroesButton.Text = "Find zero crossings";
		FindZeroesButton.UseVisualStyleBackColor = true;
		FindZeroesButton.Click += FindZeroesButton_Click;
		// 
		// ZeroCrossingBox
		// 
		ZeroCrossingBox.Anchor =  AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		ZeroCrossingBox.Location = new Point(3, 185);
		ZeroCrossingBox.Multiline = true;
		ZeroCrossingBox.Name = "ZeroCrossingBox";
		ZeroCrossingBox.ScrollBars = ScrollBars.Vertical;
		ZeroCrossingBox.Size = new Size(257, 147);
		ZeroCrossingBox.TabIndex = 18;
		// 
		// label5
		// 
		label5.Anchor =  AnchorStyles.Top | AnchorStyles.Right;
		label5.AutoSize = true;
		label5.Location = new Point(51, 77);
		label5.Name = "label5";
		label5.Size = new Size(44, 15);
		label5.TabIndex = 8;
		label5.Text = "Length";
		// 
		// label4
		// 
		label4.Anchor =  AnchorStyles.Top | AnchorStyles.Right;
		label4.AutoSize = true;
		label4.Location = new Point(50, 48);
		label4.Name = "label4";
		label4.Size = new Size(45, 15);
		label4.TabIndex = 7;
		label4.Text = "Fidelity";
		// 
		// label3
		// 
		label3.Anchor =  AnchorStyles.Top | AnchorStyles.Right;
		label3.AutoSize = true;
		label3.Location = new Point(26, 19);
		label3.Name = "label3";
		label3.Size = new Size(69, 15);
		label3.TabIndex = 6;
		label3.Text = "Sample rate";
		// 
		// SampleCountBox
		// 
		SampleCountBox.Anchor =  AnchorStyles.Top | AnchorStyles.Right;
		SampleCountBox.Enabled = false;
		SampleCountBox.Location = new Point(101, 74);
		SampleCountBox.Name = "SampleCountBox";
		SampleCountBox.PlaceholderText = "-";
		SampleCountBox.ReadOnly = true;
		SampleCountBox.Size = new Size(159, 23);
		SampleCountBox.TabIndex = 19;
		// 
		// FidelityBox
		// 
		FidelityBox.Anchor =  AnchorStyles.Top | AnchorStyles.Right;
		FidelityBox.Enabled = false;
		FidelityBox.Location = new Point(101, 45);
		FidelityBox.Name = "FidelityBox";
		FidelityBox.PlaceholderText = "-";
		FidelityBox.ReadOnly = true;
		FidelityBox.Size = new Size(159, 23);
		FidelityBox.TabIndex = 20;
		// 
		// SampleRateBox
		// 
		SampleRateBox.Anchor =  AnchorStyles.Top | AnchorStyles.Right;
		SampleRateBox.Enabled = false;
		SampleRateBox.Location = new Point(101, 16);
		SampleRateBox.Name = "SampleRateBox";
		SampleRateBox.PlaceholderText = "-";
		SampleRateBox.ReadOnly = true;
		SampleRateBox.Size = new Size(159, 23);
		SampleRateBox.TabIndex = 21;
		// 
		// TaskProgress
		// 
		TaskProgress.Dock = DockStyle.Fill;
		TaskProgress.Location = new Point(446, 0);
		TaskProgress.Margin = new Padding(3, 0, 3, 0);
		TaskProgress.Name = "TaskProgress";
		TaskProgress.Size = new Size(440, 29);
		TaskProgress.Style = ProgressBarStyle.Continuous;
		TaskProgress.TabIndex = 0;
		// 
		// panel2
		// 
		panel2.Controls.Add(RefreshFileButton);
		panel2.Controls.Add(FileNameBox);
		panel2.Controls.Add(label1);
		panel2.Controls.Add(label13);
		panel2.Controls.Add(ExportNameBox);
		panel2.Dock = DockStyle.Top;
		panel2.Location = new Point(0, 24);
		panel2.Name = "panel2";
		panel2.Padding = new Padding(1, 6, 3, 1);
		panel2.Size = new Size(967, 34);
		panel2.TabIndex = 8;
		// 
		// RefreshFileButton
		// 
		RefreshFileButton.Anchor =  AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		RefreshFileButton.BackColor = Color.FromArgb(  0,   192,   0);
		RefreshFileButton.BackgroundImage = Properties.Resources.refresh;
		RefreshFileButton.BackgroundImageLayout = ImageLayout.Zoom;
		RefreshFileButton.Cursor = Cursors.Hand;
		RefreshFileButton.FlatAppearance.BorderColor = Color.FromArgb(  0,   192,   0);
		RefreshFileButton.FlatAppearance.BorderSize = 0;
		RefreshFileButton.FlatStyle = FlatStyle.Flat;
		RefreshFileButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point,  0);
		RefreshFileButton.Location = new Point(659, 6);
		RefreshFileButton.Name = "RefreshFileButton";
		RefreshFileButton.Size = new Size(26, 23);
		RefreshFileButton.TabIndex = 22;
		RefreshFileButton.TabStop = false;
		RefreshFileButton.UseVisualStyleBackColor = false;
		RefreshFileButton.Click += RefreshFileButton_Click;
		// 
		// menuStrip1
		// 
		menuStrip1.Items.AddRange(new ToolStripItem[] { windowToolStripMenuItem, helpToolStripMenuItem, UpdateAvailableToolStripMenuItem });
		menuStrip1.Location = new Point(0, 0);
		menuStrip1.Name = "menuStrip1";
		menuStrip1.Size = new Size(967, 24);
		menuStrip1.TabIndex = 9;
		menuStrip1.Text = "menuStrip1";
		// 
		// windowToolStripMenuItem
		// 
		windowToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { frequencyCheatsheetToolStripMenuItem });
		windowToolStripMenuItem.Name = "windowToolStripMenuItem";
		windowToolStripMenuItem.Size = new Size(63, 20);
		windowToolStripMenuItem.Text = "Window";
		// 
		// frequencyCheatsheetToolStripMenuItem
		// 
		frequencyCheatsheetToolStripMenuItem.Name = "frequencyCheatsheetToolStripMenuItem";
		frequencyCheatsheetToolStripMenuItem.Size = new Size(189, 22);
		frequencyCheatsheetToolStripMenuItem.Text = "Frequency cheatsheet";
		frequencyCheatsheetToolStripMenuItem.Click += FrequencyCheatsheetToolStripMenuItem_Click;
		// 
		// helpToolStripMenuItem
		// 
		helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { acknowledgementsToolStripMenuItem });
		helpToolStripMenuItem.Name = "helpToolStripMenuItem";
		helpToolStripMenuItem.Size = new Size(44, 20);
		helpToolStripMenuItem.Text = "Help";
		// 
		// acknowledgementsToolStripMenuItem
		// 
		acknowledgementsToolStripMenuItem.Name = "acknowledgementsToolStripMenuItem";
		acknowledgementsToolStripMenuItem.Size = new Size(179, 22);
		acknowledgementsToolStripMenuItem.Text = "Acknowledgements";
		acknowledgementsToolStripMenuItem.Click += AcknowledgementsToolStripMenuItem_Click;
		// 
		// UpdateAvailableToolStripMenuItem
		// 
		UpdateAvailableToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
		UpdateAvailableToolStripMenuItem.AutoSize = false;
		UpdateAvailableToolStripMenuItem.BackColor = Color.SpringGreen;
		UpdateAvailableToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
		UpdateAvailableToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point,  0);
		UpdateAvailableToolStripMenuItem.Margin = new Padding(0, 0, 10, 0);
		UpdateAvailableToolStripMenuItem.Name = "UpdateAvailableToolStripMenuItem";
		UpdateAvailableToolStripMenuItem.Padding = new Padding(0);
		UpdateAvailableToolStripMenuItem.ShowShortcutKeys = false;
		UpdateAvailableToolStripMenuItem.Size = new Size(98, 20);
		UpdateAvailableToolStripMenuItem.Text = "Update available";
		UpdateAvailableToolStripMenuItem.Click += UpdateAvailableToolStripMenuItem_Click;
		// 
		// LoopsFolderPanel
		// 
		LoopsFolderPanel.Controls.Add(OutputDirectoryBox);
		LoopsFolderPanel.Controls.Add(label17);
		LoopsFolderPanel.Dock = DockStyle.Left;
		LoopsFolderPanel.Location = new Point(0, 0);
		LoopsFolderPanel.Name = "LoopsFolderPanel";
		LoopsFolderPanel.Padding = new Padding(3);
		LoopsFolderPanel.Size = new Size(446, 29);
		LoopsFolderPanel.TabIndex = 10;
		// 
		// OutputDirectoryBox
		// 
		OutputDirectoryBox.Cursor = Cursors.Hand;
		OutputDirectoryBox.Dock = DockStyle.Right;
		OutputDirectoryBox.Location = new Point(54, 3);
		OutputDirectoryBox.Name = "OutputDirectoryBox";
		OutputDirectoryBox.PlaceholderText = "Click to select output directory";
		OutputDirectoryBox.ReadOnly = true;
		OutputDirectoryBox.Size = new Size(389, 23);
		OutputDirectoryBox.TabIndex = 0;
		OutputDirectoryBox.Click += OutputDirectoryBox_Click;
		// 
		// label17
		// 
		label17.Dock = DockStyle.Left;
		label17.Location = new Point(3, 3);
		label17.Name = "label17";
		label17.Size = new Size(50, 23);
		label17.TabIndex = 6;
		label17.Text = "Output";
		label17.TextAlign = ContentAlignment.MiddleRight;
		// 
		// CancelTaskButton
		// 
		CancelTaskButton.BackColor = Color.RosyBrown;
		CancelTaskButton.Dock = DockStyle.Right;
		CancelTaskButton.Enabled = false;
		CancelTaskButton.FlatStyle = FlatStyle.Popup;
		CancelTaskButton.Location = new Point(886, 0);
		CancelTaskButton.Name = "CancelTaskButton";
		CancelTaskButton.Size = new Size(81, 29);
		CancelTaskButton.TabIndex = 11;
		CancelTaskButton.Text = "Cancel";
		CancelTaskButton.UseVisualStyleBackColor = false;
		CancelTaskButton.Click += CancelTaskButton_Click;
		// 
		// ListenGroupBox
		// 
		ListenGroupBox.Anchor =  AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		ListenGroupBox.Controls.Add(BrrExportTypeBox);
		ListenGroupBox.Controls.Add(LoopStartInputLabel);
		ListenGroupBox.Controls.Add(label20);
		ListenGroupBox.Controls.Add(ExportWAVButton);
		ListenGroupBox.Controls.Add(ExportBRRBox);
		ListenGroupBox.Controls.Add(label19);
		ListenGroupBox.Controls.Add(label18);
		ListenGroupBox.Controls.Add(AutoPlayCheckBox);
		ListenGroupBox.Controls.Add(SizeLabel);
		ListenGroupBox.Controls.Add(LoopPointLabel);
		ListenGroupBox.Controls.Add(StopButton);
		ListenGroupBox.Controls.Add(PlayButton);
		ListenGroupBox.Controls.Add(BRRTestBox);
		ListenGroupBox.Controls.Add(panel3);
		ListenGroupBox.Location = new Point(551, 64);
		ListenGroupBox.Name = "ListenGroupBox";
		ListenGroupBox.Size = new Size(413, 466);
		ListenGroupBox.TabIndex = 14;
		ListenGroupBox.TabStop = false;
		ListenGroupBox.Text = "Listen";
		// 
		// BrrExportTypeBox
		// 
		BrrExportTypeBox.DropDownStyle = ComboBoxStyle.DropDownList;
		BrrExportTypeBox.FormattingEnabled = true;
		BrrExportTypeBox.Items.AddRange(new object[] { "Raw", "Header", "BRR Suite Sample" });
		BrrExportTypeBox.Location = new Point(294, 248);
		BrrExportTypeBox.Name = "BrrExportTypeBox";
		BrrExportTypeBox.Size = new Size(110, 23);
		BrrExportTypeBox.TabIndex = 0;
		// 
		// LoopStartInputLabel
		// 
		LoopStartInputLabel.AutoSize = true;
		LoopStartInputLabel.Location = new Point(208, 195);
		LoopStartInputLabel.Name = "LoopStartInputLabel";
		LoopStartInputLabel.Size = new Size(12, 15);
		LoopStartInputLabel.TabIndex = 14;
		LoopStartInputLabel.Text = "-";
		// 
		// label20
		// 
		label20.AutoSize = true;
		label20.Location = new Point(207, 180);
		label20.Name = "label20";
		label20.Size = new Size(94, 15);
		label20.TabIndex = 13;
		label20.Text = "Loop start input:";
		// 
		// ExportWAVButton
		// 
		ExportWAVButton.AutoSize = true;
		ExportWAVButton.Location = new Point(207, 275);
		ExportWAVButton.Name = "ExportWAVButton";
		ExportWAVButton.Size = new Size(88, 19);
		ExportWAVButton.TabIndex = 15;
		ExportWAVButton.Text = "Export WAV";
		ExportWAVButton.UseVisualStyleBackColor = true;
		// 
		// ExportBRRBox
		// 
		ExportBRRBox.AutoSize = true;
		ExportBRRBox.Checked = true;
		ExportBRRBox.CheckState = CheckState.Checked;
		ExportBRRBox.Location = new Point(207, 250);
		ExportBRRBox.Name = "ExportBRRBox";
		ExportBRRBox.Size = new Size(84, 19);
		ExportBRRBox.TabIndex = 16;
		ExportBRRBox.Text = "Export BRR";
		ExportBRRBox.UseVisualStyleBackColor = true;
		// 
		// label19
		// 
		label19.AutoSize = true;
		label19.Location = new Point(207, 141);
		label19.Name = "label19";
		label19.Size = new Size(68, 15);
		label19.TabIndex = 8;
		label19.Text = "Loop point:";
		// 
		// label18
		// 
		label18.AutoSize = true;
		label18.Location = new Point(207, 102);
		label18.Name = "label18";
		label18.Size = new Size(30, 15);
		label18.TabIndex = 7;
		label18.Text = "Size:";
		// 
		// AutoPlayCheckBox
		// 
		AutoPlayCheckBox.AutoSize = true;
		AutoPlayCheckBox.Checked = true;
		AutoPlayCheckBox.CheckState = CheckState.Checked;
		AutoPlayCheckBox.Location = new Point(265, 50);
		AutoPlayCheckBox.Name = "AutoPlayCheckBox";
		AutoPlayCheckBox.Size = new Size(79, 19);
		AutoPlayCheckBox.TabIndex = 17;
		AutoPlayCheckBox.Text = "Auto-play";
		AutoPlayCheckBox.UseVisualStyleBackColor = true;
		// 
		// SizeLabel
		// 
		SizeLabel.AutoSize = true;
		SizeLabel.Location = new Point(208, 117);
		SizeLabel.Name = "SizeLabel";
		SizeLabel.Size = new Size(12, 15);
		SizeLabel.TabIndex = 4;
		SizeLabel.Text = "-";
		// 
		// LoopPointLabel
		// 
		LoopPointLabel.AutoSize = true;
		LoopPointLabel.Location = new Point(208, 156);
		LoopPointLabel.Name = "LoopPointLabel";
		LoopPointLabel.Size = new Size(12, 15);
		LoopPointLabel.TabIndex = 3;
		LoopPointLabel.Text = "-";
		// 
		// StopButton
		// 
		StopButton.Location = new Point(207, 73);
		StopButton.Name = "StopButton";
		StopButton.Size = new Size(52, 23);
		StopButton.TabIndex = 18;
		StopButton.Text = "Stop";
		StopButton.UseVisualStyleBackColor = true;
		StopButton.Click += StopButton_Click;
		// 
		// PlayButton
		// 
		PlayButton.Location = new Point(207, 49);
		PlayButton.Name = "PlayButton";
		PlayButton.Size = new Size(52, 23);
		PlayButton.TabIndex = 19;
		PlayButton.Text = "Play";
		PlayButton.UseVisualStyleBackColor = true;
		PlayButton.Click += PlayerButton_Click;
		// 
		// BRRTestBox
		// 
		BRRTestBox.Dock = DockStyle.Left;
		BRRTestBox.FormattingEnabled = true;
		BRRTestBox.ItemHeight = 15;
		BRRTestBox.Location = new Point(3, 43);
		BRRTestBox.Name = "BRRTestBox";
		BRRTestBox.Size = new Size(198, 420);
		BRRTestBox.TabIndex = 20;
		BRRTestBox.SelectedValueChanged += BRRTestBox_SelectedValueChanged;
		BRRTestBox.DoubleClick += BRRTestBox_DoubleClick;
		// 
		// panel3
		// 
		panel3.Controls.Add(ExportFinalNameBox);
		panel3.Controls.Add(ExportThisButton);
		panel3.Dock = DockStyle.Top;
		panel3.Location = new Point(3, 19);
		panel3.Name = "panel3";
		panel3.Size = new Size(407, 24);
		panel3.TabIndex = 9;
		// 
		// ExportFinalNameBox
		// 
		ExportFinalNameBox.Dock = DockStyle.Fill;
		ExportFinalNameBox.Location = new Point(0, 0);
		ExportFinalNameBox.Margin = new Padding(0);
		ExportFinalNameBox.Name = "ExportFinalNameBox";
		ExportFinalNameBox.PlaceholderText = "exported file name";
		ExportFinalNameBox.Size = new Size(332, 23);
		ExportFinalNameBox.TabIndex = 0;
		ExportFinalNameBox.KeyDown += ExportNames_KeyDown;
		ExportFinalNameBox.Leave += ExportNames_Leave;
		// 
		// ExportThisButton
		// 
		ExportThisButton.Dock = DockStyle.Right;
		ExportThisButton.Location = new Point(332, 0);
		ExportThisButton.Name = "ExportThisButton";
		ExportThisButton.Size = new Size(75, 24);
		ExportThisButton.TabIndex = 1;
		ExportThisButton.Text = "Export";
		ExportThisButton.UseVisualStyleBackColor = true;
		ExportThisButton.Click += ExportThisButton_Click;
		// 
		// panel1
		// 
		panel1.Controls.Add(TaskProgress);
		panel1.Controls.Add(LoopsFolderPanel);
		panel1.Controls.Add(CancelTaskButton);
		panel1.Dock = DockStyle.Bottom;
		panel1.Location = new Point(0, 537);
		panel1.Name = "panel1";
		panel1.Size = new Size(967, 29);
		panel1.TabIndex = 13;
		// 
		// MainForm
		// 
		AllowDrop = true;
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		CancelButton = CancelTaskButton;
		ClientSize = new Size(967, 566);
		Controls.Add(panel1);
		Controls.Add(ListenGroupBox);
		Controls.Add(InputGroupBox);
		Controls.Add(OutputGroupBox);
		Controls.Add(panel2);
		Controls.Add(menuStrip1);
		FormBorderStyle = FormBorderStyle.FixedDialog;
		Icon = (Icon) resources.GetObject("$this.Icon");
		MainMenuStrip = menuStrip1;
		MaximizeBox = false;
		MinimumSize = new Size(983, 605);
		Name = "MainForm";
		Text = "BRR Suite";
		DragDrop += MainForm_DragDrop;
		DragEnter += MainForm_DragEnter;
		DragLeave += MainForm_DragLeave;
		OutputGroupBox.ResumeLayout(false);
		OutputGroupBox.PerformLayout();
		groupBox1.ResumeLayout(false);
		groupBox1.PerformLayout();
		((System.ComponentModel.ISupportInitialize) LoopFindRangeBox).EndInit();
		((System.ComponentModel.ISupportInitialize) LoopAttemptsBox).EndInit();
		((System.ComponentModel.ISupportInitialize) LoopIncrementBox).EndInit();
		((System.ComponentModel.ISupportInitialize) LoopStartBox).EndInit();
		groupBox3.ResumeLayout(false);
		groupBox3.PerformLayout();
		((System.ComponentModel.ISupportInitialize) AdjustRangeBox).EndInit();
		((System.ComponentModel.ISupportInitialize) SampleAdjustAtBox).EndInit();
		InputGroupBox.ResumeLayout(false);
		InputGroupBox.PerformLayout();
		((System.ComponentModel.ISupportInitialize) TrimPointBox).EndInit();
		panel2.ResumeLayout(false);
		panel2.PerformLayout();
		menuStrip1.ResumeLayout(false);
		menuStrip1.PerformLayout();
		LoopsFolderPanel.ResumeLayout(false);
		LoopsFolderPanel.PerformLayout();
		ListenGroupBox.ResumeLayout(false);
		ListenGroupBox.PerformLayout();
		panel3.ResumeLayout(false);
		panel3.PerformLayout();
		panel1.ResumeLayout(false);
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private TextBox FileNameBox;
	private Label label1;
	private Label label2;
	private GroupBox OutputGroupBox;
	private ComboBox ResampleBox;
	private GroupBox InputGroupBox;
	private TextBox SampleRateBox;
	private TextBox SampleCountBox;
	private TextBox FidelityBox;
	private TextBox ZeroCrossingBox;
	private Label label5;
	private Label label4;
	private Label label3;
	private NumericUpDown LoopStartBox;
	private NumericUpDown SampleAdjustAtBox;
	private GroupBox groupBox3;
	private Label label7;
	private NumericUpDown AdjustRangeBox;
	private Label label6;
	private Button AdjustButton;
	private Label label8;
	private Button FindZeroesButton;
	private Label label10;
	private NumericUpDown TrimPointBox;
	private Label label11;
	private TextBox BRRBlocksBox;
	private Button FindLoopsButton;
	private Label label12;
	private ComboBox OutputInterpolationBox;
	private ProgressBar TaskProgress;
	private Label label13;
	private TextBox ExportNameBox;
	private Label label14;
	private NumericUpDown LoopIncrementBox;
	private Label label9;
	private NumericUpDown LoopAttemptsBox;
	private Label label15;
	private NumericUpDown LoopFindRangeBox;
	private TextBox ScratchBox;
	private Panel panel2;
	private MenuStrip menuStrip1;
	private ToolStripMenuItem windowToolStripMenuItem;
	private ToolStripMenuItem frequencyCheatsheetToolStripMenuItem;
	private ToolStripMenuItem helpToolStripMenuItem;
	private ToolStripMenuItem acknowledgementsToolStripMenuItem;
	private Panel LoopsFolderPanel;
	private Label label17;
	private TextBox OutputDirectoryBox;
	private CheckBox TrimZerosBox;
	private Button CancelTaskButton;
	private GroupBox ListenGroupBox;
	private ListBox BRRTestBox;
	private Button StopButton;
	private Button PlayButton;
	private Label LoopPointLabel;
	private TextBox ExportFinalNameBox;
	private Label SizeLabel;
	private CheckBox AutoPlayCheckBox;
	private Panel panel1;
	private Label label19;
	private Label label18;
	private Panel panel3;
	private Button ExportThisButton;
	private CheckBox ExportBRRBox;
	private CheckBox ExportWAVButton;
	private Button CreateUnloopedButton;
	private Label LoopStartInputLabel;
	private Label label20;
	private GroupBox groupBox1;
	private ComboBox BrrExportTypeBox;
	private CheckBox FilterSilenceBox;
	private Label label21;
	private ComboBox TrebleBoostFilterBox;
	private Button RefreshFileButton;
	private ToolStripMenuItem UpdateAvailableToolStripMenuItem;
}
