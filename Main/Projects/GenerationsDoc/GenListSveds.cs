using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Telegram.Bot;
using Telegram.Bot.Types.InputFiles;
using BRONUF_Main.Main.Commands.Menu.SearchScientificPapers.GetForm16;

namespace BRONUF_Main.Main.Projects.GenerationsDoc
{
    
    partial class Word_Gen
    {
        public bool GenAndSendListSveds(List<int> CurrentList, List<ProjectHelper> projectHelpers, int CountSved, string NameUser, TelegramBotClient _client, long ChatId)
        {

            object ФорматСтроки = Microsoft.Office.Interop.Word.WdUnits.wdLine;
            //object СмещениеКурсора;
            var t = Type.Missing; //значение по умолчанию
            Microsoft.Office.Interop.Word.Application WORD = new Microsoft.Office.Interop.Word.Application();
            //Делаем видимым все происодящее 
            WORD.Visible = false;
            // Открываем новый документ 
            var Документ = WORD.Documents.Add(t, t, t, t);
            //работа с текстом
            WORD.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            WORD.Selection.Font.Name = ("Times New Roman"); //тип шрифта
            WORD.Selection.Font.Bold = 0; // жирный шрифт
            WORD.Selection.Font.Size = 14; // высота шрифта 20
            WORD.Selection.TypeText("Список работ пользователя: ");
            WORD.Selection.TypeParagraph();
            WORD.Selection.Font.Bold = 1;
            WORD.Selection.TypeText($"{NameUser}");
            //Transform_Text(NameUser, 0);
            WORD.Selection.Paragraphs.SpaceAfter = 0;
            WORD.Selection.TypeParagraph();
            WORD.Selection.TypeParagraph();
            WORD.Selection.Font.Bold = 0;
            WORD.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;


            object ПоказыватьГраницы = WdDefaultTableBehavior.wdWord9TableBehavior;
            object РегулирШирины = WdAutoFitBehavior.wdAutoFitWindow;
            WORD.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            Range wrdRng = WORD.Selection.Range;
            WORD.Selection.Font.Size = 12;

            int rows = projectHelpers.Count + 1;

            Table table = WORD.ActiveDocument.Tables.Add(wrdRng, rows, 4, ПоказыватьГраницы, РегулирШирины);

            wrdRng = WORD.ActiveDocument.Tables[1].Cell(1, 1).Range;
            wrdRng.Cells.VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            wrdRng.Text = "№ п/п";

            wrdRng = WORD.ActiveDocument.Tables[1].Cell(1, 2).Range;
            wrdRng.Text = "Регистрационный номер";
            wrdRng = WORD.ActiveDocument.Tables[1].Cell(1, 3).Range;
            wrdRng.Text = "Название работы";
            wrdRng = WORD.ActiveDocument.Tables[1].Cell(1, 4).Range;
            wrdRng.Text = "Дата регистрации";

            for (int i = 2; i <= rows; i++)
            {
                wrdRng = WORD.ActiveDocument.Tables[1].Cell(i, 1).Range;
                wrdRng.Cells.VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                wrdRng.Text = Convert.ToString(i-1);
                wrdRng = WORD.ActiveDocument.Tables[1].Cell(i, 2).Range;
                wrdRng.Cells.VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                wrdRng.Text = projectHelpers[i-2].registration_number;
                wrdRng = WORD.ActiveDocument.Tables[1].Cell(i, 3).Range;
                wrdRng.Cells.VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                wrdRng.Text = String.Format("{0}\n\"{1}\"", projectHelpers[i - 2].typesProject,projectHelpers[i-2].program_name);
                wrdRng = WORD.ActiveDocument.Tables[1].Cell(i, 4).Range;
                wrdRng.Cells.VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                wrdRng.Text = extractDate(projectHelpers[i-2].registration_publish_date).ToShortDateString() +" г.";
            }
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\SKYNET3\\Project\\Temp\\";
           
            string FileNameDoc = path +System.IO.Path.GetFileNameWithoutExtension(System.IO.Path.GetRandomFileName());
            string FileName = FileNameDoc + ".pdf";
            object pdfForm = WdSaveFormat.wdFormatPDF;
            WORD.ActiveDocument.SaveAs2(FileNameDoc, t, t, t, t, t, t, t, t, t, t, t, t, t, t, t, t);
            WORD.ActiveDocument.SaveAs2(FileName, pdfForm, t, t, t, t, t, t, t, t, t, t, t, t, t, t, t);
            WORD.ActiveDocument.Close(t, t, t);
            WORD.Quit(t, t, t);
            int count = CountSved;
            int tmp_count = count % 10;
              
            if (count > 0)
            {
                _client.SendTextMessageAsync(ChatId, string.Format("У пользователя:\n\"<b>{0}</b>\"\n\nНайдено: <b>{1}</b> работ{2}", NameUser, count, count == 11 || count == 0 ? "" : (tmp_count <= 1 || tmp_count >= 5 ? (tmp_count == 1 ? "" : "") : "а")), Telegram.Bot.Types.Enums.ParseMode.Html, replyMarkup: null);
            }
            else
            {
                _client.SendTextMessageAsync(ChatId, "У пользователя:\n\"<b>" + NameUser + "</b>\"\n\nНаучных работ <b>не найдено</b>\n\nНе расстраивайтесь у Вас всё еще впереди, для этого и был создан этот бот!", Telegram.Bot.Types.Enums.ParseMode.Html, replyMarkup: null);
            }
            using (var stream = System.IO.File.OpenRead(FileName))
            {
                InputOnlineFile inputOnlineFile = new InputOnlineFile(stream, FileName);
                inputOnlineFile.FileName = $"Список научных работ {NameUser}.pdf";
                var r = _client.SendDocumentAsync(ChatId, inputOnlineFile, caption: $"Список научных работ пользователя:\n<b>{NameUser} по состоянию на {DateTime.Now.ToLongDateString()}</b>", parseMode: Telegram.Bot.Types.Enums.ParseMode.Html, replyMarkup: null).Result;
            }
          
            //WORD.Quit(t, t, t);
            //WORD.Quit(t, t, t);

            List<int> newList = new List<int>();
            foreach (Process proc in Process.GetProcessesByName("WINWORD"))
            {
                newList.Add(proc.Id);
            }
            List<int> DeleteList = new List<int>();
            foreach (int a in newList)
            {
                if (CurrentList.Contains(a)) continue;
                else DeleteList.Add(a);
            }
            foreach (int b in DeleteList)
            {
                Process.GetProcessById(b).Kill();
            }
            System.IO.File.Delete(FileName);
            System.IO.File.Delete(FileNameDoc+".docx");
            return true;


        }
        private DateTime extractDate(string line)
        {
            try
            {
                DateTime dateTime = DateTime.Parse(line);
                return dateTime;
            }
            catch (Exception)
            {
                int year = Convert.ToInt32(line.Substring(0, 4));
                int month = Convert.ToInt32(line.Substring(4, 2));
                int day = Convert.ToInt32(line.Substring(6, 2));
                return new DateTime(year, month, day);
            }
        }
    }
}
