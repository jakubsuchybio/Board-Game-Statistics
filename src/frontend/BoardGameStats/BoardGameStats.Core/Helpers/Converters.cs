using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace BoardGameStats.Core.Helpers
{
    public class FromBoolToListViewSelectionMode : IValueConverter
    {
        // This converts the DateTime object to the string to display.
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool inputValue = (bool) value;
            return inputValue ? ListViewSelectionMode.Multiple : ListViewSelectionMode.None;
        }

        // No need to implement converting back on a one-way binding
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
