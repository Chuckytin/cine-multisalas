using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace CineMultisalas.Helpers
{
    public class SeatsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is List<int> seats)
            {
                return string.Join(", ", seats);
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}