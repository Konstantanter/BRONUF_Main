using Telegram.Bot;

namespace TelegramBotIsSimple.Main.Commands.Menu.IndividualProject
{
    /// <summary>
    /// Команда "Оформить заявку: Программа"
    /// </summary>
    internal class CommansApplicationProgramm: Commands
    {
        /// <summary>
        /// Команда "Оформить заявку: Программа"
        /// </summary>
        public CommansApplicationProgramm() { }
        public override System.String Name { set; get; } = Buttons.Button.ButtonsApplicationProgramm;
        public override async void Execute(TelegramBotClient _client, long ChatId)
        {
            var button = new Buttons.Button();
            await _client.SendTextMessageAsync(ChatId, Buttons.Button.ButtonNotDevelop, Telegram.Bot.Types.Enums.ParseMode.Html, replyMarkup: null);
        }
        /// <summary>
        /// Родительская команда данной команды это дочернее меню
        /// </summary>
        public override Commands ParentsComands { set; get; } = new CommandsChildMenu();
    }
}
