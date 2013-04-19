
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace ZgenMobil
{
	public partial class ViewLogin : UIViewController
	{
		ViewMitarbeiterselektion viewMitarbeiterselektion;

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

		partial void actionBtnAnmelden (NSObject sender)		
		{
			if(viewMitarbeiterselektion == null){
				viewMitarbeiterselektion =  new ViewMitarbeiterselektion();
			}

			this.NavigationController.PushViewController(viewMitarbeiterselektion, true);
		}

	}
}

