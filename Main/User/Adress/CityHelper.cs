using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRONUF_Main.Main.User
{
    partial class Users
    {
        public string GetrandomAdress()
        {
            List<string> allfiles = System.IO.Directory.GetFiles(GeneralData.NameAdress).ToList();

            Random rand = new Random();
            string rand_file = allfiles[rand.Next(0, allfiles.Count - 1)];

            List<string> allAdress = System.IO.File.ReadAllLines(rand_file, Encoding.Default).ToList();
            string randadress = allAdress[rand.Next(0, allAdress.Count - 1)];
            return randadress;
        }
    }
}
