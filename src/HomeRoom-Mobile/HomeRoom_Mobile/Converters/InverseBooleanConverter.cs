using System;
using System.Globalization;
using Xamarin.Forms;

namespace HomeRoom_Mobile.Converters
{
    /// <summary>
    /// Converter used to return the inverse of a boolean.
    /// This will convert True to False, and visa-versa
    /// </summary>
    /// <seealso cref="Xamarin.Forms.IValueConverter" />
    public class InverseBooleanConverter : IValueConverter
    {
        /// <summary>
        /// Use this method to convert <paramref name="value" /> to its inverse boolean value.
        /// </summary>
        /// <param name="value">Value we are attempting to convert</param>
        /// <param name="targetType">type being converted too</param>
        /// <param name="parameter">parameter passed in</param>
        /// <param name="culture">the culture info</param>
        /// <returns>
        /// The inverse of a given boolean value
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(!(value is bool))
            {
                return value;
            }

            return !((bool)value);
        }

        /// <summary>
        /// Use this method to convert <paramref name="value" /> to its inverse boolean value.
        /// </summary>
        /// <param name="value">Value we are attempting to convert</param>
        /// <param name="targetType">type being converted too</param>
        /// <param name="parameter">parameter passed in</param>
        /// <param name="culture">the culture info</param>
        /// <returns>
        /// The inverse of a given boolean value
        /// </returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool))
                return value;

            return !((bool) value);
        }
    }
}
