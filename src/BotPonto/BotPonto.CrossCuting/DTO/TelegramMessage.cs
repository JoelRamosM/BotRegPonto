using BotPonto.CrossCuting.Extensions;
using BotPonto.CrossCuting.Interfaces;
using Telegram.Bot.Types;

namespace BotPonto.CrossCuting.DTO
{
    public class TelegramMessage : ITelegramMessage
    {
        public Update Update { get; }

        public TelegramMessage(Update update)
        {
            Update = update;
        }

        public long ChatId => Update.Message.Chat.Id;

        public string NomeUsuario => Update.Message.Chat.Username;

        public string Comando => Update.Command();

        public string[] Argumentos => Update.Arguments();

        public string Mensagem => Update.Message.Text;

        public bool EhComando => Update.IsCommand();
    }
}
