using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EmployeeData.Models;

namespace EmployeeData.Components
{
    /// <summary>
    /// 
    /// </summary>
    public class FileMethods
    {
        /// <summary>
        /// 
        /// </summary>
        private static string _fileName = "Diary.txt";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        internal FileMethods(string fileName = "")
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                _fileName = fileName;
            }
        }

        /// <summary>
        /// Чтение файла
        /// </summary>
        /// <returns></returns>
        internal static string[] ReadFile()
        {
            if (!FindFile())
            {
                throw new Exception("Файл отсутствует");
            }
            return File.ReadAllLines(_fileName, Encoding.Unicode);
        }

        /// <summary>
        /// Записать файл
        /// </summary>
        /// <param name="fileRows"></param>
        public static void WriteFile(string[] fileRows)
        {
            if (!FindFile())
            {
                CreateEmptyFile();
            }
            else
            {
                ClearFile();
            }
            using var sw = new StreamWriter(_fileName, true, Encoding.Unicode);
            foreach (var row in fileRows)
            {
                sw.WriteLine(row);
            }
        }

        /// <summary>
        /// Создание пустого файла
        /// </summary>
        private static void CreateEmptyFile()
        {
            File.Create(_fileName);
        }

        /// <summary>
        /// Очистка текста
        /// </summary>
        /// <param name="path"></param>
        private static void ClearFile()
        {
            File.WriteAllText(_fileName, string.Empty);
        }

        /// <summary>
        /// Поиск файла
        /// </summary>
        /// <param name="path"></param>
        private static bool FindFile()
        {
            return File.Exists(_fileName);
        }
    }
}