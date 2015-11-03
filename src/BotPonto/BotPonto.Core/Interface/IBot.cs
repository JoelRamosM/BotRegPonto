using System.Threading.Tasks;
using BotPonto.CrossCuting.Interfaces;

namespace BotPonto.Core.Interface
{
    public interface IBot
    {
        string Name { get; }
        string Token { get; }
        string WebHookUrl { get; }

        void RunCommand(ITelegramMessage message);
        Task RunCommandAsync(ITelegramMessage message);
        void NotifyChat(long chatId, string message);
        void ConfigureWebHook();
    }
}
