using System.Threading.Tasks;
using BotPonto.Core.Interface;

namespace BotPonto.Core.Commands
{
    public class RegisterCommand : IBotCommand
    {
        public string Command => "register";
        public void Run(string chartId, params string[] arguments)
        {
            throw new System.NotImplementedException();
        }

        public Task RunAsync(string chartId, params string[] arguments)
        {
            throw new System.NotImplementedException();
        }
    }
}
