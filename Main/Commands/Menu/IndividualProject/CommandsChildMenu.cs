using Telegram.Bot;
using BRONUF_Main.Main.Buttons;


namespace BRONUF_Main.Main.Commands
{
    /// <summary>
    /// Команда для отрисовки основоного (дочернего) меню
    /// </summary>
    internal class CommandsChildMenu : Commands
    {
        /// <summary>
        /// Команда для отрисовки основоного (дочернего) меню
        /// </summary>
        public CommandsChildMenu() { }
        public override string Name { set; get; } = Button.ButtonsMainsMenu;
        public override async void Execute(TelegramBotClient _client, long ChatId)
        {
            Button button = new Button();
            await _client.SendTextMessageAsync(ChatId, "Объяснение что за режим", Telegram.Bot.Types.Enums.ParseMode.Html, replyMarkup: button.DrawIndividualMenu());
        }
        public override Commands ParentsComands { set; get; } = new CommandsDrawMainsMenu();
    }
}
