using Telegram.Bot;

namespace BRONUF_Main.Main.Commands
{
    /// <summary>
    /// Класс описывающий команды 
    /// </summary>
    internal abstract class Commands
    {
        /// <summary>
        /// Имя команды
        /// </summary>
        public abstract System.String Name { set; get; } //имя команды например /start, Привет, Пока
        /// <summary>
        /// Тело команды (то что она должна выполнить)
        /// </summary>
        /// <param name="botClient"></param>
        /// <param name="ChatId"></param>
        public abstract void Execute(TelegramBotClient botClient, long ChatId);//выполнение кода
        /// <summary>
        /// Родительская команда
        /// </summary>
        public abstract Commands ParentsComands { get; set; }

        

    }
}
