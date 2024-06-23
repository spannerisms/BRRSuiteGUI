namespace BRRSuiteGUI;

internal sealed record ItemWithName(string Name, object? Thing) {
	public override string ToString() => Name;
}
