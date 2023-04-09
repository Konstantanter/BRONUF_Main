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
        /// Кнопка основного меню
        /// </summary>
        public const string ButtonsMainsMenu = "Основное меню";
        /// <summary>
        /// Кнопка справочной системы
        /// </summary>
        public const string ButtonsSpravSystem = "Справочная система";
        /// <summary>
        /// Функция отрисовки основного меню
        /// </summary>
        /// <returns></returns>
        public IReplyMarkup DrawMainsMenuButtons()
        {
            return new ReplyKeyboardMarkup
            {
                //Инициализация клавиатуры
                Keyboard = new List<List<KeyboardButton>>
                {
                        //Основное меню
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = "📂 "+ ButtonsMainsMenu } },
                        //Меню регистрации
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = "📝 "+ ButtonsRegistration } },
                        //Меню справочной системы
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = "💬 "+ ButtonsSpravSystem } },
                        },
                //Определение перерисови клавиатуры
                ResizeKeyboard = true
            };
        }
    }
}
