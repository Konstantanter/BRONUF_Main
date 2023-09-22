using Telegram.Bot;
using BRONUF_Main.Main.Buttons;

namespace BRONUF_Main.Main.Commands
{
    /// <summary>
    /// Команда "О Нас"
    /// </summary>
    internal class CommandsAboutOur : Commands
    {
        /// <summary>
        /// Команда "О Нас"
        /// </summary>
        public CommandsAboutOur() { }
        public override System.String Name { set; get; } = Buttons.Button.ButtonsAboutOur;
        public override async void Execute(TelegramBotClient _client, long ChatId)
        {
            var button = new Button();
            await _client.SendTextMessageAsync(ChatId, Button.DataAboutOur, Telegram.Bot.Types.Enums.ParseMode.Html, replyMarkup: button.DrawSpravSystemMenu());
        }
        public override Commands ParentsComands { set; get; } = new CommandsChildMenu();
    }
}
