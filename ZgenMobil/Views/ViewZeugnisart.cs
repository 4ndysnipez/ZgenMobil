
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace ZgenMobil
{
	public partial class ViewZeugnisart : UIViewController
	{

		private static ViewZeugnisart instance;
		
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

		ViewTaetigkeitsbeschreibung viewTaetigkeitsbeschreibung;
		PickerViewController pickerViewControllerArt;
		PickerViewController pickerViewControllerGrund;

		string selektionZArt;
		string selektionZGrund;
		string globname;
		string globteil;



		public ViewZeugnisart () : base ("ViewZeugnisart", null)
		{
			this.Title = "Zeugnisart wählen";
		}

		
		public string Globname {
			get {
				return globname;
			}
			set {
				globname = value;
			}
		}
		
		
		
		
		public string Globteil {
			get {
				return globteil;
			}
			set {
				globteil = value;
			}
		}
		
		
		public string SelektionZGrund {
			get {
				return selektionZGrund;
			}
			set {
				selektionZGrund = value;
			}
		}
		
		public string SelektionZArt {
			get {
				return selektionZArt;
			}
			set {
				selektionZArt = value;
			}
		}	


		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Perform any additional setup after loading the view, typically from a nib.
		}

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


		partial void actionPickerZArt (NSObject sender)
		{
			pickerZArt.Hidden = true;
			toolbarZArt.Hidden = true;
			labelZArt.Text = selektionZArt;
			//zArtwaehlen.TitleLabel.Text = selektionZArt;
			//zArtwaehlen.TitleLabel.TextAlignment = UITextAlignment.Center;
		}


		partial void actionPickerDoneGrund (NSObject sender)
		{
			pickerZGrund.Hidden = true;
			toolbarZGrund.Hidden = true;
			labelZGrund.Text = selektionZGrund;
			//btnZGrundwaehlen.TitleLabel.Text = selektionZGrund;
			//btnZGrundwaehlen.TitleLabel.TextAlignment = UITextAlignment.Center;
		}

		partial void actionBtnWeiter (NSObject sender)
		{
			if(viewTaetigkeitsbeschreibung == null)
			{
				viewTaetigkeitsbeschreibung = new ViewTaetigkeitsbeschreibung();
			}

			this.NavigationController.PushViewController(viewTaetigkeitsbeschreibung, true);
		}
	}
}

