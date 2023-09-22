using Telegram.Bot;

namespace BRONUF_Main.Main.Commands
{
    /// <summary>
    /// Команда для отрисовки меню "Научные труды что и для чего?"
    /// </summary>
    internal class CommandsScientificPapersMenu : Commands
    {
        /// <summary>
        /// Команда для отрисовки меню "Научные труды что и для чего?"
        /// </summary>
        public CommandsScientificPapersMenu() { }
        public override string Name { set; get; } = Buttons.Button.ButtonsScientificPapersHelp;
        public override async void Execute(TelegramBotClient _client, long ChatId)
        {
            Buttons.Button button = new Buttons.Button();
            await _client.SendTextMessageAsync(ChatId, "Добро пожаловать в меню \"ℹ️ Научные труды: что и для чего?\":", replyMarkup: button.DrawScientificPapersHelpMenu());
        }
        public override Commands ParentsComands { set; get; } = new CommandSpravSystemMenu();
    }
}
