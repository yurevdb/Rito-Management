using System;
using System.Security;
using ServerControl.Core;

namespace ServerControl
{
    /// <summary>
    /// Interaction logic for CreateUserPage.xaml
    /// </summary>
    public partial class CreateUserPage : BasePage<CreateUserViewModel>, IHavePassword
    {
        public CreateUserPage()
        {
            InitializeComponent();
        }

        public SecureString SecurePassword => tbxPassword.SecurePassword;
    }
}
