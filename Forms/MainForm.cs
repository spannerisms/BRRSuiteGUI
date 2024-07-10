using System.Diagnostics;
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

	private static readonly byte[]? engineBase;

	private static readonly string AppDirectory;

	static MainForm() {
		AppDirectory = AppDomain.CurrentDomain.BaseDirectory;

		// try to get the test SPC engine
		try {
			using var rd = new FileStream($"{AppDirectory}/testengine.bin", FileMode.Open, FileAccess.Read);
			// Verify WAV
			engineBase = new byte[(int) rd.Length];
			rd.Read(engineBase, 0, engineBase.Length);
		} catch {
			// give up
			engineBase = null;
		}

		// find the current app version
		try {
			var thisXml = new XmlDocument();
			thisXml.LoadXml(Properties.Resources.version);
			thisVersion = MakeVersion(thisXml);
		} catch {
			thisVersion = null; // give up
		}

#if DEBUG
		availableVersion = new(0, 0, 0);
#else
		// find the available version
		try {
			var newXml = new XmlDocument();
			newXml.Load(XmlReader.Create("https://raw.githubusercontent.com/spannerisms/BRRSuiteGUI/main/version.xml"));
			availableVersion = MakeVersion(newXml);
		} catch {
			availableVersion = null; // give up
		}
#endif

		// local function to parse them the same way
		static AppVersion? MakeVersion(XmlDocument xml) {
			try {
				var vnode = xml.SelectSingleNode("//version");

				if (vnode?.Attributes is not XmlAttributeCollection attrs) return null;

				// get each version number; if any fail, give up
				if (!int.TryParse(attrs["major"]?.Value, out int maj)) return null;
				if (!int.TryParse(attrs["minor"]?.Value, out int min)) return null;
				if (!int.TryParse(attrs["build"]?.Value, out int bld)) return null;

				return new(maj, min, bld);

			} catch {
				return null; // if any problems occur, just return null
			}
		} // end local
	}


	private readonly WaveformWindow waveWindow = new() { Visible = false };


	private void InitializeMore() {
		DisableTabStop(this);

		ResampleBox.DataSource = sampleRates;
		ResampleBox.SelectedItem = SampleRate.SR32000;

		OutputInterpolationBox.DataSource = new ItemWithName[] {
			new("Nearest neighbor", ResamplingAlgorithms.NoInterpolation),
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

		ExportNameBox.AcceptsReturn = true;
		ExportFinalNameBox.AcceptsReturn = true;

		// add button windows
		WaveformViewButton.Tag = waveWindow;
		FrequencyCheatsheetButton.Tag = new FrequencyWindow() { Visible = false };

		if (engineBase is null) {
			ExportTestSongBox.Checked = false;
			ExportTestSongBox.Enabled = false;
		}


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

	private readonly UpdateAnnouncer UpdateShower = new();

	private static readonly Color Periwinkle = Color.FromArgb(0xCC, 0xCC, 0xFF);
	private static readonly Color DarkPeriwinkle = Color.FromArgb(0x64, 0x64, 0xC8);

	private void CheckForUpdates() {
		UpdateShower.VersionCurrent = thisVersion?.ToString() ?? UnknownVersion;
		UpdateShower.VersionNew = availableVersion?.ToString() ?? UnknownVersion;

		if (thisVersion is null || availableVersion is null) {
			UpdateAvailableToolStripMenuItem.BackColor = Color.Orange;
			UpdateAvailableToolStripMenuItem.ForeColor = Color.Maroon;
			UpdateAvailableToolStripMenuItem.Text = "Problem";

			UpdateShower.Message = (thisVersion, availableVersion) switch {
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
			UpdateAvailableToolStripMenuItem.ForeColor = Color.Green;
			UpdateAvailableToolStripMenuItem.Text = "Update available";
			UpdateShower.Message = "A new version is available.";
		} else if (test > 0) {
			UpdateAvailableToolStripMenuItem.BackColor = Periwinkle;
			UpdateAvailableToolStripMenuItem.ForeColor = DarkPeriwinkle;
			UpdateAvailableToolStripMenuItem.Text = "Beta";
			UpdateShower.Message = "It appears you have an unreleased version.";
		} else {
			UpdateAvailableToolStripMenuItem.BackColor = Color.Silver;
			UpdateAvailableToolStripMenuItem.ForeColor = Color.DimGray;
			UpdateAvailableToolStripMenuItem.Text = "No updates";
			UpdateShower.Message = "Your application is up to date.";
		}
	}

	private void UpdateAvailableToolStripMenuItem_Click(object sender, EventArgs e) {
		UpdateShower.ShowDialog();
	}

	private readonly AdvancedSettingsWindow AdvancedWindow = new();
	private decimal DecodeMinimumLength = 1.5M;
	private int MinimumTrimZeros = 3;

	private void AdvancedButtonClick(object sender, EventArgs e) {
		AdvancedWindow.PreviewDuration = DecodeMinimumLength;
		AdvancedWindow.MinimumTrimZeros = MinimumTrimZeros;

		if (AdvancedWindow.ShowDialog() is DialogResult.OK) {
			DecodeMinimumLength = decimal.Round(AdvancedWindow.PreviewDuration, 1);
			MinimumTrimZeros = AdvancedWindow.MinimumTrimZeros;
		}
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
		string.Format("{0} block{2} - {1} bytes (${1:X4})", blocks, Conversion.BRRBlockSize * blocks, blocks == 1 ? "" : "s");

	private static string GetFormattedLoopPoint(int blocks) => blocks switch {
		< 0 => "-",
		_ => string.Format("{0} block{2} (${1:X4})", blocks, Conversion.BRRBlockSize * blocks, blocks == 1 ? "" : "s")
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

	private void AddCandidateToBox(TestContainer brr) {
		BRRTestBox.Items.Add(brr);
	}

	private void ClearFileListConditional() {
		if (ClearWhenGenButton.Checked) {
			ClearFileList();
		}
	}

	private void ClearFileList() {
		StopSamplePreview();
		CurrentBRR = null;
		BRRTestBox.Items.Clear();
		BRRTestBox.SelectedIndex = -1;
		ClearPreviewInfo();
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
			// Task was cancelled. Everything is fine.
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
		try {
			CheckForWave();
		} catch (Exception x) {
			ZeroCrossingBox.Text = string.Empty;
			ShowError(x.Message);
			return;
		}

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
#pragma warning disable IDE0079 // shut up
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Performance",
		"CA1859:Use concrete types when possible for improved performance",
		Justification = "We'll have other encoders eventually.")]
	private BRREncoder GetCurrentEncoder() {
		BRRtoolsEncoder ret = new() {
			Resampler = GetCurrentResamplingAlgorithm(),
			Filters = GetFilters(),
			EnableFilter0 = true,
			EnableFilter1 = true,
			EnableFilter2 = true,
			EnableFilter3 = true,
			LeadingZeros = TrimZerosBox.Checked ? MinimumTrimZeros : -1,
			ResampleFactor = CurrentSampleRate.ResampleFrom(CurrentWAV!.SampleRate),
			Truncate = (int) TrimPointBox.Value,
		};

		return ret;
	}
#pragma warning restore IDE0079

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
		CurrentSampleRate = (ResampleBox.SelectedItem as SampleRate?) ?? SampleRate.SR32000;
		RecalculateNumberOfBRRBlocks();
	}

	private async void CreateUnloopedButton_Click(object sender, EventArgs e) {
		await RunGUITask(UnloopedFiles);
	}

	private PreEncodingFilter GetFilters() {
		PreEncodingFilter ret = PreEncodingFilters.NoFilter;

		if (TrebleBoostFilterBox.SelectedItem is ItemWithName i) {
			if (i.Thing is PreEncodingFilter j) {
				ret += j;
			}
		}

		return ret;
	}

	private async Task UnloopedFiles() {
		CheckForWave();

		ClearFileListConditional();

		string sampleName = wavName;

		NewTaskBarThing(2 * sampleRates.Count);

		int[] wavSamples = CurrentWAV!.SamplesToArray();
		BRREncoder enc = GetCurrentEncoder();
		bool freqEst = EstimatedFrequencyBox.Checked;

		var tasks = new List<Task>();
		foreach (var freq in sampleRates) {
			CancelToken.ThrowIfCancellationRequested();

			enc.ResampleFactor = CurrentSampleRate.ResampleFrom(freq);

			BRRSample brr = await Task.Run(() =>
				enc.Encode(
					pcmSamples: wavSamples,
					pcmLoopPoint: Conversion.NoLoop
				));

			TaskProgress.PerformStep();
			CancelToken.ThrowIfCancellationRequested();

			WaveContainer wavOut = await Task.Run(() =>
				brr.Decode(
					pitch: Conversion.DefaultVxPitch
				));

			TaskProgress.PerformStep();

			TestContainer addbrr = new(sampleName, brr, wavOut) {
				ListName = $"{sampleName}_{freq.FrequencykHz}",
				FileName = $"{sampleName}_{freq.FrequencykHz}",
				LoopSample = null,
				EncodingFrequency = freq,
				Trim = enc.Truncate,
			};

			if (freqEst) {
				tasks.Add(Task.Run(addbrr.DoFrequencyEstimate));
			}

			AddCandidateToBox(addbrr);
		}

		await Task.WhenAll(tasks);

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

		ClearFileListConditional();

		int minLoop = (int) LoopStartBox.Value;
		int increment = (int) LoopIncrementBox.Value;
		int attempts = (int) LoopAttemptsBox.Value;
		int range = (int) LoopFindRangeBox.Value;
		int maxLoop = (attempts - 1) * increment + minLoop;

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
		var loopList = attemptsList.Distinct();
		NewTaskBarThing(2 * loopList.Count());

		int[] wavSamples = CurrentWAV!.SamplesToArray();
		bool freqEst = EstimatedFrequencyBox.Checked;
		decimal minLength = DecodeMinimumLength;
		SampleRate freq = CurrentSampleRate;

		BRREncoder enc = GetCurrentEncoder();

		// doing each step as an async task and making a wave file for each brr as it's encoded is fast
		// but it also can't be cancelled, so plbt
		var tasks = new List<Task>();

		foreach (int loop in loopList) {
			CancelToken.ThrowIfCancellationRequested();

			BRRSample brr = await Task.Run(() =>
				enc.Encode(
					pcmSamples: wavSamples,
					pcmLoopPoint: loop
				));

			TaskProgress.PerformStep();
			CancelToken.ThrowIfCancellationRequested();

			WaveContainer wavOut = await Task.Run(() =>
				brr.Decode(
					pitch: Conversion.DefaultVxPitch,
					minimumLength: minLength
				));

			TaskProgress.PerformStep();

			TestContainer addbrr = new(sampleName, brr, wavOut) {
				ListName = $"{sampleName}_{freq.FrequencykHz}_{loop}",
				FileName = $"{sampleName}_{freq.FrequencykHz}_{brr.LoopBlock}",
				LoopSample = loop,
				EncodingFrequency = freq,
				Trim = enc.Truncate,
			};


			if (freqEst) {
				tasks.Add(Task.Run(addbrr.DoFrequencyEstimate));
			}

			AddCandidateToBox(addbrr);
		}

		await Task.WhenAll(tasks);
	}


	/*************************************************************************************************\
	* Fine adjustment methods and events
	\*************************************************************************************************/

	private async void AdjustButton_Click(object sender, EventArgs e) {
		await RunGUITask(SampleAdjust);
	}

	private async Task SampleAdjust() {
		CheckForWave();

		ClearFileListConditional();

		int loop = (int) SampleAdjustAtBox.Value;
		int distance = (int) AdjustRangeBox.Value;

		int trimPoint = (int) TrimPointBox.Value;
		int minTrim = Math.Max(trimPoint - distance, 0);
		int maxTrim = Math.Min(trimPoint + distance, CurrentWAV!.SampleCount);

		NewTaskBarThing(2 * (maxTrim - minTrim + 1));

		ResamplingAlgorithm outResamp = GetCurrentResamplingAlgorithm();

		SampleRate freq = CurrentSampleRate;
		string sampleName = wavName;

		int[] wavSamples = CurrentWAV.SamplesToArray();
		bool freqEst = EstimatedFrequencyBox.Checked;
		decimal minLength = DecodeMinimumLength;

		BRREncoder enc = GetCurrentEncoder();

		var tasks = new List<Task>();
		for (int trim = minTrim; trim <= maxTrim; trim++) {
			CancelToken.ThrowIfCancellationRequested();

			enc.Truncate = trim;

			BRRSample brr = await Task.Run(() =>
				enc.Encode(
					pcmSamples: wavSamples,
					pcmLoopPoint: loop
				));

			TaskProgress.PerformStep();
			CancelToken.ThrowIfCancellationRequested();

			WaveContainer wavOut = await Task.Run(() =>
				brr.Decode(
					pitch: Conversion.DefaultVxPitch,
					minimumLength: minLength
				));

			TaskProgress.PerformStep();

			TestContainer addbrr = new(sampleName, brr, wavOut) {
				ListName = $"{sampleName}_{freq.FrequencykHz}_p{loop}t{trim}",
				FileName = $"{sampleName}_{freq.FrequencykHz}_{brr.LoopBlock}",
				LoopSample = loop,
				EncodingFrequency = freq,
				Trim = enc.Truncate,
			};

			if (freqEst) {
				tasks.Add(Task.Run(addbrr.DoFrequencyEstimate));
			}

			AddCandidateToBox(addbrr);
		}

		await Task.WhenAll(tasks);
	}

	private void RecalculateNumberOfBRRBlocks() {
		if (CurrentWAV is null) return;

		int numberOfBlocks = (int) (TrimPointBox.Value / CurrentSampleRate.Cram / Conversion.PCMBlockSize);
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

	private static WaveContainer ReadWaveFromFile(string path) {
		using var rd = new FileStream(path, FileMode.Open, FileAccess.Read);

		WaveContainer ret;

		try {
			ret = new(rd);
		} finally {
			rd.Close();
		}

		return ret;
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
				WaveContainer wav = ReadWaveFromFile(path);
				SetWAV(wav);
				EnableForm(true);
				EnableControls(true);
				SampleAdjustAtBox.Maximum = TrimPointBox.Value = TrimPointBox.Maximum = CurrentWAV!.SampleCount;

				// if the sample is too large, don't detect the pitch and uncheck the sample calc box
				if (wav.SampleCount > 15000) {
					InFreqLabel.Text = "-";
					EstimatedFrequencyBox.Checked = false;
				} else {
					double freq = Aubio.Aubio.DetectPitch(wav);
					InFreqLabel.Text = MusicUtility.GetFormattedFrequency(freq);
				}

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
		SampleRateBox.Text = $"{wav.SampleRate} Hz";
		FidelityBox.Text = $"{wav.BitsPerSample} bits per sample";
		SampleCountBox.Text = $"{wav.SampleCount} samples";
	}

	/*************************************************************************************************\
	* Auxiliary windows
	\*************************************************************************************************/
	private readonly AcknowledgementsWindow acknowledgementWindow = new();
	private void Acknowledgements_Click(object sender, EventArgs e) {
		acknowledgementWindow.ShowDialog();
	}

	private void BonusWindowClick(object sender, EventArgs e) {
		// check for types that have a Tag property
		object? w = sender switch {
			ToolStripItem a => a.Tag,
			Control a       => a.Tag,
			_               => null
		};

		// show w if it's a form
		if (w is Form f) {
			f.Show();
			f.Focus();
		}
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

	private void OpenOutputButton_Click(object sender, EventArgs e) {
		if (OutputDirectory is not null) {
			Process.Start("explorer.exe", OutputDirectory);
		}
	}


	/*************************************************************************************************\
	* Listen area
	\*************************************************************************************************/

	private TestContainer? CurrentBRR = null;
	private readonly System.Media.SoundPlayer Player = new();

	private void BRRTestBox_SelectedValueChanged(object sender, EventArgs e) {
		if (SetClickedBRR() is SampleClickAction.SampleChanged && AutoPlayCheckBox.Checked) {
			PlaySamplePreview();
		}
	}

	private SampleClickAction SetClickedBRR() {
		StopSamplePreview();

		var newbr = BRRTestBox.SelectedItem as TestContainer;

		if (newbr == CurrentBRR) {
			if (newbr is null) {
				return SampleClickAction.SampleNull;
			}
			return SampleClickAction.SampleUnchanged;
		}

		CurrentBRR = newbr;

		waveWindow.TestSample = CurrentBRR;

		Player.Stream?.Dispose();

		if (CurrentBRR is null) {
			ClearPreviewInfo();
			return SampleClickAction.SampleNull;
		};

		SizeLabel.Text = GetFormattedSize(CurrentBRR.BlockCount);
		LoopPointLabel.Text = GetFormattedLoopPoint(CurrentBRR.LoopBlock);
		LoopStartInputLabel.Text = CurrentBRR.LoopSample?.ToString() ?? "-";

		ExportFinalNameBox.Text = CurrentBRR.FileName;
		Player.Stream = CurrentBRR.WaveFile.AsMemoryStream();

		if (CurrentBRR.EstimatedFrequency is double freq) {
			EstimatedFrequencyLabel.Text = MusicUtility.GetFormattedFrequency(freq);
			EstimatedFrequencyLabel.Cursor = Cursors.Default;
		} else {
			EstimatedFrequencyLabel.Text = "[No frequency calculated]";
			EstimatedFrequencyLabel.Cursor = Cursors.Hand;
		}

		EstimatedFrequencyLabel.Enabled = true;

		return SampleClickAction.SampleChanged;
	}

	private void EstimatedFrequencyLabel_CursorChanged(object sender, EventArgs e) {
		if (EstimatedFrequencyLabel.Cursor == Cursors.Hand) {
			EstimatedFrequencyLabel.ForeColor = SystemColors.HotTrack;
			EstimatedFrequencyLabel.Font = new Font(EstimatedFrequencyLabel.Font, FontStyle.Underline);
			EstimatedFrequencyLabel.Enabled = true;
		} else {
			EstimatedFrequencyLabel.ForeColor = SystemColors.ControlText;
			EstimatedFrequencyLabel.Font = new Font(EstimatedFrequencyLabel.Font, FontStyle.Regular);
			EstimatedFrequencyLabel.Enabled = false;
		}
	}

	private void ClearPreviewInfo() {
		SizeLabel.Text = "-";
		LoopPointLabel.Text = "-";
		LoopStartInputLabel.Text = "-";
		EstimatedFrequencyLabel.Text = "-";
		EstimatedFrequencyLabel.Cursor = Cursors.Default;
		ExportFinalNameBox.Text = null;
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
		try {
			CheckForOutputDirectory();
			CheckForPreviewBRR();
		} catch (Exception x) {
			ShowError(x.Message);
			return;
		}

		string fileName = $"{OutputDirectory}/{ExportFinalNameBox.Text.Trim()}";
		BRRSample brr = CurrentBRR!.BRRFile;

		if (ExportBRRBox.Checked) {
			switch (BrrExportTypeBox.SelectedIndex) {
				case 0:
					brr.Save($"{fileName}.{BRRSample.Extension}");
					break;

				case 1:
					brr.ExportWithHeader($"{fileName}.{BRRSample.HeaderedExtension}");
					break;

				case 2:
					var bs = new SuiteSample(brr){
						EncodingFrequency = CurrentBRR.EncodingFrequency,
						InstrumentName = CurrentBRR.Name
					};
					bs.Save($"{fileName}.{SuiteSample.Extension}");
					break;
			}
		}

		if (ExportWAVButton.Checked) {
			CurrentBRR!.WaveFile.Save($"{fileName}.{WaveContainer.Extension}");
		}

		if (ExportTestSongBox.Checked) {
			//string path = $"{OutputDirectory}/{ExportFinalNameBox.Text.Trim()}-spctest.spc";
			string path = $"{OutputDirectory}/_test_.spc";

			//string path2 = $"{OutputDirectory}/{ExportFinalNameBox.Text.Trim()}-spctest.spc";
			using var fs = new FileStream(path, FileMode.Create, FileAccess.Write);

			ExportSPCFile(CurrentBRR!, fs);


			//File.Copy(path, path2, true);
		}
	}

	private void EstimatedFrequencyLabel_Click(object sender, EventArgs e) {
		GetPitchOfCurrentCandidate();
	}

	private void GetPitchOfCurrentCandidate() {
		EstimatedFrequencyLabel.Cursor = Cursors.Default;

		if (CurrentBRR is null) {
			EstimatedFrequencyLabel.Text = "-";
			EstimatedFrequencyLabel.Enabled = true;
			return;
		}

		CurrentBRR.DoFrequencyEstimate();

		if (CurrentBRR.EstimatedFrequency is double f) {
			EstimatedFrequencyLabel.Text = MusicUtility.GetFormattedFrequency(f);
		} else {
			EstimatedFrequencyLabel.Text = "Something went wrong.";
			EstimatedFrequencyLabel.ForeColor = Color.Red;
		}
	}


	private void ClearCandidatesBox_Click(object sender, EventArgs e) {
		ClearFileList();
	}

	private void BRRTestBox_KeyDown(object sender, KeyEventArgs e) {
		if (e.Handled) {
			return;
		}

		// don't override the base functionality
		switch (e.KeyCode) {
			case Keys.Down:
			case Keys.Up:
			case Keys.PageUp:
			case Keys.PageDown:
			case Keys.Home:
			case Keys.End:
				return;
		}

		e.Handled = true;

		// TODO figure out how to disable letters from navigating
		// other keys
		//switch (e.KeyCode) {
		//	case Keys.A:
		//		AutoPlayCheckBox.Checked = !AutoPlayCheckBox.Checked;
		//		return;
		//}


		int index = BRRTestBox.SelectedIndex;

		// the following commands require a valid item to be selected
		if (index < 0 || CurrentBRR is null) {
			return;
		}

		switch (e.KeyCode) {
			// delete item
			case Keys.Delete:
				BRRTestBox.Items.RemoveAt(index);

				int size = BRRTestBox.Items.Count;

				if (size == 0) {
					index = -1;
				} else if (index >= size) {
					index = size - 1;
				}
				BRRTestBox.SelectedIndex = index;
				return;

			// play sample
			case Keys.Space:
				PlaySamplePreview();
				return;


			case Keys.Enter: // TODO use this for pitch if can't figure out letters
				GetPitchOfCurrentCandidate();
				return;

			// add loop point
			case Keys.Back:
				if (CurrentBRR?.LoopSample is not int lppt) return;
				if (string.IsNullOrWhiteSpace(ScratchBox.Text)) {
					ScratchBox.Text = $"{lppt}";
				} else {
					ScratchBox.Text += $" {lppt}";
				}
				return;

			// detect pitch
			//case Keys.P:
			//	GetPitchOfCurrentCandidate();
			//	return;
			//
			//// select nothing
			//case Keys.N:
			//	BRRTestBox.ClearSelected();
			//	return;
		}
	}

	private enum SampleClickAction {
		SampleNull = 0,
		SampleChanged,
		SampleUnchanged
	}



	// https://wiki.superfamicom.org/spc-and-rsn-file-format
	private static void ExportSPCFile(TestContainer brr, Stream stream) {
		if (engineBase is null) {
			throw new FileNotFoundException("No engine base resource is loaded.");
		}

		stream.SetLength(0x10200);

		stream.Position = 0x00000;

		WriteString("SNES-SPC700 Sound File Data v0.30", 33);

		stream.WriteByte(26); // $00021
		stream.WriteByte(26); // $00022
		stream.WriteByte(26); // $00023 - add ID666 info
		stream.WriteByte(30); // $00024 - minor version

		stream.WriteByte(0x00); // $00025 - PC low
		stream.WriteByte(0x03); // $00026 - PC high

		stream.WriteByte(0x00); // $00027 - A
		stream.WriteByte(0x00); // $00028 - X
		stream.WriteByte(0x00); // $00029 - Y
		stream.WriteByte(0x00); // $0002A - PSW
		stream.WriteByte(0xFF); // $0002B - SP

		stream.WriteByte(0x00); // $0002C - Reserved
		stream.WriteByte(0x00); // $0002D - Reserved

		WriteString($"{brr.FileName}", 32); // $0002E - song title
		WriteString("BRR Suite GUI sample test song", 32); // $0004E - game title
		WriteString("BRR Suite GUI", 16); // $0006E - name of dumper
		WriteString("Cool song", 32); // $0007E - comments
		WriteString(DateTime.Now.ToString("MM/dd/yyyy"), 11); // $0009E - dump date (MM/DD/YYYY)

		WriteString("999", 3); // $000A9 - time to play song before fading out
		WriteString("0123", 4); // $000AC - length of fade

		WriteString("kan, with samples by you!", 32); // $000B1 - artist

		stream.WriteByte(0x01); // $000D1 - channel disables
		stream.WriteByte(0x00); // $000D2 - emulator

		stream.WriteByte(0x00); // $000D3 - reserved

		PadTo(0x00100);

		stream.Position = 0x00100;
		stream.Write(engineBase!);

		// remember the position we're at
		long loop = stream.Position - 0x0100;
		loop += brr.BRRFile.LoopPoint;

		stream.Write(brr.BRRFile.AsSpan());

		if (brr.BRRFile.IsLooping) {
			stream.Position = 0x00100 + 0x0202; // navigate to where loop point is saved
			stream.WriteByte((byte) loop);
			stream.WriteByte((byte) (loop >> 8));
		}

		stream.Position = 0x10100;
		stream.Write(engineBase!, 0x0100, 0x80); // copy registers hidden in the stack

		PadTo(stream.Length); // top off the reserved area

		void WriteString(string s, int len) {
			if (s.Length < len) {
				s = s.PadRight(len, ' ');
			}

			for (int i = 0; i < len; i++) {
				stream.WriteByte((byte) s[i]);
			}
		}

		void PadTo(long pos) {
			long count = pos - stream.Position;

			for (; count > 0; count--) {
				stream.WriteByte(0x00);
			}
		}
	}
}
