using Telegram.Bot;

namespace BRONUF_Main.Main.Commands.Menu.IndividualProject
{
    /// <summary>
    /// Команда "Заказать индивидуальный проект"
    /// </summary>
    internal class CommandSpravSystemMenu : Commands
    {
        /// <summary>
        /// Команда "Справочная система"
        /// </summary>
        public  CommandSpravSystemMenu(){ }
        public override System.String Name { set; get; } = Buttons.Button.ButtonsSpravSystem;
        public override async void Execute(TelegramBotClient _client, long ChatId)
        {
            var button = new Buttons.Button();
            await _client.SendTextMessageAsync(ChatId, "Справочное меню", Telegram.Bot.Types.Enums.ParseMode.Html, replyMarkup: button.DrawSpravSystemMenu());
        }
        public override Commands ParentsComands { set; get; } = new CommandsChildMenu();
    }
}
