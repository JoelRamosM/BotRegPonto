using System.Collections.Generic;

namespace BotPonto.Core.Interface
{
    public interface IBot
    {
        Dictionary<string, IBotCommand> Commands { get; }
        string Name { get; }
        string Token { get; }
        string WebHookUrl { get; }

        void RunCommand(string chartId, string command, params string[] arguments);

    }
}
