using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace BRONUF_Main.Main.Buttons
{
    public partial class Button
    {

            /// <summary>
            /// Функция отрисовки кнопок остановки текущего прокесса
            /// </summary>
            /// <returns></returns>
            public IReplyMarkup DrawBackAndStopButtons()
            {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                        {
                        //Кнопка Стоп
                        new List<KeyboardButton>{
                            
                            new KeyboardButton { Text = ButtonsBack}}
                        //Кнопка Назад
                       
                        },
                //Перерисовка клавиатуры
                ResizeKeyboard = true
            };
        }
    }
}
