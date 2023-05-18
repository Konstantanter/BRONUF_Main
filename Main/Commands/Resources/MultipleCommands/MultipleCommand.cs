using BRONUF_Library;
using System;
using System.Data.SqlClient;
using Telegram.Bot;


namespace BRONUF_Main.Main.Commands.MultipleCommands
{
    /// <summary>
    /// Класс описывающий команды 
    /// </summary>
    internal abstract class MultipleCommand
    {
        public string StatusFromBd()
        {
            //Задаем переменную для хранения статуса
            string ans = "";
            //Класс для подключения к базе данных
            DataBase dat = new DataBase();
            //Команда подключения к базе данных
            string sqlCommand = "SELECT * FROM [dbo].[OtherData]";
            //Используем подключение к базе данных
            using (SqlConnection conn = dat.getConnection())
            {
                //Задаем подключение к команде
                using (SqlCommand cmd = new SqlCommand(sqlCommand, conn))
                {
                    //Время подключения к базе данных
                    cmd.CommandTimeout = 3000000;
                    //Проверяем состояние подключения
                    if (conn.State != System.Data.ConnectionState.Open)
                        conn.Open();
                    //Используем чтение из БД
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        //Выполняем чтение из базы данных
                        while (reader.Read())
                        {
                            //Получаем текущий статус из базы данных
                            ans = String.Format("{0}", reader[3].ToString());
                            break;
                        }

                    }
                }
            }
            //Возвращаем нашу почту 
            return ans;
        }
        public abstract System.String Name { set; get; } //имя команды например /start, Привет, Пока

        public abstract void Execute(TelegramBotClient botClient, long ChatId);//выполнение кода
        public abstract void SendAnswer(TelegramBotClient _client, long ChatId, string nameCommand);

        public abstract Commands ParentsComands { get; set; }
        public abstract void Reset();
    }
}
