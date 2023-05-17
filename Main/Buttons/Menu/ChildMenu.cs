using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotIsSimple.Main.Buttons
{
    public partial class Button
    {
        /// <summary>
        /// Функция отрисовки дочернего меню
        /// </summary>
        /// <returns></returns>
        public IReplyMarkup DrawChildsMenuButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                        //Режим готовых решений
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = "🔐 "+ ButtonsReadySolution } },
                        //Заказ индивидуальных проектов
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = "👤 "+ ButtonsIndividualProject } },
                        //Режим поиска научных трудов
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = "🔎 "+ ButtonsSearchScientificPapers } },
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = ButtonsBack } },
                        },
                ResizeKeyboard = true
            };
        }
    }
}
