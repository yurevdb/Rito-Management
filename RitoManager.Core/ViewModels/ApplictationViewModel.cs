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
    }
}
