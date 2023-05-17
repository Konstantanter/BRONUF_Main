using System;

namespace BRONUF_Main.Main
{
    /// <summary>
    /// Класс предназнчен для создания и хранения основных данных требуемых для хранения и считывания информации
    /// </summary>
    public class GeneralData
    {
        public static string MainPath { get; private set; } = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\SKYNET3\\";
        /// <summary>
        /// Константа для имени директории в которую мы будем закружать файлы свидетельств программ для ЭВМ
        /// </summary>
        public const string NameDirectoryEVM = "EVMProgFile";

        public const string TmpProgrammName = "Программа";
        public const string TmpBDName = "База данных";

        /// /// <summary>
        /// Константа для имени директории в которую мы будем закружать файлы свидетельств баз данных
        /// </summary>
        public const string NameDirectoryBD = "BDProgFile";
        public static string NameDirectoryEVMPath { get; private set; } = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\SKYNET3\\Sved\\" + NameDirectoryEVM;
        public static string NameDirectoryBDPath { get; private set; } = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\SKYNET3\\Sved\\" + NameDirectoryBD;

        public static string NameAdress = MainPath + "Project\\Adress";
        /// <summary>
        /// Констаруктор по умолчанию
        /// </summary>
        public GeneralData()
        {
            //Создаём директорую
            System.IO.Directory.CreateDirectory(MainPath);

        }
    }
}
