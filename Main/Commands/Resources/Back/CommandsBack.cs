using Telegram.Bot;

namespace TelegramBotIsSimple.Main.Commands
{
    /// <summary>
    /// Команда "Назад"
    /// </summary>
    internal class CommandsBack : Commands
    {
        /// <summary>
        /// Команда "Назад"
        /// </summary>
        public CommandsBack() { }
        public override System.String Name { set; get; } = Buttons.Button.ButtonsBack;
        public override async void Execute(TelegramBotClient _client, long ChatId)
        {
            var button = new Buttons.Button();
            await _client.SendTextMessageAsync(ChatId, "Добро пожаловать в основное меню:", replyMarkup: button.DrawMainsMenuButtons());
        }
        public override Commands ParentsComands { set; get; } = null;

    }
}
