using System.ComponentModel;

namespace BRRSuiteGUI;

[DefaultProperty(nameof(Value))]
[DefaultEvent(nameof(ValueChanged))]
[DefaultBindingProperty(nameof(Value))]
internal class RoundedUpDown : NumericUpDown {
	public RoundedUpDown() : base() { }

	[Bindable(true)]
	public new decimal Value {
		get => base.Value;
		set => base.Value = decimal.Round(value, DecimalPlaces, MidpointRounding.ToZero);
	}

	protected override void OnMouseWheel(MouseEventArgs e) {
		if (e is HandledMouseEventArgs f) {
			f.Handled = true;
		}

		if (e.Delta > 0) {
			UpButton();
		} else if (e.Delta < 0) {
			DownButton();
		}

		base.OnMouseWheel(e);
	}
}
