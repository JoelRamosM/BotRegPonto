using BotPonto.Core.Interface;
using BotPonto.CrossCuting;
using BotPonto.IoC;
using Microsoft.Owin.Hosting;
using Ninject;
using static System.Console;

namespace BotPonto.Service.ConsoleApp
{
    class Program
    {
        private static string url;

        static void Main(string[] args)
        {
            WriteLine("Informe o token do Telegram bot:");
            BotConfiguration.Token = ReadLine();
            WriteLine("Informe URL do servidor WebHook:");
            url = ReadLine();
            WriteLine("O servidor web hook respondera na porta 8443, portanto não esqueça de libera-a no firewall. X)");
            StartWebHookServer();
        }


        private static void StartWebHookServer()
        {
            BotConfiguration.WebHook = url;
            WriteLine($"Iniciando servidor WebHook em : {BotConfiguration.WebHook}");
            WebApp.Start<Startup>("http://localhost:8443/");
            var bot = NinjectCommom.Kernel.Get<IBot>();
#if !DEBUG
                bot.ConfigureWebHook();
#endif
            BotConfiguration.WebHookConfigured = true;
            WriteLine("Press key to stop..");
            ReadKey();
            WriteLine("Server has ended...");
            ReadKey();
        }
    }
}
