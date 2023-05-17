using Telegram.Bot;

namespace BRONUF_Main.Main.Commands.Menu.IndividualProject
{
    /// <summary>
    /// Команда "Соавторство: статья Scopus"
    /// </summary>
    internal class CommandsScopus : Commands
    {
        /// <summary>
        /// Команда "Соавторство: статья Scopus"
        /// </summary>
        public CommandsScopus() { }
        public override System.String Name { set; get; } = Buttons.Button.ButtonsScopus;
        public override async void Execute(TelegramBotClient _client, long ChatId)
        {
            var button = new Buttons.Button();
            await _client.SendTextMessageAsync(ChatId, Buttons.Button.ButtonNotDevelop, Telegram.Bot.Types.Enums.ParseMode.Html, replyMarkup: null);
        }
        public override Commands ParentsComands { set; get; } = new CommandsChildMenu();
    }
}
