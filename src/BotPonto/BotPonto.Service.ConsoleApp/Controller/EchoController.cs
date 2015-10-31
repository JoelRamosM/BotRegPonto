using System.Web.Http;
using BotPonto.Core.Interface;

namespace BotPonto.Service.ConsoleApp.Controller
{
    public class EchoController : ApiController
    {
        private readonly IBot _bot;

        public EchoController(IBot bot)
        {
            _bot = bot;
        }

        [HttpGet]
        public string Echo()
        {
           _bot.RunCommand("1", "register");
            return "Teste";
        }
    }
}
