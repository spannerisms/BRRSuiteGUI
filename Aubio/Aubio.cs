global using System.Runtime.InteropServices;

namespace Aubio;

public static unsafe class Aubio {
	internal const string dll = "libaubio-5.dll";
	internal const CharSet CharEnc = CharSet.Ansi;

	public static float DetectPitch(WaveContainer wave, PitchDetectionAlgorithm method = PitchDetectionAlgorithm.Default, float? tolerance = null) {
		int hopSize = wave.SampleCount;

		using var tmp = new PitchDetect(method, (uint) hopSize, (uint) hopSize, (uint) wave.SampleRate);

		if (tolerance is float tolf) {
			tmp.Tolerance = tolf;
		}

		return tmp.Do(wave);
	}
}
