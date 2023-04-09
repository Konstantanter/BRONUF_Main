using Telegram.Bot;


namespace TelegramBotIsSimple.Main.Commands.Menu.IndividualProject
{
    /// <summary>
    /// Команда "Заявка на базу данных"
    /// </summary>
    internal class CommandsApplicationDataBase : Commands
    {
        /// <summary>
        /// Команда "Заявка на базу данных"
        /// </summary>
        public CommandsApplicationDataBase() { }
        public override System.String Name { set; get; } = Buttons.Button.ButtonsApplicationDataBase;
        public override async void Execute(TelegramBotClient _client, long ChatId)
        {
            var button = new Buttons.Button();
            await _client.SendTextMessageAsync(ChatId, Buttons.Button.ButtonNotDevelop, Telegram.Bot.Types.Enums.ParseMode.Html, replyMarkup: null);
        }
        public override Commands ParentsComands { set; get; } = new CommandsChildMenu();
    }
}
