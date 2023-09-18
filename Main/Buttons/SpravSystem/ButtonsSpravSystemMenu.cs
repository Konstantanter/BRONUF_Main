﻿using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace BRONUF_Main.Main.Buttons
{
    public partial class Button
    {

        /// <summary>
        /// Отрисовка кнопок раздела "Справочная система"
        /// </summary>
        /// <returns>Клавиатура раздела Справочная система</returns>
        public IReplyMarkup DrawSpravSystemMenu()
        {
            //Возвращаем отрисованную клавиатуру
            return new ReplyKeyboardMarkup
            {
                //Инициализация клавиатуры
                Keyboard = new List<List<KeyboardButton>>
                        {
                        //Поддержка
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = ButtonsSupport}},
                        //Инструкция по использованию
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = ButtonsInstruction}},
                        //Научные труды что и для чего
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = ButtonsScientificPapersHelp}},
                        //Вузам и научным организациям
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = ButtonsUniversitiesAndOrganizations}},
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