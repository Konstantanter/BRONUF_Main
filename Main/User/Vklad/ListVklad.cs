using System.Collections.Generic;

namespace TelegramBotIsSimple.Main.User
{
    public partial class Users
    {
        /// <summary>
        /// Список возможных вкладов пользователя
        /// </summary>
        static public List<string> listVklad = new List<string>
            {
                "Идея программы",
                "Реализация алгоритма",
                "Описание блок схемы программы",
                "Идея алгоритма",
                "Создание технического задания",
                "Тестирование программы",
                "Графический дизайн программы",
                "Перевод программы на различные языки",
                "Оптимизация программы",
                "Рефакторинг программного кода"
            };
    }
}
