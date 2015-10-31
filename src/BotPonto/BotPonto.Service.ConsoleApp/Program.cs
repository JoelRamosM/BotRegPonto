using BotPonto.CrossCuting;
using Microsoft.Owin.Hosting;
using static System.Console;

namespace BotPonto.Service.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Informe o token do Telegram bot:");
            BotConfiguration.Token = ReadLine();
            string baseUri = "http://localhost:8080";

            StartWebHookServer(baseUri);
        }

        private static void StartWebHookServer(string baseUri)
        {
            BotConfiguration.WebHook = baseUri;
            WriteLine($"Iniciando servidor WebHook em : {baseUri}");
            WebApp.Start<Startup>(baseUri);
            WriteLine("Press key to stop..");
            ReadKey();
            WriteLine("Server has ended...");
            ReadKey();
        }
    }
}
