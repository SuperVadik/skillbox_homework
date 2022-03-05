using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HomeWork_08
{
    internal class XmlWork
    {
        /// <summary>
        /// 
        /// </summary>
        private static List<Notebook>? Notebooks;

        /// <summary>
        /// 
        /// </summary>
        private static XmlSerializer ? _xmlSerializer = GetXmlSerializer();

        /// <summary>
        /// 
        /// </summary>
        public static string _path = "notebookList.xml";

        /// <summary>
        /// 
        /// </summary>
        public static void RunXmlWork()
        {
            ReadXml();
            Console.WriteLine("Введите данные или Введите пробел, чтобы закончить ввод");
            while (true)
            {
                var item = new Notebook();
                Console.WriteLine("Введите ФИО");
                item.FIO = Console.ReadLine();
                if (item.FIO == " ")
                    break;
                Console.WriteLine("Введите Улицу");
                item.Street = Console.ReadLine();
                Console.WriteLine("Введите Номер дома");
                item.House = Console.ReadLine();
                Console.WriteLine("Введите Номер квартиры");
                item.Float = Console.ReadLine();
                Console.WriteLine("Введите Мобильный телефон");
                item.MobilePhone = Console.ReadLine();
                Console.WriteLine("Введите Домашний телефон");
                item.Phone = Console.ReadLine();
                Notebooks.Add(item);
            }
            WriteXml(Notebooks);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notebookList"></param>
        private static void WriteXml(List<Notebook> notebookList)
        {
            //_path = "notebookList.xml";
            using FileStream fs = new FileStream(_path, FileMode.Create, FileAccess.Write);
            _xmlSerializer?.Serialize(fs, notebookList);
            Console.WriteLine("Запись в файл завершена");
        }

        /// <summary>
        /// 
        /// </summary>
        private static void ReadXml ()
        {
            List<Notebook> notebookList;
            if (!File.Exists(_path))
            {
                File.Create(_path);
                Notebooks = new List<Notebook>();
                return;
            }

            try
            {
                using Stream fs = new FileStream(_path, FileMode.Open, FileAccess.Read);
                notebookList = _xmlSerializer.Deserialize(fs) as List<Notebook>;

                if (notebookList == null || !notebookList.Any())
                {
                    return;
                }
            }
            catch
            {
                Notebooks = new List<Notebook>();
                return;
            }

            Notebooks = notebookList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static XmlSerializer GetXmlSerializer()
        {
            return new XmlSerializer(typeof(List<Notebook>));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Notebook
    {
        /// <summary>
        /// 
        /// </summary>
        public string FIO { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string House { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Float { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string MobilePhone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Phone { get; set; }
    }
}
