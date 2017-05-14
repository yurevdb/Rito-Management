namespace RitoManager.UserManagement
{
    public class Manager : BaseUser
    {
        #region Constructor

        /// <summary>
        /// Specified constructor
        /// </summary>
        /// <param name="name">Name of the Manager</param>
        /// <param name="sirname">Sirname of the Manager</param>
        /// <param name="age">Age of the Manager</param>
        /// <param name="level"><see cref="UserLevel"/> of the user, default <see cref="UserLevel.User"/></param>
        /// <param name="info">Extra info about the user</param>
        public Manager(string name, string sirname, string password, int age, string info)
        {
            Name = name;
            Sirname = sirname;
            Password = password;
            Age = age;
            Level = UserLevel.Manager;
            Info = info;

            GenerateIdentifier();
            GenerateBackgroundColor();
        }

        #endregion
    }
}
