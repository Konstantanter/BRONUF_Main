using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBotIsSimple.Main.User;
namespace TelegramBotIsSimple.Main.Commands.MultipleCommands
{
    /// <summary>
    /// Меню -> Стать со автором
    /// </summary>
    internal class MultipleRegUser : MultipleCommand
    {
        int countQwesh;
        List<Users> usersList;
        Users user;
        public MultipleRegUser()
        {
            countQwesh = 0;
        }
        /// <summary>
        /// Имя комманды
        /// </summary>
        public override System.String Name { set; get; } = Buttons.Button.ButtonsRegistration;
        /// <summary>
        /// Списко действий которые должны выполниться при вызове команды
        /// </summary>
        public override async void Execute(TelegramBotClient _client, long ChatId)
        {
            var button = new Buttons.Button();
           
            if (System.IO.File.Exists("Users.bin"))
            {
                usersList = Serializer.LoadListFromXml<Users>("Users.bin");
                if (usersList != null)
                {
                    user = usersList.Find(a => a.ChatId.Equals(Convert.ToString(ChatId)));
                }
            }
            else
            {
                usersList = null;
                user = null;
            }
            string str = "Добро пожаловать в меню регистрации!\nПожалуйста введите Вашу фамилию:";
            if (user != null)
            {
                str = "Добро пожаловать на повторную регистрацию!\nПожалуйста введите Вашу фамилию:";
                await _client.SendTextMessageAsync(ChatId, $"Вы уже зарегистрированы как:\n{user.GetFullNameUser()}\n\nПовторная регистрация приведёт к замене данных (если Вы этого не хотете нажмите \"Назад\"", replyMarkup: button.DrawBackAndStopButtons());
            }
            //else
            //{
            await _client.SendTextMessageAsync(ChatId, str, replyMarkup: button.DrawBackAndStopButtons());
            //}
        }
        string family="", name="", otche="";
        public override async void SendAnswer(TelegramBotClient _client, long ChatId, string nameCommand)
        {
          
            var button = new Buttons.Button();
               
            if (countQwesh == 2)
            {
                otche = nameCommand;
                var tmpuser = new Users(family, name, otche, Convert.ToString(ChatId));
                user = null;
                

                await _client.SendTextMessageAsync(ChatId, $"Уважаемый пользователь, обращаем Ваше внимание, что во всех работах Вы будете числиться как:\n<b>{tmpuser.GetFullNameUser()}</b>\n\nЕсли в данных обнаружена опечатка, пожалуйста пройдите регистрацию <b>повторно</b>:\n🗂 Меню => 8️⃣ Зарегистрироваться", Telegram.Bot.Types.Enums.ParseMode.Html, replyMarkup: null);
                await Task.Delay(5000);
                await _client.SendTextMessageAsync(ChatId, $"Регистрация успешно завершена", replyMarkup: button.DrawBackAndStopButtons());
                usersList = null;
                if (System.IO.File.Exists("Users.bin"))
                {
                    usersList = Serializer.LoadListFromXml<Users>("Users.bin");
                    user = usersList.Find(a => a.ChatId.Equals(Convert.ToString(ChatId)));
                }
                if (user != null)
                {
                    int index = usersList.FindIndex(a => a.ChatId.Equals(Convert.ToString(ChatId)));
                    usersList.RemoveAt(index);
                    usersList.Add(tmpuser);
                    Serializer.SaveToXml("Users.bin", usersList);
                    await _client.SendTextMessageAsync(ChatId, $"Ваши данные обновлены в базе данных", replyMarkup: button.DrawBackAndStopButtons());
                }
                else
                {
                    Serializer.SaveElem("Users.bin", tmpuser);
                }

            countQwesh++;
            }
            if (countQwesh == 1)
            {
                name = nameCommand;
                await _client.SendTextMessageAsync(ChatId, $"Пожалуйста введите своё отчество:", replyMarkup: button.DrawBackAndStopButtons());


                countQwesh++;
            }
            if (countQwesh == 0)
            {
                family = nameCommand;
                await _client.SendTextMessageAsync(ChatId, $"Пожалуйста введите своё имя:", replyMarkup: button.DrawBackAndStopButtons());


                countQwesh++;
            }
            
            
        }
        public override Commands ParentsComands { set; get; } = null;

        public override void Reset()
        {
            countQwesh = 0;
        }

    }
}
