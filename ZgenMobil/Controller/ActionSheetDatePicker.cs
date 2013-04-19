using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace ZgenMobil {
	public class ActionSheetDatePicker
	{
		#region -= declarations =-
		
		UIActionSheet _actionSheet;
		UIBarButtonItem _doneButton;
		UILabel titleLabel = new UILabel ();
		
		UIView _owner;

		UIToolbar _toolbar;
		
		const int CHROMEWIDTHLEFT = 9;
		const int CHROMEWIDTHRIGHT = 8;
		
		const int MARGIN = 1;
		
		#endregion
		
		#region -= properties =-
		
		/// <summary>
		/// Set any datepicker properties here
		/// </summary>
		public UIDatePicker Picker
		{
			get { return picker; }
			set { picker = value; }
		}
		UIDatePicker picker = new UIDatePicker(RectangleF.Empty);
		
		/// <summary>
		/// The title that shows up for the date picker
		/// </summary>
		public string Title
		{
			get { return titleLabel.Text; }
			set { titleLabel.Text = value; }
		}
		
		#endregion
		
		#region -= constructor =-
		
		

		
		/// <summary>
		/// 
		/// </summary>
		public ActionSheetDatePicker (UIView owner)
		{
			// save our uiview owner
			this._owner = owner;
			
			// configure the title label
			titleLabel.BackgroundColor = UIColor.Clear;
			titleLabel.TextColor = UIColor.LightTextColor;
			titleLabel.Font = UIFont.BoldSystemFontOfSize (18);
			
			// create + configure the action sheet
			_actionSheet = new UIActionSheet () { Style = UIActionSheetStyle.BlackTranslucent };
			_actionSheet.Clicked += (s, e) => { Console.WriteLine ("Clicked on item {0}", e.ButtonIndex); };
			
			// add our controls to the action sheet
			_actionSheet.AddSubview (picker);
			_actionSheet.AddSubview (titleLabel);
						
			// Add the toolbar
			_toolbar = new UIToolbar(new RectangleF(0, 0, _actionSheet.Frame.Width, 10));
			_toolbar.BarStyle = UIBarStyle.Black;
			_toolbar.Translucent = true;
			
			// Add the done button
			_doneButton = new UIBarButtonItem(UIBarButtonSystemItem.Done, null, null);
			_doneButton.Clicked += (object sender, EventArgs e) => {
				_actionSheet.DismissWithClickedButtonIndex (0, true); 

			};
			
			_toolbar.Items = new UIBarButtonItem[] {
				new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace, null, null),
				_doneButton
			};
			
			_toolbar.SizeToFit();
			
			_actionSheet.Add (_toolbar);
		}
		
		#endregion
		
		#region -= public methods =-
		
		/// <summary>
		/// Shows the action sheet picker from the view that was set as the owner.
		/// </summary>
		public void Show ()
		{
			// declare vars
			float titleBarHeight = 40;
			SizeF actionSheetSize = new SizeF (_owner.Frame.Width, picker.Frame.Height + titleBarHeight);
			RectangleF actionSheetFrame = new RectangleF (0, (UIScreen.MainScreen.ApplicationFrame.Height - actionSheetSize.Height), actionSheetSize.Width, actionSheetSize.Height);
			
			// show the action sheet and add the controls to it

			_actionSheet.ShowInView (_owner);

			
			// resize the action sheet to fit our other stuff
			_actionSheet.Frame = actionSheetFrame;
			
			// move our picker to be at the bottom of the actionsheet (view coords are relative to the action sheet)
			picker.Frame = new RectangleF (picker.Frame.X, titleBarHeight, picker.Frame.Width, picker.Frame.Height);
			
			// move our label to the top of the action sheet
			titleLabel.Frame = new RectangleF (10, 4, _owner.Frame.Width - 100, 35);


			var popover = _actionSheet.Superview.Superview;
		
			var x = _actionSheet.Frame.X + MARGIN;
			var y = (UIScreen.MainScreen.ApplicationFrame.Height - _actionSheet.Frame.Height) / 2;
			var width = _actionSheet.Frame.Width - (MARGIN * 2);
			var height = _actionSheet.Frame.Height;
				
			popover.Frame = new RectangleF (x, y, width, height);
			_actionSheet.Frame = new RectangleF (x, y, width - (CHROMEWIDTHLEFT + CHROMEWIDTHRIGHT), height - (CHROMEWIDTHLEFT + CHROMEWIDTHRIGHT));
				
			picker.Frame = new RectangleF (picker.Frame.X, picker.Frame.Y, _actionSheet.Frame.Width, picker.Frame.Height);
				
			_toolbar.SizeToFit();



		}
		
		/// <summary>
		/// Dismisses the action sheet date picker
		/// </summary>
		public void Hide (bool animated)
		{
			_actionSheet.DismissWithClickedButtonIndex (0, animated);
		}
		
		#endregion   
	}
}

