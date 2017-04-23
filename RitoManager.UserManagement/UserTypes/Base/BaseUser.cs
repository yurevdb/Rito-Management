namespace RitoManager.UserManagement
{
    public class BaseUser
    {
        #region Public Properties

        /// <summary>
        /// The systems username of the user
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Name of the user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Sirname of the user
        /// </summary>
        public string Sirname { get; set; }

        /// <summary>
        /// Accountnumber of the user
        /// </summary>
        public long Accountnumber { get; set; }

        /// <summary>
        /// Age of the user
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// The access level of the user
        /// </summary>
        public UserLevel Level { get; set; }

        #endregion

        #region Base Methods

        /// <summary>
        /// Generates a unique username in the system 
        /// </summary>
        /// <returns></returns>
        public string GenerateUsername(UserLevel level)
        {

            return $"";
        }

        #endregion
    }
}
