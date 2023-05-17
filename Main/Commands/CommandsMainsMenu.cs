using System;
using Telegram.Bot;

namespace BRONUF_Main.Main.Commands
{
    /// <summary>
    /// Команда "Основное меню"
    /// </summary>
    internal class CommandsMainsMenu : Commands
    {
        /// <summary>
        /// Команда "Основное меню"
        /// </summary>
        public CommandsMainsMenu() { }
        public override System.String Name { set; get; } = Buttons.Button.ButtonsMainsMenu;
        public override async void Execute(TelegramBotClient _client, long ChatId)
        {
          
                Buttons.Button button = new Buttons.Button();

                await _client.SendTextMessageAsync(ChatId, "Добро пожаловать в основное меню:", replyMarkup: button.DrawChildsMenuButtons());
            
        }
        public override Commands ParentsComands { set; get; } = new CommandsStart();
    }
}
