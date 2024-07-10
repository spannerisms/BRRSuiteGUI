namespace BRRSuiteGUI;

public static class MusicUtility {
	public const double ConcertA4 = 440.0000D;
	public const double ConcertC4 = 261.6256D;
	private const int OneOctave = 12;

	private static readonly string[] Notes = [ "A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#" ];
	public static string GetNoteNameAndOctave(double freq) {
		return $"{GetNoteName(freq)}{GetOctave(freq)}";
	}

	public static int GetOctave(double freq) {
		int cents = GetCentsDifference(freq, ConcertC4);
		cents += 50; // round

		if (cents >= 0) { // let flat Cs stay the correct octave
			return 4 + cents / 1200;
		}

		return 3 + cents / 1200;
	}

	public static string GetNoteName(double freq) {
		int n = GetNoteDifference(freq, ConcertA4);
		n %= 12;
		n += 12;
		n %= 12;
		return Notes[n];
	}

	public static int GetCentsFromConcertPitch(double freq) {
		double betterFreq = RoundToNearestNote(freq);
		int cents = GetCentsDifference(freq, betterFreq);

		if (cents < 51) {
			return cents;
		}

		return -(100 - cents);
	}

	public static string GetCentsFromConcertPitchFormatted(double freq) {
		int cents = GetCentsFromConcertPitch(freq);

		return cents switch {
			  0 => "±0",
			< 0 => $"{cents}",
			> 0 => $"+{cents}"
		};
	}

	public static double RoundToNearestNote(double freq) {
		return Math.Pow(2, Math.Round(OneOctave * Math.Log2(freq / ConcertA4)) / OneOctave) * ConcertA4;
	}

	public static int GetCentsDifference(double freqN, double freqD) {
		return (int) Math.Round(OneOctave * 100 * Math.Log2(freqN / freqD));
	}

	private static int GetNoteDifference(double freqN, double freqD) {
		return (int) Math.Round(OneOctave * Math.Log2(freqN / freqD));
	}

	public static string GetFormattedFrequency(double freq) {
		return $"{freq:#####.0000} Hz ({GetNoteNameAndOctave(freq)} {GetCentsFromConcertPitchFormatted(freq)} cents)";
	}

}
