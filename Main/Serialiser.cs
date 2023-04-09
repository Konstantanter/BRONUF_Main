using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace TelegramBotIsSimple
{
    /// <summary>
    /// Класс для сериализации данных
    /// </summary>
    public static class Serializer
    {
        public static void SaveListToBinnary<T>(String FileName, List<T> SerializableObjects)
        {

            using (FileStream fs = File.Create(FileName))
            {

                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, SerializableObjects);
            }
        }

        #region Сериализация и десериализация списка объектов
        public static void SaveElem<T>(String FileName, T SerializableObjects)
        {

            List<T> list = new List<T>();
            if (System.IO.File.Exists(FileName))
            {
                list = LoadListFromBinnary<T>(FileName);

            }
            using (FileStream fs = File.Open(FileName, FileMode.OpenOrCreate))
            {
                list.Add(SerializableObjects);
                BinaryFormatter formatter = new BinaryFormatter();

                formatter.Serialize(fs, list);
            }

        }

        public static void SaveToXml<T>(String FileName, T SerializableObject)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextWriter textWriter = new StreamWriter(FileName))
            {
                serializer.Serialize(textWriter, SerializableObject);
            }
        }

        public static T LoadFromXml<T>(String FileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextReader textReader = new StreamReader(FileName))
            {
                return (T)serializer.Deserialize(textReader);
            }
        }
        //====================================================================
        public static List<T> LoadListFromBinnary<T>(String FileName)
        {
            try
            {
                if (System.IO.File.Exists(FileName))
                {
                    using (FileStream fs = File.Open(FileName, FileMode.Open))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        return (List<T>)formatter.Deserialize(fs);
                    }
                }

            }
            catch (Exception)
            {

            }
            return null;
        }
        //====================================================================

        #endregion
    }
}
