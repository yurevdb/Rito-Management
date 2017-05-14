using System.Collections.Generic;

namespace ServerControl.Core
{
    /// <summary>
    /// Design time data for a <see cref="UserListControl"/>
    /// </summary>
    public class UserListDesignModel: UserListViewModel
    {
        #region Public Properties

        /// <summary>
        /// Singleton for use at design time of this class
        /// </summary>
        public static UserListDesignModel Instance { get; } = new UserListDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserListDesignModel()
        {
            Items = new List<UserListItemViewModel>
            {
                new UserListItemViewModel
                {
                    Name = "Yuré Vanderbruggen",
                    Initials = "YV",
                    ImageColorBackground = "30995c",
                    IsSelected = true
                },
                new UserListItemViewModel
                {
                    Name = "Bard Bardus",
                    Initials = "BB",
                    ImageColorBackground = "00d309",
                },
                new UserListItemViewModel
                {
                    Name = "Xayah the Rebel",
                    Initials = "XR",
                    ImageColorBackground = "ff3402",
                },
                new UserListItemViewModel
                {
                    Name = "Yuré Vanderbruggen",
                    Initials = "YV",
                    ImageColorBackground = "30995c",
                    IsSelected = true
                },
                new UserListItemViewModel
                {
                    Name = "Bard Bardus",
                    Initials = "BB",
                    ImageColorBackground = "00d309",
                },
                new UserListItemViewModel
                {
                    Name = "Xayah the Rebel",
                    Initials = "XR",
                    ImageColorBackground = "ff3402",
                },
                new UserListItemViewModel
                {
                    Name = "Yuré Vanderbruggen",
                    Initials = "YV",
                    ImageColorBackground = "30995c",
                    IsSelected = true
                },
                new UserListItemViewModel
                {
                    Name = "Bard Bardus",
                    Initials = "BB",
                    ImageColorBackground = "00d309",
                },
                new UserListItemViewModel
                {
                    Name = "Xayah the Rebel",
                    Initials = "XR",
                    ImageColorBackground = "ff3402",
                },
            };
        }

        #endregion
    }
}
