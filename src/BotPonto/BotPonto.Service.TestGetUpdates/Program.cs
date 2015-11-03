using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using static System.Console;

namespace BotPonto.Service.TestGetUpdates
{
    class Program
    {
        private static Api api;
        private static string token;

        static void Main(string[] args)
        {
            WriteLine("Informe o token do bot:");
            token = ReadLine();
            WriteLine("Iniciando");
            Run().Wait();
        }

        static async Task Run()
        {
            api = new Api(token);
            var bot = await api.GetMe();

            WriteLine($"Bot: {bot.Username}");

            var offset = 0;

            while (true)
            {
                Enumerable.Range(0, 4).ToList().ForEach(x => WriteLine(""));
                WriteLine("Getting updates!");
                var updates = await api.GetUpdates(offset);
                updates.ToList().ForEach(up => TratarUpdate(up, ref offset));
                WriteLine("Waiting!");
                await Task.Delay(2000);
            }
        }

        private static void TratarUpdate(Update update, ref int offset)
        {
            var message = update.Message;
            WriteLine($"Mensagem recebida!");
            WriteLine($"Id: {message.MessageId} | Message type: {message.Type} | Message: {message.Text} | from: {message.Chat.Username}");
            api.SendTextMessage(message.Chat.Id, $"Olá {message.Chat.FirstName}, recebi sua mensagem X)");
            offset = update.Id + 1;
        }
    }

}
