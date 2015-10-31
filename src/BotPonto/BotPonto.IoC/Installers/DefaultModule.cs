using BotPonto.Core.Bot;
using BotPonto.Core.Interface;
using BotPonto.CrossCuting;
using Ninject.Extensions.Conventions;
using Ninject.Modules;
using Ninject.Web.Common;

namespace BotPonto.IoC.Installers
{
    public class DefaultModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(syntax => syntax.FromAssemblyContaining<IBotCommand>()
                .SelectAllClasses()
                .BindAllInterfaces()
                .Configure(conf => conf.InRequestScope()));
            Kernel.Bind(syntax => syntax.FromAssemblyContaining<IBotCommand>()
                .SelectAllClasses()
                .BindDefaultInterfaces()
                .Configure(conf => conf.InRequestScope()));

            Kernel.Unbind<IBot>();
            Kernel.Bind<IBot>()
                .To<RegistroPontoBot>()
                .WithConstructorArgument("token", BotConfiguration.Token)
                .WithConstructorArgument("webHookUrl", BotConfiguration.WebHook);
        }
    }
}
