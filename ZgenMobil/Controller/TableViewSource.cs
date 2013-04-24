using System;
using MonoTouch.UIKit;

namespace ZgenMobil
{
	public class TableViewSource : UITableViewSource 
	{
		private ViewMitarbeiterselektion _parentView;
		ViewMitarbeiterselektion viewMitarbeiterselektion;
		UITableViewCell row;
		private string[] _items;
		public string SelectedRow { get; set; }
		//public event EventHandler rowSelected;

		//UIImage img { get; set; }

		public TableViewSource (ViewMitarbeiterselektion parentView, params string[] items)
		{
			_items = items;
			_parentView = parentView;
		}

	//	private void OnRowSelected()
	//	{
	//		if(_items != null)
	//		{
				//rowSelected(this , EventArgs.Empty);

	//		}
	//	}


		public override int NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return _items.Length;
		}

		public override UITableViewCell GetCell(UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{



			//cell = tableView.DequeueReusableCell ("Placeholder");
			//cell = new UITableViewCell(UITableViewCellStyle.Subtitle, null);

			row = new UITableViewCell(UITableViewCellStyle.Value1, null);

				//(UITableViewCellStyle.Subtitle, "Placeholder");

			row.SelectionStyle = UITableViewCellSelectionStyle.Blue;

			row.DetailTextLabel.TextAlignment = UITextAlignment.Center;

			//TODO
			//create string[] wie bei _items
			row.DetailTextLabel.Text = "Textiiiii";
			row.ImageView.Image = UIImage.FromFile("img/scdsoftLogo.png");

			row.TextLabel.Text = _items[indexPath.Row];

			return row;
		}

		public override void RowSelected(UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			string name = _items[indexPath.Row].ToString();
			Console.WriteLine(name + " JOOOOOOOOO");
			//SelectedRow = _items[indexPath];
			//OnRowSelected();

//			if(viewMitarbeiterselektion == null){

//				viewMitarbeiterselektion =  new ViewMitarbeiterselektion();
//			}

			_parentView.mitarbeiterSelected(name);

		}


	}
}

