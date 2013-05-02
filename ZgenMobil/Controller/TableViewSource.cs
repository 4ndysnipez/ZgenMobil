using System;
using MonoTouch.UIKit;
using System.Collections.Generic;
using MonoTouch.Foundation;

namespace ZgenMobil
{
	public class TableViewSource : UITableViewSource 
	{
		private ViewMitarbeiterselektion _parentView;
		UITableViewCell row;
		private List<string> _itemsName;
		private List<string> _itemsPernr;
		private List<string> _itemsTeilbereich;
		private List<string> _itemsOrg;
		private List<NSData> _itemsImg;


		public string SelectedRow { get; set; }

		public TableViewSource (ViewMitarbeiterselektion parentView,	List<string> itemsName, 
		                        										List<string> itemsPernr,
		                        										List<string> itemsTeilbereich,
		                        										List<string> itemsOrg,
		                        										List<NSData> itemsImg)
		{
			_itemsName 			= itemsName;
			_itemsPernr			= itemsPernr;
			_itemsTeilbereich 	= itemsTeilbereich; 
			_itemsOrg		 	= itemsOrg; 
			_itemsImg			= itemsImg;

			_parentView = parentView;
		}

		public override int NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return _itemsName.Count;
		}

		public override UITableViewCell GetCell(UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			//cell = tableView.DequeueReusableCell ("Placeholder");
			//cell = new UITableViewCell(UITableViewCellStyle.Subtitle, null);

			row = new UITableViewCell(UITableViewCellStyle.Value1, null);
			//(UITableViewCellStyle.Subtitle, "Placeholder");

			row.SelectionStyle = UITableViewCellSelectionStyle.None;
			row.DetailTextLabel.TextAlignment = UITextAlignment.Center;

			row.ImageView.Image = UIImage.LoadFromData(_itemsImg[indexPath.Row]);
			row.TextLabel.Text = _itemsName[indexPath.Row];
			row.DetailTextLabel.Text = _itemsPernr[indexPath.Row];

			return row;
		}

		public override void RowSelected(UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			string name = _itemsName[indexPath.Row].ToString();
			string pernr = _itemsPernr[indexPath.Row].ToString();
			string teilbereich = _itemsTeilbereich[indexPath.Row].ToString();
			string org = _itemsOrg[indexPath.Row].ToString();
			NSData img = _itemsImg[indexPath.Row];

			Console.WriteLine("Gewählter Name: " + name);
			Console.WriteLine("Gewählte  Pernr: " + pernr);
			Console.WriteLine("Gewählter Teilbereich: " + teilbereich);
			Console.WriteLine("Gewählte  OrgEinheit: " + org);

			_parentView.mitarbeiterSelected(name, pernr, teilbereich, org, img);

		}


	}
}

