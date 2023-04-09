using System;
using System.Collections.Generic;
using TelegramBotIsSimple.Main.User;

namespace TelegramBotIsSimple.Main.Projects
{
    [Serializable]
    /// <summary>
    /// Класс описывающий проект
    /// </summary>
    
    public class Project
    {
        /// <summary>
        /// Имя проекта
        /// </summary>
        public string NameProject { get; set; }
        /// <summary>
        /// Имя темы проекта
        /// </summary>
        public string NameTheme { get; set; }
        /// <summary>
        /// Это хэш нашего проекта
        /// </summary>
        public string HandShake { get; set; }
        /// <summary>
        /// Описание проекта
        /// </summary>
        public string AnothProject { get; set; }
        /// <summary>
        /// Имя файла
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Тип проекта
        /// </summary>
        public string TypeProject { get; set; }
        /// <summary>
        /// Списко пользователей проекта
        /// </summary>
        public List<Users> ListUsers { get; set; } = new List<Users>();
        public string MainPath = $"{GeneralData.MainPath}Project\\Оплаченные проекты\\";

        public Project() { }
        public Project(string strFile)
        {

            string[] separator = { "$$$" };
            string[] sArr = strFile.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            NameProject = sArr[0];
            AnothProject = sArr[1];
        }
    }
}
