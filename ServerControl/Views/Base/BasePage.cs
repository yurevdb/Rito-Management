using System.Windows.Controls;
using System.Windows;
using System.Threading.Tasks;
using ServerControl.Core;

namespace ServerControl
{
    /// <summary>
    /// A base page for all pages to gain base functionality
    /// </summary>
    public class BasePage<VM> : Page
        where VM: BaseViewModel, new()
    {
        #region Private Members

        /// <summary>
        /// Viewmodel associated with this page
        /// </summary>
        private VM mViewModel;

        #endregion

        #region Public Properties

        /// <summary>
        /// Animation to play when the page loads
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.FadeIn;

        /// <summary>
        /// Animation to play when the page unloads
        /// </summary>
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.FadeOut;

        /// <summary>
        /// The time any slide animation take to complete
        /// </summary>
        public float AnimateSeconds { get; set; } = 0.3F;

        /// <summary>
        /// Viewmodel associated with this page
        /// </summary>
        public VM ViewModel
        {
            get { return mViewModel; }
            set
            {
                // If nothing has changed, return
                if (mViewModel == value)
                    return;

                mViewModel = value;

                // Set the datacontext of this page
                this.DataContext = mViewModel;
            }
        }

        #endregion
        
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BasePage()
        {
            // if we are animating in, hide to begin with
            if (this.PageLoadAnimation != PageAnimation.None)
                this.Visibility = Visibility.Collapsed;
            
            // Listen out for the page loading
            this.Loaded += BasePage_Loaded;

            // Create a default view model
            this.ViewModel = new VM();
        }

        #endregion

        #region Animation load / unload

        /// <summary>
        /// Once the page is loaded, perform any required animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            // Animate the page in
            await AnimateIn();
        }

        /// <summary>
        /// Animates in the page
        /// </summary>
        /// <returns></returns>
        public async Task AnimateIn()
        {
            //Make sure we have something to do
            if (this.PageLoadAnimation == PageAnimation.None)
            {
                this.Visibility = Visibility.Visible;
                return;
            }

            switch (this.PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:

                    // Start the animation
                    await this.SlideAndFadeInFromRight(this.AnimateSeconds);
                    
                    break;

                case PageAnimation.SlideAndFadeInFromTop:

                    // Start the animation
                    await this.SlideAndFadeInFromTop(this.AnimateSeconds);

                    break;

                case PageAnimation.FadeIn:
                    await this.FadeIn(this.AnimateSeconds);
                    break;
            }
        }

        /// <summary>
        /// Animates the page out
        /// </summary>
        /// <returns></returns>
        public async Task AnimateOut()
        {
            //Make sure we have something to do
            if (this.PageUnloadAnimation == PageAnimation.None)
                return;

            switch (this.PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeToLeft:

                    // Start the animation
                    await this.SlideAndFadeOutToLeft(this.AnimateSeconds);

                    break;

                case PageAnimation.SlideAndFadeToBottom:

                    // Start the animation
                    await this.SlideAndFadeOutToBottom(this.AnimateSeconds);

                    break;

                case PageAnimation.FadeOut:
                    await this.FadeOut(this.AnimateSeconds);
                    break;
            }
        }

        #endregion
    }
}
