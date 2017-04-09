using Ninject;

namespace RitoManager.Core
{
    public static class IoC
    {
        public static IKernel Kernel { get; private set; } = new StandardKernel();
    }
}
