// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace ZgenMobil
{
	[Register ("ViewBeurteilung")]
	partial class ViewBeurteilung
	{
		[Outlet]
		MonoTouch.UIKit.UIScrollView propScrollView { get; set; }

		[Action ("actionBtnErstellen:")]
		partial void actionBtnErstellen (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (propScrollView != null) {
				propScrollView.Dispose ();
				propScrollView = null;
			}
		}
	}
}
