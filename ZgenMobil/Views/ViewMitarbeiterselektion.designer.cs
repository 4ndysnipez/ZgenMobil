// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace ZgenMobil
{
	[Register ("ViewMitarbeiterselektion")]
	partial class ViewMitarbeiterselektion
	{
		[Outlet]
		MonoTouch.UIKit.UILabel labelDate { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIPickerView pickerView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel labelSelektion { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIToolbar toolbarSelektion { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView tableView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIToolbar toolbarDate { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIDatePicker datumPicker { get; set; }

		[Action ("actionBtnDate:")]
		partial void actionBtnDate (MonoTouch.Foundation.NSObject sender);

		[Action ("actionBtnSelektion:")]
		partial void actionBtnSelektion (MonoTouch.Foundation.NSObject sender);

		[Action ("actionSelektionDone:")]
		partial void actionSelektionDone (MonoTouch.Foundation.NSObject sender);

		[Action ("actionBtnDateDone:")]
		partial void actionBtnDateDone (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (labelDate != null) {
				labelDate.Dispose ();
				labelDate = null;
			}

			if (pickerView != null) {
				pickerView.Dispose ();
				pickerView = null;
			}

			if (labelSelektion != null) {
				labelSelektion.Dispose ();
				labelSelektion = null;
			}

			if (toolbarSelektion != null) {
				toolbarSelektion.Dispose ();
				toolbarSelektion = null;
			}

			if (tableView != null) {
				tableView.Dispose ();
				tableView = null;
			}

			if (toolbarDate != null) {
				toolbarDate.Dispose ();
				toolbarDate = null;
			}

			if (datumPicker != null) {
				datumPicker.Dispose ();
				datumPicker = null;
			}
		}
	}
}
