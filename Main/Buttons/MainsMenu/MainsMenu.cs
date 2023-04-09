using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotIsSimple.Main.Buttons
{
    public partial class Button
    {
        public const string ButtonsMainsMenu = "Основное меню";
       
        public const string ButtonsSpravSystem = "Справочная система";
        
        /// <summary>
        /// Функция получения основного состояния клавиатуры
        /// </summary>
        /// <returns></returns>
        public IReplyMarkup DrawMainsMenuButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                { 
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = "📂 "+ ButtonsMainsMenu } },
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = "📝 "+ ButtonsRegistration } },
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = "💬 "+ ButtonsSpravSystem } },

                        },
                ResizeKeyboard = true
            };
        }
    }
}
