using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotIsSimple.Main;
using TelegramBotIsSimple.Main.Commands.MultipleCommands;
using TelegramBotIsSimple.Main.Projects;

namespace TelegramBotIsSimple
{

    /// <summary>
    /// Внешний вспомогательный класс 
    /// </summary>
    internal partial class TelegramBotHelper
    {
        internal void GetUpdates()
        {
            try
            {
                _client = new Telegram.Bot.TelegramBotClient(_token);
                var me = _client.GetMeAsync().Result;
                if (me != null && !string.IsNullOrEmpty(me.Username))
                {
                    int offset = 0;
                    while (true)
                    {

                        var updates = _client.GetUpdatesAsync(offset).Result;
                        if (updates != null && updates.Count() > 0)
                        {
                            foreach (var update in updates)
                            {
                                processUpdate(update);
                                offset = update.Id + 1;
                            }
                        }


                        Thread.Sleep(1000);
                    }
                }
            }
            catch (Exception)
            {

           }
        }
        private async void processUpdate(Update update)
        {
            await Task.Run(() =>
            {
                switch (update.Type)
                {

                    case UpdateType.Message:
                        
                        long id1 = update.Message.Chat.Id;
                        string state = _clientStates.ContainsKey(update.Message.Chat.Id) ? _clientStates[update.Message.Chat.Id] : (string)null;
                     
                        if (update.Message.Type == MessageType.Text)
                        {

                            string text = update.Message.Text;
                            if (state != null)
                            {
                                JobsCommands(update, state, text);
                                break;
                            }
                            JobsCommands(update, state, text);
                            break;
                        }
                        if (state != null)
                        {
                            //TODO: Наверное это не надо
                            if (!state.Equals("Добавить аннотацию и название"))
                            {
                                //new SaveImage().ExeSaveImage(_client, id1, update);
                                //new SaveCode().ExeSaveCode(_client, id1, update);
                            }
                            else
                                JobsCommands(update, state, (string)null);
                        }
                        break;
                    case UpdateType.CallbackQuery:
                        string text1 = update.CallbackQuery.Message.Text;
                        long ChatId = update.CallbackQuery.Message.Chat.Id;
                        if (text1.Contains("yoomoney"))
                        {
                            string data = update.CallbackQuery.Data;
                            string id_payment = "";
                            string HashProject = "";
                            string typesProgs = "";
                            int i = 0;


                            foreach (string line in data.Split('!'))
                            {
                                if (i == 0)
                                    id_payment = line;
                                if (i == 1)
                                    HashProject = line;
                                if (i == 2)
                                    typesProgs = line;
                                ++i;
                            }

                            if (typesProgs.Equals(TypesProgs.PatentEVM.ToString()))
                            {
                                if (MyPay.GetStatusPayment(_client, ChatId, id_payment).Contains("Succeeded"))
                                {

                                    //MultipleCommandsPatentBD multiple = new MultipleCommandsPatentBD();


                                    Project project = createdPatentEVM.GetListProject().Find(a => a.HandShake.Contains(HashProject));
                                    project.TypeProject = TypesProgs.PatentEVM.ToString();
                                    new MultipleCommandsPatentEVM(createdPatentEVM).SuccessRegAuthor(_client, ChatId, project);
                                    break;
                                }

                            }
                            if (typesProgs.Equals(TypesProgs.DataBase.ToString()))
                            {
                                if (MyPay.GetStatusPayment(_client, ChatId, id_payment).Contains("Succeeded"))
                                {
                                    Project project = createdPatentBD.GetListProject().Find(a => a.HandShake.Contains(HashProject));
                                    project.TypeProject = TypesProgs.DataBase.ToString();
                                    new MultipleCommandsPatentBD(createdPatentBD).SuccessRegAuthor(_client, ChatId, project);
                                    break;
                                }

                            }
                            MyPay.SendWaitPay(_client, ChatId);
                            break;
                        }
                        if (text1.Contains(GeneralData.TmpProgrammName +" №"))
                        {
                            //createdPatentEVM = new ServiceCreatedPatentEVM();
                            new MultipleCommandsPatentEVM(createdPatentEVM).RegAuthor(update.CallbackQuery.Message.Text, _client, ChatId);
                        }
                        if (text1.Contains(GeneralData.TmpBDName +" №"))
                        {
                           // createdPatentBD = new ServiceCreatedPatentBD();
                            new MultipleCommandsPatentBD(createdPatentBD).RegAuthor(update.CallbackQuery.Message.Text, _client, ChatId);
                        }
                        break;
                    case UpdateType.ShippingQuery:
                        break;
                    case UpdateType.PreCheckoutQuery:
                        MyPay.Send(_client, update);
                        break;
                    case UpdateType.MyChatMember:
                        break;
                    default:
                        Console.WriteLine(string.Format("Сообщение вида: {0} не поддерживается!", update.Type));
                        break;
                }
            });
        }

     
    }


}