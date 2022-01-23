using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Homework_Theme_02
{
    /// <summary>
    /// Базовый класс пользователя
    /// </summary>
    public class User
    {
        /// <summary>
        /// Имя
        /// </summary>
        private string Name { get; set; }
        
        /// <summary>
        /// Возраст
        /// </summary>
        private int Age { get; set; }
        
        /// <summary>
        /// Рост
        /// </summary>
        private int Height { get; set; }
        
        /// <summary>
        /// Оценка по истории
        /// </summary>
        private int? HistoryRating { get; set; }
        
        /// <summary>
        /// Оценка по математике
        /// </summary>
        private int? MathsRating { get; set; }
        
        /// <summary>
        /// Оценка по Русскому языку
        /// </summary>
        private int? RussianRating { get; set; }

        /// <summary>
        /// Средняя оценка
        /// </summary>
        public double AverageRating => (HistoryRating ?? 0 +
            MathsRating ?? 0 +
            RussianRating ?? 0) / 3.00;

        /// <summary>
        /// Позиция курсора в середине
        /// </summary>
        private readonly int _cursorPosition = Console.BufferWidth / 2;

        /// <summary>
        /// Установить имя
        /// </summary>
        public void SetName()
        {
            string name;
            bool error;
            do
            {
                Console.WriteLine("Введите имя :");
                error = true;
                name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine($"Имя не может быть пустым");
                }
                else
                {
                    error = false;
                }
            } while (error);
            Name = name;
        }

        /// <summary>
        /// Установить возраст
        /// </summary>
        public void SetAge()
        {
            int age;
            bool error;
            do
            {
                Console.WriteLine("Введите возраст: ");
                error = true;
                string ageString = Console.ReadLine();
                if (!Int32.TryParse(ageString, out age))
                {
                    Console.WriteLine("Строка имеет не верный формат");
                }
                else if (age < 0 || age > 120)
                {
                    Console.WriteLine($"Возраст не может быть {age}, укажите число от 0 до 120");
                }
                else
                {
                    error = false;
                }
            } while (error);
            Age = age;
        }

        /// <summary>
        /// Установить рост
        /// </summary>
        public void SetHeight()
        {
            int height;
            bool error;
            do
            {
                Console.WriteLine("Введите рост: ");
                error = true;
                string heightString = Console.ReadLine();
                if (!Int32.TryParse(heightString, out height))
                {
                    Console.WriteLine("Строка имеет не верный формат");
                }
                else if (height < 0 || height > 300)
                {
                    Console.WriteLine($"Рост не может быть {height}, укажите число от 0 до 300");
                }
                else
                {
                    error = false;
                }
            } while (error);
            Height = height;
        }

        /// <summary>
        /// Установить оценку
        /// </summary>
        /// <param name="subject">Предмет</param>
        public void SetRating(Subject subject)
        {
            int rating;
            bool error;
            do
            {
                Console.WriteLine($"{subject.ToString()}. Введите оценку:");
                error = true;
                string ratingString = Console.ReadLine();
                if (!Int32.TryParse(ratingString, out rating))
                {
                    Console.WriteLine("Строка имеет не верный формат");
                }
                else if (rating < 0 || rating > 10)
                {
                    Console.WriteLine($"Оценка не может быть {rating}, укажите число от 0 до 10");
                }
                else
                {
                    error = false;
                }
            } while (error);

            switch (subject)
            {
                case Subject.History:
                    HistoryRating = rating;
                    break;
                case Subject.Maths:
                    MathsRating = rating;
                    break;
                case Subject.Russian:
                    RussianRating = rating;
                    break;
                default:
                    Console.WriteLine("Неизвестная ошибка");
                    break;
            }
        }
        
        /// <summary>
        /// Обычный вывод
        /// </summary>
        public void GetNormalOutput()
        {
            string outputName = "Обычный вывод";
            string outputString = Name + Age + Height + AverageRating;
            Output(outputName, outputString);
        } 

        /// <summary>
        /// Форматированный вывод
        /// </summary>
        public void GetFormattedOutput()
        {
            string outputName = "Форматированный вывод";
            string outputString = string.Format("Имя: {0}, Возраст: {1}, Рост: {2}, Средняя оценка: {3:#.##}", Name, Age, Height, AverageRating);
            Output(outputName, outputString);
        }
            

        /// <summary>
        /// Интерполяция строк
        /// </summary>
        public void GetStringInterpolation()
        {
            string outputName = "Интерполяция строк";
            string outputString = $"Имя: {Name}, Возраст: {Age}, Рост: {Height}, Средняя оценка: {AverageRating:#.##}";
            Output(outputName, outputString);
        }

        private void Output(string outputName, string outputString)
        {
            Console.SetCursorPosition(_cursorPosition - outputName.Length / 2 , Console.BufferHeight);
            Console.WriteLine(outputName);
            Console.SetCursorPosition(_cursorPosition - outputString.Length / 2, Console.BufferHeight);
            Console.WriteLine(outputString);
        }
    }

    /// <summary>
    /// Предмет
    /// </summary>
    public enum Subject
    {
        [Display(Name = "История")]
        [Description("История")]
        History,
        
        [Display(Name = "Математика")]
        [Description("Математика")]
        Maths,
        
        [Display(Name = "Русский язык")]
        [Description("Русский язык")]
        Russian
    }
}