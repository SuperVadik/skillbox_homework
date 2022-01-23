using System;
using System.Collections.Generic;

namespace Homework_01
{

    /// <summary>
    /// Организация хранения и генерации данных
    /// </summary>
    class Repository
    {
        /// <summary>
        /// База данных имён
        /// </summary>
        static readonly string[] FirstNames;

        /// <summary>
        /// База данных фамилий
        /// </summary>
        static readonly string[] LastNames;

        /// <summary>
        /// Генератор псевдослучайных чисел
        /// </summary>
        private static readonly Random Randomize;

        /// <summary>
        /// Статический конструктор, в котором "хранятся"
        /// данные о именах и фамилиях баз данных firstNames и lastNames
        /// </summary>
        static Repository()
        {
            Randomize = new Random(); // Размещение в памяти генератора случайных чисел

            // Размещение имен в базе данных firstNames
            FirstNames = new[] {
                "Агата",
                "Агнес",
                "Аделаида",
                "Аделина",
                "Алдона",
                "Алима",
                "Аманда",
            };

            // Размещение фамилий в базе данных lastNames
            LastNames = new[]
            {
                "Иванова",
                "Петрова",
                "Васильева",
                "Кузнецова",
                "Ковалёва",
                "Попова",
                "Пономарёва",
                "Дьячкова",
                "Коновалова",
                "Соколова",
                "Лебедева",
                "Соловьёва",
                "Козлова",
                "Волкова",
                "Зайцева",
                "Ершова",
                "Карпова",
                "Щукина",
                "Виноградова",
                "Цветкова",
                "Калинина"
            };
        }

        /// <summary>
        /// База данных работников, в которой хранятся 
        /// Имя, фамилия, возраст и зарплаты каждого сотрудника
        /// </summary>
        private List<Worker> Workers { get; set; }

        /// <summary>
        /// Конструктор, заполняющий базу данных Workers
        /// </summary>
        /// <param name="count">Количество сотрудников, которых нужно создать</param>
        public Repository(int count)
        {
            this.Workers = new List<Worker>(); // Выделение памяти для хранения базы данных Workers

            for (int i = 0; i < count; i++)    // Заполнение базы данных Workers. Выполняется Count раз
            {
                // Добавляем нового работника в базы данных Workers
                this.Workers.Add(
                    new Worker(
                        // выбираем случайное имя из базы данных имён
                        FirstNames[Repository.Randomize.Next(Repository.FirstNames.Length)],
                        
                        // выбираем случайное имя из базы данных фамилий
                        LastNames[Repository.Randomize.Next(Repository.LastNames.Length)],

                        // Генерируем случайный возраст в диапазоне 19 лет - 60 лет
                        Randomize.Next(19, 60),

                        // Генерируем случайную зарплату в диапазоне 10000руб - 80000руб
                        Randomize.Next(10000, 35000)
                        ));
            }
        }

        /// <summary>
        /// Метод вывода базы данных Workers в консоль
        /// </summary>
        /// <param name="text">Вспомогательный текст, который будет напечатан перед выводом базы</param>
        public int Print(string text)
        {
            Console.WriteLine(text);    // Печать в консоль вспомогательного текста

            // Изменяем цвет шрифта для печати в консоли на DarkBlue
            Console.ForegroundColor = ConsoleColor.DarkBlue; 

            // Выводим Заголовки колонок базы данных
            Console.WriteLine($"{"Имя",15} {"Фамилия",15} {"Возраст",10} {"Зарплата",15}");

            // Изменяем цвет шрифта для печати в консоли на Gray
            Console.ForegroundColor = ConsoleColor.Gray;

            
            foreach (var worker in this.Workers) //
            {                                    // Печатаем в консоль всех работников
                Console.WriteLine(worker);       //
            }                                    //

            Console.WriteLine($"Итого: {this.Workers.Count}\n");    // Сводный отчёт. Сколько работников распечатано

            return this.Workers.Count;
        }

        /// <summary>
        /// Метод, увольняющий работников с зарплатой больше заданной
        /// </summary>
        /// <param name="maxSalary">Уровень зарплаты работника, которых нужно уволить</param>
        public void DeleteWorkerBySalary(int maxSalary)
        {
            this.Workers.RemoveAll(e => e.Salary > maxSalary);//Удаление работников чья зарплата больше заданной MaxSalary
        }

        /// <summary>
        /// Метод, увольняющий работников с заданным именем
        /// </summary>
        public void DeleteWorkerByName()
        {
            string currentName = FirstNames[Repository.Randomize.Next(Repository.FirstNames.Length)];
            Console.WriteLine(string.Format("Удаляем работников с именем \"{0}\"", currentName));
            this.Workers.RemoveAll(e => e.FirstName == currentName);//Удаление работников чьё имя Удовлетворяет выбранному CurrentName
        }
    }
}
