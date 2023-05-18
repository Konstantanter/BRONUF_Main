using BRONUF_Library;
using BRONUF_Library.Projects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BRONUF_Main.Main.Projects
{
    /// <summary>
    /// Технология генерации проектов
    /// </summary>
    public class ServiceCreatedProject
    {

        public Theme theme;

        public List<string> fileNames { get; set; } = new List<string>();
        /// <summary>
        /// Список тем 
        /// </summary>
        public static List<string> listThemes;
        /// <summary>
        /// Список проектов
        /// </summary>
        public static List<Project> ListProjects { get; set; }

        public List<Project> GetListProject()
        {
            return ListProjects;
        }
        public ServiceCreatedProject()
        {
        }
        /// <summary>
        /// Функция получения N случайных файлов из папки
        /// </summary>
        /// <param name="N"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<string> GetNRandFiles(int N, string nameTheme)
        {
            // List<string> listThemes = System.IO.File.Exists(BRONUF_Main.Main.Projects.Theme.FileNamesTheme) ? Serializer.LoadListFromBinnary<string>(BRONUF_Main.Main.Projects.Theme.FileNamesTheme) : new List<string>();
            List<string> allFiles = System.IO.Directory.GetFiles(theme.MainPath + $"{nameTheme}\\").ToList();
            List<string> clearList = new List<string>();
            int tmpNum, count = 0;
            if (allFiles.Count != 0)
            {
                if (allFiles.Count > N)
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
                }
                else
                {
                    clearList.AddRange(allFiles);
                }
                return clearList;
            }
            else return clearList;
        }
        /// <summary>
        /// Функция для тестирования получения всех файлов в указанной теме
        /// </summary>
        public List<Project> GetAllRandFiles()
        {

            List<Project> projects = new List<Project>();
            fileNames.Clear();
            //Внутри каждой темы нам нужно получить необходимое число случайных файлов
            foreach (string line in listThemes)
            {
                if (line != null) fileNames.AddRange(GetNRandFiles(4, line));
            }

            foreach (string line in fileNames)
            {
                if (line != null)
                {

                    Project project = new Project(System.IO.File.ReadAllText(line));
                    project.NameTheme = System.IO.Path.GetFileName(System.IO.Path.GetDirectoryName(line));
                    project.HandShake = System.IO.Path.GetFileNameWithoutExtension(System.IO.Path.GetRandomFileName());
                    project.FileName = line;
                    projects.Add(project);
                }
            }
            return projects;
        }



        public void UpdateProjects()
        {
            fileNames = new List<string>();
            listThemes = System.IO.File.Exists(theme.FileNamesTheme) ? Serializer.LoadListFromXml<string>(theme.FileNamesTheme) : new List<string>();
            var clearList = new List<Project>();
            if (listThemes.Count != 0)
            {
                var listNotEmpty = ListProjects.FindAll(a => a.ListUsers.Count != 0);



                List<Project> projects = GetAllRandFiles();

        

                clearList.AddRange(listNotEmpty);

                foreach(Project project in projects)
                {
                    if (clearList.Any(a => a.HandShake.Equals(project.HandShake))) continue;
                    else clearList.Add(project);
                }
            }
            ListProjects = clearList;
        }
       
        /// <summary>
        /// Функция проверки статуса проекта
        /// </summary>
        public void getStatusProject()
        {

        }
        /// <summary>
        /// Функция получения случайного имени файла из папки
        /// </summary>
        /// <returns>случайное имя файла</returns>
        public string GetRandFileName(string pathDirectory)
        {
            string[] fileNames = System.IO.Directory.GetFiles(pathDirectory);
            int countFiles = fileNames.Count();
            if (countFiles > 0)
            {
                return fileNames[(new Random()).Next(0, countFiles)];
            }
            else
                return null;
        }
    }
    

}
