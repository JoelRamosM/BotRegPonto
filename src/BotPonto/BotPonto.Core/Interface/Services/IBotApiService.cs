namespace BotPonto.Core.Interface.Services
{
    public interface IBotApiService
    {
        void SetWebHook(string url);
        void EnviarMensagem(long chatId, string mensagem);
    }
}