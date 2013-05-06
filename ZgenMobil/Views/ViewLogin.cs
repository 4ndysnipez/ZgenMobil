using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace ZgenMobil
{
	/// <summary>
	/// View login.
	/// </summary>
	public partial class ViewLogin : UIViewController
	{

		/// <summary>
		/// Deklarationen
		/// </summary>
		ViewMitarbeiterselektion viewMitarbeiterselektion;
		HttpRestController httpRestController;

		/// <summary>
		/// Initializes a new instance of the <see cref="ZgenMobil.ViewLogin"/> class.
		/// </summary>
		public ViewLogin () : base ("ViewLogin", null)
		{
			this.Title = "scdsoft Zeugnisgenerator";
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
			
			imgViewLogo.Image = UIImage.FromFile("img/scdsoftLogo.png");
		}

		/// <summary>
		/// Base64s the encode.
		/// </summary>
		/// <returns>The encode.</returns>
		/// <param name="http_user">Http_user.</param>
		/// <param name="http_pw">Http_pw.</param>
		public string base64Encode(string http_user, string http_pw){

			//zum testen
			//http_user = "p20000000";
			//http_pw = "scdsoft1";
			
			string user_pw = http_user + ":" + http_pw;
			
			System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
			byte[] bytes = encoding.GetBytes(user_pw);
			string base64 = System.Convert.ToBase64String(bytes);
			
			return "Basic " + base64;
		}

		/// <summary>
		/// Actions the button anmelden.
		/// </summary>
		/// <param name="sender">Sender.</param>
		partial void actionBtnAnmelden (NSObject sender)		
		{
			View.Add(LoadingOverlay.Instance);
			Console.WriteLine("overlay added");

			string logindata = base64Encode(txtFldUser.Text, txtFldPasswort.Text);//
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

