using Telegram.Bot;

namespace BRONUF_Main.Main.Commands.Menu.IndividualProject
{
    /// <summary>
    /// Команда "Соавторство: патент на ТИМС"
    /// </summary>
    internal class CommandsPatentTIMS : Commands
    {
        /// <summary>
        /// Команда "Соавторство: патент на ТИМС"
        /// </summary>
        public CommandsPatentTIMS() { }
        public override System.String Name { set; get; } = Buttons.Button.ButtonsPatentTIMS;
        public override async void Execute(TelegramBotClient _client, long ChatId)
        {
            var button = new Buttons.Button();
            await _client.SendTextMessageAsync(ChatId, Buttons.Button.ButtonNotDevelop, Telegram.Bot.Types.Enums.ParseMode.Html, replyMarkup: null);
        }
        public override Commands ParentsComands { set; get; } = new CommandsChildMenu();
    }
}
