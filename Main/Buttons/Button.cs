using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotIsSimple.Main.Buttons
{
    /// <summary>
    /// Класс реализующий управление кнопками
    /// </summary>
    public partial class Button
    {
        /// <summary>
        /// Кнопка назад
        /// </summary>
        public static string ButtonsBack = "⬅️ Назад";
        /// <summary>
        /// Кнопка участия
        /// </summary>
        public static string ButtonUch = "Участвовать";
        /// <summary>
        /// Кнопка выбора
        /// </summary>
        public static string ButtonSelected = "Выбрать";
        /// <summary>
        /// Кнопка старта
        /// </summary>
        public static string ButtonStart = "/start";
        /// <summary>
        /// Кнопка о том что это пока не сделано
        /// </summary>
        public const string ButtonNotDevelop = "Данная функция, в текущей версии бота не реализована\nПриносим извинения за неудобства\nС Уважением <b>KobraLab</b>";
        /// <summary>
        /// Отрисовка кнопки участия в проекте
        /// </summary>
        /// <param name="Shake">Дополнительные данные</param>
        /// <returns>Клавиатура для участия в проекте</returns>
        public InlineKeyboardMarkup DrawInlineButton(string Shake)
        {
            return new InlineKeyboardMarkup(new InlineKeyboardButton { Text = ButtonUch, CallbackData = Shake });
        }
    }

    
}
