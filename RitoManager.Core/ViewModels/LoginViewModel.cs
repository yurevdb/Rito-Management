using Newtonsoft.Json;
using RitoManager.Core;
using RitoManager.UserManagement;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ServerControl.Core
{
    /// <summary>
    /// A view model for a login page
    /// </summary>
    public class LoginViewModel: BaseViewModel
    {
        #region Commands

        /// <summary>
        /// The command to login
        /// </summary>
        public ICommand LoginCommand { get; set; }
        
        #endregion

        #region Public Properties

        /// <summary>
        /// The username of the user
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Error text to show when the username and or password is wrong
        /// </summary>
        public string ErrorText { get; set; }

        /// <summary>
        /// A flag indicating if the login command is running
        /// </summary>
        public bool LoginIsRunning { get; set; } = false;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public LoginViewModel()
        {
            // Create Commands
            // Taskception
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await Login(parameter));
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Attempts to log the user in
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/> passed if from the view for the users password</param>
        /// <returns></returns>
        public async Task Login(object parameter)
        {
            await RunCommand(() => this.LoginIsRunning, async () => 
            {
                /*
                 * use this part if the server is online for testing
                 * 
                SslSender ConfirmLogin = new SslSender("Rito", 5005);
                string message = string.Format(" login,{0},{1}", this.Username, (parameter as IHavePassword).SecurePassword.Unsecure());
                ConfirmLogin.SendData(message);
                Func<bool> function = new Func<bool>(() => ConfirmLogin.GetLoginConfirmation());
                bool res = await Task.Factory.StartNew<bool>(function);
                if (res == true)
                {
                    // Bad but worked
                    WindowViewModel window = ((MainWindow)Application.Current.MainWindow).DataContext as WindowViewModel;
                    window.CurrentPage = ApplicationPage.App;

                    // Good way, Injection of Control through ninject (dependency injection made easy)
                    IoC.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.Welcome;
                    IoC.Get<ApplicationViewModel>().IsLoggedIn = true;
                    ErrorText = string.Empty;
                }
                */

                //await Task.Delay(1);

                await Task.Run(() => 
                {
                    // Testing protocol
                    if (Username == "admin" && (parameter as IHavePassword).SecurePassword.Unsecure() == "admin")
                    {
                        IoC.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.Welcome;
                        IoC.Get<ApplicationViewModel>().IsLoggedIn = true;
                        IoC.Get<ApplicationViewModel>().LoggedInUser = new Employee("admin", "admin", "admin", 0, "admin");
                        ErrorText = string.Empty;
                        return;
                    }

                    // Check for actual users
                    if (CheckUser(Username, (parameter as IHavePassword).SecurePassword))
                    {
                        IoC.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.Welcome;
                        IoC.Get<ApplicationViewModel>().IsLoggedIn = true;
                        ErrorText = string.Empty;
                    }
                });
            });
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Gets the database of users and checks if the username is known to the system,
        /// If the username is known then it will check if the password is correct,
        /// When the credentials are correct it will return true, else it will return false.
        /// </summary>
        /// <param name="Username">The username of the user to log in</param>
        /// <param name="Password">The password of the user to log in</param>
        /// <returns></returns>
        private bool CheckUser(string Username, SecureString Password)
        {
            // Value of correct user credentials
            var value = false;
            
            // Get the list of users
            var users = JsonConvert.DeserializeObject<List<BaseUser>>(File.ReadAllText(IoC.Get<ApplicationViewModel>().JsonPath));
            
            // Go through all the users
            foreach(var baseuser in users)
            {
                // If the username exists...
                if (baseuser.Name == Username)
                    // A user that wants to log in must be at a higher access level that the standard user
                    if (baseuser.Level > UserLevel.User)
                        // Check if the password is correct...
                        if (baseuser.Password == Password.Unsecure())
                        {
                            // Set true
                            value = true;

                            // Set the logged in user
                            IoC.Get<ApplicationViewModel>().LoggedInUser = baseuser;
                        }
                        else
                        {
                            ErrorText = Status.LoginError;
                            break;
                        }
                    else
                        ErrorText = "You don't have the required access level.";
            }

            // Return the value
            return value;
        }

        #endregion
    }
}
