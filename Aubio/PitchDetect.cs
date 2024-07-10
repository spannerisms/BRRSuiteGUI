namespace Aubio;

public sealed unsafe partial class PitchDetect : IDisposable {
	private readonly PitchT* _cstruct;

	public int Type => _cstruct->type;
	public int Mode => _cstruct->mode;

	public float Silence {
		get => _cstruct->silence;
		set => _cstruct->silence = Math.Clamp(value, -200F, 0F);
	}

	private string _pitchUnit = "Hz";
	public string PitchUnit {
		get => _pitchUnit;
		set {
			string clean = value?.ToLowerInvariant() switch {
				"hz" or
				"hertz" or
				"frequency" or
				"freq" => "Hz",

				"midi" => "midi",

				"cent" or
				"cents" => "cent",

				"bin" => "bin",

				_ => throw new ArgumentException($"Invalid unit: {value}")
			};

			_pitchUnit = clean;
			aubio_pitch_set_unit(_cstruct, _pitchUnit);

			//[LibraryImport(Aubio.dll, EntryPoint = "aubio_pitch_set_unit", StringMarshalling = StringMarshalling.Utf8)]
			[DllImport(Aubio.dll, EntryPoint = "aubio_pitch_set_unit", CharSet = CharSet.Ansi)]
			[return: MarshalAs(UnmanagedType.Bool)]
			static extern bool aubio_pitch_set_unit(PitchT* t, string s);
		}
	}

	private uint _toleranceError = 0;
	private bool meGone;

	public float Tolerance {
		get {
			return aubio_pitch_get_tolerance(_cstruct);

			//[LibraryImport(Aubio.dll, EntryPoint = "aubio_pitch_get_tolerance")]
			[DllImport(Aubio.dll, EntryPoint = "aubio_pitch_get_tolerance")]
			[return: MarshalAs(UnmanagedType.R4)]
			static extern float aubio_pitch_get_tolerance(PitchT* p);
		}
		set {
			_toleranceError = aubio_pitch_set_tolerance(_cstruct, value);

			//[LibraryImport(Aubio.dll, EntryPoint = "aubio_pitch_set_tolerance")]
			[DllImport(Aubio.dll, EntryPoint = "aubio_pitch_set_tolerance")]
			[return: MarshalAs(UnmanagedType.U4)]
			static extern uint aubio_pitch_set_tolerance(PitchT* p, float v);
		}
	}


	/// <summary>
	/// Pitch Detective
	/// </summary>
	public PitchDetect(PitchDetectionAlgorithm method, uint bufferSize, uint hopSize, uint sampleRate) {
		_cstruct = new_aubio_pitch(method.GetToken(), bufferSize, hopSize, sampleRate);
	}

	[LibraryImport(Aubio.dll, EntryPoint = "new_aubio_pitch", StringMarshalling = StringMarshalling.Utf8)]
	private static partial PitchT* new_aubio_pitch(string method, uint bufferSize, uint hopSize, uint sampleRate);

	public float Do(WaveContainer w) {
		using FvecRet ret = new();
		using FvecSamples samps = new(w);
		aubio_pitch_do(_cstruct, samps, ret);

		return ret;

		//[LibraryImport(Aubio.dll, EntryPoint = "aubio_pitch_do")]
		[DllImport(Aubio.dll, EntryPoint = "aubio_pitch_do")]
		static extern void aubio_pitch_do(PitchT* p, FvecSamples ptr, FvecRet retPtr);
	}

	~PitchDetect() {
		Dispose(false);
	}

	private void Dispose(bool disposing) {
		if (!meGone) {
			if (disposing) {
				del_aubio_pitch(_cstruct);

				//[LibraryImport(Aubio.dll, EntryPoint = "del_aubio_pitch")]
				[DllImport(Aubio.dll, EntryPoint = "del_aubio_pitch")]
				static extern void del_aubio_pitch(PitchT* p);
			}

			meGone = true;
		}
	}

	public void Dispose() {
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	// This should never actually be created as a managed struct
	// it only exists as a wrapper for member access to the unmanaged memory created by the aubio library
	[StructLayout(LayoutKind.Sequential)]
	private unsafe struct PitchT {
		public int type;
		public int mode;
		public uint samplerate;
		public uint bufsize;
		public void* pobject;
		public void* filter;
		public void* filtered;
		public void* pv;
		public void* fftgrain;
		public void* buf;
		public void* detect_cb;
		public void* conv_cb;
		public void* conf_cb;
		public float silence;
	}
}
