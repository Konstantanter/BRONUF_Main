using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace BRONUF_Main.Main.Buttons
{
    public partial class Button
    {
        /// <summary>
        /// Отрисовка кнопок раздела "Научные труды что и для чего"
        /// </summary>
        /// <returns>Клавиатура раздела "Научные труды что и для чего"</returns>
        public IReplyMarkup DrawScientificPapersHelpMenu()
        {
            //Возвращаем отрисованную клавиатуру
            return new ReplyKeyboardMarkup
            {
                //Инициализация клавиатуры
                Keyboard = new List<List<KeyboardButton>>
                        {
                        //Программа для ЭВМ
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = ButtonsScientificEVM}},
                        //База данных
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = ButtonsScientificDataBase}},
                        //Кнопка назад
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = ButtonsBack}}
                        },
                //Перерисовка клавиатуры
                ResizeKeyboard = true
            };
        }
    }
}
