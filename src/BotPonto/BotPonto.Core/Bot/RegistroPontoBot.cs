using System.Collections.Generic;
using System.Linq;
using BotPonto.Core.Interface;

namespace BotPonto.Core.Bot
{
    public class RegistroPontoBot : IBot
    {
        public Dictionary<string, IBotCommand> Commands { get; }

        public string Name => "Registro de Ponto Bot";
        public string Token { get; }
        public string WebHookUrl { get; }

        public RegistroPontoBot(string token, string webHookUrl, IEnumerable<IBotCommand> commands)
        {
            Token = token;
            WebHookUrl = webHookUrl;
            Commands = commands.ToDictionary(c => c.Command);
        }

        public void RunCommand(string chartId, string command, params string[] arguments) => Commands[command].Run(chartId, arguments);
    }
}
