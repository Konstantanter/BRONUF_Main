namespace TelegramBotIsSimple.Main.User
{
    public class BaseUser
    {
        public string FIO { get; set; }
        public BaseUser(string fio)
        {
            if (fio[0] == '\n')
            {
                FIO = fio.Substring(1, fio.Length - 1);
            }
            else
            {
                FIO = fio;
            }
        }
    }
   
}
