using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotIsSimple.Main.Buttons
{
    public partial class Button
    {
        /// <summary>
        /// Кнопка режима поиска научных трудов
        /// </summary>
        public const string ButtonsSearchScientificPapers = "Режим поиска научных трудов";
        /// <summary>
        /// Отрисовка кнопок раздела "Режим поиска научных трудов"
        /// </summary>
        /// <returns>Клавиатура режима поиска научных трудов</returns>
        public IReplyMarkup DrawScientificPapersMenu()
        {
            //Возвращаем отрисованную клавиатуру
            return new ReplyKeyboardMarkup
            {
                //Инициализация клавиатуры
                Keyboard = new List<List<KeyboardButton>>
                        {
                    
                    new List<KeyboardButton>{
                            new KeyboardButton { Text = "🔎 " + ButtonsSearchScientificPapers}},
                        //Форма 16
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = "📝 " + ButtonGetForm16}},
                        //Кнопка назад
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = ButtonsBack}}
                        },
                ResizeKeyboard = true
            };
        }
    }
}
