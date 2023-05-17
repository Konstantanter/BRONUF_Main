using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRONUF_Main
{
    /// <summary>
    /// Типы научных проектов
    /// </summary>
    public enum TypesProgs
    {
        /// <summary>
        /// Акт реализации
        /// </summary>
        Akt,
        /// <summary>
        /// статья ВАК
        /// </summary>
        BAK,
        /// <summary>
        /// патент на базу данных
        /// </summary
        DataBase,
        /// <summary>
        /// Изобретение
        /// </summary>
        Invention,
        /// <summary>
        /// статья не РИНЦ
        /// </summary>
        NotRinc,
        /// <summary>
        /// патент на программу для ЭВМ
        /// </summary
        PatentEVM,
        /// <summary>
        /// патент на топологию интегральных микросхем
        /// </summary
        PatentTIMS,
        /// <summary>
        /// статья РИНЦ
        /// </summary>
        Rinc,
        /// <summary>
        /// статья СКОПУС
        /// </summary>
        Scopuc,
        /// <summary>
        /// полезная модель
        /// </summary>
        UtilityModel
    }
}
