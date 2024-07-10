namespace BRRSuiteGUI;

public partial class FrequencyWindow : Form {

	private const double A440 = 440.0000D;
	private const int A4Key = 49;
	private const int C4Key = 40;

	private const int MinOctave = 2;
	private const int MaxOctave = 6;
	private const int OctaveWidth = 75;
	private const int NameWidth = 50;
	public FrequencyWindow() {
		InitializeComponent();

		Width = NameWidth + (OctaveWidth * (MaxOctave - MinOctave + 1)) + 10;

		Populate();
		CheatSheet.ClearSelection();
	}

	private void Populate() {
		CheatSheet.AutoGenerateColumns = false;
		CheatSheet.Columns.Add(new DataGridViewTextBoxColumn() {
			DataPropertyName = nameof(NoteValues.Name),
			HeaderText = "",
			Width = NameWidth,
		});

		string[] props = [
			nameof(NoteValues.Octave0Hz),
			nameof(NoteValues.Octave1Hz),
			nameof(NoteValues.Octave2Hz),
			nameof(NoteValues.Octave3Hz),
			nameof(NoteValues.Octave4Hz),
			nameof(NoteValues.Octave5Hz),
			nameof(NoteValues.Octave6Hz),
			nameof(NoteValues.Octave7Hz),
		];

		for (int i = MinOctave; i <= MaxOctave; i++) {
			CheatSheet.Columns.Add(new DataGridViewTextBoxColumn() {
				DataPropertyName = props[i],
				HeaderText = $"{i}",
				Width = OctaveWidth,
			});
		}

		NoteValues[] allnotes = [
			new("C", 0),
			new("C#", 1),
			new("D", 2),
			new("D#", 3),
			new("E", 4),
			new("F", 5),
			new("F#", 6),
			new("G", 7),
			new("G#", 8),
			new("A", 9),
			new("A#", 10),
			new("B", 11),
		];

		CheatSheet.DataSource = allnotes;
	}

	protected override void OnFormClosing(FormClosingEventArgs e) {
		if (e.CloseReason == CloseReason.UserClosing) {
			Hide();
			e.Cancel = true;
		}
	}


	private class NoteValues {
		public string Name { get; }

		public string Octave0Hz { get; }
		public string Octave1Hz { get; }
		public string Octave2Hz { get; }
		public string Octave3Hz { get; }
		public string Octave4Hz { get; }
		public string Octave5Hz { get; }
		public string Octave6Hz { get; }
		public string Octave7Hz { get; }

		private const string format = "{0,10:0.0000}";
		public NoteValues(string name, int value) {
			Name = name;

			Octave0Hz = string.Format(format, GetFrequency(0));
			Octave1Hz = string.Format(format, GetFrequency(1));
			Octave2Hz = string.Format(format, GetFrequency(2));
			Octave3Hz = string.Format(format, GetFrequency(3));
			Octave4Hz = string.Format(format, GetFrequency(4));
			Octave5Hz = string.Format(format, GetFrequency(5));
			Octave6Hz = string.Format(format, GetFrequency(6));
			Octave7Hz = string.Format(format, GetFrequency(7));

			double GetFrequency(int octave) {
				int key = C4Key + value + (octave - 4) * 12;
				return A440 * Math.Pow(Math.Pow(2, 1D / 12), key - A4Key);
			}
		}
	}
}
