using BotPonto.Core.Interface;
using Ninject;
using Ninject.Extensions.Conventions;

namespace BotPonto.Service.Console.Configuration
{
    public static class NinjectBootstraper
    {
        private static StandardKernel _kernel;
        public static IKernel Kernel => _kernel;

        public static IKernel CreateKernel()
        {
            _kernel = new StandardKernel(new NinjectSettings() { AllowNullInjection = true }); ;
            ConfigureKernel(_kernel);
            return _kernel;
        }

        private static void ConfigureKernel(IKernel kernel)
        {
            kernel.Bind(c => c.FromAssemblyContaining<IBotCommand>().SelectAllClasses().BindDefaultInterfaces());
        }
    }
}
