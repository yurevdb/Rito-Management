using ServerControl.Core;
using System.Security;

namespace ServerControl
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : BasePage<LoginViewModel>, IHavePassword
    {
        public LoginPage()
        {
            InitializeComponent();

            this.PageLoadAnimation = PageAnimation.None;
            this.PageUnloadAnimation = PageAnimation.None;
            this.AnimateSeconds = 0F;
        }

        /// <summary>
        /// The secure password for this login page
        /// </summary>
        public SecureString SecurePassword => tbxPassword.SecurePassword;
    }
}
