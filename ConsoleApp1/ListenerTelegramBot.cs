using Telegram.Bot.Polling;
using Telegram.Bot;
using Telegram.Bot.Types;
using Vocabulary_Telegram_Helper.Interfaces;
using Vocabulary_Telegram_Helper.HandlerMessageStrategy;

class ListenerTelegramBot
{
    private static ITelegramBotClient bot;
    private static List<long> AccessUser;

    /// <summary>
    /// Запуск слушателя telegramBot
    /// </summary>
    public static void Start(string telegramToken, List<long> accessUser)
    {
        bot = new TelegramBotClient(telegramToken);
        AccessUser = accessUser;
        Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);

        var cts = new CancellationTokenSource();
        var cancellationToken = cts.Token;
        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = { },
        };
        bot.StartReceiving(
            HandleUpdateAsync,
            HandleErrorAsync,
            receiverOptions,
            cancellationToken
        );
    }


    /// <summary>
    /// Сам слушателель
    /// </summary>
    /// <param name="botClient"></param>
    /// <param name="update"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
        {
            Message message = update.Message;
            Console.WriteLine($"[{message.Chat.LastName} {message.Chat.FirstName} {message.Chat.Id}]: {message.Text}");

            if (!AccessUser.Contains(message.Chat.Id))
            {
                await botClient.SendTextMessageAsync(message.Chat, "У Вас нет доступа к этому боту!!!");
            }
            else
            {
                IMessageHandler messageHandler = MessageHandlerDistribution.Distribution(message.Text);
                string answer = messageHandler.ProcessMessage(message.Text);
                await botClient.SendTextMessageAsync(message.Chat, answer);
            }
        }
    }


    /// <summary>
    /// Обработчик ошибок
    /// </summary>
    /// <param name="botClient"></param>
    /// <param name="exception"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken) =>
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
}
