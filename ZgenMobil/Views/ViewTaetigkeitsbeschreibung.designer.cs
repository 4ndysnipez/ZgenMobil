// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace ZgenMobil
{
	[Register ("ViewTaetigkeitsbeschreibung")]
	partial class ViewTaetigkeitsbeschreibung
	{
		[Outlet]
		MonoTouch.UIKit.UIScrollView propScrollView { get; set; }

		[Action ("actionBtnWeiter:")]
		partial void actionBtnWeiter (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (propScrollView != null) {
				propScrollView.Dispose ();
				propScrollView = null;
			}
		}
	}
}
