using System;
using System.Linq;

namespace HomeWork_05
{
    /// <summary>
    /// Задание 4. Написание метода, определяющего, является ли последовательность чисел прогрессией
    /// </summary>
    public class NumberHelper
    {
        #region Задание
        /*
         Что нужно сделать:
         
         Напишите метод, принимающий произвольное количество чисел в виде массива, 
         который определяет, являются ли эти числа арифметической или геометрической прогрессией 
         или не являются прогрессией вовсе.
         
         Что оценивается:

        Создан метод, который принимает массив чисел как параметр.
        Метод определяет, являются ли числа в массиве арифметической или геометрической прогрессией или массив не содержит прогрессии.
        Метод возвращает результат в виде строки или перечисления. 
         */
        #endregion
        
        /// <summary>
        /// Запуск
        /// </summary>
        internal static void NumberHelperRun()
        {
            int[] geometricNumberArray = {2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192};
            int[] arithmeticNumberArray = {2,4,6,8,10,12,14,16,18,20,22};
            
            //------------------------------------------//
            Console.WriteLine("Проверка прогрессии");
            //Console.WriteLine("Введите текст: ");
            Console.WriteLine("Печать результата");
            Print(CheckProgression(arithmeticNumberArray));
            Print(CheckProgression(geometricNumberArray));
            Print(CheckProgression(geometricNumberArray.Concat(arithmeticNumberArray).ToArray()));
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
        /// <param name="numberArray"></param>
        /// <returns></returns>
        private static string CheckProgression(int[] numberArray)
        {
            Array.Sort(numberArray);
            if (CheckArithmeticProgression(numberArray))
            {
                return $"Арифметическая прогрессия: {string.Join(", ", numberArray)}";
            }

            return CheckGeometricProgression(numberArray) ? $"Геометрическая прогрессия: {string.Join(", ", numberArray)}" : "Не является прогрессией";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberArray"></param>
        /// <returns></returns>
        private static bool CheckArithmeticProgression(int[] numberArray)
        {
            if (numberArray.Length <= 1)
            {
                return false;
            }
            var step = GetArithmeticProgressionStep(numberArray[0], numberArray[1]);
            for (int i = 1; i < numberArray.Length; i++)
            {
                if (Math.Abs(numberArray[i - 1] - numberArray[i]) != step)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static int GetArithmeticProgressionStep(int firstNumber, int secondNumber)
        {
            return Math.Abs(secondNumber - firstNumber);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberArray"></param>
        /// <returns></returns>
        private static bool CheckGeometricProgression(int[] numberArray)
        {
            if (numberArray.Length <= 1)
            {
                return false;
            }
            var step = GetGeometricProgressionStep(numberArray[0], numberArray[1]);
            for (int i = 1; i < numberArray.Length; i++)
            {
                if (numberArray[i] / numberArray[i - 1] != step)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static int GetGeometricProgressionStep(int firstNumber, int secondNumber)
        {
            return secondNumber % firstNumber > 0 ? 0 : Math.Abs(secondNumber / firstNumber);
        }
    }
}