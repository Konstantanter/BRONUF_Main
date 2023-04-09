using Telegram.Bot;

namespace TelegramBotIsSimple.Main.Commands.Menu.IndividualProject
{
    /// <summary>
    /// Команда "Главное меню"
    /// </summary>
    internal class CommandsDrawMainsMenu : Commands
    {
        /// <summary>
        /// Команда "Главное меню"
        /// </summary>
        public CommandsDrawMainsMenu() { }
        public override System.String Name { set; get; } = "Главное меню";
        public override async void Execute(TelegramBotClient _client, long ChatId)
        {
            var button = new Buttons.Button();
            await _client.SendTextMessageAsync(ChatId, "Приветствую в главном меню", Telegram.Bot.Types.Enums.ParseMode.Html, replyMarkup: button.DrawMainsMenuButtons());
        }
        public override Commands ParentsComands { set; get; } = null;
    }
}
