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
                // Inserta un salto de línea cada 15 asientos
                const int seatsPerLine = 15;
                var result = new System.Text.StringBuilder();

                for (int i = 0; i < seats.Count; i++)
                {
                    result.Append(seats[i]);

                    // Inserta un salto de línea después de cada 15 asientos
                    if ((i + 1) % seatsPerLine == 0 && i != seats.Count - 1)
                    {
                        result.AppendLine();
                    }
                    else if (i != seats.Count - 1)
                    {
                        result.Append(", ");
                    }
                }

                return result.ToString();
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}