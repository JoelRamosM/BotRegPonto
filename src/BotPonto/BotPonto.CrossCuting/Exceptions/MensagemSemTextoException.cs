namespace BotPonto.CrossCuting.Exceptions
{
    public class MensagemSemTextoException : BotPontoException
    {
        public MensagemSemTextoException(string message = "Desculpe, entendo apenas os comandos disponíveis.") : base(message) { }
    }
}
