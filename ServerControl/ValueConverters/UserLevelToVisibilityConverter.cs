using RitoManager.UserManagement;
using System;
using System.Globalization;
using System.Windows;

namespace ServerControl
{
    /// <summary>
    /// A converter that takes in a <see cref="UserLevel"/> and returns a <see cref="Visibility"/>
    /// </summary>
    public class UserLevelToVisibilityConverter : BaseValueConverter<UserLevelToVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Get the value as a baseuser
            var u = value as BaseUser;

            // if no user is logged in...
            if (u == null)
                // Set the visibility as collapsed
                return Visibility.Collapsed;

            // Get the userlevel of the logged in user
            UserLevel ul = u.Level;

            // If the accesslevel of the user is lower or equal to manager...
            if (ul <= UserLevel.Manager)
                // Set the visibility as collapsed
                return Visibility.Collapsed;
            // Else...
            else
                // Set the visibility to visibile
                return Visibility.Visible;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
