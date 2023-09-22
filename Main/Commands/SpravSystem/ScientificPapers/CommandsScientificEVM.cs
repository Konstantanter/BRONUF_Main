using BRONUF_Library;
using BRONUF_Main.Properties;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types.InputFiles;

namespace BRONUF_Main.Main.Commands
{
    /// <summary>
    /// Команда для отрисовки меню "О патенте на ЭВМ?"
    /// </summary>
    internal class CommandsScientificEVM : Commands
    {
        /// <summary>
        /// Команда для отрисовки меню "О патенте на ЭВМ?"
        /// </summary>
        public CommandsScientificEVM() { }
        public override string Name { set; get; } = Buttons.Button.ButtonsScientificEVM;
        public override async void Execute(TelegramBotClient _client, long ChatId)
        {
            Buttons.Button button = new Buttons.Button();
            string path = GeneralData.NameDirectoryTemp + GeneralData.ImageSved;
            if (!System.IO.File.Exists(path))
            {
                var bmpr = new Bitmap(Resources.Sved);
                bmpr.Save(path);
            }
            Bitmap bmp = new Bitmap(path);
            using (var ms = new MemoryStream())
            {
                bmp.Save(ms, ImageFormat.Png);
                ms.Position = 0;
                await _client.SendPhotoAsync(ChatId,  new InputOnlineFile(ms, path), caption: button.DataBaseEVM_Mess(TypesProgs.DataBase), parseMode: Telegram.Bot.Types.Enums.ParseMode.Html, replyMarkup: null);
            }
           
            Thread.Sleep(300);
            await _client.SendTextMessageAsync(ChatId, Buttons.Button.ThisISPatentProgEVMmes2, Telegram.Bot.Types.Enums.ParseMode.Html, replyMarkup: null);
        }
        public override Commands ParentsComands { set; get; } = new CommandSpravSystemMenu();
    }
}
