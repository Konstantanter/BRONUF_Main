namespace TelegramBotIsSimple.Main.Commands.Menu.PatentEVM
{
    /// <summary>
    /// Вспомогательный класс для работы с файлами проектов
    /// </summary>
    public class FilesHelper
    {
        /// <summary>
        /// Путь к файлу проекта
        /// </summary>
        public string PathToFile { get; set; }
        /// <summary>
        /// Переменная которая показывает что файл посещён или нет
        /// </summary>
        public bool Visited { get; set; } = false;
        /// <summary>
        /// Конструктор с параметром
        /// </summary>
        /// <param name="pathfile">Путь к фалу</param>
        public FilesHelper(string pathfile)
        {
            PathToFile = pathfile;
            Visited = false;
        }
    }
}
