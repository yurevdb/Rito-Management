using System.Collections.Generic;

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

    }
}
