using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace BRONUF_Main.Main.Buttons
{
    public partial class Button
    {
        /// <summary>
        /// Кнопка режима готовых решений
        /// </summary>
        public const string ButtonsReadySolution = "Режим готовых решений";
        /// <summary>
        /// Функция отрисовки меню режима готовых решений
        /// </summary>
        /// <returns>Нарисованная клавиатура режима готовых решений</returns>
        public IReplyMarkup DrawReadySolutionModeMenu()
        {
            //Возвращаем отрисованную клавиатуру
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                        {
                        //Патент ЭВМ
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = "📕 " + ButtonsPatentntEVM}},
                        //Изобретение
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = "📕 " + ButtonsInvension}},
                        //Полезная модель
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = "📕 " + ButtonsUtilityModel}},
                        //Статья скопус
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = "📗 " + ButtonsScopus}},
                        //Статья ВАК
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = "📗 " + ButtonsBAK}},
                        //Статья РИНЦ
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = "📗 " + ButtonsRinc}},
                        //Статья не РИНЦ
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = "📘 " + ButtonsNotRinc}},
                        //Топология интегральных микросхем
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = "📘 " + ButtonsPatentTIMS}},
                        //База данных
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = "📘 " + ButtonsDataBase}},
                        //Акт реализации
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = "📚 " + ButtonsAkt}},
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
