using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace ZgenMobil
{
	public partial class ViewMitarbeiterselektion : UIViewController
	{
		
		ActionSheetDatePicker datePicker;
		
		
		public ViewMitarbeiterselektion () : base ("ViewMitarbeiterselektion", null)
		{
			this.Title = "Mitarbeiterselektion";
			this.NavigationItem.SetHidesBackButton(true, true);
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

			labelDate.Text = System.DateTime.Now.ToString();
			labelSelektion.Text = "";
			toolbarSelektion.Hidden = true;

						
			// Perform any additional setup after loading the view, typically from a nib.
		}


		partial void actionBtnDate (NSObject sender)
		{
			
			//Console.WriteLine(this.View.Frame.ToString());
			
			datePicker = new ActionSheetDatePicker(this.View);
			
			datePicker.Title = "Datum wählen...";
			datePicker.Picker.Mode = UIDatePickerMode.Date;
			
			datePicker.Picker.ValueChanged += (s, e) => {
				
				labelDate.Text = (s as UIDatePicker).Date.ToString();
			};
			
			datePicker.Show();
		}

		partial void actionBtnSelektion (NSObject sender)
		{
			PickerViewController model = new PickerViewController("Alle Mitarbeiter" , "Direkt unterstellte" , "Alle Org-Einheiten");
						
			pickerView.Model = model;
			pickerView.Hidden = false;
			toolbarSelektion.Hidden = false;

			model.fruitSelected += (object se, EventArgs ea) => 
			{
				labelSelektion.Text = model.SelectedFruit;
				//pickerView.Hidden = true;
			};

		}

		partial void actionSelektionDone (NSObject sender)
		{
			pickerView.Hidden = true;
			toolbarSelektion.Hidden = true;
		}
		
	}
}

