using System;
using System.Globalization;
using System.Windows.Data;

namespace TicTacGame.WindowsApp.Converters
{
    public class Array2DToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var array = value as string[,];
            if (array != null && parameter is string indices)
            {
                var splitIndices = indices.Split(',');
                if (splitIndices.Length == 2 &&
                    int.TryParse(splitIndices[0], out int row) &&
                    int.TryParse(splitIndices[1], out int column))
                {
                    return array[row, column];
                }
            }
            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}