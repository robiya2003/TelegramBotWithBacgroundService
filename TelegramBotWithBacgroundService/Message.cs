using Telegram.Bot.Polling;
using Telegram.Bot;

namespace TelegramBotWithBacgroundService
{
    public class Message: BackgroundService
    {
        private readonly TelegramBotClient client;
        private readonly IUpdateHandler updateHandler;

        public Message(TelegramBotClient client, IUpdateHandler updateHandler)
        {
            this.client = client;
            this.updateHandler = updateHandler;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await client.SendTextMessageAsync(
                    chatId: 1633746526,
                    text: "Iya",
                    cancellationToken: stoppingToken
                );

                await Task.Delay(1000);
            }
        }
    }
}
