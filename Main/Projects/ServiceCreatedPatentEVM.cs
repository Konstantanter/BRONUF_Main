using BRONUF_Library;
using BRONUF_Library.Projects;
using System.Collections.Generic;

namespace BRONUF_Main.Main.Projects
{
    public class ServiceCreatedPatentEVM : ServiceCreatedProject
    {
        /// <summary>
        /// Сервис для генерации документов на Программу для ЭВМ
        /// </summary>
        public ServiceCreatedPatentEVM()
        {
            theme = new Theme(TypesProgs.PatentEVM);
            listThemes = System.IO.File.Exists(theme.FileNamesTheme) ? Serializer.LoadListFromXml<string>(theme.FileNamesTheme) : new List<string>();

            ListProjects = new List<Project>();
            if (listThemes.Count != 0)
            {
                ListProjects = GetAllRandFiles();
            }
        }
    }
}
