using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace ZgenMobil
{
	/// <summary>
	/// View zeugnisart.
	/// </summary>
	public partial class ViewZeugnisart : UIViewController
	{
		/// <summary>
		/// Deklarationen
		/// </summary>
		private static ViewZeugnisart instance;
		ViewTaetigkeitsbeschreibung viewTaetigkeitsbeschreibung;
		PickerViewController pickerViewControllerArt;
		PickerViewController pickerViewControllerGrund;
		string selektionZArt;
		string selektionZGrund;
		string globname;
		string globteil;

		/// <summary>
		/// Initializes a new instance of the <see cref="ZgenMobil.ViewZeugnisart"/> class.
		/// </summary>
		public ViewZeugnisart () : base ("ViewZeugnisart", null)
		{
			this.Title = "Zeugnisart wählen";
			this.NavigationItem.SetRightBarButtonItem(
				new UIBarButtonItem("Logout" , UIBarButtonItemStyle.Plain, (sender, args) =>
			                    {
					ViewMitarbeiterselektion.Instance.Logout();
			}), true);
		}

		/// <summary>
		/// Gets or sets the globname.
		/// </summary>
		/// <value>The globname.</value>
		public string Globname {
			get {
				return globname;
			}
			set {
				globname = value;
			}
		}

		/// <summary>
		/// Gets or sets the instance.
		/// </summary>
		/// <value>The instance.</value>
		public static ViewZeugnisart Instance {
			get {
				if(instance == null)
				{
					instance = new ViewZeugnisart();
				}
				return instance;
			}
			set {
				instance = value;
			}
		}

		/// <summary>
		/// Gets or sets the globteil.
		/// </summary>
		/// <value>The globteil.</value>
		public string Globteil {
			get {
				return globteil;
			}
			set {
				globteil = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the selektion Z grund.
		/// </summary>
		/// <value>The selektion Z grund.</value>
		public string SelektionZGrund {
			get {
				return selektionZGrund;
			}
			set {
				selektionZGrund = value;
			}
		}

		/// <summary>
		/// Gets or sets the selektion Z art.
		/// </summary>
		/// <value>The selektion Z art.</value>
		public string SelektionZArt {
			get {
				return selektionZArt;
			}
			set {
				selektionZArt = value;
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
		}

		/// <summary>
		/// Views the did load.
		/// </summary>
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
		}

		/// <summary>
		/// Sets the labels.
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="pernr">Pernr.</param>
		/// <param name="teilbereich">Teilbereich.</param>
		/// <param name="org">Org.</param>
		/// <param name="img">Image.</param>
		public void setLabels(string name, string pernr, string teilbereich, string org, NSData img)
		{
			labelName.Text = name;
			globname = name;
			globteil = teilbereich;
			labelPernr.Text = pernr;
			labelTeilbereich.Text = teilbereich;
			labelOrgEinheit.Text = org;
			imgView.Image  = UIImage.LoadFromData(img);
		}

		/// <summary>
		/// Actions the button Z artwaehlen.
		/// </summary>
		/// <param name="sender">Sender.</param>
		partial void actionBtnZArtwaehlen (NSObject sender)
		{
			toolbarZGrund.Hidden = true;
			pickerZGrund.Hidden = true;

			string[] items = new string[3]{"Endzeugnis Gewerblich" , "Endzeugnis Tarifangestellte" , "Endzeugnis AT-Angestellte"};
			pickerViewControllerArt = new PickerViewController(items);
			pickerZArt.Model = pickerViewControllerArt;
			pickerZArt.Hidden = false;
			toolbarZArt.Hidden = false;

			pickerViewControllerArt.selektionSelected += (object se, EventArgs ea) => 
			{
				selektionZArt = pickerViewControllerArt.SelectedSelektion;
			};
		}

		/// <summary>
		/// Actions the button Z grundwaehlen.
		/// </summary>
		/// <param name="sender">Sender.</param>
		partial void actionBtnZGrundwaehlen (NSObject sender)
		{
			toolbarZArt.Hidden = true;
			pickerZArt.Hidden = true;
			string[] items = new string[4]{"Arbeitnehmerseitige Kündigung (ohne Begründung)" , "Beendigung durch Aufhebungsvertrag oder Vergleich" , "Betriebsbedingte arbeitgeberseitige Kündigung" , "Arbeitgeberseitige Kündigung (Sonstiges)"};
			pickerViewControllerGrund = new PickerViewController(items);
			pickerZGrund.Model = pickerViewControllerGrund;
			pickerZGrund.Hidden = false;
			toolbarZGrund.Hidden = false;
						
			pickerViewControllerGrund.selektionSelected += (object se, EventArgs ea) => 
			{
				selektionZGrund = pickerViewControllerGrund.SelectedSelektion;
			};
		}

		/// <summary>
		/// Actions the picker Z art.
		/// </summary>
		/// <param name="sender">Sender.</param>
		partial void actionPickerZArt (NSObject sender)
		{
			pickerZArt.Hidden = true;
			toolbarZArt.Hidden = true;
			labelZArt.Text = selektionZArt;
		}

		/// <summary>
		/// Actions the picker done grund.
		/// </summary>
		/// <param name="sender">Sender.</param>
		partial void actionPickerDoneGrund (NSObject sender)
		{
			pickerZGrund.Hidden = true;
			toolbarZGrund.Hidden = true;
			labelZGrund.Text = selektionZGrund;
		}

		/// <summary>
		/// Actions the button weiter.
		/// </summary>
		/// <param name="sender">Sender.</param>
		partial void actionBtnWeiter (NSObject sender)
		{
			if(labelZArt.Text.Length < 1)
			{
				new UIAlertView("Fehler", "Bitte wählen Sie eine Zeugnisart.",null,"OK",null).Show();
			}
			else if(labelZGrund.Text.Length < 1)
			{
				new UIAlertView("Fehler", "Bitte wählen Sie einen Zeugnisgrund.",null,"OK",null).Show();
			}
			else{
				if(viewTaetigkeitsbeschreibung == null)
				{
					viewTaetigkeitsbeschreibung = new ViewTaetigkeitsbeschreibung();
				}
				this.NavigationController.PushViewController(viewTaetigkeitsbeschreibung, true);
			}
		}
	}
}

