// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace ZgenMobil
{
	[Register ("ViewEntwurf")]
	partial class ViewEntwurf
	{
		[Outlet]
		MonoTouch.UIKit.UITextView textView { get; set; }

		[Action ("actionBtnSenden:")]
		partial void actionBtnSenden (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (textView != null) {
				textView.Dispose ();
				textView = null;
			}
		}
	}
}
