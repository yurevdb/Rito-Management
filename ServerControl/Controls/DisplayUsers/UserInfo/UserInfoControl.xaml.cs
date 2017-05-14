using RitoManager.Core;
using System.Windows.Controls;

namespace ServerControl
{
    /// <summary>
    /// Interaction logic for UserInfoControl.xaml
    /// </summary>
    public partial class UserInfoControl : UserControl
    {
        public UserInfoControl()
        {
            InitializeComponent();

            UserInfoViewModel u = IoC.Get<UserInfoViewModel>();
            DataContext = u;
        }
    }
}
