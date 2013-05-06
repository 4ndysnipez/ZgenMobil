using System;
using MonoTouch.UIKit;
using System.Collections.Generic;
using MonoTouch.Foundation;

namespace ZgenMobil
{
	/// <summary>
	/// Table view source Klasse.
	/// </summary>
	public class TableViewSource : UITableViewSource 
	{
		private ViewMitarbeiterselektion _parentView;
		UITableViewCell row;
		private List<string> _itemsName;
		private List<string> _itemsPernr;
		private List<string> _itemsTeilbereich;
		private List<string> _itemsOrg;
		private List<NSData> _itemsImg;

		/// <summary>
		/// Gets or sets the selected row.
		/// </summary>
		/// <value>The selected row.</value>
		public string SelectedRow { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ZgenMobil.TableViewSource"/> class.
		/// </summary>
		/// <param name="parentView">Parent view.</param>
		/// <param name="itemsName">Items name.</param>
		/// <param name="itemsPernr">Items pernr.</param>
		/// <param name="itemsTeilbereich">Items teilbereich.</param>
		/// <param name="itemsOrg">Items org.</param>
		/// <param name="itemsImg">Items image.</param>
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

		/// <Docs>Table view displaying the sections.</Docs>
		/// <returns>Number of sections required to display the data. The default is 1 (a table must have at least one section).</returns>
		/// <para>Declared in [UITableViewDataSource]</para>
		/// <summary>
		/// Numbers the of sections.
		/// </summary>
		/// <param name="tableView">Table view.</param>
		public override int NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		/// <Docs>Table view displaying the rows.</Docs>
		/// <summary>
		/// Rowses the in section.
		/// </summary>
		/// <returns>The in section.</returns>
		/// <param name="tableview">Tableview.</param>
		/// <param name="section">Section.</param>
		public override int RowsInSection (UITableView tableview, int section)
		{
			return _itemsName.Count;
		}

		/// <Docs>Table view requesting the cell.</Docs>
		/// <summary>
		/// Gets the cell.
		/// </summary>
		/// <returns>The cell.</returns>
		/// <param name="tableView">Table view.</param>
		/// <param name="indexPath">Index path.</param>
		public override UITableViewCell GetCell(UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			row = new UITableViewCell(UITableViewCellStyle.Value1, null);

			row.SelectionStyle = UITableViewCellSelectionStyle.None;
			row.DetailTextLabel.TextAlignment = UITextAlignment.Center;

			row.ImageView.Image = UIImage.LoadFromData(_itemsImg[indexPath.Row]);
			row.TextLabel.Text = _itemsName[indexPath.Row];
			row.DetailTextLabel.Text = _itemsPernr[indexPath.Row];

			return row;
		}

		/// <Docs>Table view containing the row.</Docs>
		/// <summary>
		/// Rows the selected.
		/// </summary>
		/// <param name="tableView">Table view.</param>
		/// <param name="indexPath">Index path.</param>
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

