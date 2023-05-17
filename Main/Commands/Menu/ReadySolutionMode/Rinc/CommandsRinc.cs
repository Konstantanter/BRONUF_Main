using Telegram.Bot;

namespace BRONUF_Main.Main.Commands.Menu.IndividualProject
{
    internal class CommandsRinc : Commands
    {
        /// <summary>
        /// Команда "Соавторство: статья РИНЦ"
        /// </summary>
        public CommandsRinc() { }
        public override System.String Name { set; get; } = Buttons.Button.ButtonsRinc;
        public override async void Execute(TelegramBotClient _client, long ChatId)
        {
            var button = new Buttons.Button();
            await _client.SendTextMessageAsync(ChatId, Buttons.Button.ButtonNotDevelop, Telegram.Bot.Types.Enums.ParseMode.Html, replyMarkup: null);
        }
        public override Commands ParentsComands { set; get; } = new CommandsChildMenu();
    }
}
