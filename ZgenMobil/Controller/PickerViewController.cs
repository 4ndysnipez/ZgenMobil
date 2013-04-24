using System;
using MonoTouch.UIKit;

namespace ZgenMobil
{
	public class PickerViewController : UIPickerViewModel
	{
		private string[] _selektionen;
		public string SelectedSelektion { get; set; }
		public event EventHandler selektionSelected;

		//UIToolbar _toolbar;
		//UIBarButtonItem _doneButton;

		public PickerViewController (params string[] selektionen)
		{
			this._selektionen = selektionen;

		/*
			_doneButton = new UIBarButtonItem(UIBarButtonSystemItem.Done, null, null);
			_doneButton.Clicked += (object sender, EventArgs e) => {
			_actionSheet.DismissWithClickedButtonIndex (0, true); 

			var flexibleSpace = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace);

			_toolbar = new UIToolbar();//new RectangleF(0, 0, _actionSheet.Frame.Width, 10));
			_toolbar.BarStyle = UIBarStyle.Black;
			_toolbar.Translucent = true;
			_toolbar.SetItems(new [] { _doneButton } , false);

			_toolbar.Items = new UIBarButtonItem[] {
			new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace, null, null),
			_doneButton
			};


			_toolbar.SizeToFit();
		*/

		}

		private void OnSelektionSelected()
		{
			if(_selektionen != null)
			{
				selektionSelected(this , EventArgs.Empty);
			}
		}

		public override void Selected(UIPickerView picker, int row, int component)
		{
			SelectedSelektion = _selektionen[row];
			OnSelektionSelected();
		}

		public override int GetComponentCount(UIPickerView picker)
		{
			return 1;
		}

		public override int GetRowsInComponent(UIPickerView picker, int component)
		{
			return _selektionen.Length;
		}

		public override string GetTitle(UIPickerView picker, int row, int component)
		{
			return _selektionen[row];
		}

	}

}

