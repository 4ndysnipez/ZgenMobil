
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace ZgenMobil
{
	public partial class ViewZeugnisart : UIViewController
	{
		PickerViewController pickerViewController;
		string selektionZArt;


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

			string[] items = new string[5]{"Eins" , "Zwei" , "Drei" , "Vier" , "Fünf"};

			pickerViewController = new PickerViewController(items);

			pickerZArt.Model = pickerViewController;

			pickerZArt.Hidden = false;
			toolbarZArt.Hidden = false;




			pickerViewController.selektionSelected += (object se, EventArgs ea) => 
			{
				selektionZArt = pickerViewController.SelectedSelektion;
			};



		}

		partial void actionPickerZArt (NSObject sender)
		{
			pickerZArt.Hidden = true;
			toolbarZArt.Hidden = true;
			zArtwaehlen.TitleLabel.Text = selektionZArt;
			//zArtwaehlen.TitleLabel.TextAlignment = UIControlContentHorizontalAlignment.Center;
			zArtwaehlen.TitleLabel.TextAlignment = UITextAlignment.Center;
		}





	}
}

