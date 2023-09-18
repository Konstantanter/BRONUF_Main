using System.Collections.Generic;
using BRONUF_Main.Main.Commands;
using BRONUF_Main.Main.Commands.Menu.IndividualProject;
using BRONUF_Main.Main.Commands.Menu.SearchScientificPapers;
using BRONUF_Main.Main.Commands.Menu.SearchScientificPapers.GetForm16;



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
        List<Commands> commands;
        /// <summary>
        /// Функция инициализации обычных команд
        /// </summary>
        private void SetCommands() => commands = new List<Commands>()
        {
            
            new CommandsAkt(),
            new CommandsApplicationDataBase(),
            new CommandsApplicationInvention(),
            new CommandsApplicationScheme(),
            new CommandsApplicationUtilityModel(),
            new CommandsBAK(),
            //new CommandsDataBase(),
            new CommandsInvension(),
            new CommandsNotRinc(),
          
            new CommandsPatentTIMS(),
            new CommandsRinc(),
            new CommandsScopus(),
            new CommandsUtilityModel(),
            new CommandsStart(),
            new CommandsMainsMenu(),

            new CommandsReadySolutionMode(),
            new CommandsIndividualProject(),
            new CommansApplicationProgramm(),
            new CommandsGetForm16(),
            new CommandsSearchScientificPaper(),


            new CommandsChildMenu(),

            new CommandSpravSystemMenu(),

            new CommandsSupport(),

            new CommandsBack()
           
        };
    }
}
