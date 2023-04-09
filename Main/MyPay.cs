using System;
using System.Data.SqlClient;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBotIsSimple.Main.DataBases;
using TelegramBotIsSimple.Main.Projects;
using Yandex.Checkout.V3;

namespace TelegramBotIsSimple.Main
{
    /// <summary>
    /// Класс реализующий операции по платежам
    /// </summary>
    public class MyPay
    {
       
       
        public static async void Send(TelegramBotClient _client, Telegram.Bot.Types.Update update)
        {
     
            await _client.AnswerPreCheckoutQueryAsync(update.PreCheckoutQuery.Id);
         
        }
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
        public string _Status;
        public MyPay()
        {
            string str = StatusFromBd();
            _Status = str;
            string key = str.Equals("Test") ? "test_AnQVw3FYWfBzk8rrjUD6yIew_CLLkF3txkARA34YtHI" : "Хуй его знает";
            client = new Yandex.Checkout.V3.Client(shopId: "838191", secretKey: key);
        }
        public static async void SendWaitPay(TelegramBotClient _client,long ChatId)
        {
           await _client.SendTextMessageAsync(ChatId,"Ваш платеж пока не поступил:(");
        }
        static Yandex.Checkout.V3.Client client; 
        /// <summary>
        /// Получить платеж по айди
        /// </summary>
        /// <param name="id_payment">Айди платежа</param>
        /// <returns>Возвращает платеж</returns>
        static Yandex.Checkout.V3.Payment getPayment(string id_payment)
        {
            var payment = client.GetPayment(id_payment);

            return payment;
        }
        public static string GetStatusPayment(TelegramBotClient _client, long ChatId, string id_payment)
        {
           return getPayment(id_payment).Status.ToString(); 
        }
        public async void CreatePay(TelegramBotClient _client, long ChatId, Project project, TypesProgs typesProgs)
        {
            AsyncClient asyncClient = client.MakeAsync();
            // 1. Создайте платеж и получите ссылку для оплаты
            var newPayment = new NewPayment
            {
                Amount = new Amount { Value = 3000, Currency = "RUB" },
                Confirmation = new Confirmation
                {
                    Type = ConfirmationType.Redirect,
                    ReturnUrl = "http://myshop.ru/thankyou"
                },
                Description = $"Оплата госпошлины для Пр. для ЭВМ",
                Capture = true,
                Receipt = new Receipt()
                {
                    Email = "Почта юзера",
                    Phone = "телефон юзера",
                    Items = new System.Collections.Generic.List<ReceiptItem>()
                    {
                        new ReceiptItem()
                        {
                            Amount = new Amount()
                            {
                                Currency = "RUB",
                                Value = 3000
                            },
                            Description = $"Оплата госпошлины Пр. для ЭВМ",
                            Quantity = 1,
                            VatCode = VatCode.NoVat
                        }
                    }
                }
            };
            Payment payment = client.CreatePayment(newPayment);
            // 2. Перенаправьте пользователя на страницу оплаты
            string url = payment.Confirmation.ConfirmationUrl;

            InlineKeyboardMarkup reply = new InlineKeyboardMarkup(new InlineKeyboardButton
            {
                Text = "Проверить статус платежа",
                CallbackData = payment.Id + "!" + project.HandShake + "!" + typesProgs.ToString()
            });
            await _client.SendTextMessageAsync(ChatId, $"Оплата госпошлины на проект:\n<code>{project.NameProject}</code>\n\n" + url, Telegram.Bot.Types.Enums.ParseMode.Html, replyMarkup: reply);
            if (_Status.Equals("Test"))
            {
                await _client.SendTextMessageAsync(ChatId, "Для проведения тестового платежа используйте следующие данные:\nНомер карты: <b>5555 5555 5555 4477</b>\nДата действия: <b>любая от текущей даты</b>\nCVV (код на обратной стороне): <b>любые три цифры</b>\nКод подтверждения: <b>любые три цифры</b>", Telegram.Bot.Types.Enums.ParseMode.Html, replyMarkup: null);
            }
        }
    }
}
