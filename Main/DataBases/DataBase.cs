using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotIsSimple.Main.DataBases
{
    //// <summary>
    /// Класс для управления базой данных
    /// </summary>
    /// <summary>
    /// Класс для управления базой данных
    /// </summary>
    public partial class DataBase
    {

       public  DataBase()
        {
 
           // OpenConnection();
        }
        /// <summary>
        /// Строка подключения к БД
        /// </summary>
        /// Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="{System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath)}\UsersBase.mdf";Integrated Security=True
        /// Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="C:\Users\KOBRA\Desktop\приеры оих работ\SkyNet\GUI_V_2\UsersBase.mdf";Integrated Security=True;Connect Timeout=30
        public static string srt = @"C:\Users\BRONUF\Desktop\Sveds.mdf";
        //public static string srt = $"{System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath)}\\UsersBase.mdf";
        public SqlConnection sqlConnection;
        //System.IO.Path.GetNA
        /// <summary>
        /// Открытие Соединения
        /// </summary>
        public async void OpenConnection()
        {

            await Task.Run(() =>
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                {

                    //sqlConnection.
                    sqlConnection.Open();
                }
            });
        }
        /// <summary>
        /// Закрытие Соединения
        /// </summary>
        public async void CloseConnection()
        {
            await Task.Run(() =>
            {
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            });
        }
        public SqlConnection getConnection()
        {
            //string str = ;

            
            return new SqlConnection($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={srt};Integrated Security=True;Connect Timeout=30");
        }
    }
}
