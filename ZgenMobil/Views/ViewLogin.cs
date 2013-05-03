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

			View.Add(LoadingOverlay.Instance);
			Console.WriteLine("overlay added");


			//TODO: statische login wegmachen
			//string login = base64Encode(txtFldUser.Text, txtFldPasswort.Text);
			string logindata = base64Encode("p20000000", "scdsoft1");
			Console.WriteLine("logindata: " + logindata);

			if(httpRestController == null){
				Console.WriteLine("create httpcctrl");
				httpRestController = HttpRestController.Instance;
			}

			string respRest = httpRestController.buildRestUrl("SCD/ZGEN_MI_ORG_VIEWS/ORGVIEWS", logindata);
			httpRestController.buildRestUrl(respRest, logindata);

			if(respRest == "fehler")
			{
				LoadingOverlay.Instance.Hide();
				new UIAlertView("Login Error", "User unauthorised",null,"OK",null).Show();

			}
			
			else if(respRest != "fehler")
			{
				if(viewMitarbeiterselektion == null){
					Console.WriteLine("mitarb ist null");
					viewMitarbeiterselektion =  ViewMitarbeiterselektion.Instance;
				}
				else if(viewMitarbeiterselektion != null)
				{
					Console.WriteLine("mitarb ist schon da");
				}

				LoadingOverlay.Instance.Hide();
				this.NavigationController.PushViewController(viewMitarbeiterselektion, true);
				viewMitarbeiterselektion.buildTable(respRest);
			}
			
		}
		
	}
}

