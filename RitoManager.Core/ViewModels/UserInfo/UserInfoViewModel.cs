using Newtonsoft.Json;
using RitoManager.UserManagement;
using ServerControl.Core;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;

namespace RitoManager.Core
{
    public class UserInfoViewModel : BaseViewModel
    {
        /// <summary>
        /// The selected user
        /// </summary>
        public BaseUser User { get; set; }

        /// <summary>
        /// Username of the selected user
        /// </summary>
        public string UserName => (User == null) ? "No user selected" : User.Name + " " + User.Sirname;

        /// <summary>
        /// Age of the selected user
        /// </summary>
        public string UserAge => (User == null) ? "N/A" : User.Age.ToString();

        /// <summary>
        /// Info of the selected user
        /// </summary>
        public string UserInfo => (User == null) ? "N/A" : User.Info;

        /// <summary>
        /// Access level of the selectd user
        /// </summary>
        public string UserLevel => (User == null) ? "N/A" : User.Level.ToString();

        /// <summary>
        /// Identifier of the selected user
        /// </summary>
        public string UserIdentifier => (User == null) ? "N/A" : User.Identifier;
        
        /// <summary>
        /// Command to delete a user
        /// ! THIS WILL NOT SHOW THE USER DELETE IN THE VIEW, RELOAD OF THE PAGE IS REQUIRED!
        /// </summary>
        public ICommand DeleteUser { get; set; }

        public UserInfoViewModel()
        {
            DeleteUser = new RelayCommand(() => DeleteUserFromDatabase());
        }


        #region Helpers

        /// <summary>
        /// Deletes the selected user from the database
        /// </summary>
        private void DeleteUserFromDatabase()
        {
            // Gets the list of users
            var users = JsonConvert.DeserializeObject<List<BaseUser>>(File.ReadAllText(IoC.Get<ApplicationViewModel>().JsonPath));

            // Removes the selected user from the list. Searches on the base of the unique identifier
            users.RemoveAt(users.FindIndex(a => a.Identifier == User.Identifier));

            // Saves the list without the selected user
            File.WriteAllText(IoC.Get<ApplicationViewModel>().JsonPath, JsonConvert.SerializeObject(users));
        }

        #endregion
    }
}
