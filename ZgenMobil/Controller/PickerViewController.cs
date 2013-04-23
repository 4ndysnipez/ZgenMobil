using System;
using MonoTouch.UIKit;

namespace ZgenMobil
{
	public class PickerViewController : UIPickerViewModel
	{
		private string[] fruits;
		public string SelectedFruit { get; set; }
		public event EventHandler fruitSelected;

		public PickerViewController (params string[] fruits)
		{
			this.fruits = fruits;
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

