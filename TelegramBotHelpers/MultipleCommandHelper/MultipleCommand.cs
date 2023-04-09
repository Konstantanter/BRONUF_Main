﻿using System.Collections.Generic;
using TelegramBotIsSimple.Main.Commands.MultipleCommands;



namespace TelegramBotIsSimple
{

    /// <summary>
    /// Внешний вспомогательный класс 
    /// </summary>
    internal partial class TelegramBotHelper 
    {
        private void SetMultipleCommands() => mulcommands = new List<MultipleCommand>()
        {
           
             //Меню -> Стать соавтором
            new MultipleCommandsPatentEVM(new Main.Projects.ServiceCreatedPatentEVM()),

            new MultipleCommandsPatentBD(new Main.Projects.ServiceCreatedPatentBD()),
            //Меню -> Зарегистрироваться
            new MultipleRegUser(),
          

        };
    }
}
