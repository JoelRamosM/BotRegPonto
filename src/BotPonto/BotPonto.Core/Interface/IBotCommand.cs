using System.Threading.Tasks;

namespace BotPonto.Core.Interface
{
    public interface IBotCommand
    {
        string Command { get; }

        void Run(string chartId, params string[] arguments);
        Task RunAsync(string chartId, params string[] arguments);
    }
}
