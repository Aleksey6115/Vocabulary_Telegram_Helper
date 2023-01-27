using Vocabulary_Telegram_Helper.Interfaces;

namespace Vocabulary_Telegram_Helper.HandlerMessageStrategy
{
    public class MessageHandlerDistribution
    {
        public static IMessageHandler Distribution(string message)
        {
            if (message == "/all") return new GetAllHandler();
            else if (message == "/deletelast") return new DeleteHandler();
            else if (message.Contains("-")) return new InsertHandler();
            else return new DeffaultHandler();
        }
    }
}
