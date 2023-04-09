using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotIsSimple.Main.Buttons
{
    public partial class Button
    {

        /// <summary>
        /// Отрисовка кнопок раздела "Поддержка"
        /// </summary>
        /// <returns>Клавиатура раздела поддержка</returns>
        public IReplyMarkup DrawSpravMenu()
        {
            //Возвращаем отрисованную клавиатуру
            return new ReplyKeyboardMarkup
            {
                //Инициализация клавиатуры
                Keyboard = new List<List<KeyboardButton>>
                        {
                        //Поддержка
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = "👨‍🔧 " + ButtonsSupport}},
                        //Инструкция по использованию
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = "💬 " + ButtonsInstruction}},
                        //Научные труды что и для чего
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = "ℹ️ " + ButtonsScientificPapersHelp}},
                        //Вузам и научным организациям
                        new List<KeyboardButton>{
                            new KeyboardButton { Text ="📖 " + ButtonsUniversitiesAndOrganizations}},
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
