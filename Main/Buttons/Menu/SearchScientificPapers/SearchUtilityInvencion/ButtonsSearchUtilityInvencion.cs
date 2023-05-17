using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace BRONUF_Main.Main.Buttons
{
    public partial class Button
    {
        /// <summary>
        /// Кнопка режима поиска зарегистрированных изобретений, полез. моделей
        /// </summary>
        public const string ButtonsSearchUtilityInvencion = "Поиск зарегистрированных изобретений, полез. моделей";

        public const string ButtonsSearchInvencion = "Поиск зарегистрированных ПрЭВМ";
        public const string ButtonsSearchUtility = "Поиск зарегистрированных ПрЭВМ";

        /// Отрисовка кнопок раздела "Поиск зарегистрированных изобретений, полез. моделей"
        /// </summary>
        /// <returns>Клавиатура раздела "Поиск зарегистрированных изобретений, полез. моделей"/returns>
        public IReplyMarkup DrawSearchUtilityInvencionMenu()
        {
            //Возвращаем отрисованную клавиатуру
            return new ReplyKeyboardMarkup
            {
                //Инициализация клавиатуры
                Keyboard = new List<List<KeyboardButton>>
                        {

                        new List<KeyboardButton>{
                            new KeyboardButton { Text = "🔎 " + ButtonsSearchInvencion}},
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = "🔎 " + ButtonsSearchUtility}},
                        //Кнопка назад
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = ButtonsBack}}
                        },
                ResizeKeyboard = true
            };
        }
    }
}
