using Newtonsoft.Json;
using RitoManager.Core;
using RitoManager.UserManagement;
using System;
using System.Collections.Generic;
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

            // Check if the appdata directory is setup, if not it will set it up
            CheckAppData();

            // Set up the IoC
            IoC.Setup();

            // Create the main window
            Current.MainWindow = new MainWindow();
            
            // Show the main window
            Current.MainWindow.Show();

            // Denk er nog eens over na hoe je de window niet mag tonen tot de video achtergrond volledig is geladen

        }

        /// <summary>
        /// Checks if the appdata directory exists and if th database of users exists, if not it will create them
        /// </summary>
        private void CheckAppData()
        {
            // variables to the appdata directory and file
            var file = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Rito Manager\\RitoManager_Users.json";
            var dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Rito Manager";

            // If the "Rito Manager" directory does not exist in the appdata folder
            if (!Directory.Exists(dir))
                // Create the "Rito Manager" directory in the appdata folder
                Directory.CreateDirectory(dir);
            
            // if the RitoManager_Users.json file does noet exists...
            if (!File.Exists(file))
            {
                // Create the file
                FileStream fs = File.Create(file);
                
                // Close the creator of the file
                fs.Close();

                // serialize an empty list
                var json = JsonConvert.SerializeObject(new List<BaseUser>());

                // write the json data to the file
                File.WriteAllText(file, json);
            }

        }
    }
}
