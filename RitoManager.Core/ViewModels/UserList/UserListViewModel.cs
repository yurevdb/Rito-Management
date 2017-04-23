using System.Collections.Generic;
using System.Windows.Input;

namespace ServerControl.Core
{
    /// <summary>
    /// A viewmodel for the user list
    /// </summary>
    public class UserListViewModel: BaseViewModel
    {
        /// <summary>
        /// The <see cref="List{T}"/> holding the <see cref="UserListItemViewModel"/>.
        /// </summary>
        public List<UserListItemViewModel> Items { get; set; }

        /// <summary>
        /// Command to register wether the list item is selected
        /// </summary>
        public ICommand IsSelected { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserListViewModel()
        {
        }

    }
}
