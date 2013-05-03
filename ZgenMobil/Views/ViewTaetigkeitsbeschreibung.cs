
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace ZgenMobil
{
	public partial class ViewTaetigkeitsbeschreibung : UIViewController
	{

		ViewBeurteilung viewBeurteilung;

		public ViewTaetigkeitsbeschreibung () : base ("ViewTaetigkeitsbeschreibung", null)
		{
			this.Title = "Tätigkeitsbeschreibung";
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

		partial void actionBtnWeiter (NSObject sender)
		{
			if(viewBeurteilung == null)
			{
				viewBeurteilung = new ViewBeurteilung();
			}

			this.NavigationController.PushViewController(viewBeurteilung, true);
		}

	}
}

