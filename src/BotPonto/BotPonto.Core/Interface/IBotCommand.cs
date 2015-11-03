using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace BotPonto.Core.Interface
{
    public interface IBotCommand
    {
        string Command { get; }

        string Run(Update update);

        Task<string> RunAsync(Update update);
    }
}
