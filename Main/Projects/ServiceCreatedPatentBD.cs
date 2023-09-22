using BRONUF_Library;
using BRONUF_Library.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRONUF_Main.Main.Projects
{
    public class ServiceCreatedPatentBD : ServiceCreatedProject
    {
        /// <summary>
        /// Сервис для генерации документов на Базу данных
        /// </summary>
        public ServiceCreatedPatentBD() {
            theme = new Theme(TypesProgs.DataBase);
            listThemes = System.IO.File.Exists(theme.FileNamesTheme) ? Serializer.LoadListFromXml<string>(theme.FileNamesTheme) : new List<string>();
            ListProjects = new List<Project>();
            if (listThemes.Count != 0)
            {
                ListProjects = GetAllRandFiles();

            }
        }
    }
}
