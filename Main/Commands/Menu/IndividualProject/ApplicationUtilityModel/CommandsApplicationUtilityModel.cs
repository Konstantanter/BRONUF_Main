using Telegram.Bot;

namespace BRONUF_Main.Main.Commands.Menu.IndividualProject
{
    /// <summary>
    /// Комманда "Оформить заявку: полез. модель"
    /// </summary>
    internal class CommandsApplicationUtilityModel : Commands
    {
        /// <summary>
        /// Комманда "Оформить заявку: полез. модель"
        /// </summary>
        public CommandsApplicationUtilityModel() { }
        public override System.String Name { set; get; } = Buttons.Button.ButtonsApplicationUtilityModel;
        public override async void Execute(TelegramBotClient _client, long ChatId)
        {
            var button = new Buttons.Button();
            await _client.SendTextMessageAsync(ChatId, Buttons.Button.ButtonNotDevelop, Telegram.Bot.Types.Enums.ParseMode.Html, replyMarkup: null);
        }
        public override Commands ParentsComands { set; get; } = new CommandsMainsMenu();
    }
}
