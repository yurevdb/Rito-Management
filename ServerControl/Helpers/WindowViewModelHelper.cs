using System.Windows;
using System.Windows.Controls;

namespace ServerControl
{
    public static class WindowViewModelHelper
    {

        private static WindowViewModel window = ((MainWindow)Application.Current.MainWindow).DataContext as WindowViewModel;

        /// <summary>
        /// Sets the <see cref="Page"/> as the view of the <see cref="Frame"/>.
        /// The <see cref="Frame"/> needs to be named "placeholder".
        /// </summary>
        /// <param name="view">The view to set.</param>
        public static void SetView(this WindowViewModel vm, ApplicationPage page)
        {
            vm.CurrentPage = page;
        }

        /// <summary>
        /// Sets the <see cref="Page"/> as the view of the <see cref="Frame"/>.
        /// The <see cref="Frame"/> needs to be named "placeholder".
        /// </summary>
        /// <param name="view">The view to set.</param>
        public static void SetViewFromViewModel(ApplicationPage page)
        {
            window.CurrentPage = page;
        }

        /// <summary>
        /// Sets the property wether a users is logged in or not.
        /// </summary>
        /// <param name="setter">The value to set</param>
        public static void SetLoggedIn(bool setter)
        {
            window.IsLoggedIn = setter;
        }

        /// <summary>
        /// Sets the status bar text.
        /// </summary>
        /// <param name="Text">The text to show.</param>
        public static void SetStatusText(string Text)
        {
            window.StatusBarText = Text;
        }
    }
}
