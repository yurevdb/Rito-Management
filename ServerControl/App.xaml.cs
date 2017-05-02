using RitoManager.Core;
using System;
using System.IO;
using System.Windows;

namespace ServerControl
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Custom start up so we load our IoC before anything else
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            // Let it do it's thang
            base.OnStartup(e);

            // Set up the IoC
            IoC.Setup();

            // Create the main window
            Current.MainWindow = new MainWindow();
            
            // Show the main window
            Current.MainWindow.Show();

            // Denk er nog eens over na hoe je de window niet mag tonen tot de video achtergrond volledig is geladen

        }
    }
}
