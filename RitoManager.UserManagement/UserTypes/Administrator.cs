namespace RitoManager.UserManagement
{
    public class Administrator : BaseUser
    {
        #region Constructor

        /// <summary>
        /// Specified constructor
        /// </summary>
        /// <param name="name">Name of the Administrator</param>
        /// <param name="sirname">Sirname of the Administrator</param>
        /// <param name="age">Age of the Administrator</param>
        /// <param name="level"><see cref="UserLevel"/> of the user, default <see cref="UserLevel.User"/></param>
        /// <param name="info">Extra info about the user</param>
        public Administrator(string name, string sirname, string password, int age, string info, string identifier)
        {
            Name = name;
            Sirname = sirname;
            Password = password;
            Age = age;
            Level = UserLevel.Administrator;
            Info = info;
            Identifier = identifier;

            GenerateBackgroundColor();
        }

        #endregion
    }
}
