using ServerControl.Core;

namespace RitoManager.Core
{
    /// <summary>
    /// A viewmodel to holds the application variables
    /// </summary>
    public class ApplictationViewModel: BaseViewModel
    {
        /// <summary>
        /// The current page of the application
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;

        /// <summary>
        /// Represents if the page navigation menu can be shown
        /// </summary>
        public bool ShowNavigationMenu { get; set; } = false;

        /// <summary>
        /// Represents if someone is logged in
        /// </summary>
        public bool IsLoggedIn { get; set; } = false;

        /// <summary>
        /// The status of the application
        /// </summary>
        public string StatusText { get; set; } = Status.Ready;
    }
}
