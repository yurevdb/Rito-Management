namespace RitoManager.UserManagement
{
    public class Employee : BaseUser
    {
        #region Constructor

        /// <summary>
        /// Specified constructor
        /// </summary>
        /// <param name="name">Name of the employee</param>
        /// <param name="sirname">Sirname of the employee</param>
        /// <param name="age">Age of the employee</param>
        /// <param name="accountnumber">Accountnumber of the Employee</param>
        /// <param name="level"><see cref="UserLevel"/> of the user, default <see cref="UserLevel.User"/></param>
        public Employee(string name, string sirname, string password, int age)
        {
            Identifier = GenerateIdentifier(); //GenerateIdentifier()
            Name = name;
            Sirname = sirname;
            Password = password;
            Age = age;
            Level = UserLevel.Employee;
        }

        #endregion
    }
}
