using BRONUF_Library;

namespace BRONUF_Main.Main.Buttons
{
    public partial class Button
    {
        /// <summary>
        /// Кнопка Начные труды, что и для чего? - "О патенте на базу данных"
        /// </summary>
        public const string ButtonsScientificDataBase= "🗃️ О патенте на базу данных";


        public string DataBaseEVM_Mess(TypesProgs type)
        {
            string str = "";
            if(type == TypesProgs.DataBase)
            {
                str = "базу данных";
            }
            if (type == TypesProgs.PatentEVM)
            {
                str = "программу для ЭВМ";
            }
            return string.Format("Это патент на {0}.\n\nОн приравнивается к статье ВАК(высшая аттестационная комиссия) и публикуется в РИНЦ(Российский индекс народного цитирования) -все эти работы очень ценны в научном мире и публикуются в крупнейшей научной электронной библиотеке https://www.elibrary.ru Такие работы должны быть обязательно,  чтобы защитить кандидатскую диссертацию или диплом при окончании вуза, чтобы получать повышенную стипендию.\n\nЧем больше таких работ, тем больше у вас рейтинг и шансов получать повышенную стипендию за научную деятельность.", str);
        }
    }
}
