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
		MonoTouch.UIKit.UILabel labelZArt { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel labelZGrund { get; set; }

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

		[Outlet]
		MonoTouch.UIKit.UIButton zArtwaehlen { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIPickerView pickerZArt { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIToolbar toolbarZArt { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIToolbar toolbarZGrund { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIPickerView pickerZGrund { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnZGrundwaehlen { get; set; }

		[Action ("actionBtnZArtwaehlen:")]
		partial void actionBtnZArtwaehlen (MonoTouch.Foundation.NSObject sender);

		[Action ("actionBtnZGrundwaehlen:")]
		partial void actionBtnZGrundwaehlen (MonoTouch.Foundation.NSObject sender);

		[Action ("actionPickerZArt:")]
		partial void actionPickerZArt (MonoTouch.Foundation.NSObject sender);

		[Action ("actionPickerDoneGrund:")]
		partial void actionPickerDoneGrund (MonoTouch.Foundation.NSObject sender);

		[Action ("actionBtnWeiter:")]
		partial void actionBtnWeiter (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (labelZArt != null) {
				labelZArt.Dispose ();
				labelZArt = null;
			}

			if (labelZGrund != null) {
				labelZGrund.Dispose ();
				labelZGrund = null;
			}

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

			if (zArtwaehlen != null) {
				zArtwaehlen.Dispose ();
				zArtwaehlen = null;
			}

			if (pickerZArt != null) {
				pickerZArt.Dispose ();
				pickerZArt = null;
			}

			if (toolbarZArt != null) {
				toolbarZArt.Dispose ();
				toolbarZArt = null;
			}

			if (toolbarZGrund != null) {
				toolbarZGrund.Dispose ();
				toolbarZGrund = null;
			}

			if (pickerZGrund != null) {
				pickerZGrund.Dispose ();
				pickerZGrund = null;
			}

			if (btnZGrundwaehlen != null) {
				btnZGrundwaehlen.Dispose ();
				btnZGrundwaehlen = null;
			}
		}
	}
}
