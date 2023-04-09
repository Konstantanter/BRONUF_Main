using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotIsSimple.Main.Buttons
{
    public partial class Button
    {
        /// <summary>
        /// Информация о стипендиях
        /// </summary>
        public const string SupportSteps = "Информация о стипендиях";
        /// <summary>
        /// Информация о программах для ЭВМ
        /// </summary>
        public const string SupportProgEVM = "Информация о ПрЭВМ";
        /// <summary>
        /// Информация о 
        /// </summary>
        public const string SupportRIPM = "Информация о РИ/ПМ";
        /// <summary>
        /// Информация о ВАК/Scopus
        /// </summary>
        public const string SupportBAK = "Информация о ВАК/Scopus";
        public IReplyMarkup DrawSupportMenuButton()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                        {
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = "1⃣ "+SupportSteps}},
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = "2⃣ "+SupportProgEVM}},
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = "3⃣ "+SupportRIPM}},
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = "4⃣ "+SupportBAK}},
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = ButtonsBack}}
                        },
                ResizeKeyboard = true
            };
        }
}
}
