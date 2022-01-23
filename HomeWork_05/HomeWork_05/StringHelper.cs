using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork_05
{
    /// <summary>
    /// Задание 2. Создание методов, которые принимают текст и возвращают слова
    /// Задание 3. Создание метода, принимающего строку и возвращающего новую строку, в которой удалены все рядом стоящие повторяющиеся символы
    /// </summary>
    public class StringHelper
    {
        /// <summary>
        /// Запуск 
        /// </summary>
        internal static void StringHelperRun()
        {
            //------------------------------------------//
            Console.WriteLine("Cлово с минимальной длиной");
            Console.WriteLine("Введите текст: ");
            var inputString = Console.ReadLine();
            Console.WriteLine("Печать результата");
            Print(GetMinimumWordLength(inputString));
            Console.WriteLine("--------------------");
            
            //------------------------------------------//
            Console.WriteLine("Cлова с максимальной длиной");
            Console.WriteLine("Введите текст: ");
            inputString = Console.ReadLine();
            Console.WriteLine("Печать результата");
            Print(string.Join("; ",GetMaximumWordsLength(inputString)));
            Console.WriteLine("--------------------");
            
            //------------------------------------------//
            Console.WriteLine("Удаление всех рядом стоящих повторяющихся символов");
            Console.WriteLine("Введите текст: ");
            inputString = Console.ReadLine();
            Console.WriteLine("Печать результата");
            Print(string.Join("; ", GetStringWithOutDoubles(inputString)));
            Console.WriteLine("--------------------");
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputString"></param>
        private static void Print(string inputString)
        {
            Console.WriteLine(inputString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private static string GetMinimumWordLength(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
            {
                throw new Exception("Строка не может быть пустой");
            }
            var wordArray =
                inputString.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            return wordArray.OrderBy(c => c.Length).FirstOrDefault();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        private static string[] GetMaximumWordsLength(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
            {
                throw new Exception("Строка не может быть пустой");
            }
            
            var wordArray =
                inputString.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            return wordArray.Where(c => c.Length == wordArray.OrderByDescending(s => s.Length).FirstOrDefault().Length)
                .ToArray();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        private static string GetStringWithOutDoubles(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
            {
                throw new Exception("Строка не может быть пустой");
            }
            List<char> stringList = new List<char>();
            string toLoverString = inputString.ToLower();
            for (int i = 0; i < toLoverString.Length; i++)
            {
                if (i == 0 || toLoverString[i] != toLoverString[i - 1] || toLoverString[i] == ' ' )
                {
                    stringList.Add(inputString[i]);
                }
            }

            return string.Join("", stringList);
        }
    }
}