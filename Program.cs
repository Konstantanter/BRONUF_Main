using BRONUF_Library;
using System;
using System.Text;

namespace BRONUF_Main
{

    class Program
    {
        /// <summary>
        /// Основной токен 
        /// </summary>
        //const string Token = "1248432377:AAEs_YD9M2da-9IoxA-_HtFt4TGRMCibag8";

       const string Token = "1890057432:AAG_Or8B_LP1AVoE8pmnwtc3NtpKxCzHp1w";
        //1890057432:AAG_Or8B_LP1AVoE8pmnwtc3NtpKxCzHp1w (KOBRA)
        public static void Main(string[] args)
        {

            
                //Создаём необходимые директории при запуске
                GeneralData genetal = new GeneralData();
                //протокол безопасного соединения
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                //Вызов вспомогательного класса
                TelegramBotHelper hlp = new TelegramBotHelper(token: Token);
                Console.OutputEncoding = Encoding.UTF8;
                //Уведомление о том что бот успешно запущен
                Console.WriteLine("Бот успешно запущен\n\n");


                //Получаем обновления
                hlp.GetUpdates();

            //}
            //Обработка исключений
            //catch (Exception ex)
            //{
            //    Console.WriteLine(String.Format("Возникло исключение: {0}", ex.Message));
            //    Console.ReadKey();
            //    //Console.Beep();
            //}
        }
    }
}
