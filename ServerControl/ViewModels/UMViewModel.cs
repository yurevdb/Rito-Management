using System.Windows.Input;

namespace ServerControl
{
    public class UMViewModel: BaseViewModel
    {
        #region Commands

        public ICommand ShowCreateUserPage { get; set; }

        public ICommand ShowUserInfoPage { get; set; }

        #endregion

        public UMViewModel()
        {
            ShowCreateUserPage = new RelayCommand(() => 
            {
                WindowViewModelHelper.SetViewFromViewModel(ApplicationPage.CreateUser);
            });

            ShowUserInfoPage = new RelayCommand(() =>
            {
                WindowViewModelHelper.SetViewFromViewModel(ApplicationPage.UserInfo);
            });
        }
    }
}
