using Vocabulary_Telegram_Helper.Interfaces;
using Vocabulary_Telegram_Helper.Models;
using Vocabulary_Telegram_Helper.Repository;

namespace Vocabulary_Telegram_Helper.HandlerMessageStrategy
{
    public class DeleteHandler : IMessageHandler
    {
        public string ProcessMessage(string message)
        {
            List<VocabularyModel> vocabularyModels = DBRepository.GetAllItems();

            if (vocabularyModels.Any())
            {
                DBRepository.DeleteItem(vocabularyModels.Last().Id);
            }
            
            return vocabularyModels.Any() ? "Последняя запись удалена" : "Словарь пока пуст";
        }
    }
}
