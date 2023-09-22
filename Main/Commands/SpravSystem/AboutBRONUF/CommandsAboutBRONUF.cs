using Telegram.Bot;
using BRONUF_Main.Main.Buttons;

namespace BRONUF_Main.Main.Commands
{
    /// <summary>
    /// Команда "О проекте"
    /// </summary>
    internal class CommandsAboutBRONUF : Commands
    {
        /// <summary>
        /// Команда "О проекте"
        /// </summary>
        public CommandsAboutBRONUF() { }
        public override string Name { set; get; } = Buttons.Button.ButtonsAboutBRONUF;
        public override async void Execute(TelegramBotClient _client, long ChatId)
        {
            var button = new Button();
            await _client.SendTextMessageAsync(ChatId, Button.DataAboutProject, Telegram.Bot.Types.Enums.ParseMode.Html, replyMarkup: button.DrawSpravSystemMenu());
        }
        public override Commands ParentsComands { set; get; } = new CommandsChildMenu();
    }
}
