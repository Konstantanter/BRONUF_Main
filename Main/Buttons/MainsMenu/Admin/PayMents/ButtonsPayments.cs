using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotIsSimple.Main.Buttons
{
    public partial class Button
    {
        /// <summary>
        /// Кнопка оплаты
        /// </summary>
        public const string ButtonsPayments = "Оплата";
        public const string ButtonCheckPayments = "Проверить статус платежа";
        public IReplyMarkup DrawCheckPaymentsButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                        {
                        
                        new List<KeyboardButton>{
                            new KeyboardButton { Text = ButtonCheckPayments}},
                        },
                // Сводка:
                // Необязательно. Просит клиентов изменить размер клавиатуры по вертикали для оптимальной посадки
                // (например, уменьшите клавиатуру, если есть только две строки типов Telegram.Bot.Ответные пометки.Кнопка клавиатуры).
                // По умолчанию установлено значение false, и в этом случае пользовательская клавиатура всегда имеет одинаковую высоту
                // в качестве стандартной клавиатуры приложения.
                ResizeKeyboard = true
            };
        }
    }
}
