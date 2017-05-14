using System;
using System.Globalization;

namespace ServerControl
{
    class BooleanToOpacityValueConverter : BaseValueConverter<BooleanToOpacityValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
                return 0.2;
            else
                return 1;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
