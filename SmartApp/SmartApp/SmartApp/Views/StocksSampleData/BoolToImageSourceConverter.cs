using System;
using System.Globalization;
using Xamarin.Forms;

namespace SmartApp.Views
{
    public class BoolToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ImageSource.FromResource(string.Format("SmartApp.Views.StocksSampleData.{0}.png", (bool)value ? "up" : "down"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
