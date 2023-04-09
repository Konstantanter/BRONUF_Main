using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotIsSimple.Main.Projects
{
    public class ServiceCreatedPatentEVM : ServiceCreatedProject
    {
        public ServiceCreatedPatentEVM()
        {
            theme = new Theme(TypesProgs.PatentEVM);
            listThemes = System.IO.File.Exists(theme.FileNamesTheme) ? Serializer.LoadListFromBinnary<string>(theme.FileNamesTheme) : new List<string>();

            ListProjects = new List<Project>();
            if (listThemes.Count != 0)
            {
                ListProjects = GetAllRandFiles();
            }
        }
    }
}
