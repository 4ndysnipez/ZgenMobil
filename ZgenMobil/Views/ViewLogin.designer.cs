// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace ZgenMobil
{
	[Register ("ViewLogin")]
	partial class ViewLogin
	{
		[Outlet]
		MonoTouch.UIKit.UITextField txtFldUser { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtFldPasswort { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView imgViewLogo { get; set; }

		[Action ("actionBtnAnmelden:")]
		partial void actionBtnAnmelden (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (txtFldUser != null) {
				txtFldUser.Dispose ();
				txtFldUser = null;
			}

			if (txtFldPasswort != null) {
				txtFldPasswort.Dispose ();
				txtFldPasswort = null;
			}

			if (imgViewLogo != null) {
				imgViewLogo.Dispose ();
				imgViewLogo = null;
			}
		}
	}
}
