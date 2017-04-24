using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace RitoManager.UserManagement
{
    public static class UserSerialization
    {

        /// <summary>
        /// <see cref="BinaryFormatter"/> for serialization
        /// </summary>
        private static BinaryFormatter bf = new BinaryFormatter();

        /// <summary>
        /// Extension method to serialize a list of baseusers
        /// </summary>
        /// <param name="list">The list to serialize</param>
        public static void Serialize(this List<BaseUser> list)
        {
            using (FileStream fs = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\RitoManager_Users.rmu", FileMode.OpenOrCreate, FileAccess.Write))
            {
                bf.Serialize(fs, list);
            }
        }

        /// <summary>
        /// Extension method to deserialize a list a baseusers
        /// </summary>
        /// <param name="list">The list with the users</param>
        /// <returns></returns>
        public static List<BaseUser> Deserialize()
        {
            using (FileStream fs = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\RitoManager_Users.rmu", FileMode.Open, FileAccess.Read))
            {
                List<BaseUser> users = bf.Deserialize(fs) as List<BaseUser>;
                return users;
            }
        }

        /// <summary>
        /// Gets the list of users and adds the given user to it and saves the list again
        /// </summary>
        /// <param name="user">The <see cref="User"/> to save</param>
        public static void Save(this User user)
        {
            // Get the list of users
            List<BaseUser> users = Deserialize();

            // If the list does not exists yet
            if (users == null)
                // Create it
                users = new List<BaseUser>();

            // Add the given user to the list
            users.Add(user);

            // Save the list again
            users.Serialize();
        }
    }
}
