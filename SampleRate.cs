namespace BRRSuiteGUI;

/// <summary>
/// Represents an audio sample rate given in hertz.
/// </summary>
public readonly struct SampleRate : IComparable<SampleRate> {
	/// <summary>
	/// Gets the number of samples per second expressed by this frequency.
	/// </summary>
	public int Frequency { get; } = Conversion.DSPFrequency;

	/// <summary>
	/// Gets the frequency expressed as and rounded down to the nearest kilohertz.
	/// </summary>
	public int FrequencykHz => Frequency / 1000;

	/// <summary>
	/// Gets the ratio between the SNES DSP frequency of 32000 and this frequency.
	/// </summary>
	public decimal Cram => 32000M / Frequency;

	/// <summary>
	/// Creates a new <see cref="SampleRate"/> struct for the specified frequency.
	/// </summary>
	/// <param name="frequency">The frequency of this sample. This should be a positive, nonzero value.</param>
	/// <exception cref="ArgumentException">When <paramref name="frequency"/> is 0 or negative.</exception>
	public SampleRate(int frequency) {
		if (frequency < 1) {
			throw new ArgumentException("Frequency should be a positive, non-zero value.");
		}

		Frequency = frequency;
	}

	/// <summary>
	/// Returns a readable string of this frequency with units hertz.
	/// </summary>
	public override string ToString() => $"{Frequency} Hz";

	/// <summary>
	/// Calculates the ratio representing this sample rate resampled to the given target frequency.
	/// </summary>
	/// <param name="targetFrequency">The target frequency to resample to.</param>
	/// <returns>A <see langword="decimal"/> resampling ratio.</returns>
	public decimal ResampleTo(int targetFrequency) {
		return (decimal) Frequency / targetFrequency;
	}

	/// <inheritdoc cref="ResampleTo(int)"/>
	public decimal ResampleTo(SampleRate targetFrequency) {
		return ResampleTo(targetFrequency.Frequency);
	}

	/// <summary>
	/// Calculates the ratio representing this sample rate resampled from the given target frequency.
	/// </summary>
	/// <param name="fromFrequency">The frequency to resample from.</param>
	/// <returns>A <see langword="decimal"/> resampling ratio.</returns>
	public decimal ResampleFrom(int fromFrequency) {
		return (decimal) Frequency / fromFrequency;
	}

	/// <inheritdoc cref="ResampleFrom(int)"/>
	public decimal ResampleFrom(SampleRate fromFrequency) {
		return ResampleFrom(fromFrequency.Frequency);
	}

	/// <inheritdoc cref="IComparable.CompareTo(object?)"/>
	public int CompareTo(SampleRate other) {
		return Frequency.CompareTo(other.Frequency);
	}

	/// <summary>
	/// Represents a sample rate of 32000 Hz, the frequency of the SNES DSP.
	/// </summary>
	public static readonly SampleRate SR32000 = new(32000);

	/// <summary>
	/// Represents a sample rate of 16000 Hz.
	/// </summary>
	public static readonly SampleRate SR16000 = new(16000);

	/// <summary>
	/// Represents a sample rate of 8000 Hz.
	/// </summary>
	public static readonly SampleRate SR8000 = new(8000);

	/// <summary>
	/// Represents a sample rate of 4000 Hz.
	/// </summary>
	public static readonly SampleRate SR4000 = new(4000);

	/// <summary>
	/// Represents a sample rate of 44100 Hz, the standard for CD-quality audio.
	/// </summary>
	public static readonly SampleRate SR44100 = new(44100);

	public static explicit operator SampleRate(int sr) => new(Math.Max(1, sr));

	public static implicit operator int(SampleRate sr) => sr.Frequency;
	public static implicit operator uint(SampleRate sr) => (uint) sr.Frequency;
	public static implicit operator decimal(SampleRate sr) => sr.Frequency;
}
