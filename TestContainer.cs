namespace BRRSuiteGUI;

/// <summary>
/// Holds an encoded audio sample, a preview audio file, and, optionally, the parameters these files were generated with.
/// </summary>
internal sealed class TestContainer {
	/// <summary>
	/// Gets a reference to the encoded BRR file associated with this test candidate.
	/// </summary>
	public BRRSample BRRFile { get; }

	/// <summary>
	/// Gets a reference to the wave audio associated with this test candidate.
	/// </summary>
	public WaveContainer WaveFile { get; }

	/// <summary>
	/// The name of this object as it should appear in the user interface.
	/// </summary>
	public string Name { get; }

	/// <summary>
	/// Gets the name this object should appear as in the user interface.
	/// </summary>
	public string ListName { get; init; }

	/// <summary>
	/// Gets the preferred file name this container's children should use for export.
	/// </summary>
	public string FileName { get; init; }

	/// <summary>
	/// The sample the source audio was trimmed to
	/// </summary>
	public int Trim { get; init; } = 0;

	/// <summary>
	/// 
	/// </summary>
	public decimal ResampleRatio { get; set; } = 1.0M;

	/// <summary>
	/// The attempted sample the source audio was looped at.
	/// </summary>
	public int? LoopSample { get; init; } = null;

	/// <summary>
	/// The number of blocks in the BRR file.
	/// </summary>
	public int BlockCount => BRRFile.BlockCount;

	/// <summary>
	/// The block number of the loop for the BRR file.
	/// </summary>
	public int LoopBlock => BRRFile.LoopBlock;

	/// <summary>
	///
	/// </summary>
	/// <param name="name">A simple name for this file.</param>
	/// <param name="brr"></param>
	/// <param name="wav"></param>
	public TestContainer(string name, BRRSample brr, WaveContainer wav) {
		FileName = ListName = Name = name;
		BRRFile = brr;
		WaveFile = wav;
	}

	/// <inheritdoc cref="object.ToString()"/>
	public override string ToString() => ListName;
}
