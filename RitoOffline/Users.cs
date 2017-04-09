using System;
using System.Collections.Generic;

namespace RitoOffline
{
    /// <summary>
    /// A class holding methods to get users and create users offline.
    /// </summary>
    public static class Users
    {
        #region Public Properities

        /// <summary>
        /// The list of users of rito banks
        /// </summary>
        public static List<RitoUser> RitoUsers { get; set; }

        #endregion 

        #region User Creation

        /// <summary>
        /// Creates a new <see cref="RitoUser"/> in the system offline.
        /// </summary>
        /// <param name="User">The <see cref="RitoUser"/> to create.</param>
        public static void CreateUser(RitoUser User)
        {
            RitoUsers.Add(User);
        }

        /// <summary>
        /// Creates a new <see cref="RitoUser"/> in the system offline.
        /// </summary>
        /// <param name="Username">The username of the user</param>
        /// <param name="Name">The name of the user</param>
        /// <param name="Sirname">The sirname of the user</param>
        /// <param name="Accountnumber">The accountnumber of the user</param>
        /// <param name="Age">The age of the user</param>
        /// <param name="Level">The type of user</param>
        public static void CreateUser(string Username, string Name, string Sirname, string Accountnumber, int Age, Level Level)
        {
            var user = new RitoUser(Username, Name, Sirname, Accountnumber, Age, Level);
            RitoUsers.Add(user);
        }

        #endregion

        #region Get User

        /// <summary>
        /// Gets the list of users for rito bank
        /// </summary>
        /// <returns>The list of users</returns>
        public static List<RitoUser> GetUsers()
        {
            return RitoUsers;
        }

        /// <summary>
        /// Gets a user equal to the given username
        /// </summary>
        /// <param name="Username">The username of the user to get</param>
        /// <returns><see cref="RitoUser"/></returns>
        public static RitoUser GetUser(string Username)
        {
            RitoUser user = null;

            // Check the username of a user
            // If correct return the user
            foreach (var u in RitoUsers)
                user = (u.Username == Username) ? u : null;

            return user;
        }

        /// <summary>
        /// Gets a user equal to the given name and sirname
        /// </summary>
        /// <param name="Name">The name of the user to get</param>
        /// <param name="Sirname">The sirname of the user to get</param>
        /// <returns><see cref="RitoUser"/></returns>
        public static RitoUser GetUser(string Name, string Sirname)
        {
            RitoUser user = null;

            // Check the name of a user to the given user
            // And check the sirname of a user to the given sirname
            // If correct return the user
            foreach (var u in RitoUsers)
                user = ((u.Name == Name) && (u.Sirname == Sirname)) ? u : null;

            return user;
        }

        #endregion
    }

    /// <summary>
    /// A class holding the info for a rito bank user
    /// </summary>
    public class RitoUser
    {
        /// <summary>
        /// The username of the user
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The name of the user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The sirname of the user
        /// </summary>
        public string Sirname { get; set; }

        /// <summary>
        /// The initials of the user
        /// </summary>
        public string Initials => $"{Name.ToUpper().ToCharArray()[0].ToString()}{Sirname.ToUpper().ToCharArray()[0].ToString()}";

        /// <summary>
        /// The accountnumber of the user
        /// </summary>
        public string Accountnumber { get; set; }

        /// <summary>
        /// The age of the user
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// The type of user
        /// </summary>
        public Level Level { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public RitoUser()
        {

        }


        public RitoUser(string username, string name, string sirname, string accountnumber, int age, Level level)
        {
            Username = username;
            Name = name;
            Sirname = sirname;
            Accountnumber = accountnumber;
            Age = age;
            Level = level;
        }
    }
}
