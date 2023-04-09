using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types.InputFiles;
using TelegramBotIsSimple.Main.Commands.Menu.UserFindProject;
using TelegramBotIsSimple.Main.User;

namespace TelegramBotIsSimple.Main.Commands.Menu.SearchScientificPapers.GetForm16
{
    internal class CommandsGetForm16 : Commands
    {
        /// <summary>
        ///  Команда для поиска проектов пользователя
        /// </summary>
        public CommandsGetForm16(){}
        /// <summary>
        /// Переопределяем имя команды
        /// </summary>
        public override System.String Name { set; get; } = Buttons.Button.ButtonGetForm16;
        /// <summary>
        /// Переорпределяем функцию  выполнения команды
        /// </summary>
        public override async void Execute(TelegramBotClient _client, long ChatId)
        {
            //Вспомогательный список пользователей
            List<Users> usersList = null;
            //Текущий пользователь
            Users user = null;
            //Проеряем если существует файл с пользователями
            if (System.IO.File.Exists("Users.bin"))
            {
                //Инициализируем список пользователей
                usersList = Serializer.LoadListFromBinnary<Users>("Users.bin");
                //Если он не пуст 
                if (usersList != null)
                {
                    //находим текущего пользователя по id его чата
                    user = usersList.Find(a => a.ChatId.Equals(Convert.ToString(ChatId)));
                    //Очищаем наш временный список пользователй для экономии памяти
                    usersList.RemoveAll(a => a.Family.Length >= 0);
                }
            }
            //Если мы нашли текущего пользователя
            if (user != null)
            {
                //Инициализиуем вспомогательный класс по генерации проектов пользователя
                ProjectListHelper projectListHelper = new ProjectListHelper(user.GetFullNameUser(), ChatId);
                //Формируем список сивдетельств пользователя
               // projectListHelper.GenIndividualList(_client);
                ProjectManager.listHelpers.Add(projectListHelper);
                ProjectManager.Start(_client);
            }
            //Если пользователя не найдено
            else
            {
                //Формируем соответствующее сообщение
                await _client.SendTextMessageAsync(ChatId, $"Для начала нужно зарегистрироваться! Меню -> Зарегистрироваться", replyMarkup: (new Buttons.Button()).DrawMainsMenuButtons());
            }
        }
        //Родительская команда это комнада для вызова "Основаное меню"
        public override Commands ParentsComands { set; get; } = new CommandsSearchScientificPaper();
    }
}
