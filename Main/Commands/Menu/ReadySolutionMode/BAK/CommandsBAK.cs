using Telegram.Bot;

namespace TelegramBotIsSimple.Main.Commands.Menu.IndividualProject
{
    /// <summary>
    /// Комманда "Соавторство: статья ВАК"
    /// </summary>
    internal class CommandsBAK : Commands
    {
        /// <summary>
        /// Комманда "Соавторство: статья ВАК"
        /// </summary>
        public CommandsBAK() { }
        public override System.String Name { set; get; } = Buttons.Button.ButtonsBAK;
        public override async void Execute(TelegramBotClient _client, long ChatId)
        {
            var button = new Buttons.Button();
            await _client.SendTextMessageAsync(ChatId, Buttons.Button.ButtonNotDevelop, Telegram.Bot.Types.Enums.ParseMode.Html, replyMarkup: null);
        }

        public override Commands ParentsComands { set; get; } = new CommandsChildMenu();
    }
}
