using BotPonto.Core.Bot;
using BotPonto.Core.Interface;
using BotPonto.Core.Interface.Services;
using BotPonto.Core.Services;
using BotPonto.CrossCuting;
using Ninject.Extensions.Conventions;
using Ninject.Modules;
using Ninject.Web.Common;

namespace BotPonto.IoC.Installers
{
    public class DefaulWebModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(syntax => syntax.FromAssemblyContaining<IBotCommand>()
                .SelectAllClasses()
                .BindAllInterfaces()
                .Configure(conf => conf.InRequestScope()));
            Kernel.Unbind<IBot>();
            Kernel.Unbind<IBotApiService>();

            Kernel.Bind<IBotApiService>()
                .To<BotApiService>().InRequestScope()
                .WithConstructorArgument("token", BotConfiguration.Token);

            Kernel.Bind<IBot>()
                .To<RegistroPontoBot>()
                .InRequestScope()
                .WithConstructorArgument("token", BotConfiguration.Token)
                .WithConstructorArgument("webHookUrl", BotConfiguration.WebHook);
        }
    }
}
