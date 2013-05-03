
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace ZgenMobil
{
	public partial class ViewEntwurf : UIViewController
	{

		public ViewEntwurf () : base ("ViewEntwurf", null)
		{
			this.Title = "Zeugnisentwurf";
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

		public void buildTextView(string bereitschaft, string befaehigung , string wissen, string weise, string erfolg, string zusammen)
		{
			textView.Text = "";
			string nz = "\n\n";

			textView.Text += bereitschaft + nz;
			textView.Text += wissen + nz;
			textView.Text += weise + nz;
			textView.Text += erfolg + nz;
			textView.Text += zusammen+ nz;
		}
	}
}

