namespace Aubio;

public enum PitchDetectionAlgorithm {
	Default = 0,

	YIN,
	YINFast,
	Schmitt,

	// TODO these aren't actually implemented in the current dll this calls
	FComb,
	MComb,
	YINFFT,
	SpecAcf
}

public static class PitchDetectionAlgorithmExtensions {
	public static string GetToken(this PitchDetectionAlgorithm p) => p switch {
		PitchDetectionAlgorithm.Default or
		PitchDetectionAlgorithm.YIN => "yin",
		PitchDetectionAlgorithm.YINFast => "yinfast",
		PitchDetectionAlgorithm.Schmitt => "schmitt",
		PitchDetectionAlgorithm.FComb => "fcomb",
		PitchDetectionAlgorithm.MComb => "mcomb",
		PitchDetectionAlgorithm.YINFFT => "yinfft",
		PitchDetectionAlgorithm.SpecAcf => "specacf",
		_ => throw new ArgumentException($"Not a valid {nameof(PitchDetectionAlgorithm)}!"),
	};

	public static string GetName(this PitchDetectionAlgorithm p) => p switch {
		PitchDetectionAlgorithm.Default => "Default algorithm",
		PitchDetectionAlgorithm.YIN => "YIN",
		PitchDetectionAlgorithm.YINFast => "YIN but fast",
		PitchDetectionAlgorithm.Schmitt => "Schmitt trigger",
		PitchDetectionAlgorithm.FComb => "Fast comb filter",
		PitchDetectionAlgorithm.MComb => "Multi-comb filter",
		PitchDetectionAlgorithm.YINFFT => "Spectral YIN",
		PitchDetectionAlgorithm.SpecAcf => "Spectral autocorrelation",
		_ => throw new ArgumentException($"Not a valid {nameof(PitchDetectionAlgorithm)}!"),
	};
}
