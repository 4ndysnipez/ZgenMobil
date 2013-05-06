using System;
using MonoTouch.UIKit;

namespace ZgenMobil
{
	/// <summary>
	/// Picker view controller.
	/// </summary>
	public class PickerViewController : UIPickerViewModel
	{
		private string[] _selektionen;
		public string SelectedSelektion { get; set; }
		public event EventHandler selektionSelected;

		/// <summary>
		/// Initializes a new instance of the <see cref="ZgenMobil.PickerViewController"/> class.
		/// </summary>
		/// <param name="selektionen">Selektionen.</param>
		public PickerViewController (params string[] selektionen)
		{
			this._selektionen = selektionen;
		}

		/// <summary>
		/// Raises the selektion selected event.
		/// </summary>
		private void OnSelektionSelected()
		{
			if(_selektionen != null)
			{
				selektionSelected(this , EventArgs.Empty);
			}
		}

		/// <Docs>To be added.</Docs>
		/// <param name="component">To be added.</param>
		/// <remarks>To be added.</remarks>
		/// <summary>
		/// Selected the specified picker, row and component.
		/// </summary>
		/// <param name="picker">Picker.</param>
		/// <param name="row">Row.</param>
		public override void Selected(UIPickerView picker, int row, int component)
		{
			SelectedSelektion = _selektionen[row];
			OnSelektionSelected();
		}

		/// <Docs>To be added.</Docs>
		/// <returns>1.</returns>
		/// <summary>
		/// Gets the component count.
		/// </summary>
		/// <param name="picker">Picker.</param>
		public override int GetComponentCount(UIPickerView picker)
		{
			return 1;
		}

		/// <Docs>To be added.</Docs>
		/// <summary>
		/// To be added.
		/// </summary>
		/// <remarks>Returns selected Row.</remarks>
		/// <returns>The rows in component.</returns>
		/// <param name="picker">Picker.</param>
		/// <param name="component">Component.</param>
		public override int GetRowsInComponent(UIPickerView picker, int component)
		{
			return _selektionen.Length;
		}

		/// <Docs>To be added.</Docs>
		/// <param name="component">To be added.</param>
		/// <returns>To be added.</returns>
		/// <summary>
		/// Gets the title.
		/// </summary>
		/// <param name="picker">Picker.</param>
		/// <param name="row">Row.</param>
		public override string GetTitle(UIPickerView picker, int row, int component)
		{
			return _selektionen[row];
		}

	}

}

