using System;
using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotIsSimple.Main.Buttons
{
    public partial class Button
    {
        /// <summary>
        /// Кнопка получения всех тем
        /// </summary>
        public const string ButtonsGetAllTheme = "Получить все темы";
        /// <summary>
        /// Функция отрисовки всех тем
        /// </summary>
        /// <returns></returns>
        public IReplyMarkup DrawAllThemes()
        {
            //Определяем список в котором будут все текущие темы
            List<string> listTheme = Serializer.LoadListFromBinnary<string>(Projects.Theme.FileNamesTheme);
            //Определяем список для отрисовки наших тем
            var listThemeButtons = new List<List<KeyboardButton>>();
            if (listTheme != null && listTheme.Count != 0)
            {
                //Перебираем список тем
                foreach (string line in listTheme)
                {
                    //Если тема не пуста
                    if (line != String.Empty)
                    {
                        //Добавлем в наш список кнопок новуб кнопку с названием темы
                        listThemeButtons.Add(new List<KeyboardButton>{
                            new KeyboardButton { Text = line}});
                    }

                }
            }
            //Кидаем в наш список также кнопку назад
            listThemeButtons.Add(new List<KeyboardButton>{
                            new KeyboardButton { Text = ButtonsBack}});
            //Возвращаем клавиатуру со списком кнопок с текстом тем
            return new ReplyKeyboardMarkup
            {
                Keyboard = listThemeButtons,
                //Перерисовываем клавиатуру
                ResizeKeyboard = true
            };
        }
    }
}
