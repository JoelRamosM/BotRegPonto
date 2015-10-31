using System.Collections.Generic;

namespace BotPonto.Core.Interface
{
    public interface IBotCommand
    {
        string Command { get; }
        List<string> Parameters { get; }
    }
}
