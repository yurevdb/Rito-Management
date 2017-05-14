using RitoManager.Core;
using ServerControl.Core;
using System.Windows.Controls;

namespace ServerControl
{
    /// <summary>
    /// Interaction logic for UserListControl.xaml
    /// </summary>
    public partial class UserListControl : UserControl
    {
        public UserListControl()
        {
            InitializeComponent();

            UserListViewModel u = new UserListViewModel();
            DataContext = u;
        }
    }
}
