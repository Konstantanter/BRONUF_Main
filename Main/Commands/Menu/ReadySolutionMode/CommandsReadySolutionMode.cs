using System.Threading.Tasks;
using Telegram.Bot;

namespace TelegramBotIsSimple.Main.Commands.Menu.IndividualProject
{
    /// <summary>
    /// Команда "Режим готовых решений"
    /// </summary>
    internal class CommandsReadySolutionMode : Commands
    {
        /// <summary>
        /// Команда "Режим готовых решений"
        /// </summary>
        public CommandsReadySolutionMode() { }
        public override System.String Name { set; get; } = Buttons.Button.ButtonsReadySolution;
        public override async void Execute(TelegramBotClient _client, long ChatId)
        {
            var button = new Buttons.Button();
           
            await _client.SendTextMessageAsync(ChatId, "Это режим готовых решений", Telegram.Bot.Types.Enums.ParseMode.Html, replyMarkup: button.DrawReadySolutionModeMenu());
        }
        public override Commands ParentsComands { set; get; } = new CommandsMainsMenu();
    }
}
