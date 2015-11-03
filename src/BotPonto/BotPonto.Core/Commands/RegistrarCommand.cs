using System.Threading.Tasks;
using BotPonto.Core.Interface;
using Telegram.Bot.Types;

namespace BotPonto.Core.Commands
{
    public class RegistrarCommand : IBotCommand
    {
        public string Command => "/registrar";

        public string Run(Update update)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> RunAsync(Update update)
        {
            throw new System.NotImplementedException();
        }
    }
}
