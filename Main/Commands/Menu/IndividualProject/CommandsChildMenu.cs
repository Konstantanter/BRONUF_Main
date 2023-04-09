using Telegram.Bot;

namespace TelegramBotIsSimple.Main.Commands.Menu.IndividualProject
{
    /// <summary>
    /// Команда для отрисовки основоного (дочернего) меню
    /// </summary>
    internal class CommandsChildMenu : Commands
    {
        /// <summary>
        /// Команда для отрисовки основоного (дочернего) меню
        /// </summary>
        public CommandsChildMenu() { }
        public override System.String Name { set; get; } = Buttons.Button.ButtonsMainsMenu;
        public override async void Execute(TelegramBotClient _client, long ChatId)
        {
            var button = new Buttons.Button();
            await _client.SendTextMessageAsync(ChatId, "Объяснение что за режим", Telegram.Bot.Types.Enums.ParseMode.Html, replyMarkup: button.DrawIndividualMenu());
        }
        public override Commands ParentsComands { set; get; } = new CommandsDrawMainsMenu();
    }
}
