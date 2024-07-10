namespace BRRSuiteGUI;

// I should learn how data binding works instead
public partial class AdvancedSettingsWindow : Form {
	public decimal PreviewDuration {
		get => PreviewDurationBox.Value;
		set => PreviewDurationBox.Value = value;
	}

	public int MinimumTrimZeros {
		get => (int) TrimZerosBox.Value;
		set => TrimZerosBox.Value = value;
	}

	public AdvancedSettingsWindow() {
		InitializeComponent();
	}
}
