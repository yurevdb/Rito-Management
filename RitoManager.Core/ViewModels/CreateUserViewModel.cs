using RitoManager.UserManagement;
using System.Windows.Input;

namespace ServerControl.Core
{
    public class CreateUserViewModel: BaseViewModel
    {
        #region Commands

        /// <summary>
        /// The command to create a user
        /// </summary>
        public ICommand Createuser { get; set; }

        #endregion

        #region Public Properties

        /// <summary>
        /// Name of the user to create
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Sirname of the user to create
        /// </summary>
        public string Sirname { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public CreateUserViewModel()
        {
            Createuser = new RelayCommand(() =>
            {
                User u = new User(Name, Sirname, 22, 0987654321234567890, UserLevel.Administrator);
                u.Save();
            });
        } 

        #endregion
    }
}
