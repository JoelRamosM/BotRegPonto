using Telegram.Bot.Types;

namespace BotPonto.CrossCuting.Interfaces
{
    public interface ITelegramMessage
    {
        Update Update { get; }
        long ChatId { get; }
        string NomeUsuario { get; }
        string Comando { get; }
        string[] Argumentos { get; }
        string Mensagem { get; }
        bool EhComando { get; }
    }
}
