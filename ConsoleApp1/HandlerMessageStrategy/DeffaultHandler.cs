using Vocabulary_Telegram_Helper.Interfaces;

namespace Vocabulary_Telegram_Helper.HandlerMessageStrategy
{
    public class DeffaultHandler : IMessageHandler
    {
        public string ProcessMessage(string message) => "Я не знаю такой команды";
    }
}
