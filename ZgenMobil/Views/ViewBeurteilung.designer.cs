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

		[Outlet]
		MonoTouch.UIKit.UISegmentedControl segmentArbBereitschaft { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISegmentedControl segmentArbBefaehigung { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISegmentedControl segmentWissen { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISegmentedControl segmentArbWeise { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISegmentedControl segmentArbErfolg { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISegmentedControl segmentZusammenfassung { get; set; }

		[Action ("actionBtnErstellen:")]
		partial void actionBtnErstellen (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (propScrollView != null) {
				propScrollView.Dispose ();
				propScrollView = null;
			}

			if (segmentArbBereitschaft != null) {
				segmentArbBereitschaft.Dispose ();
				segmentArbBereitschaft = null;
			}

			if (segmentArbBefaehigung != null) {
				segmentArbBefaehigung.Dispose ();
				segmentArbBefaehigung = null;
			}

			if (segmentWissen != null) {
				segmentWissen.Dispose ();
				segmentWissen = null;
			}

			if (segmentArbWeise != null) {
				segmentArbWeise.Dispose ();
				segmentArbWeise = null;
			}

			if (segmentArbErfolg != null) {
				segmentArbErfolg.Dispose ();
				segmentArbErfolg = null;
			}

			if (segmentZusammenfassung != null) {
				segmentZusammenfassung.Dispose ();
				segmentZusammenfassung = null;
			}
		}
	}
}
