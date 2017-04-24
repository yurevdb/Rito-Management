using RitoManager.UserManagement;
using System.Windows.Input;

namespace ServerControl.Core
{
    public class CreateUserViewModel: BaseViewModel
    {
        public ICommand Createuser { get; set; }

        public string Name { get; set; }

        public string Sirname { get; set; }

        public CreateUserViewModel()
        {
            Createuser = new RelayCommand(() => 
            {
                User u = new User()
                {
                    Sirname = Sirname,
                    Name = Name
                };

                u.Save();
            });
        }
    }
}
