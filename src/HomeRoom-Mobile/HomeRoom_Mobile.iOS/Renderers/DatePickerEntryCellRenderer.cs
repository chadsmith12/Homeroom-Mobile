using System;
using Foundation;
using HomeRoom_Mobile.Controls;
using HomeRoom_Mobile.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(DatePickerEntryCell), typeof(DatePickerEntryCellRenderer))]
namespace HomeRoom_Mobile.iOS.Renderers
{
    /// <summary>
    /// Provides a custom renderer for a DatePickerEntryCell
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.iOS.EntryCellRenderer" />
    public class DatePickerEntryCellRenderer : EntryCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            var cell = base.GetCell(item, reusableCell, tv);
            var datePickerCell = (DatePickerEntryCell) item;
            UITextField textField = null;

            if (cell != null)
                textField = (UITextField) cell.ContentView.Subviews[0];

            // the default deatepicker display attributes
            var mode = UIDatePickerMode.Date;
            var displayFormat = "d";
            var date = NSDate.Now;
            var isLocalTime = false;

            // update the datepicker based on the cells properties
            if (datePickerCell != null)
            {
                if (datePickerCell.Date.Kind == DateTimeKind.Unspecified)
                {
                    var local = new DateTime(datePickerCell.Date.Ticks, DateTimeKind.Local);
                    date = (NSDate) local;
                }
                else
                {
                    date = (NSDate) datePickerCell.Date;
                }

                isLocalTime = datePickerCell.Date.Kind == DateTimeKind.Local || datePickerCell.Date.Kind == DateTimeKind.Unspecified;
            }

            // now create the iOS datepicker
            var datePicker = new UIDatePicker
            {
                Mode = mode,
                BackgroundColor = UIColor.White,
                Date = date,
                TimeZone = isLocalTime ? NSTimeZone.LocalTimeZone : new NSTimeZone("UTC")
            };

            // create a toolbar with a done button
            var done = new UIBarButtonItem("Done", UIBarButtonItemStyle.Done, (s, e) =>
            {
                var pickedDate = (DateTime) datePicker.Date;

                if (isLocalTime)
                    pickedDate = pickedDate.ToLocalTime();

                // update the date property on the cell
                if(datePickerCell != null)
                    datePickerCell.Date = pickedDate;

                // update the textfield within the cell
                if (textField != null)
                {
                    textField.Text = pickedDate.ToString(displayFormat);
                    textField.ResignFirstResponder();
                }
            });

            var toolBar = new UIToolbar
            {
                BarStyle = UIBarStyle.Default,
                Translucent = false
            };
            toolBar.SizeToFit();
            toolBar.SetItems(new [] {done}, true);

            // set the input view, toolbar, and the initial value for the cell's textfield
            if (textField != null)
            {
                textField.InputView = datePicker;
                textField.InputAccessoryView = toolBar;

                if (datePickerCell != null)
                    textField.Text = datePickerCell.Date.ToString(displayFormat);
            }

            return cell;
        }
    }
}
