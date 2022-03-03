using System;
using System.Linq;

namespace HomeWork_04
{
    internal class Subsequence
    {
        /// <summary>
        /// Ввести последовательность
        /// </summary>
        public static void SetSubsequence()
        {
            Console.Write($"Укажите длину последовательности: ");
            var length = int.Parse(Console.ReadLine());
            int[] subsequence = new int[length];
            for (int i = 0; i < length; i++)
            {
                Console.Write($"Укажите {i + 1} элемент последовательности: ");
                var subsequenceItem = int.Parse(Console.ReadLine());
                subsequence[i] = subsequenceItem;
            }
            subsequence.ToList().ForEach(c => Console.Write($"{c} "));
            Console.WriteLine($"Минимальное число последовательности: {subsequence.Min()}");
        }
    }
}
