using System;


namespace BRONUF_Main.Main.User
{
    [Serializable]
    public partial class Users
    {
        /// <summary>
        /// Фамилия
        /// </summary>
        public string Family { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string Otche { get; set; }
        /// <summary>
        /// ИНН
        /// </summary>
        public string INN { get; set; }
        /// <summary>
        /// СНИЛС
        /// </summary>
        public string SNILS { get; set; }
        /// <summary>
        /// Серия и номер паспорта
        /// </summary>
        public string SER_NUM { get; set; }
        public string DAT_Rozh { get; set; }
        /// <summary>
        /// ВКЛАД
        /// </summary>
        public string VKLAD { get; set; }
        /// <summary>
        /// Адрес
        /// </summary>
        public string ADRESS { get; set; }
        /// <summary>
        /// Дата выдачи
        /// </summary>
        public string DatVyd { get; set; }
        /// <summary>
        /// Кем выдан
        /// </summary>
        public string Kem_Vyd { get; set; }
        static Random random = new Random();
        /// <summary>
        /// Флаг определяющий правообладатель ли данный пользователь или нет
        /// </summary>
        public bool ITPRAVO { get; set; }
        /// <summary>
        /// Ид чата
        /// </summary>
        public string ChatId { get; set; }
        string UpperFirstLetter(string str)
        {
            string firstLetter = str.Substring(0, 1);
            str = str.Substring(1, str.Length - 1);
            firstLetter = firstLetter.ToUpper();
            return firstLetter + str;
        }
        public string GetFullNameUser()
        {
            return $"{Family} {Name} {Otche}";
        }
        public Users(string FIO, bool itPravo)
        {
            int i = 0;
            foreach(string line in FIO.Split(' '))
            {
                if (i == 0) Family = UpperFirstLetter(line);
                if (i == 1) Name = UpperFirstLetter(line);
                if (i == 2) Otche = UpperFirstLetter(line);
                i++;
            }
            ITPRAVO = itPravo;
           

            INN = string.Format($"{random.Next(1000, 9999)}{random.Next(1000, 9999)}{random.Next(1000, 9999)}");
            SNILS = string.Format($"{random.Next(100, 999)} {random.Next(100, 999)} {random.Next(100, 999)} {random.Next(10, 99)}");

            SER_NUM = string.Format($"{random.Next(10, 99)}{random.Next(10, 99)} {random.Next(100000, 999999)}");

            VKLAD = listVklad[random.Next(0, listVklad.Count)];


            ADRESS = GetrandomAdress();
            DAT_Rozh = RandomDate(DateTime.Now.Year-23);
            DatVyd = RandomGenerateDatPassport(DAT_Rozh);
            Kem_Vyd = listKemVyd[random.Next(0, listKemVyd.Count)];
        }
        string RandomGenerateDatPassport(string DatRozhd)
        {
            int yearPolych=0;
            DateTime dat = new DateTime(Convert.ToInt32(DatRozhd.Substring(DAT_Rozh.Length - 4, 4)), Convert.ToInt32(DatRozhd.Substring(3, 2)), Convert.ToInt32(DatRozhd.Substring(0, 2)));
            DateTime nowDate = DateTime.Now;
            int CountYear = Convert.ToInt32(Count_year(dat));
            if(CountYear>=14 && CountYear < 20)
            {
                yearPolych = nowDate.Year - (CountYear - 14);
            }
            if (CountYear >= 20 && CountYear < 45)
            {
                yearPolych = nowDate.Year - (CountYear - 20);
            }
            if (CountYear >= 45)
            {
                yearPolych = nowDate.Year - (CountYear - 45);
            }
            
            dat = dat.AddDays(new Random().Next(3, 14));
            string  dayPoluch = (dat.Day < 10 ? String.Format("0{0}", dat.Day) : Convert.ToString(dat.Day));
            string mounthPoluch = (dat.Month < 10 ? String.Format("0{0}", dat.Month) : Convert.ToString(dat.Month));


            return $"{dayPoluch} {mounthPoluch} {yearPolych}";
        }
        string Count_year(DateTime datRozhd)
        {
            //День 
            int day = datRozhd.Day;
            //MessageBox.Show(Dat_Pozhd.Substring(3, 2));
            //Месяц
            int mounth = datRozhd.Month;
            //Сегодняшняя дата
            DateTime now_dat = DateTime.Now;
            //Текущий год
            int year = now_dat.Year;
            //полуаем дату рождения пользователя в этом году
            DateTime Happy_BithDay = new DateTime(year, mounth, day, 0, 0, 0);
            //Переопределяем сегодняшнюю дату на 00:00
            DateTime Now_dat = new DateTime(year, now_dat.Month, now_dat.Day, 0, 0, 0);
            //Находим разницу между датами
            TimeSpan days = Happy_BithDay - Now_dat;
            string count = "";
            if (days.Days >= 0)count =  Convert.ToString((DateTime.Now).Year - datRozhd.Year);
            //else
            //{
            //   count = Convert.ToString((DateTime.Now).Year + 1 - datRozhd.Year);
            //}
            return Convert.ToString((DateTime.Now).Year - datRozhd.Year);
           // return count;
        }
        public Users(string family,string name,string otche,string chatId, bool itPravo = false)
        {
            Family = family;
            Name = name;
            Otche = otche;
            ChatId = chatId;
            ITPRAVO = itPravo;
            Random rand = new Random();
        
            INN = string.Format($"{rand.Next(1000, 9999)}{rand.Next(1000, 9999)}{rand.Next(1000, 9999)}");
            SNILS = string.Format($"{rand.Next(100, 999)} {rand.Next(100, 999)} {rand.Next(100, 999)} {rand.Next(10, 99)}");

            SER_NUM = string.Format($"{rand.Next(10, 99)}{rand.Next(10, 99)} {rand.Next(100000,999999)}");
    
            VKLAD = listVklad[rand.Next(0, listVklad.Count)];

           
            ADRESS = GetrandomAdress();
            DAT_Rozh = RandomDate(DateTime.Now.Year - 23);
            DatVyd = RandomGenerateDatPassport(DAT_Rozh);
            Kem_Vyd = listKemVyd[rand.Next(0, listKemVyd.Count)];

        }
        public string RandomDate(int startYear = 1999, string outputDateFormat = "dd MM yyyy")
        {
            DateTime start = new DateTime(startYear, 1, 1);
            Random gen = new Random(Guid.NewGuid().GetHashCode());
            int range = (new DateTime(DateTime.Now.Year - 18,new Random().Next(1,12), new Random().Next(1, 29)) - start).Days;
            return start.AddDays(gen.Next(range)).ToString(outputDateFormat);
        }
        public void SaveUser(Users user, string Path)
        {
            Serializer.SaveElem(Path, user);
        }
        public bool IsPravo()
        {
            return ITPRAVO;
        }
    }
}
