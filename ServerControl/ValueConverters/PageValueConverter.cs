using RitoManager.Core;
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
            //Find the appropriate page
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.Login:
                    IoC.Get<ApplicationViewModel>().ShowNavigationMenu = false;
                    return new LoginPage();
                case ApplicationPage.Plot:
                    return new PlotView();
                case ApplicationPage.UserManagement:
                    return new UMPage();
                case ApplicationPage.CreateUser:
                    return new CreateUserUserControl();
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
