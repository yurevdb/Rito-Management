using RitoManager.Core;
using RitoManager.UserManagement;
using ServerControl.Core;
using System;
using System.Diagnostics;
using System.Globalization;

namespace ServerControl
{
    /// <summary>
    /// Convert the Application page to an actual view/page
    /// </summary>
    class PageValueConverter : BaseValueConverter<PageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Get the user that is currently logged in
            BaseUser user = IoC.Get<ApplicationViewModel>().LoggedInUser;
            
            // Create the variable to hold the userlevel of the logged in user
            UserLevel userlevel = UserLevel.User;

            // If there is a user logged in...
            if (user != null)
                // get the access level of the user
                userlevel = user.Level;

            //Find the appropriate page
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.Login:
                    IoC.Get<ApplicationViewModel>().ShowNavigationMenu = false;
                    return new LoginPage();
                case ApplicationPage.Plot:
                    return new PlotView();
                case ApplicationPage.UserManagement:
                    if (userlevel == UserLevel.Employee)
                        return new CreateUserPage();
                    else
                        return new UMPage();
                case ApplicationPage.CreateUser:
                    return new CreateUserPage();
                case ApplicationPage.UserInfo:
                    return new DisplayUsersPage();
                case ApplicationPage.Welcome:
                    IoC.Get<ApplicationViewModel>().ShowNavigationMenu = true;
                    return new WelcomePage();
                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
