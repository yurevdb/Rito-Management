using Newtonsoft.Json;
using RitoManager.Core;
using RitoManager.UserManagement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ServerControl.Core
{
    /// <summary>
    /// A viewmodel for the user list
    /// </summary>
    public class UserListViewModel: BaseViewModel
    {
        #region Private Variables

        /// <summary>
        /// A variable to store the previous selected user so only one user can be selected at once
        /// </summary>
        private UserListItemViewModel previousSelectedUser = null;

        #endregion

        #region Public Properties

        /// <summary>
        /// The <see cref="List{UserListItemViewModel}"/> holding the <see cref="UserListItemViewModel"/>.
        /// </summary>
        public List<UserListItemViewModel> Items { get; set; } = IoC.Get<ApplicationViewModel>().UserList;

        #endregion

        #region Commands

        /// <summary>
        /// Command to register wether the list item is selected
        /// </summary>
        public ICommand Selected { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserListViewModel()
        {
            // Await the creation of the user list
            /*
             * Dit stuk code zorgt ervoor dat de pagina niet asynchroon geladen kan worden.
             * Dit doe ik omdat het bewerken van de listview itemssource geen update maakt in de view
             * Dit is de reden voor deze slechte bewerking, maar hierdoor werkt het
             */
            Task.WaitAll(GetUserList());
            
            Selected = new RelayParameterizedCommand((param) =>
            {
                // Get the given parameter as a userlistitemviewmodel
                var user = param as UserListItemViewModel;

                // Dependency Injection for setting the user in the UserInfoViewModel
                #region Dependency Injection Stuff

                // Set the user as the baseuser of the viewmodel
                IoC.Get<UserInfoViewModel>().User = user.User;

                #endregion

                // Set the user to selected
                user.IsSelected = true;

                // If the user is not already set...
                if (previousSelectedUser == null)
                    // Set the selected user
                    previousSelectedUser = user;
                // If the user was already set...
                else
                {
                    // Set the selection for the previous user to null
                    previousSelectedUser.IsSelected = false;

                    // Set the current selected user as the new selected user
                    previousSelectedUser = user;
                }
            });
            
            // If there is an element in items...
            if(Items.Count > 0)
                // Select the first element in the list
                Selected.Execute(Items.FirstOrDefault());
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Creates the user for displaying in the <see cref="UserListViewModel"/>
        /// </summary>
        private Task GetUserList()
        {
            // Variable for the users in the json file
            List<BaseUser> items = null;

            BaseUser x = null;

            // Get the users from the json file
            if (File.Exists(IoC.Get<ApplicationViewModel>().JsonPath))
            {
                x = IoC.Get<ApplicationViewModel>().LoggedInUser;

                items = JsonConvert.DeserializeObject<List<BaseUser>>(File.ReadAllText(IoC.Get<ApplicationViewModel>().JsonPath));
            }

            if (items == null || x == null)
                return Task.Delay(1);

            // Asynchronous Creation
            return Task.Run(() =>
            {
                Items.Clear();

                // Create userlistitems for displaying 
                foreach (var u in items)
                {
                    // If the logged in user is not the user to check...
                    if (x.Identifier != u.Identifier)
                        // If the logged in user is an administrator...
                        if (x.Level == UserLevel.Administrator)
                            // show all the users except himself
                            Items.Add(ConvertUser(u));
                        // Else if the user to add has a lower access level then the logged in user...
                        else if (u.Level < x.Level)
                            // Add that user to the list of users to show
                            Items.Add(ConvertUser(u));
                }

                IoC.Get<ApplicationViewModel>().UserList = Items;
            });
        }

        /// <summary>
        /// Converts a <see cref="BaseUser"/> or derived to a <see cref="UserListItemViewModel"/>
        /// </summary>
        /// <param name="user">The <see cref="BaseUser"/> to convert</param>
        /// <returns></returns>
        public static UserListItemViewModel ConvertUser(BaseUser user)
        {
            return new UserListItemViewModel
            {
                User = user,
                ImageColorBackground = user.BackgroundColor,
                Initials = user.Name.ToCharArray()[0].ToString().ToUpper() + user.Sirname.ToCharArray()[0].ToString().ToUpper(),
                Name = user.Name + " " + user.Sirname,
            };
        }

        /// <summary>
        /// Updates the user base
        /// </summary>
        public void UpdateUsers()
        {
            // Get the data from the json file
            var users = JsonConvert.DeserializeObject<List<BaseUser>>(File.ReadAllText(IoC.Get<ApplicationViewModel>().JsonPath));

            Items.Clear();

            // Asynchronous Creation
            Task.Run(() =>
            {
                // Create userlistitems for displaying 
                foreach (var u in users)
                {
                    Items.Add(ConvertUser(u));
                }
            });
        }

        #endregion
    }
}
