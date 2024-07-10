using System.Diagnostics.CodeAnalysis;

namespace Aubio;

[StructLayout(LayoutKind.Sequential)]
internal abstract unsafe class FvecBase : IDisposable {
	public readonly uint Count;
	public readonly nint ptr;
	private bool amDead;

	protected FvecBase(uint count, nint size) {
		Count = count;
		ptr = Marshal.AllocHGlobal(size);
	}

	~FvecBase() {
		Dispose(false);
	}

	protected virtual void Dispose(bool disposing) {
		if (!amDead) {
			if (disposing) {
				Marshal.FreeHGlobal(ptr);
			}

			amDead = true;
		}
	}

	public void Dispose() {
		Dispose(true);
		GC.SuppressFinalize(this);
	}
}

[StructLayout(LayoutKind.Sequential)]
internal unsafe sealed class FvecRet : FvecBase {
	public FvecRet() : base(1, sizeof(float)) {
	}

	// again, this is just a float
	public static implicit operator float(FvecRet f) => ((float*) f.ptr)[0];
}

[StructLayout(LayoutKind.Sequential)]
internal unsafe class FvecSamples : FvecBase {

	public FvecSamples(WaveContainer samples) : base((uint) samples.SampleCount, samples.SampleCount * sizeof(float)) {
		float* fsamps = (float*) ptr;

		for (int i = 0; i < Count; i++) {
			fsamps[i] = samples[i];
		}
	}
}
