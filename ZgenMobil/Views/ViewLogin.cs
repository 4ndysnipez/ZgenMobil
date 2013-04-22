
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace ZgenMobil
{
	public partial class ViewLogin : UIViewController
	{
		
		ViewMitarbeiterselektion viewMitarbeiterselektion;
		HttpRestController httpRestController;
		
		public ViewLogin () : base ("ViewLogin", null)
		{
			this.Title = "scdsoft Zeugnisgenerator";
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
			
			imgViewLogo.Image = UIImage.FromFile("img/scdsoftLogo.png");
			
			// Perform any additional setup after loading the view, typically from a nib.
		}
		
		public string base64Encode(string http_user, string http_pw){
			
			//http_user = "p20000000";
			//http_pw = "scdsoft1";
			
			string user_pw = http_user + ":" + http_pw;
			
			System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
			byte[] bytes = encoding.GetBytes(user_pw);
			string base64 = System.Convert.ToBase64String(bytes);
			
			return "Basic " + base64;
			
		}
		
		partial void actionBtnAnmelden (NSObject sender)		
		{
			
			if(httpRestController == null){
				httpRestController =  new HttpRestController();
			}
			
			
			//string login = base64Encode(txtFldUser.Text, txtFldPasswort.Text);
			string login = base64Encode("p20000000", "scdsoft1");
			//string test = httpRestController.buildRestUrl("test", login);
			string test = httpRestController.buildRestUrl("test", login);
			
			
			if(test != "OK")
			{
				new UIAlertView("fehler", "nix gut",null,"OK",null).Show();
			}
			
			else if(test == "OK")
			{
				if(viewMitarbeiterselektion == null){
					Console.WriteLine("mitarb ist null");
					viewMitarbeiterselektion =  new ViewMitarbeiterselektion();
				}
				else if(viewMitarbeiterselektion != null)
				{
					Console.WriteLine("mitarb ist schon da");
				}
				this.NavigationController.PushViewController(viewMitarbeiterselektion, true);
			}
			
			
			
			
		}
		
	}
}

