namespace BRRSuiteGUI;

internal partial class WaveformWindow : Form {

	public static readonly Color Futaba = Color.FromArgb(unchecked((int) 0xFF78886A));
	public static readonly Color DarkFutaba = Color.FromArgb(unchecked((int) 0xFF313D26));
	public static readonly Color Periwinkle = Color.FromArgb(unchecked((int) 0xFFCCCCFF));
	public static readonly Color LoopColor = Color.RoyalBlue;

	private TestContainer? sampleContainer = null;
	public TestContainer? TestSample {
		get => sampleContainer;
		set {
			if (value == sampleContainer) {
				return;
			}

			sampleContainer = value;
			RefreshImage();
		}
	}

	private Bitmap? waveImage = null;

	public WaveformWindow() {
		InitializeComponent();
		WavePanel.BackColor = Futaba;
	}

	protected override void OnFormClosing(FormClosingEventArgs e) {
		if (e.CloseReason == CloseReason.UserClosing) {
			Hide();
			e.Cancel = true;
		}
	}

	private void RefreshImage() {
		waveImage?.Dispose();

		if (!Visible) {
			WavePanel.Image = null;
			return;
		}

		waveImage = CreateWaveformImage(sampleContainer);
		WavePanel.Image = waveImage;
	}

	private static Bitmap? CreateWaveformImage(TestContainer? sample) {
		if (sample is null) {
			return null;
		}

		const int height = 3201;
		const int halfheight = height / 2;

		int width = sample.BRRFile.SampleCount;
		var img = new Bitmap(width, height);

		using var g = Graphics.FromImage(img);

		g.Clear(DarkFutaba);

		var col = new Pen(Periwinkle);

		for (int i = 0; i < width; i++) {
			if (i == sample.LoopBlock * 16) {
				col = new Pen(LoopColor);
			}
			int h = sample.WaveFile[i] / 20;
			g.DrawLine(col, i, halfheight, i, h + halfheight);


		}

		g.DrawLine(new(Color.Black), 0, halfheight, width, halfheight);

		g.Flush();

		return img;
	}

	private void WaveformWindow_VisibleChanged(object sender, EventArgs e) {
		if (Visible) {
			RefreshImage();
		}
	}
}
