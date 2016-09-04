using System;
using Xamarin.Forms;

namespace HomeRoom_Mobile.Controls
{
    /// <summary>
    /// Custom DatePicker control that is used inside a cell
    /// </summary>
    /// <seealso cref="Xamarin.Forms.EntryCell" />
    public class DatePickerEntryCell : EntryCell
    {
        /// <summary>
        /// The date BindableProperty so this custom control can still be data bound, like any other control
        /// </summary>
        public static readonly BindableProperty DateProperty = BindableProperty.Create<DatePickerEntryCell, DateTime>(p => p.Date, DateTime.Now, propertyChanged: DatePropertyChanged);

        /// <summary>
        /// Fires when the property has changed
        /// When completed fires the Completed event
        /// </summary>
        /// <param name="bindable">The bindable.</param>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        private static void DatePropertyChanged(BindableObject bindable, DateTime oldValue, DateTime newValue)
        {
            var property = (DatePickerEntryCell) bindable;

            property.Completed?.Invoke(bindable, new EventArgs());
        }

        /// <summary>
        /// Event fired when the user presses 'Done' on the EntryCell's keyboard
        /// </summary>
        public new event EventHandler Completed;

        /// <summary>
        /// Gets or sets the date selected from the user.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public DateTime Date
        {
            get { return (DateTime) GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
        }
    }
}
