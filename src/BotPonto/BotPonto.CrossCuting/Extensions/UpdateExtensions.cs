using System.Linq;
using Telegram.Bot.Types;

namespace BotPonto.CrossCuting.Extensions
{
    public static class UpdateExtensions
    {

        public static string Command(this Update update) => !update.IsCommand() ? "" : update.Message.Text.Split(' ')[0];

        public static string[] Arguments(this Update update)
            => !update.IsCommand() ? new string[0] : update.Message.Text.Split(' ').SkipWhile((x, i) => i == 0).ToArray();

        public static long ChatId(this Update update) => update.Message.Chat.Id;

        public static bool IsCommand(this Update update) =>
            update.Message.Type == MessageType.TextMessage && update.Message.Text.StartsWith("/");


    }
}
