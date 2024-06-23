using System.Xml;

namespace BRRSuiteGUI;

public sealed partial class MainForm : Form {
	private const string UntitledName = "i_love_monkeys";

	private readonly List<SampleRate> sampleRates = [
			SampleRate.SR32000,
			SampleRate.SR16000,
			SampleRate.SR8000,
			SampleRate.SR4000,
		];

	private SampleRate CurrentSampleRate = SampleRate.SR32000;

	private string? OutputDirectory = null;

	private WaveContainer? CurrentWAV = null;
	private string wavName = UntitledName;

	private CancellationTokenSource CancelSource = new();
	private CancellationToken CancelToken => CancelSource.Token;



	/*************************************************************************************************\
	* Initialization
	\*************************************************************************************************/

	public MainForm() {
		InitializeComponent();
		MinimumSize = Size;
		InitializeMore();
	}


	private record AppVersion(int Major, int Minor, int Build) {
		public override string ToString() => $"v{Major}.{Minor}.{Build}";

		public int CompareTo(AppVersion? other) {
			if (other is not AppVersion other2) {
				return -999;
			}

			int test = Major - other2.Major;

			if (test is not 0) {
				return test;
			}

			test = Minor - other2.Minor;

			if (test is not 0) {
				return test;
			}

			return Build - other2.Build;
		}
	}

	private static readonly AppVersion? thisVersion = null;
	private static readonly AppVersion? availableVersion = null;

	private const string UnknownVersion = "v?.?.?";
	internal static string VersionString => thisVersion?.ToString() ?? UnknownVersion;


	static MainForm() {
		// find the current app version the 

		try {
			var thisXml = new XmlDocument();
			thisXml.LoadXml(Properties.Resources.version);
			thisVersion = MakeVersion(thisXml);
		} catch {
			thisVersion = null; // give up
		}

		try {
			var newXml = new XmlDocument();
			newXml.Load(XmlReader.Create("https://raw.githubusercontent.com/spannerisms/BRRSuiteGUI/release/version.xml"));
			availableVersion = MakeVersion(newXml);
		} catch {
			availableVersion = null; // give up
		}


		static AppVersion? MakeVersion(XmlDocument xml) {
			try {
				var vnode = xml.SelectSingleNode("//version");

				if (vnode?.Attributes is not XmlAttributeCollection attrs) {
					return null;
				}

				// get each version number
				if (!int.TryParse(attrs["major"]?.Value, out int maj)) {
					return null; // if any fail, give up
				}

				if (!int.TryParse(attrs["minor"]?.Value, out int min)) {
					return null;
				}

				if (!int.TryParse(attrs["build"]?.Value, out int bld)) {
					return null;
				}

				return new(maj, min, bld);

			} catch {
				// if any problems occur, just return null
				return null;
			}
		}
	}


	private void InitializeMore() {
		DisableTabStop(this);

		ResampleBox.DataSource = sampleRates;
		ResampleBox.SelectedItem = SampleRate.SR32000;

		OutputInterpolationBox.DataSource = new ItemWithName[] {
			new("Nearest neighbor", ResamplingAlgorithms.NoInterpolation),
			new("Linear", ResamplingAlgorithms.LinearInterpolation),
			new("Sinusoidal", ResamplingAlgorithms.SineInterpolation),
			new("Cubic", ResamplingAlgorithms.CubicInterpolation),
			new("Band-limited", ResamplingAlgorithms.BandlimitedInterpolation),
		};

		OutputInterpolationBox.SelectedIndex = OutputInterpolationBox.Items.Count - 1;

		SetOutputDirectory(Properties.Settings.Default.OutputFolderPath);

		BrrExportTypeBox.SelectedIndex = 0;

		TrebleBoostFilterBox.DataSource = new ItemWithName[] {
			new("None", null),
			new("BRRtools", PreEncodingFilters.GetTrebleBoostFilter(PreEncodingFilters.GetBRRtoolsTrebleMatrix())),
			new("Drexxx", PreEncodingFilters.GetTrebleBoostFilter(PreEncodingFilters.GetDrexxxMatrix(8))),
		};

		TrebleBoostFilterBox.SelectedIndex = 0;

		AdjustRangeBox.MouseWheel += NumberBoxMouseWheel;
		LoopAttemptsBox.MouseWheel += NumberBoxMouseWheel;
		LoopFindRangeBox.MouseWheel += NumberBoxMouseWheel;
		LoopIncrementBox.MouseWheel += NumberBoxMouseWheel;
		LoopStartBox.MouseWheel += NumberBoxMouseWheel;
		SampleAdjustAtBox.MouseWheel += NumberBoxMouseWheel;
		TrimPointBox.MouseWheel += NumberBoxMouseWheel;

		ExportNameBox.AcceptsReturn = true;
		ExportFinalNameBox.AcceptsReturn = true;

		CheckForUpdates();
		EnableForm(false);

		OffTextButton();

		static void DisableTabStop(Control cont) {
			foreach (var c in cont.Controls) {
				if (c is Control b) {
					b.TabStop = false;
					DisableTabStop(b);
				}
			}
		}
	}

	private static void NumberBoxMouseWheel(object? sender, MouseEventArgs e) {
		if (sender is not NumericUpDown box) return;

		if (e is HandledMouseEventArgs f) {
			f.Handled = true;
		}

		if (e.Delta > 0) {
			if (box.Value == box.Maximum) {
				return;
			}
			box.Value++;
		} else if (e.Delta < 0) {
			if (box.Value == box.Minimum) {
				return;
			}
			box.Value--;
		}
	}


	private readonly UpdateAnnouncer announcer = new();

	private void CheckForUpdates() {
		announcer.VersionCurrent = thisVersion?.ToString() ?? UnknownVersion;
		announcer.VersionNew = availableVersion?.ToString() ?? UnknownVersion;

		if (thisVersion is null || availableVersion is null) {
			UpdateAvailableToolStripMenuItem.BackColor = Color.DarkOrange;
			UpdateAvailableToolStripMenuItem.ForeColor = SystemColors.ControlText;
			UpdateAvailableToolStripMenuItem.Text = "Problem";

			announcer.Message = (thisVersion, availableVersion) switch {
				(null, null) => "Could not determine the current version or available version.",
				(null, _) => "Could not determine the current version.",
				(_, null) => "Could not determine available version.",
				(_, _) => "????????????????????"
			};

			return;
		}

		int test = thisVersion.CompareTo(availableVersion);

		if (test < 0) {
			UpdateAvailableToolStripMenuItem.BackColor = Color.SpringGreen;
			UpdateAvailableToolStripMenuItem.ForeColor = SystemColors.ControlText;
			UpdateAvailableToolStripMenuItem.Text = "Updates available";
			announcer.Message = "A new version is available.";
		} else if (test > 0) {
			UpdateAvailableToolStripMenuItem.BackColor = Color.Aqua;
			UpdateAvailableToolStripMenuItem.ForeColor = SystemColors.ControlDark;
			UpdateAvailableToolStripMenuItem.Text = "Beta";
			announcer.Message = "It appears you have an unreleased version.";
		} else {
			UpdateAvailableToolStripMenuItem.BackColor = SystemColors.Control;
			UpdateAvailableToolStripMenuItem.ForeColor = SystemColors.ControlDark;
			UpdateAvailableToolStripMenuItem.Text = "No updates";
			announcer.Message = "Your application is up to date.";
		}
	}

	private void UpdateAvailableToolStripMenuItem_Click(object sender, EventArgs e) {
		announcer.ShowDialog();
	}




	/*************************************************************************************************\
	* User communication
	\*************************************************************************************************/
	private void ShowError(string message) {
		MessageBox.Show(this, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}

	private void CheckForWave() {
		if (CurrentWAV is null) {
			throw new ArgumentNullException(null, "Please load a valid Wave Sound file.");
		}
	}

	private void CheckForPreviewBRR() {
		if (CurrentBRR is null) {
			throw new ArgumentNullException(null, "No preview candidate selected");
		}
	}

	private void CheckForOutputDirectory() {
		if (OutputDirectory is null) {
			throw new ArgumentNullException(null, "No output directory selected");
		}

		if (!Directory.Exists(OutputDirectory)) {
			throw new DirectoryNotFoundException($"Could not find directory:\r\n{OutputDirectory}");
		}
	}

	private static string GetFormattedSize(int blocks) =>
		string.Format("{0} blocks - {1} bytes (${1:X4})", blocks, BrrBlockSize * blocks);

	private static string GetFormattedLoopPoint(int blocks) => blocks switch {
		< 0 => "-",
		_ => string.Format("{0} blocks (${1:X4})", blocks, BrrBlockSize * blocks)
	};


	/*************************************************************************************************\
	* GUI control tinkering
	\*************************************************************************************************/

	private void OffTextButton() {
		Focus();
		ActiveControl = null;
	}

	private void SetControlEnabled() {
		EnableForm(CurrentWAV is not null);
	}

	private void EnableForm(bool enable) {
		InputGroupBox.Enabled = enable;
		OutputGroupBox.Enabled = enable;
		ListenGroupBox.Enabled = enable;
	}

	private void EnableControls(bool enable) {
		FileNameBox.Enabled = enable;
		LoopsFolderPanel.Enabled = enable;
		AllowDrop = enable;
		EnableForm(enable);
	}


	private void SetOutputDirectory(string path) {
		OutputDirectory = null;

		if (Directory.Exists(path)) {
			try {
				OutputDirectory = path;
				Properties.Settings.Default.OutputFolderPath = OutputDirectory;
				Properties.Settings.Default.Save();
			} catch {
				OutputDirectory = null;
			}
		}

		OutputDirectoryBox.Text = OutputDirectory;

		SetControlEnabled();
		OffTextButton();
	}

	private void ClearFileList() {
		Player.Stop();
		CurrentBRR = null;
		BRRTestBox.Items.Clear();
	}

	private const string InvalidChars = @"<>:""/\|?*[]{}";

	private void ExportNameBox_TextChanged(object sender, EventArgs e) {
		if (string.IsNullOrWhiteSpace(ExportNameBox.Text)) {
			wavName = UntitledName;
		} else {
			wavName = ExportNameBox.Text;
		}
	}

	private void ExportNames_Leave(object sender, EventArgs e) {
		if (sender is not TextBox t) return;
		ValidateFileName(t);
	}

	private void ExportNames_KeyDown(object? sender, KeyEventArgs e) {
		if (e.Handled) {
			return;
		}

		if (sender is not TextBox t) return;

		if (e.KeyCode is Keys.Enter) {
			ValidateFileName(t);

			t.SelectionStart = t.TextLength;
			t.SelectionLength = 0;
			e.Handled = true;
			e.SuppressKeyPress = true;
		}
	}

	private static void ValidateFileName(TextBox t) {
		string text = t.Text.Trim();

		foreach (var c in InvalidChars) {
			text = text.Replace(c.ToString(), "");
		}

		text = text.Trim().Replace("..", "").Trim();

		if (text.Length > 0) {
			if (text[^1] is '.') {
				text = text[..^1].Trim();
			}
		}

		t.Text = text;
	}


	/*************************************************************************************************\
	* Async tasks
	\*************************************************************************************************/
	private async Task RunGUITask(Func<Task> func) {
		SetGUIForTask(false);

		try {
			await func();
		} catch (OperationCanceledException) {
			// Do nothing
		} catch (Exception f) {
			ShowError(f.Message);
		}

		SetGUIForTask(true);

		FinishTask();
	}

	private void SetGUIForTask(bool enable) {
		EnableControls(enable);

		if (!enable) {
			CancelTaskButton.BackColor = Color.Red;
			CancelTaskButton.Enabled = true;
			CancelSource = new();
		} else {
			CancelTaskButton.BackColor = Color.RosyBrown;
			CancelTaskButton.Enabled = false;
		}
	}

	private void NewTaskBarThing(int count) {
		TaskProgress.Minimum = 1;
		TaskProgress.Maximum = count;
		TaskProgress.Value = 1;
		TaskProgress.Step = 1;
	}

	private void FinishTask() {
		TaskProgress.Value = TaskProgress.Maximum;
	}

	private void CancelTaskButton_Click(object sender, EventArgs e) {
		CancelSource.Cancel();
	}

	/*************************************************************************************************\
	* Input area methods and events
	\*************************************************************************************************/
	private void FindZeroesButton_Click(object sender, EventArgs e) {
		CheckForWave();

		var crossings = new List<int>();
		int min = (int) LoopStartBox.Value;
		int trim = (int) TrimPointBox.Value;

		bool lastNegative = CurrentWAV![min] < 0;

		for (int i = min + 1; i < trim; i++) {
			int t = CurrentWAV[i];
			switch (t) {
				case 0:
				case > 0 when lastNegative:
				case < 0 when !lastNegative:
					crossings.Add(i);
					lastNegative = !lastNegative;
					break;
			}
		}

		ZeroCrossingBox.Text = string.Join(' ', crossings);
	}

	/*************************************************************************************************\
	* General conversion methods and events
	\*************************************************************************************************/
	private ResamplingAlgorithm GetCurrentResamplingAlgorithm() {
		var temp = OutputInterpolationBox.SelectedItem as ItemWithName;

		if (temp?.Thing is ResamplingAlgorithm r) {
			return r;
		}

		return ResamplingAlgorithms.CubicInterpolation;
	}

	private void TrimPointBox_ValueChanged(object sender, EventArgs e) {
		RecalculateNumberOfBRRBlocks();
	}

	private void SampleBox_SelectedIndexChanged(object sender, EventArgs e) {
		CurrentSampleRate = (ResampleBox.SelectedItem as SampleRate) ?? SampleRate.SR32000;
		RecalculateNumberOfBRRBlocks();
	}


	private async void CreateUnloopedButton_Click(object sender, EventArgs e) {
		await RunGUITask(UnloopedFiles);
	}


	private EncodingAlgorithm GetEncoder() {
		return Conversion.GetBRRtoolsBruteForce(FilterSilenceBox.Checked, false, false, false, false);
	}

	private PreEncodingFilter[]? GetFilters() {
		if (TrebleBoostFilterBox.SelectedItem is ItemWithName i) {
			if (i.Thing is PreEncodingFilter j) {
				return [j];
			}
		}

		return null;
	}


	private async Task UnloopedFiles() {
		CheckForWave();

		ClearFileList();

		int trim = (int) TrimPointBox.Value;
		bool trimFront = TrimZerosBox.Checked;

		ResamplingAlgorithm outResamp = GetCurrentResamplingAlgorithm();

		string sampleName = wavName;

		NewTaskBarThing(2 * sampleRates.Count);

		int[] wavSamples = CurrentWAV!.GetSamplesCopy();
		var encoder = GetEncoder();
		var filters = GetFilters();

		foreach (var freq in sampleRates) {
			decimal resampleFactorBRR = CurrentWAV.SampleRate.ResampleTo(freq);

			BRRSample brr = await Task.Run(() =>
				Conversion.Encode(
					wavSamples: wavSamples,
					encoder: encoder,
					resampleAlgorithm: outResamp,
					resampleFactor: resampleFactorBRR,
					truncate: trim,
					waveFilters: filters,
					trimLeadingZeroes: trimFront,
					loopStart: NoLoop
				));

			brr.EncodingFrequency = freq.Frequency;

			TaskProgress.PerformStep();
			CancelToken.ThrowIfCancellationRequested();

			WaveContainer wavOut = await Task.Run(() =>
				Conversion.Decode(
					brrSample: brr.Data,
					loopBlock: NoLoop,
					sampleRate: freq.Frequency,
					applyGaussian: false
				));

			TaskProgress.PerformStep();
			CancelToken.ThrowIfCancellationRequested();

			TestContainer addbrr = new(sampleName, brr, wavOut) {
				ListName = $"{sampleName}_{freq.FrequencykHz}",
				FileName = $"{sampleName}_{freq.FrequencykHz}",
				LoopSample = null,
				Trim = trim,
			};

			BRRTestBox.Items.Add(addbrr);
		}

		return;
	}


	/*************************************************************************************************\
	* Loop find methods and events
	\*************************************************************************************************/
	private async void FindLoopsButton_Click(object sender, EventArgs e) {
		await RunGUITask(LoopSearch);
	}

	private async Task LoopSearch() {
		CheckForWave();

		ClearFileList();

		int minLoop = (int) LoopStartBox.Value;
		int increment = (int) LoopIncrementBox.Value;
		int attempts = (int) LoopAttemptsBox.Value;
		int range = (int) LoopFindRangeBox.Value;
		int maxLoop = attempts * increment + minLoop;
		bool trimFront = TrimZerosBox.Checked;

		SampleRate freq = CurrentSampleRate;
		string sampleName = wavName;
		string outFolder = OutputDirectory!;
		int trim = (int) TrimPointBox.Value;

		if (maxLoop > trim) {
			maxLoop = trim;
		}

		var attemptsList = new List<int>();
		for (int adda = minLoop; adda <= maxLoop; adda += increment) {
			for (int addb = -range; addb <= range; addb++) {
				attemptsList.Add(addb + adda);
			}
		}

		CancelToken.ThrowIfCancellationRequested();
		attemptsList.RemoveAll(r => r < 0 || r >= trim);

		ResamplingAlgorithm outResamp = GetCurrentResamplingAlgorithm();
		decimal resampleFactorBRR = CurrentWAV!.SampleRate.ResampleTo(CurrentSampleRate);
		decimal resampleFactorWAV = CurrentSampleRate.ResampleTo(SampleRate.SR32000);

		var loopList = attemptsList.Distinct();

		NewTaskBarThing(2 * loopList.Count());

		int[] wavSamples = CurrentWAV.GetSamplesCopy();
		var encoder = GetEncoder();
		var filters = GetFilters();

		foreach (int loop in loopList) {
			CancelToken.ThrowIfCancellationRequested();
			BRRSample brr = await Task.Run(() =>
				Conversion.Encode(
					wavSamples: wavSamples,
					encoder: encoder,
					resampleAlgorithm: outResamp,
					resampleFactor: resampleFactorBRR,
					truncate: trim,
					waveFilters: filters,
					trimLeadingZeroes: trimFront,
					loopStart: loop
				));

			brr.EncodingFrequency = freq.Frequency;

			int loopBlock = brr.LoopBlock;

			TaskProgress.PerformStep();
			CancelToken.ThrowIfCancellationRequested();

			WaveContainer wavOut = await Task.Run(() =>
				Conversion.Decode(
					brrSample: brr.Data,
					loopBlock: loopBlock,
					sampleRate: freq.Frequency,
					minimumLength: 2.0M,
					applyGaussian: false
				));

			TaskProgress.PerformStep();
			CancelToken.ThrowIfCancellationRequested();

			TestContainer addbrr = new(sampleName, brr, wavOut) {
				ListName = $"{sampleName}_{freq.FrequencykHz}_{loop}",
				FileName = $"{sampleName}_{freq.FrequencykHz}_{loopBlock}",
				LoopSample = loop,
				Trim = trim,
			};

			BRRTestBox.Items.Add(addbrr);
		}
	}

	/*************************************************************************************************\
	* Fine adjustment methods and events
	\*************************************************************************************************/

	private async void AdjustButton_Click(object sender, EventArgs e) {
		await RunGUITask(SampleAdjust);
	}

	private async Task SampleAdjust() {
		CheckForWave();
		ClearFileList();

		int loop = (int) SampleAdjustAtBox.Value;
		int distance = (int) AdjustRangeBox.Value;

		int trimPoint = (int) TrimPointBox.Value;
		int minTrim = Math.Max(trimPoint - distance, 0);
		int maxTrim = Math.Min(trimPoint + distance, CurrentWAV!.SampleCount);
		bool trimFront = TrimZerosBox.Checked;

		ResamplingAlgorithm outResamp = GetCurrentResamplingAlgorithm();
		decimal resampleFactorBRR = CurrentWAV.SampleRate.ResampleTo(CurrentSampleRate);

		SampleRate freq = CurrentSampleRate;
		string sampleName = wavName;

		NewTaskBarThing(2 * (maxTrim - minTrim + 1));

		int[] wavSamples = CurrentWAV.GetSamplesCopy();
		var encoder = GetEncoder();
		var filters = GetFilters();

		for (int trim = minTrim; trim <= maxTrim; trim++) {

			BRRSample brr = await Task.Run(() =>
				Conversion.Encode(
					wavSamples: wavSamples,
					encoder: encoder,
					resampleAlgorithm: outResamp,
					resampleFactor: resampleFactorBRR,
					trimLeadingZeroes: trimFront,
					waveFilters: filters,
					truncate: trim,
					loopStart: loop
				));

			brr.EncodingFrequency = freq.Frequency;
			int loopBlock = brr.LoopBlock;

			TaskProgress.PerformStep();
			CancelToken.ThrowIfCancellationRequested();

			WaveContainer wavOut = await Task.Run(() =>
				Conversion.Decode(
					brrSample: brr.Data,
					loopBlock: loopBlock,
					sampleRate: freq.Frequency,
					minimumLength: 2.0M,
					applyGaussian: false
				));

			CancelToken.ThrowIfCancellationRequested();

			TestContainer addbrr = new(sampleName, brr, wavOut) {
				ListName = $"{sampleName}_{freq.FrequencykHz}_p{loop}t{trim}",
				FileName = $"{sampleName}_{freq.FrequencykHz}_{loopBlock}",
				LoopSample = loop,
				Trim = trim,
			};

			BRRTestBox.Items.Add(addbrr);

			TaskProgress.PerformStep();
			CancelToken.ThrowIfCancellationRequested();
			this.MdiChildrenMinimizedAnchorBottom = true;
		}
	}

	private void RecalculateNumberOfBRRBlocks() {
		if (CurrentWAV is null) return;

		int numberOfBlocks = (int) (TrimPointBox.Value / CurrentSampleRate.Cram / PcmBlockSize);
		BRRBlocksBox.Text = GetFormattedSize(numberOfBlocks);
	}


	private string? oldText = null;
	private void MainForm_DragDrop(object sender, DragEventArgs e) {
		Activate();
		oldText = FileNameBox.Text;
		SetFile(FileNameBox.Text);
	}

	private void MainForm_DragEnter(object sender, DragEventArgs e) {
		if (e?.Data?.GetData(DataFormats.FileDrop) is string[] files) {
			FileNameBox.Text = files[0];
			e.Effect = DragDropEffects.Copy;
		}
	}

	private void MainForm_DragLeave(object sender, EventArgs e) {
		FileNameBox.Text = oldText;
	}

	private void SetFile(string path) {
		string? newText = null;
		CurrentWAV = null;

		if (string.IsNullOrWhiteSpace(path)) {
			// just continue
		} else if (!File.Exists(path)) {
			ShowError($"The file {path} was not found.");
		} else if (!Path.GetExtension(path).Equals($".{WaveContainer.Extension}", StringComparison.CurrentCultureIgnoreCase)) {
			ShowError($"The selected file is not a .{WaveContainer.Extension} file.");
		} else {
			try {
				WaveContainer wav = WaveContainer.ReadFromFile(path);
				SetWAV(wav);
				EnableForm(true);
				EnableControls(true);
				SampleAdjustAtBox.Maximum = TrimPointBox.Value = TrimPointBox.Maximum = CurrentWAV!.SampleCount;
				newText = path;
				ExportNameBox.Text = Path.GetFileNameWithoutExtension(path);
			} catch (Exception e) {
				ShowError(e.Message);
			}
		}

		FileNameBox.Text = newText;
		ValidateFileName(ExportNameBox);
		oldText = FileNameBox.Text;
		OffTextButton();
	}

	private void SetWAV(WaveContainer wav) {
		CurrentWAV = wav;
		SampleRateBox.Text = $"{wav.SampleRate.Frequency} Hz";
		FidelityBox.Text = $"{wav.BitsPerSample} bits per sample";
		SampleCountBox.Text = $"{wav.SampleCount} samples";
	}

	/*************************************************************************************************\
	* Auxiliary windows
	\*************************************************************************************************/
	private readonly AcknowledgementsWindow acknowledgementWindow = new();
	private void AcknowledgementsToolStripMenuItem_Click(object sender, EventArgs e) {
		acknowledgementWindow.ShowDialog();
	}

	private FrequencyWindow? cheatsheet = null;
	private void FrequencyCheatsheetToolStripMenuItem_Click(object sender, EventArgs e) {
		// dumb stuff because I want to only allow 1 open at a time, but not as a modal dialog
		if (cheatsheet?.IsDisposed ?? true) {
			cheatsheet = new();

			// change the class field back to null when it's disposed
			cheatsheet.Disposed += (_, _) => {
				cheatsheet = null;
			};
		}

		cheatsheet.Show();
		cheatsheet.Focus();
	}

	private readonly OpenFileDialog openWavDialog = new() {
		Multiselect = false,
		Filter = $"WAV file (*.{WaveContainer.Extension})|*.{WaveContainer.Extension}",
		CheckFileExists = true,
		CheckPathExists = true,
		DereferenceLinks = true,
		ValidateNames = true,
		Title = "Open Source WAV",
		ShowHelp = false,
	};

	private void FileNameBox_Click(object sender, EventArgs e) {
		if (openWavDialog.ShowDialog() is DialogResult.OK) {
			SetFile(openWavDialog.FileName);
		}
	}
	private void RefreshFileButton_Click(object sender, EventArgs e) {
		SetFile(FileNameBox.Text);
	}

	private readonly FolderBrowserDialog outputFolderBrowser = new() {
		ShowNewFolderButton = true,
		UseDescriptionForTitle = true,
		Description = "Output folder"
	};

	private void OutputDirectoryBox_Click(object sender, EventArgs e) {
		if (outputFolderBrowser.ShowDialog() == DialogResult.OK) {
			SetOutputDirectory(outputFolderBrowser.SelectedPath);
		} else {
			OffTextButton();
		}
	}

	/*************************************************************************************************\
	* Listen area
	\*************************************************************************************************/

	// TODO eventually add analysis tools for the preview
	// make them checkboxes with the property and a label for the info?
	//     [*] Note pitch: A#

	private TestContainer? CurrentBRR = null;
	private readonly System.Media.SoundPlayer Player = new();

	private void BRRTestBox_SelectedValueChanged(object sender, EventArgs e) {
		if (SetClickedBRR() is SampleClickAction.SampleChanged && AutoPlayCheckBox.Checked) {
			PlaySamplePreview();
		}
	}

	private SampleClickAction SetClickedBRR() {
		Player.Stop();

		var newbr = BRRTestBox.SelectedItem as TestContainer;

		if (newbr == CurrentBRR) {
			if (newbr is null) {
				return SampleClickAction.SampleNull;
			}
			return SampleClickAction.SampleUnchanged;
		}

		CurrentBRR = newbr;

		Player.Stream?.Dispose();

		if (CurrentBRR is null) {
			SizeLabel.Text = "-";
			LoopPointLabel.Text = "-";
			ExportFinalNameBox.Text = null;
			return SampleClickAction.SampleNull;
		};

		SizeLabel.Text = GetFormattedSize(CurrentBRR.BlockCount);
		LoopPointLabel.Text = GetFormattedLoopPoint(CurrentBRR.LoopBlock);
		LoopStartInputLabel.Text = CurrentBRR.LoopSample?.ToString() ?? "-";

		ExportFinalNameBox.Text = CurrentBRR.FileName;
		Player.Stream = CurrentBRR.WaveFile.AsMemoryStream();

		return SampleClickAction.SampleChanged;
	}

	private void PlaySamplePreview() {
		Player.Play();
	}

	private void StopSamplePreview() {
		Player.Stop();
	}

	private void PlayerButton_Click(object sender, EventArgs e) {
		PlaySamplePreview();
	}

	private void StopButton_Click(object sender, EventArgs e) {
		StopSamplePreview();
	}

	private void BRRTestBox_DoubleClick(object sender, EventArgs e) {
		if (SetClickedBRR() is not SampleClickAction.SampleNull) {
			PlaySamplePreview();
		}
	}

	private void ExportThisButton_Click(object sender, EventArgs e) {
		CheckForOutputDirectory();
		CheckForPreviewBRR();

		string fileName = $"{OutputDirectory}/{ExportFinalNameBox.Text.Trim()}";

		if (ExportBRRBox.Checked) {
			switch (BrrExportTypeBox.SelectedIndex) {
				case 0:
					CurrentBRR!.BRRFile.ExportRaw($"{fileName}");
					break;

				case 1:
					CurrentBRR!.BRRFile.ExportHeadered($"{fileName}");
					break;

				case 2:
					CurrentBRR!.BRRFile.ExportSuiteSample($"{fileName}.");
					break;
			}
		}

		if (ExportWAVButton.Checked) {
			CurrentBRR!.WaveFile.Export($"{fileName}.{WaveContainer.Extension}");
		}
	}

	private enum SampleClickAction {
		SampleNull = 0,
		SampleChanged,
		SampleUnchanged
	}
}
