using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace BRONUF_Main.Main.Buttons
{
    public partial class Button
    {
        /// <summary>
        /// Пункт меню индивидуальных проектов
        /// </summary>
        public const string ButtonsModeIndividualProject = "Режим индивидуальных проектов";
        /// <summary>
        /// Пункт меню заказа индивидуальных проектов
        /// </summary>

        public const string ButtonsIndividualProject = "Заказать индивидуальный проект";

        /// <summary>
        /// Отрисовка меню "Заказать индивидуальный проект"
        /// </summary>
        public IReplyMarkup DrawIndividualMenu()
        {
            //Возвращаем отрисованную клавиатуру
            return new ReplyKeyboardMarkup
            {
                    Keyboard = new List<List<KeyboardButton>>{
                         //Индивидуальный проект
                         new List<KeyboardButton>{
                                new KeyboardButton { Text = "👨‍💻 " + ButtonsIndividualProject}},
                         //Заявка на изобретение
                         new List<KeyboardButton>{
                                new KeyboardButton { Text = "📂 " + ButtonsApplicatinInvention}},
                         //Полезная модель
                         new List<KeyboardButton>{
                                new KeyboardButton { Text = "📂 " + ButtonsApplicationUtilityModel}},
                         //Программа для ЭВМ
                         new List<KeyboardButton>{
                                new KeyboardButton { Text = "📂 " + ButtonsApplicationProgramm}},
                         //База данных
                         new List<KeyboardButton>{
                                new KeyboardButton { Text = "📂 " + ButtonsApplicationDataBase}},
                         //Кнопка назад
                         new List<KeyboardButton>{
                                new KeyboardButton { Text = ButtonsBack}}
                    },
                //Перирисовка клавиатуры
                ResizeKeyboard = true
            };
        }
    }
}
