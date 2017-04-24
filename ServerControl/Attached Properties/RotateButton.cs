using System.Windows;
using System.Windows.Controls;

namespace ServerControl
{
    /// <summary>
    /// The RotateButton attached property to rotate a button on the shownavigation bool.
    /// </summary>
    public class RotateButton : BaseAttachedProperty<RotateButton, bool>
    {
        public override async void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // Get the button
            var button = (sender as Button);

            // If the navigation menu is shown...
            if ((bool)e.NewValue)
                // Rotate the button to point down
                await button.RotateAsync(0, 180);
            // If the navigation menu is hidden...
            else
                // Rotate the button to point up
                await button.RotateAsync(180, 0);
        }
    }
}
