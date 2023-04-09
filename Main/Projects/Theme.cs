using System;

namespace TelegramBotIsSimple.Main.Projects
{
    [Serializable]
    /// <summary>
    /// Класс описывающий тему проекта
    /// </summary>
    public class Theme
    {
        /// <summary>
        /// Тема проекта
        /// </summary>
        public string NameTheme { get; set; }
        /// <summary>
        /// Путь где будут храниться все файлы нашего проекта
        /// </summary>
        public string PathToTheProject { get; set; }
        //static string _mainPath = 
        /// <summary>
        /// Основной путь по которому будут лежать все темы наших проектов
        /// </summary>
        public static string MainPathEVM = $"{GeneralData.MainPath}Project\\EVM\\";
        /// <summary>
        /// Путь к файлу в котором будут храниться все темы
        /// </summary>
        public static string FileNamesThemeEVM = MainPathEVM + "Themes.bin";

        /// <summary>
        /// Основной путь по которому будут лежать все темы наших проектов
        /// </summary>
        public static string MainPathBD= $"{GeneralData.MainPath}Project\\BD\\";
        /// <summary>
        /// Путь к файлу в котором будут храниться все темы
        /// </summary>
        public static string FileNamesThemeBD = MainPathBD + "Themes.bin";

        public string FileNamesTheme { get; set; }
        public string MainPath { get; set; }
        public Theme() {

        }
        public Theme(TypesProgs typeProg)
        {
            if (typeProg == TypesProgs.DataBase)
            {

                FileNamesTheme = FileNamesThemeBD;
                MainPath = MainPathBD;
            }

            if (typeProg == TypesProgs.PatentEVM)
            { 
                FileNamesTheme = FileNamesThemeEVM;
                MainPath = MainPathEVM;
            }
        }
        /// <summary>
        /// Конструктор с параметром имя темы
        /// </summary>
        public Theme(string nameTheme, TypesProgs typeProg)
        {
           
            //Передаём имя темы
            NameTheme = nameTheme;

            if(typeProg == TypesProgs.DataBase)
            {
                //Обновляем переменную путь до проекта
                PathToTheProject = MainPathBD + nameTheme + "\\";
                FileNamesTheme = FileNamesThemeBD;
                MainPath = MainPathBD;
            }

            if (typeProg == TypesProgs.PatentEVM)
            {
                //Обновляем переменную путь до проекта
                PathToTheProject = MainPathEVM + nameTheme + "\\";
                FileNamesTheme = FileNamesThemeEVM;
                MainPath = MainPathEVM;
            }
            //Заготовка под создание новой темы
            if (!System.IO.Directory.Exists(PathToTheProject))
            {
                    //Сохраняем имя темы
                    Serializer.SaveElem<string>(FileNamesTheme, nameTheme);
                    //Если директория темы раньше несуществовала, то создаём ее
                    System.IO.Directory.CreateDirectory(PathToTheProject);


            }
           
        }
       
    }
}
