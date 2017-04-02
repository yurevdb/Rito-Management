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
        /// <summary>
        /// Bool to check if the plotview has already been constructed
        /// </summary>
        private bool DoesPlotViewExist { get; set; } = false;

        /// <summary>
        /// The plotview to keep in memory
        /// </summary>
        private PlotView plotview;

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Find the appropriate page
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.Login:
                    if (DoesPlotViewExist)
                    {
                        DoesPlotViewExist = false;
                        plotview.Dispose();
                        plotview = null;
                    }
                    return new LoginPage();
                case ApplicationPage.Plot:
                    PlotView plot;
                    if (DoesPlotViewExist)
                        plot = plotview;
                    else
                    {
                        plotview = new PlotView();
                        plot = plotview;
                        DoesPlotViewExist = true;
                    }
                    return plot;
                case ApplicationPage.UserManagement:
                    return new UMPage();
                case ApplicationPage.CreateUser:
                    return new CreateUserPage();
                case ApplicationPage.UserInfo:
                    return new DisplayUsersPage();
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
