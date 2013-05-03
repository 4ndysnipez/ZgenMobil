
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace ZgenMobil
{
	public partial class ViewZeugnisart : UIViewController
	{
		ViewTaetigkeitsbeschreibung viewTaetigkeitsbeschreibung;
		PickerViewController pickerViewControllerArt;
		PickerViewController pickerViewControllerGrund;

		string selektionZArt;
		string selektionZGrund;

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


		public ViewZeugnisart () : base ("ViewZeugnisart", null)
		{
			this.Title = "Zeugnisart wählen";
//			this.NavigationItem.RightBarButtonItem = new UIBarButtonItem(
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
			labelPernr.Text = pernr;
			labelTeilbereich.Text = teilbereich;
			labelOrgEinheit.Text = org;
			imgView.Image  = UIImage.LoadFromData(img);
		}

		partial void actionBtnZArtwaehlen (NSObject sender)
		{

			toolbarZGrund.Hidden = true;
			pickerZGrund.Hidden = true;

			string[] items = new string[5]{"Eins" , "Zwei" , "Drei" , "Vier" , "Fünf"};

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

			string[] items = new string[5]{"sechs" , "sieben" , "acht" , "neun" , "zehn"};
			
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
			zArtwaehlen.TitleLabel.Text = selektionZArt;
			zArtwaehlen.TitleLabel.TextAlignment = UITextAlignment.Center;
		}


		partial void actionPickerDoneGrund (NSObject sender)
		{
			pickerZGrund.Hidden = true;
			toolbarZGrund.Hidden = true;
			btnZGrundwaehlen.TitleLabel.Text = selektionZGrund;
			btnZGrundwaehlen.TitleLabel.TextAlignment = UITextAlignment.Center;
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

