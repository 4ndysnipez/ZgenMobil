
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace ZgenMobil
{
	public partial class ViewBeurteilung : UIViewController
	{

		ViewEntwurf viewEntwurf;

		public ViewBeurteilung () : base ("ViewBeurteilung", null)
		{
			this.Title = "Beurteilung";
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

			propScrollView.Frame = new RectangleF(0,0,768,879);
			
			propScrollView.ContentSize = new SizeF(768,880);
			
			this.View.AddSubview(propScrollView);

			// Perform any additional setup after loading the view, typically from a nib.
		}

		partial void actionBtnErstellen (NSObject sender)
		{
			if(viewEntwurf == null)
			{
				viewEntwurf = new ViewEntwurf();
			}
			this.NavigationController.PushViewController(viewEntwurf, true);
		}

	}
}

