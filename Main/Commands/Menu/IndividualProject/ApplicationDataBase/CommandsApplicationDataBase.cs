using Telegram.Bot;


namespace BRONUF_Main.Main.Commands.Menu.IndividualProject
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
        /// <summary>
        /// Переопределение имени команды
        /// </summary>
        public override string Name { set; get; } = Buttons.Button.ButtonsApplicationDataBase;
        /// <summary>
        /// Переопределение исполнения команды
        /// </summary>
        public override async void Execute(TelegramBotClient _client, long ChatId)
        {
            Buttons.Button button = new Buttons.Button();
            await _client.SendTextMessageAsync(ChatId, Buttons.Button.ButtonNotDevelop, Telegram.Bot.Types.Enums.ParseMode.Html, replyMarkup: null);
        }
        public override Commands ParentsComands { set; get; } = new CommandsChildMenu();
    }
}
