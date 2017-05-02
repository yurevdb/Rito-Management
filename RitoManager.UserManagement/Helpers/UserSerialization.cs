using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace RitoManager.UserManagement
{
    public static class UserSerialization
    {
        /// <summary>
        /// Gets the list of users and adds the given user to it and saves the list again
        /// </summary>
        /// <param name="user">The <see cref="User"/> to save</param>
        public static void Save(this User user)
        {
            // Create the list of users
            var users = new List<BaseUser>();

            // Get the path to the list of users
            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\RitoManager_Users.json";

            // If the file does not exists...
            if (!File.Exists(path))
            // Create the file
            {
                FileStream fs = null;
                try
                {
                    fs = File.Create(path);
                }
                finally
                {
                    if (fs != null)
                        fs.Close();
                }
            }
            // If the file does exists...
            else
                // Get the list of users
                users = JsonConvert.DeserializeObject<List<BaseUser>>(File.ReadAllText(path));
            
            // Add the given user to the list
            users.Add(user);

            // Save the list again
            string json = JsonConvert.SerializeObject(users);
            
            // Write the json data to the file
            File.WriteAllText(path, json);
            
        }
    }
}
