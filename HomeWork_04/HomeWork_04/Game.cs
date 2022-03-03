using System;

namespace HomeWork_04
{
    internal class Game
    {
        /// <summary>
        /// Игра, угадай число
        /// </summary>
        public static void PlayGame()
        {
            Console.WriteLine(@"
            - Пользователь вводит максимальное целое число диапазона.
            - На основе диапазона целых чисел(от 0 до «введено пользователем») программа генерирует случайное целое число из диапазона.
            - Пользователю предлагается ввести загаданное программой случайное число.Пользователь вводит свои предположения в консоли приложения.
                * Если число меньше загаданного, программа сообщает об этом пользователю.
                * Если больше, то тоже сообщает, что число больше загаданного.
            - Программа завершается, когда пользователь угадал число.
            - Если пользователь устал играть, то вместо ввода числа он вводит пустую строку и нажимает Enter.Тогда программа завершается, предварительно показывая, какое число было загадано.");
            var rnd = new Random();
            Console.WriteLine($"Введите максимальное число: ");
            var maxNumber = int.Parse(Console.ReadLine());
            var number = rnd.Next(0, maxNumber);
            while (true)
            {
                Console.WriteLine($"Введите число или пустую строку, чтобы прекратить игру: ");
                string stringNamber = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(stringNamber))
                {
                    Console.WriteLine($"Игра заверешена, компьютер загадал число {number}");
                    return;
                }
                var resultNumber = int.Parse(stringNamber);
                
                if (resultNumber == maxNumber)
                {
                    Console.WriteLine($"Поздравляю, вы угадали число");
                    return;
                }
                if (resultNumber > number)
                {
                    Console.WriteLine($"Веденное число больше, попробуйте еще раз");
                }
                else if (resultNumber < number)
                {
                    Console.WriteLine($"Веденное число меньше, попробуйте еще раз");
                }
            }
        }
    }
}
