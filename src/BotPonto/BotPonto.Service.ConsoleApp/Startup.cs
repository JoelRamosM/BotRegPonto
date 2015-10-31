using System.Web.Http;
using BotPonto.IoC;
using Ninject.Web.WebApi.OwinHost;
using Owin;

namespace BotPonto.Service.ConsoleApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var webApiConfiguration = ConfigureWebApi();
            webApiConfiguration.DependencyResolver = new OwinNinjectDependencyResolver(NinjectCommom.CreateKernel());
            app.UseWebApi(webApiConfiguration);
        }

        private HttpConfiguration ConfigureWebApi()
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute("DefaultApi", "{controller}/{action}/{id}", new { id = RouteParameter.Optional });
            return config;
        }
    }
}
