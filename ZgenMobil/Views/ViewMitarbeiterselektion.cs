using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Text;
using System.IO;

namespace ZgenMobil
{
	/// <summary>
	/// Klasse der ViewMitarbeiterselektion
	/// </summary>
	public partial class ViewMitarbeiterselektion : UIViewController
	{
		/// <summary>
		/// Deklarationen
		/// </summary>
		ViewZeugnisart viewZeugnisart;
		TableViewSource tableViewSource;
		string selektion;
		PickerViewController pickerMitarbeiterselektion;
		private static ViewMitarbeiterselektion instance;

		/// <summary>
		/// Initializes a new instance of the <see cref="ZgenMobil.ViewMitarbeiterselektion"/> class.
		/// </summary>
		public ViewMitarbeiterselektion () : base ("ViewMitarbeiterselektion", null)
		{
			this.Title = "Mitarbeiterselektion";
			this.NavigationItem.SetHidesBackButton(true, true);
			this.NavigationItem.SetRightBarButtonItem(
				new UIBarButtonItem("Logout" , UIBarButtonItemStyle.Plain, (sender, args) =>
			    {
					Logout();
				}), true);

		}

		/// <summary>
		/// Gets or sets the selektion.
		/// </summary>
		/// <value>The selektion.</value>
		public string Selektion {
			get {
				return selektion;
			}
			set {
				selektion = value;
			}
		}		

		/// <summary>
		/// Gets or sets the instance.
		/// </summary>
		/// <value>The instance.</value>
		public static ViewMitarbeiterselektion Instance {
			get {
				if(instance == null)
				{
					instance = new ViewMitarbeiterselektion();
				}	
				return instance;
			}
			set {
				instance = value;
			}
		}

		/// <Docs>Called when the system is running low on memory.</Docs>
		/// <summary>
		/// Dids the receive memory warning.
		/// </summary>
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		/// <summary>
		/// Ergänzende Einstellungsmöglichkeiten, nachdem die View geladen wurde. 
		/// </summary>
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			labelDate.Text = "";

			string datum = System.DateTime.Now.ToString();

			for(int i = 0; i<10; i++)
			{
				labelDate.Text += datum[i];
			}

			toolbarSelektion.Hidden = true;

			//create pickerView für Mitarbeiterselektion
			string[] items = new string[3]{"Alle Mitarbeiter" , "Direkt unterstellte Mitarbeiter" , "Alle Org-Einheiten"};
			pickerMitarbeiterselektion = new PickerViewController(items);
			labelSelektion.Text = items[0];
		}

		/// <summary>
		/// Parsen der OData-Struktur und Ausgabe der Tabelle
		/// </summary>
		/// <param name="respXml">Resp xml.</param>
		public void buildTable(string respXml)
		{
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.LoadXml(respXml);

			//xmlDoc durch XmlNamespaceManager parsen
			XmlNamespaceManager xmlManager = new XmlNamespaceManager(xmlDoc.NameTable);
			xmlManager.AddNamespace("atom" 	, "http://www.w3.org/2005/Atom");
			xmlManager.AddNamespace("d" 	, "http://schemas.microsoft.com/ado/2007/08/dataservices");
			xmlManager.AddNamespace("m"		, "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata");
			xmlManager.AddNamespace("sap"	, "http://www.sap.com/Protocols/SAPData");
			xmlManager.AddNamespace("base"	, "HTTP://SCDECC.SCDINTERN.DE:8000/sap/opu/sdata/SCD/ZGEN_MI_EMPLOYEES/");

			XmlNodeList elements = xmlDoc.DocumentElement.SelectNodes("./atom:entry" , xmlManager);
			Console.WriteLine("test count: " + elements.Count.ToString());

			List <string> listName = new List<string>();
			List <string> listPernr = new List<string>();
			List <string> listTeilbereich = new List<string>();
			List <string> listOrg = new List<string>();
			List <NSData> listImg = new List<NSData>();
				
			foreach (XmlNode element in elements)
			{
				XmlNodeList propName = element.SelectSingleNode("./atom:content/m:properties/d:ENAME" , xmlManager).ChildNodes;
				foreach(XmlNode name in propName)
				{
					listName.Add(name.InnerText.ToString());
				}

				XmlNodeList propPernr = element.SelectSingleNode("./atom:content/m:properties/d:PERNR" , xmlManager).ChildNodes;
				foreach(XmlNode pernr in propPernr)
				{
					listPernr.Add(pernr.InnerText.ToString());
				}

				XmlNodeList propTeilbereich = element.SelectSingleNode("./atom:content/m:properties/d:BTRTX" , xmlManager).ChildNodes;
				foreach(XmlNode teilbereich in propTeilbereich)
				{
					listTeilbereich.Add(teilbereich.InnerText.ToString());
				}

				XmlNodeList propOrg = element.SelectSingleNode("./atom:content/m:properties/d:ORGTX" , xmlManager).ChildNodes;
				foreach(XmlNode org in propOrg)
				{
					listOrg.Add(org.InnerText.ToString());
				}

				XmlNodeList propImg = element.SelectSingleNode("./atom:content/m:properties/d:PORTRAIT_IMG" , xmlManager).ChildNodes;
				foreach(XmlNode img in propImg)
				{
					string imgBase64 = img.Value.Replace("data:image/jpeg;base64,","");

					while((imgBase64.Length % 4) != 0)
					{
						imgBase64 += "=";
						Console.WriteLine("imgBase64 nicht mod 4!");
					}
					byte[] imgBytes = Convert.FromBase64String(imgBase64);
					NSData data = NSData.FromArray(imgBytes);
					listImg.Add(data);
				}
			}
			tableViewSource = new TableViewSource(this , listName, listPernr, listTeilbereich, listOrg, listImg);
			tableView.Source = tableViewSource;
		}

		/// <summary>
		/// ActionBtnDate
		/// </summary>
		/// <param name="sender">Sender.</param>
		partial void actionBtnDate (NSObject sender)
		{
			if(pickerView.Hidden == false)
			{
				pickerView.Hidden = true;
				toolbarSelektion.Hidden = true;
			}

			datumPicker.Hidden = false;
			toolbarDate.Hidden = false;
		}

		/// <summary>
		/// Actions the button selektion.
		/// </summary>
		/// <param name="sender">Sender.</param>
		partial void actionBtnSelektion (NSObject sender)
		{
			if(datumPicker.Hidden == false)
			{
				datumPicker.Hidden = true;
				toolbarDate.Hidden = true;
			}
			pickerView.Model = pickerMitarbeiterselektion;
			tableView.Hidden = true;
			pickerView.Hidden = false;
			toolbarSelektion.Hidden = false;

			pickerMitarbeiterselektion.selektionSelected += (object se, EventArgs ea) => 
			{
				selektion = pickerMitarbeiterselektion.SelectedSelektion;
			};
		}

		/// <summary>
		/// Actions the selektion done.
		/// </summary>
		/// <param name="sender">Sender.</param>
		partial void actionSelektionDone (NSObject sender)
		{
			labelSelektion.Text = selektion;
			pickerView.Hidden = true;
			toolbarSelektion.Hidden = true;
			tableView.Hidden = false;
		}
		/// <summary>
		/// Actions the button date done.
		/// </summary>
		/// <param name="sender">Sender.</param>
		partial void actionBtnDateDone (NSObject sender)
		{
			StringBuilder sb = new StringBuilder(datumPicker.Date.ToString());
			sb.Replace("-",".");

			string yy = sb[0].ToString() + sb[1].ToString() + sb[2].ToString() + sb[3].ToString();
			string mm = sb[5].ToString() + sb[6].ToString();
			string dd = sb[8].ToString() + sb[9].ToString();
			string pk = ".";
					
			Console.WriteLine( "hier " +  datumPicker.Date.ToString());


			labelDate.Text = dd+pk+mm+pk+yy;

			toolbarDate.Hidden = true;
			datumPicker.Hidden = true;
		}

		/// <summary>
		/// Daten des selektierten Mitarbeiters
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="pernr">Pernr.</param>
		/// <param name="teilbereich">Teilbereich.</param>
		/// <param name="org">Org.</param>
		/// <param name="img">Image.</param>
		public void mitarbeiterSelected(string name, string pernr , string teilbereich, string org, NSData img)
		{
			if(viewZeugnisart == null){
				viewZeugnisart =  ViewZeugnisart.Instance;
			}
			this.NavigationController.PushViewController(viewZeugnisart, true);
			viewZeugnisart.setLabels(name, pernr, teilbereich, org, img);
		}

		/// <summary>
		/// Logout this instance.
		/// </summary>
		public void Logout()
		{
			this.NavigationController.PopToRootViewController(true);
			HttpRestController.Instance.UserLogged = false;
			new UIAlertView("Logout", "Successful",null,"OK",null).Show();
		}

	}
}

