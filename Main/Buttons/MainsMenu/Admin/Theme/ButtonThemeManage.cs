using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotIsSimple.Main.Buttons
{
    public partial class Button
    {
        /// <summary>
        /// Кнопка для управления темами
        /// </summary>
        public const string ButtonsThemeManage = "Управление темами";
        /// <summary>
        /// Функция для отрисовки кнопок для управления темами
        /// </summary>
        public IReplyMarkup DrawThemeButtons()
        {
            //Отрисовываем клавиатуру для управления темами
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                        {
                        //Добавляем кнопку Добавить тему
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = AddTheme}},
                        //Добавляем кнопку Получить все темы
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = ButtonsGetAllTheme}},
                        //Добавляем кнопку Получить проблемные темы
                         new List<KeyboardButton>{
                            new KeyboardButton { Text = ButtonsGetProblemTheme}},
                        //Добавляем кнопку Назад
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = ButtonsBack}}
                        },
                //Перерисовываем клавиатуру
                ResizeKeyboard = true
            };
        }
    }
}
