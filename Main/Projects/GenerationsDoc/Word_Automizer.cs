using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Telegram.Bot;
using TelegramBotIsSimple.Main.Commands.MultipleCommands;
using TelegramBotIsSimple.Main.User;

namespace TelegramBotIsSimple.Main.Projects.GenerationsDoc
{
    public partial class Word_Gen
    {

        /// <summary>
        /// Директория для сохранения
        /// </summary>
        string dir;


        /// <summary>
        /// Месяц регистрации
        /// </summary>
        public string MOUNTH { get; set; }

        /// <summary>
        /// Год регистрации
        /// </summary>
        public string YEAR { get; set; }

        /// <summary>
        /// Имя программы
        /// </summary>
        public string name_of_programm { get; set; }

        /// <summary>
        /// Имя проекта
        /// </summary>
        string Name_proj { get; set; }
        /// <summary>
        /// Установка видимости приложения Word
        /// </summary>
        public bool VISIBLE { set { WORD.Visible = value; } }
        /// <summary>
        /// Документ
        /// </summary>
        public Document Doc { get; set; } = null;
        /// <summary>
        /// Приложение
        /// </summary>
        Application WORD;
        /// <summary>
        /// Вспомогательная переменная Type.Missing
        /// </summary>
        object t;
        /// <summary>
        /// Путь к папке с нашим проектом
        /// </summary>
        public static string DirectoryProject;
        public string ParentDirectory = GeneralData.MainPath + @"Project\Generation\";
        public static string NameProject;
        /// <summary>
        /// Вспомогательная переменная range
        /// </summary>
        Range range;
        /// <summary>
        /// Создание экземпляра класса создания документов
        /// </summary>
        /// <param name="Mouth">Месяц регистрации - например: "октябрь"</param>
        /// <param name="Year">Год регистрации: например: "2020"</param>
        /// <param name="Name_of_programm">Наименование программы</param>
        /// <param name="Name_of_project">Наименование проекта</param>

        public Word_Gen(string Name_of_programm, string AnothProject)
        {
            DateTime time = DateTime.Now;

            switch (time.Month)
            {
                case 1: MOUNTH = "января"; break;
                case 2: MOUNTH = "февраля"; break;
                case 3: MOUNTH = "марта"; break;
                case 4: MOUNTH = "апреля"; break;
                case 5: MOUNTH = "мая"; break;
                case 6: MOUNTH = "июня"; break;
                case 7: MOUNTH = "июля"; break;
                case 8: MOUNTH = "августа"; break;
                case 9: MOUNTH = "сентября"; break;
                case 10: MOUNTH = "октября"; break;
                case 11: MOUNTH = "ноября"; break;
                case 12: MOUNTH = "декабря"; break;

            }
           // Anotation = AnothProject;
            YEAR = Convert.ToString(time.Year);
            name_of_programm = Name_of_programm;
            t = Type.Missing;
            dir = System.IO.Path.GetDirectoryName(ParentDirectory);
            System.IO.Directory.CreateDirectory(dir);
            NameProject = Guid.NewGuid().ToString().Substring(0, 10);
            dir = dir + "\\" + NameProject;
            System.IO.Directory.CreateDirectory(dir);

            DirectoryProject = dir;
            dir += "\\";
            WORD = new Application();
        
        }
        public void Quit()
        {
            WORD.Quit(t, t, t);
        }
        ~Word_Gen()
        {
            //WORD.Quit(t, t, t);
        }
        /// <summary>
        /// Получение имени проекта
        /// </summary>
        /// <returns>имя проекта</returns>
        public string Get_Name_Project()
        {
            return Name_proj;
        }
        /// <summary>
        /// Функция преобразования текста
        /// </summary>
        /// <param name="text">Искомый текст</param>
        /// <param name="mode">mode = 0 -> text выделяется жирным, 
        /// 1 -> text подчёркивается одиночной линией, 
        /// 2 -> text подчёркивается одиночной линией и выделяется жирным
        /// 3 -> у text меняется размер шрифта на 11
        /// 4 -> text перестыёт быть жирным
        /// 5-> курсив</param>
        void Transform_Text(string text, int mode = 0)
        {
            object findText = text;
            Selection wrdSelection;
            while (WORD.Selection.Find.Execute(ref findText, ref t, ref t, ref t, ref t, ref t,
                                               ref t, ref t, ref t, ref t, ref t, ref t, ref t, ref t, ref t))
            {
                wrdSelection = WORD.Selection;
                if (mode == 0) wrdSelection.Font.Bold = 1;
                if (mode == 1) wrdSelection.Font.Underline = WdUnderline.wdUnderlineSingle;
                if (mode == 2)
                {
                    wrdSelection.Font.Underline = WdUnderline.wdUnderlineSingle;
                    wrdSelection.Font.Bold = 1;
                }
                if (mode == 3)
                {
                    wrdSelection.Font.Size = 11;
                }
                if (mode == 4) wrdSelection.Font.Bold = 0;
                if (mode == 5) wrdSelection.Font.Italic = 1;
            }
            Doc.Select();
            WORD.Selection.Collapse();
        }
        public void BigFindReplace(string str_old, string str_new)
        {
            range = Doc.Content;
            string main_str = str_old;
            str_old = str_old.Substring(0, str_old.Length - 1);
            range.Find.Execute(str_old);
            range = Doc.Range(range.End + 1, range.End + 1);
            range.Text = str_new;
            FindReplace(main_str, "");
        }
        /// <summary>
        /// Функция поиска и замены
        /// </summary>
        /// <param name="str_old">Текст подлежащий замене</param>
        /// <param name="str_new">Замещающий (новый) текст</param>
        public void FindReplace(string str_old, string str_new)
        {


            Find find = WORD.Selection.Find;

            find.Text = str_old; // текст поиска
            find.Replacement.Text = str_new; // текст замены

            find.Execute(FindText: t, MatchCase: false, MatchWholeWord: false, MatchWildcards: false,
                        MatchSoundsLike: t, MatchAllWordForms: false, Forward: true, Wrap: WdFindWrap.wdFindContinue,
                        Format: false, ReplaceWith: t, Replace: WdReplace.wdReplaceAll);
        }
        public List<string> GetNRandFiles(int N, string path)
        {
            List<string> allFiles = System.IO.Directory.GetFiles(path).ToList();
            List<string> clearList = new List<string>();
            int tmpNum, count = 0;
            if (allFiles.Count != 0)
            {
                while (count < N)
                {
                    tmpNum = (new Random()).Next(0, allFiles.Count);
                    clearList.Add(allFiles[tmpNum]);
                    if (allFiles.Count > 0)
                    {
                        allFiles.RemoveAt(tmpNum);
                    }
                    else
                    {
                        count = N;
                    }
                    count++;
                }
                return clearList;
            }
            else return clearList;
        }

    }
}
