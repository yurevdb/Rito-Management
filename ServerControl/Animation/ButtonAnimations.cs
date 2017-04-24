using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace ServerControl
{
    /// <summary>
    /// Helpers to animate pages in specefic ways
    /// </summary>
    public static class ButtonAnimations
    {
        /// <summary>
        /// Adds a rotation animation to a <see cref="Button"/>
        /// </summary>
        /// <param name="element">The <see cref="Button"/> to animate</param>
        /// <param name="fromAngle">The angle to start the rotation from</param>
        /// <param name="toAngle">The angle to end the rotation</param>
        /// <param name="seconds">The time to rotation should take</param>
        /// <returns></returns>
        public static async Task RotateAsync(this Button element, double fromAngle, double toAngle, float seconds = 0.3f)
        {
            // Create the storyboard
            var sb = new Storyboard();

            // Add the rotation to the storyboard
            sb.AddRotationToButton(seconds, fromAngle, toAngle);

            // Begin the animation
            sb.Begin(element);

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }
    }
}
