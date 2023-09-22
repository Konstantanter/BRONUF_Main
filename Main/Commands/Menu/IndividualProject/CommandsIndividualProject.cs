using Telegram.Bot;

namespace BRONUF_Main.Main.Commands.Menu.IndividualProject
{
    /// <summary>
    /// Команда "Заказать индивидуальный проект"
    /// </summary>
    internal class CommandsIndividualProject : Commands
    {
        /// <summary>
        /// Команда "Заказать индивидуальный проект"
        /// </summary>
        public CommandsIndividualProject() {}
        /// <summary>
        /// Переопределение имени команды
        /// </summary>
        public override System.String Name { set; get; } = Buttons.Button.ButtonsIndividualProject;
        public override async void Execute(TelegramBotClient _client, long ChatId)
        {
            var button = new Buttons.Button();
            await _client.SendTextMessageAsync(ChatId, Buttons.Button.ButtonNotDevelop, Telegram.Bot.Types.Enums.ParseMode.Html, replyMarkup: button.DrawIndividualMenu());
        }
        public override Commands ParentsComands { set; get; } = new CommandsChildMenu();
    }
}
