using System;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBotIsSimple.Main.Commands.Start
{
    internal class CommandsStart : Commands
    {
    
        public override System.String Name { set; get; } = Buttons.Button.ButtonStart;

        public bool IsActiveMember(ChatMemberStatus res)
        {
           

            if (res == ChatMemberStatus.Administrator)
                return true;
            if (res == ChatMemberStatus.Creator)
                return true;
            if (res == ChatMemberStatus.Member)
                return true;

            return false;
        }
        
        public override async void Execute(TelegramBotClient _client, long ChatId)
        {
           
               // await _client.SendTextMessageAsync(ChatId, "Пока не подпишешься хер тебе!");
               //Telegram.Bot.Types.ChatId chatChatId = new Telegram.Bot.Types.ChatId(-1001188987760);

               // //CancellationTokenSource cts = new CancellationTokenSource();
               
               // var member = _client.GetChatMemberAsync(chatChatId, ChatId);


               // if (IsActiveMember(member.Result.Status) == true)
               // {

                    var button = new Buttons.Button();
                    //await _client.SendTextMessageAsync(-1001761399974, "S");
                    await _client.SendTextMessageAsync(ChatId, "Добро пожаловать в <b>KOBRA Lab</b>\n\n<b>Perge ad cognitionem et scientiam rerum gestarum!</b>\n\nВсе права защищены", Telegram.Bot.Types.Enums.ParseMode.Html, replyMarkup: button.DrawMainsMenuButtons());
                //}
          
        }
        public override Commands ParentsComands { set; get; } = new CommandsMainsMenu();
    }

    
}
