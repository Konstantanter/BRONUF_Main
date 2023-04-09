using Telegram.Bot;

namespace TelegramBotIsSimple.Main.Commands.Menu.IndividualProject
{
    /// <summary>
    /// Команда "Оформить заявку: схема (ТИМС)"
    /// </summary>
    internal class CommandsApplicationScheme : Commands
    {
        /// <summary>
        /// Команда "Оформить заявку: схема (ТИМС)"
        /// </summary>
        public CommandsApplicationScheme() { }
        public override System.String Name { set; get; } = Buttons.Button.ButtonsApplicationScheme;
        public override async void Execute(TelegramBotClient _client, long ChatId)
        {
            var button = new Buttons.Button();
            await _client.SendTextMessageAsync(ChatId, Buttons.Button.ButtonNotDevelop, Telegram.Bot.Types.Enums.ParseMode.Html, replyMarkup: null);
        }
        public override Commands ParentsComands { set; get; } = new CommandsChildMenu();
    }
}
