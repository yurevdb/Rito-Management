using System.Windows;
using System.Windows.Navigation;

namespace ServerControl
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowViewModel wvm = new WindowViewModel(this);
            this.DataContext = wvm;
            wvm.SetView(ApplicationPage.Login);
        }
    }
}