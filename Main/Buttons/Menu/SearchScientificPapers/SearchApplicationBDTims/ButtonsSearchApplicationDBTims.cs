using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace BRONUF_Main.Main.Buttons
{
    public partial class Button
    {
        /// <summary>
        /// Кнопка режима поиска программ для ЭВМ, баз данных и ТИМС
        /// </summary>
        public const string ButtonsSearchApplicationDBTims = "Поиск зарегистрированных ПрЭВМ, БД, ТИМС";

        public const string ButtonsSearchEVM = "Поиск зарегистрированных ПрЭВМ";
        public const string ButtonsSearchBD = "Поиск зарегистрированных БД";
        public const string ButtonsSearchTIMS = "Поиск зарегистрированных ТИМС";
        /// <summary>
        /// Отрисовка кнопок раздела "Поиск зарегистрированных ПрЭВМ, БД, ТИМС"
        /// </summary>
        /// <returns>Клавиатура раздела "Поиск зарегистрированных ПрЭВМ, БД, ТИМС"/returns>
        public IReplyMarkup DrawSearchApplicationDBTimsMenu()
        {
            //Возвращаем отрисованную клавиатуру
            return new ReplyKeyboardMarkup
            {
                //Инициализация клавиатуры
                Keyboard = new List<List<KeyboardButton>>
                        {
                     
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = "🔎 " + ButtonsSearchEVM}},
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = "🔎 " + ButtonsSearchBD}},
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = "🔎 " + ButtonsSearchTIMS}},
                        //Кнопка назад
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = ButtonsBack}}
                        },
                ResizeKeyboard = true
            };
        }
    }
}
