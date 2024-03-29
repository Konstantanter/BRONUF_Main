﻿using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotIsSimple.Main.Buttons
{
    public partial class Button
    {
        /// <summary>
        /// Кнопка для остановки текущего процесса
        /// </summary>
        public const string ButtonsStop = "Стоп";
        public IReplyMarkup DrawStopButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                        {
                        //Кнопка Стоп
                        new List<KeyboardButton>{

                            new KeyboardButton { Text = ButtonsStop}}
                        //Кнопка Назад
                       
                        },
                //Перерисовка клавиатуры
                ResizeKeyboard = true
            };
        }
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
