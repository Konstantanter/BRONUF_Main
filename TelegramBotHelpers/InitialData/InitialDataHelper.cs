using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BRONUF_Main.Main.Buttons;
using BRONUF_Main.Main.Commands;
using BRONUF_Main.Main.Commands.MultipleCommands;
using BRONUF_Main.Main.DataBases;
using BRONUF_Main.Main.Projects;


namespace BRONUF_Main
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


        /// <summary>
        /// Вспомогательный класс поиска баз данных
        /// </summary>
        ServiceCreatedPatentBD createdPatentBD;
        /// <summary>
        /// Вспомогательный класс поиска программ для ЭВМ
        /// </summary>
        ServiceCreatedPatentEVM createdPatentEVM;
        /// <summary>
        /// Конструктор с параметром
        /// </summary>
        /// <param name="token">токен подключения к телеграмм</param>
        public TelegramBotHelper(string token)
        {

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
