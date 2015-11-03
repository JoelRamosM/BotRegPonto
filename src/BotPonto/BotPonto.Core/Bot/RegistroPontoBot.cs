using System.Diagnostics;
using System.Threading.Tasks;
using BotPonto.Core.Interface;
using BotPonto.Core.Interface.Services;
using BotPonto.CrossCuting.Exceptions;
using BotPonto.CrossCuting.Interfaces;

namespace BotPonto.Core.Bot
{
    public class RegistroPontoBot : IBot
    {
        private readonly IBotApiService _apiService;
        private readonly IBotCommands _comandos;

        public string Name => "RegistroPontoBot";
        public string Token { get; }
        public string WebHookUrl { get; }


        public RegistroPontoBot(string token, string webHookUrl, IBotApiService apiService, IBotCommands comandos)
        {
            _apiService = apiService;
            _comandos = comandos;
            Token = token;
            WebHookUrl = webHookUrl;
        }

        public void RunCommand(ITelegramMessage message)
        {
            try
            {
                var result = _comandos[message.Comando].Run(message.Update);
                NotifyChat(message.ChatId, result);
            }
            catch (ComandoInexistenteException e)
            {
                Trace.WriteLine(e.Message);
                NotifyChat(message.ChatId, e.Message);
            }
        }

        public async Task RunCommandAsync(ITelegramMessage message)
        {
            try
            {
                var result = await _comandos[message.Comando].RunAsync(message.Update);
                NotifyChat(message.ChatId, result);
            }
            catch (ComandoInexistenteException e)
            {
                Trace.WriteLine(e.Message);
                NotifyChat(message.ChatId, e.Message);
            }
        }

        public void NotifyChat(long chatId, string message) => _apiService.EnviarMensagem(chatId, message);

        public void ConfigureWebHook() => _apiService.SetWebHook(WebHookUrl);
    }
}
