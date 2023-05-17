using Telegram.Bot;

namespace BRONUF_Main.Main.Commands.Menu.IndividualProject
{
    /// <summary>
    /// Комманда "Заявка на изобретение"
    /// </summary>
    internal class CommandsApplicationInvention : Commands
    {
        /// <summary>
        /// Комманда "Заявка на изобретение"
        /// </summary>
        public CommandsApplicationInvention() { }
        public override System.String Name { set; get; } = Buttons.Button.ButtonsApplicatinInvention;
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
