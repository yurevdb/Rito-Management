using System;
using System.Globalization;
using System.Windows;

namespace ServerControl
{
    class VisibilityToIntConverter : BaseValueConverter<VisibilityToIntConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            MainWindow window = ((MainWindow)Application.Current.MainWindow);
            if(parameter == null)
            {
                if (((Visibility)value == Visibility.Collapsed) || ((Visibility)value == Visibility.Hidden))
                    return window.grd.ColumnDefinitions.Count;
                else
                    return 1;
            }
            else
            {
                if (((Visibility)value == Visibility.Collapsed) || ((Visibility)value == Visibility.Hidden))
                    return 0;
                else
                    return window.grd.ColumnDefinitions.Count - 1;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
