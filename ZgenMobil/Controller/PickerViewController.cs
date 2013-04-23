using System;
using MonoTouch.UIKit;

namespace ZgenMobil
{
	public class PickerViewController : UIPickerViewModel
	{
		private string[] fruits;
		public string SelectedFruit { get; set; }
		public event EventHandler fruitSelected;

		UIToolbar _toolbar;
		UIBarButtonItem _doneButton;

		public PickerViewController (params string[] fruits)
		{
			this.fruits = fruits;
			_doneButton = new UIBarButtonItem(UIBarButtonSystemItem.Done, null, null);
			//_doneButton.Clicked += (object sender, EventArgs e) => {
			//	_actionSheet.DismissWithClickedButtonIndex (0, true); 

			_toolbar = new UIToolbar();//new RectangleF(0, 0, _actionSheet.Frame.Width, 10));
			_toolbar.BarStyle = UIBarStyle.Black;
			_toolbar.Translucent = true;

			_toolbar.Items = new UIBarButtonItem[] {
				new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace, null, null),
				_doneButton
			};

			_toolbar.SizeToFit();



		}

		private void OnFruitSelected()
		{
			if(fruitSelected != null)
			{
				fruitSelected(this , EventArgs.Empty);
			}
		}

		public override void Selected(UIPickerView picker, int row, int component)
		{
			SelectedFruit = fruits[row];
			OnFruitSelected();
		}

		public override int GetComponentCount(UIPickerView picker)
		{
			return 1;
		}

		public override int GetRowsInComponent(UIPickerView picker, int component)
		{
			return fruits.Length;
		}

		public override string GetTitle(UIPickerView picker, int row, int component)
		{
			return fruits[row];
		}

	}

}

