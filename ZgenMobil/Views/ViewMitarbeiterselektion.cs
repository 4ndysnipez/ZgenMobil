using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Text;

namespace ZgenMobil
{
	public partial class ViewMitarbeiterselektion : UIViewController
	{
		
		ActionSheetDatePicker datePicker;
		ViewZeugnisart viewZeugnisart;
		TableViewSource tableViewSource;
		string selektion;
		PickerViewController model;



		
		public ViewMitarbeiterselektion () : base ("ViewMitarbeiterselektion", null)
		{
			this.Title = "Mitarbeiterselektion";
			this.NavigationItem.SetHidesBackButton(true, true);
		}

		public string Selektion {
			get {
				return selektion;
			}
			set {
				selektion = value;
			}
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

			//StringBuilder datum = new StringBuilder(10);
			//datum = System.DateTime.Now;
			labelDate.Text = "";

			string datum = System.DateTime.Now.ToString();

			for(int i = 0; i<10; i++)
			{
				labelDate.Text += datum[i];
			}





			//labelDate.Text = datum.ToString();



			toolbarSelektion.Hidden = true;

			string[] items = new string[3]{"Alle Mitarbeiter" , "Direkt unterstellte" , "Alle Org-Einheiten"};

			model = new PickerViewController(items);

			tableViewSource = new TableViewSource(this , "Franz", "Dieter" , "Otmar");
			tableView.Source = tableViewSource;

			labelSelektion.Text = items[0];
						
			// Perform any additional setup after loading the view, typically from a nib.
		}


		partial void actionBtnDate (NSObject sender)
		{
			if(pickerView.Hidden == false)
			{
				pickerView.Hidden = true;
				toolbarSelektion.Hidden = true;
			}

			datumPicker.Hidden = false;
			toolbarDate.Hidden = false;

		/*
			//Console.WriteLine(this.View.Frame.ToString());
			
			datePicker = new ActionSheetDatePicker(this.View);
			
			datePicker.Title = "Datum wählen...";
			datePicker.Picker.Mode = UIDatePickerMode.Date;
			
			datePicker.Picker.ValueChanged += (s, e) => {
				
				labelDate.Text = (s as UIDatePicker).Date.ToString();
			};
			
			datePicker.Show();
		*/
		}

		partial void actionBtnSelektion (NSObject sender)
		{
			if(datumPicker.Hidden == false)
			{
				datumPicker.Hidden = true;
				toolbarDate.Hidden = true;

			}

			pickerView.Model = model;
			tableView.Hidden = true;
			pickerView.Hidden = false;
			toolbarSelektion.Hidden = false;

			model.selektionSelected += (object se, EventArgs ea) => 
			{
				selektion = model.SelectedSelektion;
			};

		}

		partial void actionSelektionDone (NSObject sender)
		{
			labelSelektion.Text = selektion;
			pickerView.Hidden = true;
			toolbarSelektion.Hidden = true;
			tableView.Hidden = false;
		}

		partial void actionBtnDateDone (NSObject sender)
		{

			StringBuilder sb = new StringBuilder(datumPicker.Date.ToString());
			sb.Replace("-",".");


			string yy = sb[0].ToString() + sb[1].ToString() + sb[2].ToString() + sb[3].ToString();
			string mm = sb[5].ToString() + sb[6].ToString();
			string dd = sb[8].ToString() + sb[9].ToString();
			string pk = ".";


		/*

			for(int i=0; i<4;i++)
			{
				yy +=(sb[i]);
			}

			for(int i=5; i<7;i++)
			{
				mm +=(sb[i]);
			}

			for(int i=8; i<10;i++)
			{
				dd +=(sb[i]);
			}
		*/
			Console.WriteLine( "hier " +  datumPicker.Date.ToString());


			labelDate.Text = dd+pk+mm+pk+yy;//datumPicker.Date.ToString();



			toolbarDate.Hidden = true;
			datumPicker.Hidden = true;
		}

		public void mitarbeiterSelected(string name)
		{
			if(viewZeugnisart == null){

				viewZeugnisart =  new ViewZeugnisart();
			}

			this.NavigationController.PushViewController(viewZeugnisart, true);
			viewZeugnisart.setLabelName(name);
		}
		
	}
}

