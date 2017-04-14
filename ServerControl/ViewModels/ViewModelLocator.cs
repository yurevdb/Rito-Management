using RitoManager.Core;

namespace ServerControl
{
    public class ViewModelLocator
    {
        public static ViewModelLocator Instance { get; set; } = new ViewModelLocator();

        public static ApplicationViewModel ApplicationViewModel => IoC.Get<ApplicationViewModel>();
    }
}
