using System;
using MonoTouch.UIKit;

namespace ZgenMobil
{
	public class TableViewSource : UITableViewSource 
	{
		private string[] _items;
		//UIImage img { get; set; }

		public TableViewSource (params string[] items)
		{
			_items = items;
		}

		public override int NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return _items.Length;
		}

		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			UITableViewCell cell;
			//cell = tableView.DequeueReusableCell ("Placeholder");
			//cell = new UITableViewCell(UITableViewCellStyle.Subtitle, null);
			cell = new UITableViewCell(UITableViewCellStyle.Value1, null);
				//(UITableViewCellStyle.Subtitle, "Placeholder");
			cell.SelectionStyle = UITableViewCellSelectionStyle.Blue;

			cell.DetailTextLabel.TextAlignment = UITextAlignment.Center;

			//TODO
			//create string[] wie bei _items
			cell.DetailTextLabel.Text = "Textiiiii";
			cell.ImageView.Image = UIImage.FromFile("img/scdsoftLogo.png");

			cell.TextLabel.Text = _items[indexPath.Row];

			return cell;
		}
	}
}

