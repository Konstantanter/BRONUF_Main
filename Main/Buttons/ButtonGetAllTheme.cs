using System;
using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBotIsSimple.Main.Projects;

namespace TelegramBotIsSimple.Main.Buttons
{
    public partial class Button
    {
        /// <summary>
        /// Функция отрисовки всех тем
        /// </summary>
        public IReplyMarkup DrawAllThemes(TypesProgs progs)
        {
            //Определяем список в котором будут все текущие темы
            List<string> listTheme = Serializer.LoadListFromXml<string>(new Theme(progs).FileNamesTheme);
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
