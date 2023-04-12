using Telegram.Bot;

namespace TelegramBotIsSimple.Main.Commands.Menu.SearchScientificPapers
{
    /// <summary>
    /// Команда  "Режим поиска научных трудов"
    /// </summary>
    internal class CommandsSearchScientificPaper : Commands
    {
        /// <summary>
        /// Команда  "Режим поиска научных трудов"
        /// </summary>
        public CommandsSearchScientificPaper() { }
        public override System.String Name { set; get; } = Buttons.Button.ButtonsSearchScientificPapers;
        public override async void Execute(TelegramBotClient _client, long ChatId)
        {
            var button = new Buttons.Button();
         
            await _client.SendTextMessageAsync(ChatId, "Данный режим предназначен для формирования формы научных трудов, поиска и формирования дубликатов и др.", Telegram.Bot.Types.Enums.ParseMode.Html, replyMarkup: button.DrawScientificPapersMenu());
        }
        public override Commands ParentsComands { set; get; } = new CommandsMainsMenu();
    }
}
