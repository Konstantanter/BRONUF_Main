using Telegram.Bot;
using BRONUF_Main.Main.Buttons;

namespace BRONUF_Main.Main.Commands
{
    /// <summary>
    /// Команда "Поддержка"
    /// </summary>
    internal class CommandsSupport : Commands
    {
        /// <summary>
        /// Команда "Поддержка"
        /// </summary>
        public CommandsSupport() { }
        public override System.String Name { set; get; } = Buttons.Button.ButtonsSupport;
        public override async void Execute(TelegramBotClient _client, long ChatId)
        {
            var button = new Button();
            await _client.SendTextMessageAsync(ChatId, Button.ButtonNotDevelop, Telegram.Bot.Types.Enums.ParseMode.Html, replyMarkup: button.DrawSpravSystemMenu());
        }
        public override Commands ParentsComands { set; get; } = new CommandsChildMenu();
    }
}
