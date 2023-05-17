using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotIsSimple.Main.Projects
{
    public class ServiceCreatedPatentBD : ServiceCreatedProject
    {
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
