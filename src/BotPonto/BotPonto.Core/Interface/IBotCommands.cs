namespace BotPonto.Core.Interface
{
    public interface IBotCommands
    {
        IBotCommand this[string command] { get; }
    }
}
