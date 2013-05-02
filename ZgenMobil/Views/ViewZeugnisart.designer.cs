// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace ZgenMobil
{
	[Register ("ViewZeugnisart")]
	partial class ViewZeugnisart
	{
		[Outlet]
		MonoTouch.UIKit.UILabel labelName { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView imgView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel labelPernr { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel labelTeilbereich { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel labelOrgEinheit { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (labelName != null) {
				labelName.Dispose ();
				labelName = null;
			}

			if (imgView != null) {
				imgView.Dispose ();
				imgView = null;
			}

			if (labelPernr != null) {
				labelPernr.Dispose ();
				labelPernr = null;
			}

			if (labelTeilbereich != null) {
				labelTeilbereich.Dispose ();
				labelTeilbereich = null;
			}

			if (labelOrgEinheit != null) {
				labelOrgEinheit.Dispose ();
				labelOrgEinheit = null;
			}
		}
	}
}
