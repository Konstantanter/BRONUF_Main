using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TelegramBotIsSimple.Main.Buttons;
using TelegramBotIsSimple.Main.Commands;
using TelegramBotIsSimple.Main.Commands.MultipleCommands;
using TelegramBotIsSimple.Main.DataBases;
using TelegramBotIsSimple.Main.Projects;


namespace TelegramBotIsSimple
{

    /// <summary>
    /// Внешний вспомогательный класс 
    /// </summary>
    internal partial class TelegramBotHelper
    {
        
        /// <summary>
        /// Токен для работы Телеграм-бота
        /// </summary>
        private string _token;
        /// <summary>
        /// Класс кнопок меню
        /// </summary>
        public Button button;
        /// <summary>
        /// Клиент Телеграм
        /// </summary>
        Telegram.Bot.TelegramBotClient _client;

        /// <summary>
        /// Список команд которые задают несколько вопросов
        /// </summary>
        List<MultipleCommand> mulcommands;
        /// <summary>
        /// Класс для хранения предыдущей команды
        /// </summary>
        Commands PresentCommand = new CommandsMainsMenu();
   
        /// <summary>
        /// Переменная для хранения текущей многоуровневой команды
        /// </summary>
        MultipleCommand CurTmpCommand = null;
        /// <summary>
        /// Словарь Ид чата - Имя команды
        /// </summary>
        private Dictionary<long, string> _clientStates = new Dictionary<long, string>();
        DataBase dataBase;

        ServiceCreatedPatentBD createdPatentBD;
        ServiceCreatedPatentEVM createdPatentEVM;
        /// <summary>
        /// Класс для обработки csv файла
        /// </summary>
       // ProjectListHelper projectListHelper;
        /// <summary>
        /// Конструктор с параметром
        /// </summary>
        /// <param name="token">токен подключения к телеграмм</param>
        public TelegramBotHelper(string token)
        {
            dataBase = new DataBase();
            dataBase.OpenConnection();
            button = new Button();

            //createdProject = new ServiceCreatedProject();

            createdPatentBD = new ServiceCreatedPatentBD();
            createdPatentEVM = new ServiceCreatedPatentEVM();
            this._token = token;
            SetCommands();
            SetMultipleCommands();
        }
    }
}
