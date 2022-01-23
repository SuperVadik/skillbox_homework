using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Diary.Components
{
    public class FileMethods
    {
        /// <summary>
        /// 
        /// </summary>
        private static readonly string FileName = "Diary.txt";
        
        /// <summary>
        /// Чтение файла
        /// </summary>
        /// <returns></returns>
        private static List<Diary> ReadNumber()
        {
            List<Diary> diaryModelList = new List<Diary>();
            if (!File.Exists(FileName))
            {
                CreateEmptyFile();
            }
            else
            {
                var stringArray = File.ReadAllLines(FileName, Encoding.Unicode);
                diaryModelList.AddRange(stringArray.Select(str => new Diary(str)));
            }

            return diaryModelList;
        }

        /// <summary>
        /// Создание пустого файла
        /// </summary>
        private static void CreateEmptyFile()
        {
            File.Create(FileName);
        }
        
        public static void Find()
        {
            
        }
    }
}