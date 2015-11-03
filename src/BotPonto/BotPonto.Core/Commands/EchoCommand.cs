using System.Threading.Tasks;
using BotPonto.Core.Interface;
using Telegram.Bot.Types;

namespace BotPonto.Core.Commands
{
    public class EchoCommand : IBotCommand
    {
        public string Command => "/echo";
        public string Run(Update update) => $"OLA...OLa....Ola.....ola....{update.Message.Chat.FirstName}";

        public Task<string> RunAsync(Update update) => Task.Run(() => $"OLA...OLa....Ola.....ola....{update.Message.Chat.FirstName}");

    }
}
