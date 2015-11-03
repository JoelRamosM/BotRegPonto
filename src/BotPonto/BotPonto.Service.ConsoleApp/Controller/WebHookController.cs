using System.Threading.Tasks;
using System.Web.Http;
using BotPonto.Core.Interface;
using BotPonto.CrossCuting.DTO;
using Telegram.Bot.Types;

namespace BotPonto.Service.ConsoleApp.Controller
{
    public class WebHookController : ApiController
    {
        private readonly IBot _bot;

        public WebHookController(IBot bot)
        {
            _bot = bot;
        }

        public async Task<IHttpActionResult> Post(Update update)
        {
            _bot.RunCommandAsync(new TelegramMessage(update));
            return Ok();
        }
    }
}
