using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ServerControl
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
                    WindowViewModel window = ((MainWindow)Application.Current.MainWindow).DataContext as WindowViewModel;
                    window.CurrentPage = ApplicationPage.App;
                }
                */
                await Task.Delay(2000);
                if(this.Username == "yure" && (parameter as IHavePassword).SecurePassword.Unsecure() == "hallo")
                {
                    
                    WindowViewModelHelper.SetViewFromViewModel(ApplicationPage.UserManagement);
                    WindowViewModelHelper.SetLoggedIn(true);
                }
            });
        }

        #endregion
    }
}
