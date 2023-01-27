using Vocabulary_Telegram_Helper.Interfaces;
using Vocabulary_Telegram_Helper.Models;
using Vocabulary_Telegram_Helper.Repository;

namespace Vocabulary_Telegram_Helper.HandlerMessageStrategy
{
    public class GetAllHandler : IMessageHandler
    {
        public string ProcessMessage(string message)
        {
            string result = string.Empty;
            List<VocabularyModel> vocabularyModels = DBRepository.GetAllItems();

            vocabularyModels.ForEach(model =>
            {
                result += $"{model.Word} - {model.Translation}\n";
            });

            return string.IsNullOrEmpty(result) 
                   ? "Словарь пуст" 
                   : result;
        }
    }
}
