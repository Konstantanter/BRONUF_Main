using Telegram.Bot;
using BRONUF_Main.Main.Buttons;
using Telegram.Bot.Types.InputFiles;
using System.IO;

namespace BRONUF_Main.Main.Commands
{
    //// <summary>
    /// Команда "Как стать участником пр. для ЭВМ?"
    /// </summary>
    internal class CommandsInstructionEVM : Commands
    {
        /// <summary>
        /// Команда "Как стать участником пр. для ЭВМ?"
        /// </summary>
        public CommandsInstructionEVM() { }
        public override System.String Name { set; get; } = Buttons.Button.ButtonsInstructionEVM;
        public override async void Execute(TelegramBotClient _client, long ChatId)
        {
            var filePath = @"C:\Users\BRONUF\Desktop\BRONUF шлак\123.mp4";
            await _client.SendVideoAsync(ChatId,File.OpenRead(filePath),caption:"Инструкция по регистрации в программе для ЭВМ");
        }
        public override Commands ParentsComands { set; get; } = new CommandsInstructionMenu();
    }
}
