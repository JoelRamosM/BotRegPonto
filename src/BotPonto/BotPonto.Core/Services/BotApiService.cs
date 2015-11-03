using System;
using BotPonto.Core.Interface.Services;
using Telegram.Bot;

namespace BotPonto.Core.Services
{
    public class BotApiService : IBotApiService
    {
        private Api _api;

        public BotApiService(string token)
        {
            if (string.IsNullOrEmpty(token)) throw new ArgumentException("Token é necessário, para a comunicação com a API.");
            _api = new Api(token);
        }

        public void SetWebHook(string url) => _api.SetWebhook(url).Wait();

        public void EnviarMensagem(long chatId, string mensagem) => _api.SendTextMessage((int)chatId, mensagem).Wait();
    }
}
