﻿namespace ServerControl.Core
{
    /// <summary>
    /// Design time data for a UserListItemControl
    /// </summary>
    public class UserListItemDesignModel: UserListItemViewModel
    {
        #region Public Properties

        /// <summary>
        /// Singleton for use at design time of this class
        /// </summary>
        public static UserListItemDesignModel Instance { get; } = new UserListItemDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserListItemDesignModel()
        {
            Initials = "YV";
            Name = "Yuré Vanderbruggen";
            AccountNumber = "38349 98272 92883 98238 9";
            ImageColorBackground = "3099c5";
        }

        #endregion
    }
}
