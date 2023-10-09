using Telegram.Bot;
using BRONUF_Main.Main.Buttons;

namespace BRONUF_Main.Main.Commands
{
    //// <summary>
    /// Команда "Меню инструкция по использованию"
    /// </summary>
    internal class CommandsInstructionMenu : Commands
    {
        /// <summary>
        /// Команда "Меню инструкция по использованию"
        /// </summary>
        public CommandsInstructionMenu() { }
        public override System.String Name { set; get; } = Buttons.Button.ButtonsInstructionMenu;
        public override async void Execute(TelegramBotClient _client, long ChatId)
        {
            var button = new Button();
            await _client.SendTextMessageAsync(ChatId, "В данном разделе Вы можете получить ответы и инструкции по использованию нашего бота", Telegram.Bot.Types.Enums.ParseMode.Html, replyMarkup: button.DrawInstructionMenu());
        }
        public override Commands ParentsComands { set; get; } = new CommandSpravSystemMenu();
    }
}
