using System;
using System.Globalization;
using System.Windows;

namespace ServerControl
{
    class BooleanToRowSpanConverter : BaseValueConverter<BooleanToRowSpanConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            MainWindow window = ((MainWindow)Application.Current.MainWindow);
            if((bool)value == false)
                return window.grd.RowDefinitions.Count;
            else
                return 1;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
