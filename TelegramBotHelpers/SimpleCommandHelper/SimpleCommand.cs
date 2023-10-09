using BRONUF_Main.Main.Commands;
using BRONUF_Main.Main.Commands.Menu.IndividualProject;
using BRONUF_Main.Main.Commands.Menu.SearchScientificPapers;
using BRONUF_Main.Main.Commands.Menu.SearchScientificPapers.GetForm16;
using System.Collections.Generic;

namespace BRONUF_Main
{
    /// <summary>
    /// Внешний вспомогательный класс 
    /// </summary>
    internal partial class TelegramBotHelper
    {
        /// <summary>
        /// Список команд
        /// </summary>
        private List<Commands> commands;
        /// <summary>
        /// Функция инициализации обычных команд
        /// </summary>
        private void SetCommands()
        {
            commands = new List<Commands>()
        {
              //Команда основного меню
              new CommandsMainsMenu(),
                    //Индивидуальные проекты
                    new CommandsIndividualProject(),
                        //Оформить заявку "Программа"
                        new CommansApplicationProgramm(),
                        //Оформить заявку "База данных"
                        new CommandsApplicationDataBase(),
                        //Оформить заявку "Заявка на изобретение"
                        new CommandsApplicationInvention(),
                        //Оформить заявку "Заявка на ТИМС"
                        new CommandsApplicationScheme(),
                        //Оформить заявку "Заявка на полезную модель"
                        new CommandsApplicationUtilityModel(),

                    //Команда "Режим готовых решений"
                    new CommandsReadySolutionMode(),
                        //Акт реализации
                        new CommandsAkt(),
                        //Статья ВАК (соавторство)
                        new CommandsBAK(),
                        //Изобретение (соавторство)
                        new CommandsInvension(),
                        //Статья не РИНЦ (соавторство)
                        new CommandsNotRinc(),
                        //Патент на ТИМС (соавторство)
                        new CommandsPatentTIMS(),
                        //Стстья РИНЦ (соавторство)
                        new CommandsRinc(),
                        //Статья SCOPUS (соавторство)
                        new CommandsScopus(),
                        //Полезная модель (соавторство)
                        new CommandsUtilityModel(),

                    new CommandsSearchScientificPaper(),
                        new CommandsGetForm16(),

                //Меню справочной системы
                new CommandSpravSystemMenu(),
                    //Инструкция по использованию
                    new CommandsInstructionMenu(),
                        //Как стать участником программы для ЭВМ
                        new CommandsInstructionEVM(),
                    //Поддержка
                    new CommandsSupport(),
                    //Команда отрисовки меню "Научные труды что и для чего"
                    new CommandsScientificPapersMenu(),
                        //О патенте на ЭВМ
                        new CommandsScientificEVM(),
                        //О патенте на Базу данных
                        new CommandsScientificDataBase(),
                    //О Нас
                    new CommandsAboutOur(),
                    //О проекте
                    new CommandsAboutBRONUF(),
            //Старт бота
            new CommandsStart(),
            //Отрисовка дочернего меню
            new CommandsChildMenu(),
            //Команда назад
            new CommandsBack()

        };
        }
    }
}
