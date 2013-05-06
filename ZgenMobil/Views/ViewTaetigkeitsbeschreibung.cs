using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace ZgenMobil
{
	/// <summary>
	/// View taetigkeitsbeschreibung.
	/// </summary>
	public partial class ViewTaetigkeitsbeschreibung : UIViewController
	{
		/// <summary>
		/// Deklarationen
		/// </summary>
		ViewBeurteilung viewBeurteilung;

		/// <summary>
		/// Initializes a new instance of the <see cref="ZgenMobil.ViewTaetigkeitsbeschreibung"/> class.
		/// </summary>
		public ViewTaetigkeitsbeschreibung () : base ("ViewTaetigkeitsbeschreibung", null)
		{
			this.Title = "Tätigkeitsbeschreibung";
			this.NavigationItem.SetRightBarButtonItem(
				new UIBarButtonItem("Logout" , UIBarButtonItemStyle.Plain, (sender, args) =>
			    {
					ViewMitarbeiterselektion.Instance.Logout();
			}), true);
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

			propScrollView.Frame = new RectangleF(0,0,768,879);
			propScrollView.ContentSize = new SizeF(768,880);
			this.View.AddSubview(propScrollView);
		}

		/// <summary>
		/// Actions the button weiter.
		/// </summary>
		/// <param name="sender">Sender.</param>
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

