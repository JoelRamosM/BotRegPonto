using System;

namespace BotPonto.CrossCuting.Exceptions
{
    public class BotPontoException : Exception
    {
        public BotPontoException(string mensagem) : base(mensagem) { }
    }
}
