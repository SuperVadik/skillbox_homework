using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork_04
{
    public static class Helper
    {
        /// <summary>
        /// Количество месяцев
        /// </summary>
        public static readonly int MonthCount = 12;

        /// <summary>
        /// Вывод результатов в консоль
        /// </summary>
        /// <param name="columns"></param>
        /// <param name="lineLength"></param>
        private static string RowPrint(string[] columns)
        {
            string resultString = "";
            foreach (var column in columns)
            {
                resultString += ($"{column, 15} | ");
            }

            return resultString.TrimEnd(new char[]{' ', '|', ' '});
        }

        /// <summary>
        /// Получение месяцев с наименьшей прибылью
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private static string GetWorstProfit(string[][] arr)
        {
            Dictionary<string, int> worstProfitDictionary = new Dictionary<string, int>();
            List<string> resultStringList = new List<string>();
            for (int i = 1; i < arr.Length; i++)
            {
                worstProfitDictionary.Add(arr[i][0], Int32.Parse(arr[i][3]));
            }
            
            int oldValue = 0;
            foreach (var worstProfit in worstProfitDictionary.OrderBy(c => c.Value))
            {
                if (oldValue >= worstProfit.Value || resultStringList.Count < 3)
                {
                    resultStringList.Add(worstProfit.Key);
                    oldValue = worstProfit.Value;
                }
            }
            
            return string.Join(", ", resultStringList);
        }

        /// <summary>
        /// Обработка массива
        /// </summary>
        /// <param name="firstColumn"></param>
        /// <param name="count"></param>
        /// <param name="requiredDate"></param>
        /// <returns></returns>
        public static void ArrayProcessing(int count, DateTime requiredDate)
        {
            Random rnd = new Random();
            string[][] resultStringArr = new string[++count][];
            //resultStringArr[0] = firstColumn;

            string[] positiveProfitArr = new string[0];
            
            for (int i = 0; i < count; i++)
            {
                int incomeValue = rnd.Next(0, 9999);
                int expenseValue = rnd.Next(0, 9999);
                int resultValue = incomeValue - expenseValue;

                string[] arr;
                if (i == 0)
                {
                    arr = new[]
                    {
                        "Месяц",
                        "Доход",
                        "Расход",
                        "Прибыль"
                    };
                }
                else
                {
                    arr = new[]
                    {
                        requiredDate.AddMonths(-i).ToString("MMMM yyyy"),
                        incomeValue.ToString(),
                        expenseValue.ToString(),
                        resultValue.ToString()
                    };
                    if (resultValue >= 1)
                    {
                        //Количество месяцев с положительной прибылью
                        Array.Resize(ref positiveProfitArr, positiveProfitArr.Length + 1);
                        positiveProfitArr[^1] = arr[0];
                    }
                }
                
                resultStringArr[i] = arr;
                Console.WriteLine(RowPrint(resultStringArr[i]));
            }

            Console.WriteLine();
            Console.WriteLine($"Худшая прибыль в месяцах: {GetWorstProfit(resultStringArr)}");
            Console.WriteLine(
                $"Месяцы с положительной прибылью: {string.Join(", ", positiveProfitArr)}; Всего: {positiveProfitArr.Length}");
        }
        
        private static decimal Factorial(long x)
        {
            if (x == 0)
            {
                return 1;
            }
            else
            {
                return x * Factorial(x - 1);
            }
        }
        
        public static void GetPascalPyramid(long n)
        {
            for (var i = 0; i < n; i++)
            {
                for (var c = 0; c <= i; c++)
                {
                    Console.Write($"{Factorial(i) / (Factorial(c) * Factorial(i - c)), 9}"); //формула вычисления элементов треугольника
                }
                Console.WriteLine();
            }
        }
    }
}