using BRONUF_Library;
using BRONUF_Library.Projects;
using BRONUF_Library.User;
using BRONUF_Main.Main.Buttons;
using BRONUF_Main.Main.Commands.Menu.IndividualProject;
using BRONUF_Main.Main.Commands.Menu.PatentEVM;
using BRONUF_Main.Main.Projects;
using BRONUF_Main.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;

namespace BRONUF_Main.Main.Commands.MultipleCommands
{
    /// <summary>
    /// Команда "Соавторство: патент на ПрЭВМ"
    /// </summary>
    internal class MultipleCommandsPatentEVM : MultipleCommand
    {
        #region Объявление переменных
        /// <summary>
        /// Флаг который определяет число пользователь на котором будет закрываться проект и передваться на регистрауию
        /// </summary>
        public const int countUserInProject = 1;

        /// <summary>
        /// Список проектов
        /// </summary>
        private List<Project> Listprojects;

        /// <summary>
        /// Вспомогательный класс для генерации проектов
        /// </summary>
        private readonly ServiceCreatedProject CreatedProject = null;
        #endregion

        /// <summary>
        /// Успешная регистрация автора
        /// </summary>
        /// <param name="_client">Клиент телеграмм</param>
        /// <param name="ChatId">Ид чата</param>
        /// <param name="project">Проект</param>
        public async void SuccessRegAuthor(TelegramBotClient _client, long ChatId, Project project)
        {
            //Если текущий проект существует
            if (project != null)
            {
                //Объявляем список пользоватлей
                List<Users> usersList = null;
                //Объявляем пользователя
                Users user = null;
                //Вспомогательная переменная 
                Button button = new Button();
                //Проверяем существование пользовательского файла
                if (System.IO.File.Exists("Users.bin"))
                {
                    //Загружаем список пользователей
                    usersList = Serializer.LoadListFromXml<Users>("Users.bin");
                    //Пытаемся найти текущего пользователя по ID-у чата
                    user = usersList.Find(a => a.ChatId.Equals(Convert.ToString(ChatId)));
                }
                //Если среди списка пользователей проекта, ID пользователя уже сущестует, значит об был ранее зарегистрирован
                if (project.ListUsers.Find(a => a.ChatId.Equals(Convert.ToString(user.ChatId))) != null)
                {
                    //Отправка сообщения
                    await _client.SendTextMessageAsync(ChatId, "В этой программе вы уже участвуете");
                }
                else
                {
                    //мой ID чата 
                    long KostetChat = Convert.ToInt64(Resources.KostetIdChat);
                    //ID Чата моего брата
                    long BratIdChat = Convert.ToInt64(Resources.BraIdChat);
                    //Отправка сообщения об успешной оплате мне
                    await _client.SendTextMessageAsync(KostetChat, $"Пользователь:\n<b>{user.GetFullNameUser()}</b> (ID чата - <b>{user.ChatId}</b>),\n\nОплатил программу для ЭВМ:\n\n<code>{project.NameProject}</code>", Telegram.Bot.Types.Enums.ParseMode.Html, replyMarkup: null);
                    //Отправка сообщения об успешной оплате моему брату
                    //await _client.SendTextMessageAsync(BratIdChat, $"Пользователь:\n<b>{user.GetFullNameUser()}</b> (ID чата - <b>{user.ChatId}</b>),\n\nОплатил проект:\n\n<code>{project.NameProject}</code>", Telegram.Bot.Types.Enums.ParseMode.Html, replyMarkup: null);
                    //Отправка сообщения пользователю
                    await _client.SendTextMessageAsync(ChatId, $"Поздравляю Вы <b>успешно</b> оплатили программу для ЭВМ: \n\n<code>{project.NameProject}</code>", Telegram.Bot.Types.Enums.ParseMode.Html, replyMarkup: null);
                    //Если на текущий момент в списке пользователей пусто
                    if (project.ListUsers.Count == 0)
                    {
                        //То текущий пользователь становится правообладателем проекта
                        user.ITPRAVO = true;
                    }
                    //Регистрируем текущего пользователя на наш проект
                    project.ListUsers.Add(user);
                    //Проверяем достигло ли число пользователей флага укомплектованности
                    if (project.ListUsers.Count() == countUserInProject)
                    {
                        //Создаем директорию 
                        System.IO.Directory.CreateDirectory(project.MainPath);
                        //Генерируем случайное имя для проекта
                        string path = project.MainPath + System.IO.Path.GetFileNameWithoutExtension(System.IO.Path.GetRandomFileName()) + ".kobra";
                        //Сохраняем наш проект в файл
                        Serializer.SaveToXml<Project>(path, project);
                        ReplaceProject(project);
                    }
                }
            }
        }
        /// <summary>
        /// Функция замены проекта
        /// </summary>
        /// <param name="projetc">Проект который нужно заменить</param>
        public void ReplaceProject(Project projetc)
        {
            /*
             * Данный алгоритм я назвал "Если взял, то положи на место"
             */
            //Получаем акутальный список проектов
            Listprojects = CreatedProject.GetListProject();
            //Нам понадобится индекс проекта
            int mainIndex = Listprojects.FindIndex(a => a.HandShake.Equals(projetc.HandShake));
            //Удаляем наш проект
            Listprojects.RemoveAt(mainIndex);
            //Определяем новый список для кранения списка проектов в текущей теме 
            List<Project> newList = Listprojects.FindAll(a => a.NameTheme.Equals(projetc.NameTheme));

            string str = StatusFromBd();
            if (!str.Equals("Test"))
            {
                System.IO.File.Delete(projetc.FileName);
            }
            //Получаем список проектов которые имеются в текущей теме
            List<string> allFiles = System.IO.Directory.GetFiles(System.IO.Path.GetDirectoryName(Theme.FileNamesThemeEVM) + $"\\{projetc.NameTheme}\\").ToList();
            //Также потребуется вспомогательный класс для обработки файлов проектов           
            List<FilesHelper> listFileHelper = new List<FilesHelper>();
            //Добавим все файлы в наш вспомогательный класс
            foreach (string line in allFiles)
            {
                if (line != "")
                {
                    listFileHelper.Add(new FilesHelper(line));
                }
            }
            ////Объявляем новый список файлов
            //var newLists = new List<FilesHelper>();
            foreach (FilesHelper fileHelpers in listFileHelper)
            {
                //Отмечаем посещёнными, все файлы тех проектов которые были ранее
                foreach (Project files in newList)
                {
                    if (fileHelpers.PathToFile.Equals(files.FileName))
                    {

                        fileHelpers.Visited = true;
                    }
                }
            }
            //Собираем список непосещенных файлов
            List<FilesHelper> listNotVisited = listFileHelper.FindAll(a => a.Visited == false); //Если замена не работаеттут вместо listFileHelper ставь newLists и убери комментарии в цикле
            //Если список не пуст
            if (listNotVisited != null)
            {
                //Находим случайный проект из списка
                FilesHelper randProject = listNotVisited[(new Random()).Next(0, listNotVisited.Count)];
                //Создаём наш проект
                Project project = new Project(System.IO.File.ReadAllText(randProject.PathToFile))
                {
                    //Передаём имя темы
                    NameTheme = System.IO.Path.GetFileName(System.IO.Path.GetDirectoryName(randProject.PathToFile)),
                    //Генерируем хэндшейк
                    HandShake = System.IO.Path.GetFileNameWithoutExtension(System.IO.Path.GetRandomFileName()),
                    //Передавем имя файла
                    FileName = randProject.PathToFile
                };
                //Вставляем новый проект вместо старого
                Listprojects.Insert(mainIndex, project);
            }
        }
        /// <summary>
        /// Команда "Соавторство: патент на ПрЭВМ"
        /// </summary>
        public MultipleCommandsPatentEVM(ServiceCreatedProject createdProjects)
        {
            //Передаём сервис для генерации проектов
            CreatedProject = createdProjects;

            //Обнуляем счётчик текущего вопроса
            countQwesh = 0;
        }
        /// <summary>
        /// Имя комманды
        /// </summary>
        public override string Name { set; get; } = Button.ButtonsPatentntEVM;

        /// <summary>
        /// Списко действий которые должны выполниться при вызове команды
        /// </summary>
        public override async void Execute(TelegramBotClient _client, long ChatId)
        {
            Button button = new Buttons.Button();
            await _client.SendTextMessageAsync(ChatId, "Доброе время суток!\nВыберите пожалуйста интересующую вас область:", replyMarkup: button.DrawAllThemes(TypesProgs.PatentEVM));
        }
        /// <summary>
        /// Функция отпраки ответа (реализуется в мульти-командах)
        /// </summary>
        /// <param name="_client">Телеграм клиент</param>
        /// <param name="ChatId">ID чата</param>
        /// <param name="nameCommand">Имя команды</param>
        public override async void SendAnswer(TelegramBotClient _client, long ChatId, string nameCommand)
        {
            //Если текущий вопрос нулейвой
            if (countQwesh == 0)
            {
                //Вспомогательная переменная кнопка
                Button button = new Button();
                //Класс для генерации проектов
                CreatedProject.UpdateProjects();
                //Список проектоа
                Listprojects = CreatedProject.GetListProject();
                //Список тем
                List<string> listTheme = Serializer.LoadListFromXml<string>(Theme.FileNamesThemeEVM);
                //Если список команд содердит выбраннуб тему (для фильтрации от идиотов)
                if (listTheme.Contains(nameCommand))
                {
                    //Отсылаем сообщение о выбранной теме
                    await _client.SendTextMessageAsync(ChatId, $"Выбранная тема: \"{nameCommand}\"", replyMarkup: null);
                    //Объявляем новую тему
                    Theme newTheme = new Theme(nameCommand, TypesProgs.PatentEVM);
                    //Получаем список проектов в теме
                    List<Project> newList = Listprojects.Where(a => a.NameTheme.Equals(nameCommand)).ToList();
                    //Вспомогательная переменная для нумерации
                    int i = 0;
                    //Отсылка сообщения
                    await _client.SendTextMessageAsync(ChatId, $"Список доступных программ:", replyMarkup: null);
                    //Начинаем рисовать наши проекты
                    foreach (Project project in newList)
                    {
                        //Отсылаем сообщение о текущем проекте
                        await _client.SendTextMessageAsync(ChatId, $"<b>{GeneralData.TmpProgrammName} № {i + 1}</b>:\n<code>{project.NameProject}</code>", Telegram.Bot.Types.Enums.ParseMode.Html, replyMarkup: button.DrawInlineButton(project.HandShake));
                        //Инкремент указателя (номератора)
                        i++;
                    }
                }
                else
                {
                    //Сообщение о том что пользователь прислал (или выбрал что то не то)
                    await _client.SendTextMessageAsync(ChatId, $"Темы с именем: {nameCommand}, не существует", replyMarkup: null);
                }

            }
        }
        /// <summary>
        /// Регистрация пользователя на проект
        /// </summary>
        /// <param name="Data">Данные обновления</param>
        /// <param name="_client">Клиент телеграмм</param>
        /// <param name="ChatId">ID чата</param>
        public async void RegAuthor(string Data, TelegramBotClient _client, long ChatId)
        {
            //Вспомогательная переменная Кнопка
            Button button = new Button();
            //Переменная для разделения полученных данных
            string str = "\n";
            //Получаем индекс разделителя
            int index = Data.LastIndexOf(str);
            //получаем необходимые данные
            Data = Data.Substring(index + str.Length, Data.Length - index - str.Length);
            //Получеам список актуальных проектов
            Listprojects = CreatedProject.GetListProject();
            //Получаем проект с указанными данными
            Project project = Listprojects != null ? Listprojects.Find(a => a.NameProject.Contains(Data)) : null;
            //Задержка (не в развитии)
            await Task.Delay(5000);
            //Объявляем список пользователей
            List<Users> usersList = null;
            //Объявляем пользовател
            Users user = null;
            //Если файл пользователей существует
            if (System.IO.File.Exists("Users.bin"))
            {
                //Загружаем список пользователей
                usersList = Serializer.LoadListFromXml<Users>("Users.bin");
                //Если список не пуст (а поверь мне мой друг такое может быть)
                if (usersList != null)
                {
                    //Ищем нашего пользователя по номеру чата
                    user = usersList.Find(a => a.ChatId.Equals(Convert.ToString(ChatId)));
                }
            }
            //Если пользователь не зарегестрирован
            if (user == null)
            {
                //Отправляем сооьщение о регистрации
                await _client.SendTextMessageAsync(ChatId, $"Для начала нужно зарегистрироваться! Меню -> Зарегистрироваться", replyMarkup: null);
            }
            else
            {
                //Если проекта не сущесствует (наприемр он уже обработан)
                if (project == null)
                {
                    //Вывод сообщения
                    await _client.SendTextMessageAsync(ChatId, $"Такой программы уже не существует!", replyMarkup: null);

                }
                else
                {
                    //Если всё хорошо и всё существует, создаём платёж
                    MyPay myPay = new MyPay();
                    myPay.CreatePay(_client, ChatId, project, TypesProgs.PatentEVM);
                }
            }
        }

        /// <summary>
        /// Переопределяем родительскую команду
        /// </summary>
        public override Commands ParentsComands { set; get; } = new CommandsReadySolutionMode();
        /// <summary>
        /// Переопределяем функцию сброса текщуй команды
        /// </summary>
        public override void Reset()
        {
            countQwesh = 0;
        }
    }


}
