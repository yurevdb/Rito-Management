using RitoManager.UserManagement;
using System;

namespace ServerControl.Core
{
    /// <summary>
    /// A viewmodel for each userlistitem
    /// </summary>
    public class UserListItemViewModel: BaseViewModel
    {
        /// <summary>
        /// The name of the user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The account number of the user
        /// </summary>
        public string Age { get; set; }

        /// <summary>
        /// The initials of the user for the image
        /// </summary>
        public string Initials { get; set; }

        /// <summary>
        /// The unique identifier for the user
        /// </summary>
        public string Identifier => User.Identifier;

        /// <summary>
        /// The text to show beneath the user name in the userlistitem
        /// </summary>
        public string SubText => Enum.GetName(typeof(UserLevel), User.Level);

        /// <summary>
        /// The background color for the initials background
        /// </summary>
        public string ImageColorBackground { get; set; }

        /// <summary>
        /// True when this user is selected
        /// </summary>
        public bool IsSelected { get; set; } = false;

        /// <summary>
        /// The given user
        /// </summary>
        public BaseUser User { get; set; }
    }
}
