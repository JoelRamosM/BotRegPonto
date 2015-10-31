using BotPonto.IoC.Installers;
using Ninject;

namespace BotPonto.IoC
{
    public static class NinjectCommom
    {
        private static IKernel _kernel;
        public static IKernel Kernel => _kernel;

        public static IKernel CreateKernel()
        {
            _kernel = new StandardKernel(new NinjectSettings { AllowNullInjection = true });
            ConfigureKernel(_kernel);
            return _kernel;
        }
        private static void ConfigureKernel(IKernel kernel)
            => kernel.Load<DefaultModule>();
    }
}
