using RitoManager.UserManagement;
using System;
using System.Security;
using System.Threading.Tasks;
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

        /// <summary>
        /// The command to show the identifier
        /// </summary>
        public ICommand SelectionChangedCommand { get; set; }

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

        /// <summary>
        /// Identifier of the user to create
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Age of the user to create
        /// </summary>
        public string Age { get; set; } = "";

        /// <summary>
        /// Extra info about the user to create
        /// </summary>
        public string Info { get; set; }

        /// <summary>
        /// Password of the user to create
        /// </summary>
        public SecureString Password { get; set; }

        /// <summary>
        /// Different levels of access to the application
        /// </summary>
        public Array LevelItems => Enum.GetValues(typeof(UserLevel));

        /// <summary>
        /// The Selected userlevel for the new user
        /// </summary>
        public string SelectedItem { get; set; } = "0";

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public CreateUserViewModel()
        {
            Createuser = new RelayParameterizedCommand(async (param) => await Task.Run(() =>
                {
                    BaseUser u = null;
                    int age = 0;

                    try
                    {
                        age = int.Parse(Age);
                    }
                    catch
                    {
                        age = -1;
                    }

                    switch (SelectedItem)
                    {
                        case "0":
                            u = new User(Name, Sirname, (param as IHavePassword).SecurePassword.Unsecure(), age, Info, Identifier);
                            break;
                        case "1":
                            u = new Employee(Name, Sirname, (param as IHavePassword).SecurePassword.Unsecure(), age, Info, Identifier);
                            break;
                        case "2":
                            u = new Manager(Name, Sirname, (param as IHavePassword).SecurePassword.Unsecure(), age, Info, Identifier);
                            break;
                        case "3":
                            u = new Administrator(Name, Sirname, (param as IHavePassword).SecurePassword.Unsecure(), age, Info, Identifier);
                            break;
                        default:
                            break;
                    }

                    u.Save();
                    Reset();
                }));

            SelectionChangedCommand = new RelayCommand(() => 
            {
                Identifier = BaseUser.GenerateIdentifier(SelectedItem);
            });
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Resets the properties of the view
        /// </summary>
        private void Reset()
        {
            Name = string.Empty;
            Sirname = string.Empty;
            Info = string.Empty;
            Age = string.Empty;
            SelectedItem = "0";
        }

        #endregion
    }
}
