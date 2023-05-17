using Telegram.Bot;

namespace BRONUF_Main.Main.Commands.Menu.IndividualProject
{
    /// <summary>
    /// "Соавторство: статья не РИНЦ"
    /// </summary>
    internal class CommandsNotRinc: Commands
    {
        /// <summary>
        /// "Соавторство: статья не РИНЦ"
        /// </summary>
        public CommandsNotRinc() { }
        public override System.String Name { set; get; } = Buttons.Button.ButtonsNotRinc;
        public override async void Execute(TelegramBotClient _client, long ChatId)
        {
            var button = new Buttons.Button();
            await _client.SendTextMessageAsync(ChatId, Buttons.Button.ButtonNotDevelop, Telegram.Bot.Types.Enums.ParseMode.Html, replyMarkup: null);
        }
        public override Commands ParentsComands { set; get; } = new CommandsChildMenu();
    }
}
