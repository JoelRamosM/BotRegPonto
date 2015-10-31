using Microsoft.Owin.Hosting;

namespace BotPonto.Service.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseUri = "http://localhost:8080";
            WebApp.Start<Startup>(baseUri);
        }
    }
}
