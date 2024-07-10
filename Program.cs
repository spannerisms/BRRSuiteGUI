global using BRRSuite;
global using Aubio;

namespace BRRSuiteGUI;

internal static class Program {
	[STAThread]
	static unsafe void Main() {
		ApplicationConfiguration.Initialize();
		Application.Run(new MainForm());
	}
}
