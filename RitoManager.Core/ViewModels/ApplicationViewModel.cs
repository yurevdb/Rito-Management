using RitoManager.UserManagement;
using ServerControl.Core;
using System;
using System.Collections.Generic;

namespace RitoManager.Core
{
    /// <summary>
    /// A viewmodel to holds the application variables
    /// </summary>
    public class ApplicationViewModel: BaseViewModel
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
        /// Represents if the status bar button should be visible
        /// </summary>
        public bool StatusBarButtonVisibility { get; set; } = false;

        /// <summary>
        /// The status of the application
        /// </summary>
        public string StatusText { get; set; } = Status.Ready;

        /// <summary>
        /// The path to the json file with all the users
        /// </summary>
        public string JsonPath => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Rito Manager\\RitoManager_Users.json";

        /// <summary>
        /// The list of users
        /// </summary>
        public List<UserListItemViewModel> UserList { get; set; } = new List<UserListItemViewModel>();

        /// <summary>
        /// The user that is currently logged in
        /// </summary>
        public BaseUser LoggedInUser { get; set; } = null;
    }
}
