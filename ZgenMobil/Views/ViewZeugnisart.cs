
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace ZgenMobil
{
	public partial class ViewZeugnisart : UIViewController
	{
		public ViewZeugnisart () : base ("ViewZeugnisart", null)
		{
			this.Title = "Zeugnisart wählen";
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

		public void setLabelName(string name)
		{
			labelName.Text = name;
			imgView.Image  = UIImage.FromFile("img/scdsoftLogo.png");
		}

	}
}

