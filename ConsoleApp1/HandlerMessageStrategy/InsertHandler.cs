using Vocabulary_Telegram_Helper.Interfaces;
using Vocabulary_Telegram_Helper.Repository;
using Vocabulary_Telegram_Helper.Models;

namespace Vocabulary_Telegram_Helper.HandlerMessageStrategy
{
    public class InsertHandler : IMessageHandler
    {
        public string ProcessMessage(string message)
        {
            string[] splitMessage = message.Split('-');
            DBRepository.SetItem(new VocabularyModel()
            {
                Word = splitMessage.First(),
                Translation = splitMessage.Last(),
            });

            return "Новое слово успешно добавлено в словарь";
        }
    }
}
