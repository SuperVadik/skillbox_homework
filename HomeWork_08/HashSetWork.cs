using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Int32;

namespace HomeWork_08
{
    internal class HashSetWork
    {
        /// <summary>
        /// 
        /// </summary>
        private static HashSet<int> HashSet { get; set; }

        public static void RunHashSetWork()
        {
            HashSet = new HashSet<int>();
            while (true)
            {
                Console.WriteLine("Введите число или Введите пробел, чтобы закончить ввод");
                var stringNumber = Console.ReadLine();
                if (stringNumber == " ")   
                    break;
                if (TryParse(stringNumber, out int number))
                {
                    SetItem(number);
                    continue;
                }
                Console.WriteLine("Входная строка имеет неверный формат");
            }
            Print(HashSet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        private static void SetItem(int number)
        {
            if (HashSet.Add(number))
            {
                Console.WriteLine($"Число {number} успешно сохранено");
                return;
            }
            Console.WriteLine($"Число {number} уже существует в коллекции");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        private static void Print(HashSet<int> list)
        {
            list.ToList().ForEach(c => Console.Write($"{c} "));
            Console.WriteLine();
            Console.WriteLine("=========================");
            Console.WriteLine();
        }
    }
}
