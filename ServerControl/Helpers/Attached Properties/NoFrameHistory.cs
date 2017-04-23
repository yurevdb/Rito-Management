using System.Windows;
using System.Windows.Controls;

namespace ServerControl
{
    /// <summary>
    /// The NoFrameHistory attached property for creating the <see cref="Frame"/> that never shows navigation
    /// </summary>
    public class NoFrameHistory : BaseAttachedProperty<NoFrameHistory, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // Get the frame
            var frame = (sender as Frame);

            // Remove the navigation ui
            frame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;

            // Remove navigation history
            frame.Navigated += (ss, ee) => ((Frame)ss).NavigationService.RemoveBackEntry();
        }
    }
}
