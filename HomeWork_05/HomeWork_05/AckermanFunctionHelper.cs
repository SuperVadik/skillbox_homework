using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork_05
{
    /// <summary>
    /// Задание 5. Написание функции Аккермана с применением рекурсии
    /// </summary>
    public class AckermannFunctionHelper
    {
        internal static void AckermannFunctionRun()
        {
            //------------------------------------------//
            Console.WriteLine("Внимание!!!");
            Console.WriteLine("Эта функция растёт очень быстро, например, число A ( 4 , 4 ) настолько велико, что количество цифр в порядке этого числа многократно превосходит количество атомов в наблюдаемой части Вселенной");

            Console.WriteLine("Функция Аккермана с рекурсией");
            var n = SetNumber("первое");
            var m = SetNumber("второе");
            Console.WriteLine("Печать результата");
            Print(AckermannFunction(n, m));
            Console.WriteLine("--------------------");
            
            Console.WriteLine("Функция Аккермана без рекурсии");
            n = SetNumber("первое");
            m = SetNumber("второе");
            Console.WriteLine("Печать результата");
            Print(AckermannFunctionWithoutRecursion(n, m));
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
        private static void Print(int input)
        {
            Console.WriteLine(input);
        }

        private static int SetNumber(string numberIndex)
        {
            bool flag = false;
            int number;
            do
            {
                Console.WriteLine($"Введите {numberIndex} число: ");
                if (!int.TryParse(Console.ReadLine(), out number) || number < 0)
                {
                    Console.WriteLine("Введённая строка не яввляется числом или число отрицательное");
                }
                else
                {
                    flag = true;
                }
            } while (!flag);

            return number;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        private static int AckermannFunction(int n, int m)
        {
            while (true)
            {
                if (m == 0)
                {
                    return n + 1;
                }

                if (n == 0)
                {
                    m -= 1;
                    n = 1;
                }
                else
                {
                    var m1 = m;
                    m -= 1;
                    n = AckermannFunction(m1, n - 1);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        private static int AckermannFunctionWithoutRecursion(int n, int m)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(m);
            while(stack.Any())
            {
                m = stack.Pop();
                if(m == 0 || n == 0)
                    n += m + 1;
                else
                {
                    stack.Push(--m);
                    stack.Push(++m);
                    n--;
                }
            }
            return n;
        }
    }
}