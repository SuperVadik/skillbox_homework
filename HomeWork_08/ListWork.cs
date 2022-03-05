using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_08
{
    internal static class ListWork
    {
        /// <summary>
        /// 
        /// </summary>
        private static Exception _ex = new("Коллекция не может быть пустой");

        public static void RunListWork()
        {
            var list = CreateIntList(100);
            Print(list);
            Print(RemoveFromIntList(list, 50, 25));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listCount"></param>
        /// <returns></returns>
        private static List<int> CreateIntList(int listCount)
        {
            var rnd = new Random();
            var list = new List<int>();
            for (int i = 0; i < listCount; i++)
            {
                list.Add(rnd.Next(0, 100));
            }

            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="less"></param>
        /// <param name="more"></param>
        /// <returns></returns>
        private static List<int> RemoveFromIntList(List<int> list, int? less, int? more)
        {
            if (list == null || !list.Any())
            {
                throw _ex;
            }

            

            return list.Where(c => c < less).Intersect(list.Where(c => c > more)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        private static void Print(List<int> list)
        {
            if (list == null || !list.Any())
            {
                throw _ex;
            }

            list.ForEach(c => Console.Write($"{c} "));
            Console.WriteLine();
            Console.WriteLine("=========================");
            Console.WriteLine();
        }

    }
}
