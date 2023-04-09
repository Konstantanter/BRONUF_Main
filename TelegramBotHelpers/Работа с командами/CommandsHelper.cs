using System;
using System.Linq;
using System.Threading;
using TelegramBotIsSimple.Main.Buttons;
using TelegramBotIsSimple.Main.Commands;
using TelegramBotIsSimple.Main.Commands.MultipleCommands;

namespace TelegramBotIsSimple
{
    /// <summary>
    /// Внешний вспомогательный класс 
    /// </summary>
    internal partial class TelegramBotHelper
    {
        async void JobsCommands(Telegram.Bot.Types.Update update, string state, string text)
        {
            long ChatId = update.Message.Chat.Id;

            
            if (text != null || text !="")
            {

                Console.WriteLine($"{DateTime.Now.ToString("dd.MM.yyyy г. HH ч. mm м. ss сек.\n") + ": " + $"{update.Message.From.FirstName} {update.Message.From.LastName} (логин - {update.Message.From.Username})" } отправил сообщение: '{text}', ID чата '{ChatId}'\n\n");
                if (commands.Any(c => text.Contains(c.Name)))
                {
                    try
                    {
                        var curCommand = commands.FirstOrDefault(c => text.Contains(c.Name));
                        _clientStates[ChatId] = curCommand.Name;

                        if (curCommand.Name.Equals(Button.ButtonsBack))
                        {
                           
                            if(state != null)
                            {
                                if (commands.Any(a => a.Name.Equals(state)))
                                {
                                    PresentCommand = commands.FirstOrDefault(a => a.Name.Equals(state)).ParentsComands;
                                }
                                if (mulcommands.Any(a => a.Name.Equals(state)))
                                {
                                    CurTmpCommand = mulcommands.FirstOrDefault(a => a.Name.Equals(state));
                                }
                            }
                            else
                            {
                                PresentCommand = null;
                                CurTmpCommand = null;
                            }
                            if (PresentCommand != null)
                            {
                                if (CurTmpCommand is MultipleCommand)
                                {
                                    (CurTmpCommand as MultipleCommand).Reset();
                                }
                                PresentCommand.Execute(_client, ChatId);
                                PresentCommand = PresentCommand.ParentsComands;
                            }
                            else (new CommandsMainsMenu()).Execute(_client, ChatId);
                        }
                        else
                        {
                            PresentCommand = curCommand.ParentsComands;
                            curCommand.Execute(_client, ChatId); // вытягиваем 
                        }

                    }
                    catch (System.Exception ex)
                    {
                        Console.WriteLine("Исключение при обращении ко списку простых комманд: {0}", ex.Message);
                    }
                }
                else if (mulcommands.Any(c => text.Contains(c.Name)))
                {
                    try
                    {

                        var curmulCommand = mulcommands.FirstOrDefault(c => text.Contains(c.Name));

                        _clientStates[ChatId] = curmulCommand.Name;
                        CurTmpCommand = curmulCommand;
                        if (!curmulCommand.Name.Equals(Button.ButtonsBack))
                        {
                            PresentCommand = curmulCommand.ParentsComands;
                            curmulCommand.Execute(_client, ChatId); // вытягиваем 
                        }
                    }
                    catch (System.Exception ex)
                    {
                        Console.WriteLine("Исключение при обращении ко списку многоуровневых комманд: {0}", ex.Message);
                    }
                }
                else
                {
                if (state != null && mulcommands.Any(c => c.Name.Contains(state)))
                    {
                        mulcommands.FirstOrDefault(c => c.Name.Contains(state)).SendAnswer(_client, ChatId, text);
                    }
                    else
                    {
                        try
                        {
                            await _client.SendTextMessageAsync(ChatId, String.Format("Простите, но команды: \"{0}\", я не знаю. Попробуйте нажать \"Помощь\"", text), replyMarkup: button.DrawMainsMenuButtons());
                        }
                        catch (Exception)
                        {
                            Thread.Sleep(1000);
                        }
                    }

                }

            }
            else
            {
                if (state != null && mulcommands.Any(c => c.Name.Contains(state)))
                {
                    mulcommands.FirstOrDefault(c => c.Name.Contains(state)).SendAnswer(_client, ChatId, text);
                }
                else
                {
                    await _client.SendTextMessageAsync(ChatId, String.Format("Простите, но команды: \"{0}\", я не знаю. Попробуйте нажать \"Помощь\"", text), replyMarkup: button.DrawMainsMenuButtons());
                }

            }


        }
    }
}
