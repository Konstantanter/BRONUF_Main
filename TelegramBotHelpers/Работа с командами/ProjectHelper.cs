using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRONUF_Main.Main.Commands.Menu.SearchScientificPapers.GetForm16
{
    public class ProjectHelper
    {
        public string registration_number { get; set; }

        public string registration_date { get; set; }

        public string application_number { get; set; }

        public string application_date { get; set; }

        public string authors { get; set; }

        public string authors_count { get; set; }

        public string right_holders { get; set; }


        public string typesProject { get; set; }

        public string contact_to_third_parties { get; set; }

        public string program_name { get; set; }

        public string creation_year { get; set; }

        public string registration_publish_date { get; set; }

        public string registration_publish_number { get; set; }

        public string actual { get; set; }

        public string publication_URL { get; set; }

        public ProjectHelper()
        {
            this.registration_number = this.registration_date = this.application_number = this.application_date = this.authors = "";
            this.authors_count = this.right_holders = this.contact_to_third_parties = this.program_name = this.creation_year = this.registration_publish_date = "";
            this.registration_publish_number = this.actual = this.publication_URL = "";
        }
    }
}
