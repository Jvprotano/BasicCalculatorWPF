using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;


namespace CalculadoraGa1.Converter
{
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush cor1 = new SolidColorBrush();
            SolidColorBrush cor2 = new SolidColorBrush();
            switch (parameter)
            {
                case "TextBox":
                    cor1 = Brushes.Purple;
                    cor2 = Brushes.Transparent;
                    break;

                case "Igual":
                    cor1 = Brushes.Green;
                    cor2 = Brushes.White;
                    break;
            }
            if (value != "")
            {
                return cor1;
            }
            else
            {
                return cor2;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}