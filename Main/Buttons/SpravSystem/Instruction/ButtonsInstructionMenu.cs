using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace BRONUF_Main.Main.Buttons
{
    public partial class Button
    {
        /// <summary>
        /// Отрисовка кнопок раздела "Инструкция по использованию"
        /// </summary>
        /// <returns>Клавиатура раздела "Инструкция по использованию"</returns>
        public IReplyMarkup DrawInstructionMenu()
        {
            //Возвращаем отрисованную клавиатуру
            return new ReplyKeyboardMarkup
            {
                //Инициализация клавиатуры
                Keyboard = new List<List<KeyboardButton>>
                        {
                        //Программа для ЭВМ
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = ButtonsInstructionEVM}},
                        ////База данных
                        //new List<KeyboardButton>{
                        //    new KeyboardButton { Text = ButtonsScientificDataBase}},
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
