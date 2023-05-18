
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;

using System.Threading.Tasks;
using Telegram.Bot;
using BRONUF_Main.Main.Commands.Menu.SearchScientificPapers.GetForm16;
using BRONUF_Main.Main.Projects.GenerationsDoc;
using BRONUF_Library;

namespace BRONUF_Main.Main.Commands.Menu.UserFindProject
{
    /// <summary>
    /// Вспомогательный класс по генерации списка свидетельств пользователя
    /// </summary>
    public class ProjectListHelper
    {
        //Число свидетельств
        public int CountSved { get; set; } = 0;
       
        //Текущий лист id процессов
        List<int> CurrentList = new List<int>();
        public long ChatId;
        string NameUser;
        public ProjectListHelper(string nameUser, long chatId)
        {
            NameUser = nameUser;
            ChatId = chatId;
        }
      

        /// <summary>
        /// Функция генерации списка свидетельств
        /// </summary>
        /// <param name="NameUser">Имя пользователя, например: "Онуфриев Константин Николаевич"</param>
        /// <param name="_client">Клиент telegramm</param>
        /// <param name="ChatId">id чата</param>
        public bool GenIndividualList(TelegramBotClient _client)
        {
           // Task task = new Task(() => { 
                foreach (Process proc in Process.GetProcessesByName("WINWORD"))
                {
                    CurrentList.Add(proc.Id);
                }
                Word_Gen word_gen = new Word_Gen("", "");
                List<ProjectHelper> projectHelpers = new List<ProjectHelper>();
                DataBase dat = new DataBase();
            //dat.OpenConnection();
            using (SqlConnection conn = dat.getConnection())
            {
                //Задаем подключение к команде
                using (SqlCommand sqlCommand = new SqlCommand("SELECT [registration_number], [authors], [right_holders], [contact_to_third_parties], [program_name], [reg_pub_date], [application_number], [application_data] FROM [dbo].[DataSveds] WHERE [authors] LIKE N'%" + NameUser + "%'", conn))
                {
                    if (conn.State != System.Data.ConnectionState.Open)
                        conn.Open();
                    sqlCommand.CommandTimeout = 3000000;
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                     
                        while (sqlDataReader.Read())
                        {
                            ProjectHelper projectHelper = new ProjectHelper();
                            projectHelper.registration_number = sqlDataReader[0].ToString();
                            projectHelper.program_name = sqlDataReader[4].ToString();
                            projectHelper.registration_publish_date = sqlDataReader[5].ToString();
                            projectHelper.typesProject = "Программа для ЭВМ:";
                          
                            projectHelpers.Add(projectHelper);
                        }

                    }
                   
                    CountSved = projectHelpers.Count;
                }
            }

            using (SqlConnection conn = dat.getConnection())
            {
                //Задаем подключение к команде
                using (SqlCommand sqlCommand = new SqlCommand("SELECT [registration_number], [authors], [right_holders], [contact_to_third_parties], [program_name], [reg_pub_date], [application_number], [application_data] FROM [dbo].[DataBase] WHERE [authors] LIKE N'%" + NameUser + "%'", conn))
                {
                    if (conn.State != System.Data.ConnectionState.Open)
                        conn.Open();
                    sqlCommand.CommandTimeout = 3000000;
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                       
                        while (sqlDataReader.Read())
                        {
                            ProjectHelper projectHelper = new ProjectHelper();
                            projectHelper.registration_number = sqlDataReader[0].ToString();
                            projectHelper.program_name = sqlDataReader[4].ToString();
                            projectHelper.registration_publish_date = sqlDataReader[5].ToString();
                            projectHelper.typesProject = "База данных:";
                            
                            projectHelpers.Add(projectHelper);
                        }

                    }

                    CountSved = projectHelpers.Count;
                }
            }

            CountSved = projectHelpers.Count;
            if (CountSved > 0)
                {
              
                    return word_gen.GenAndSendListSveds(CurrentList,projectHelpers, CountSved, NameUser, _client, ChatId);
                }
          
            return false;
           // listTask.Enqueue(task);
            //foreach()
        }
    }
    public class ProjectManager
    {

        public static List<ProjectListHelper> listHelpers = new List<ProjectListHelper>();
        static bool started = false;

        public static  async void Start(TelegramBotClient _client)
        {
            await Task.Run(() => {
                if(started == false)
                {
                    started = true;
                    if (listHelpers.Count != 0)
                    {
                        while (listHelpers.Count > 0)
                        {
                                if (listHelpers[0].GenIndividualList(_client) == true)
                                {
                                    listHelpers.RemoveAt(0);
                                }
                        }
                        started = false;
                    }
                }
            });
        }
        



    }
}
