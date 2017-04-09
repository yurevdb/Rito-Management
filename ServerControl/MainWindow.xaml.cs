using System.Windows;
using System.Windows.Navigation;

namespace ServerControl
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new WindowViewModel(this);
        }
    }
}