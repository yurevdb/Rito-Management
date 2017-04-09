using System.Windows.Input;

namespace ServerControl.Core
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
            });

            ShowUserInfoPage = new RelayCommand(() =>
            {
            });
        }
    }
}
