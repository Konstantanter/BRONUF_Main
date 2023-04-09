using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotIsSimple.Main.Buttons
{
    public partial class Button
    {
        /// <summary>
        /// Кнопка с функциями для администраторов
        /// </summary>
        public const string ButtonsAdminMenu = "Админ меню";
        /// <summary>
        /// Функция отрисовки меню администратора
        /// </summary>
        /// <returns></returns>
        public IReplyMarkup DrawAdminMenuButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                        {
                        //Функция поиска свидетельства
                        /*
                         * Я надеюсь что в скором времени эта функция будет работать в автоматизированном редиме
                         */
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = ButtonsSearchSved}},
                        //Кнопка управлениями темами
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = ButtonsThemeManage}},
                        ////Кнопка регистрации проектов (одиночное)
                        //new List<KeyboardButton>{
                        //    new KeyboardButton { Text = ButtonsRegProject}},
                         //Кнопка регистрации проектов (множественное)
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = ButtonsMultipleRegProject}},
                        //Кнопка регистрации аннотации и названия
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = ButtonsAddAnothAndName}},
                        //Кнопка для тестирования платежей (#ПлатежиБудутЗаНами
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = ButtonsPayments}},
                        //Кнопка назад
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = ButtonsBack}}
                        },
                ResizeKeyboard = true
            };
        }
    }
}
