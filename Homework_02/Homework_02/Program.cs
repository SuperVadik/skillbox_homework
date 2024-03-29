﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Homework_Theme_02
{
    class Program
    {
        static void Main(string[] args)
        {
            // Заказчик просит написать программу «Записная книжка». Оплата фиксированная - $ 120.

            // В данной программе, должна быть возможность изменения значений нескольких переменных для того,
            // чтобы персонифецировать вывод данных, под конкретного пользователя.

            // Для этого нужно: 
            // 1. Создать несколько переменных разных типов, в которых могут храниться данные
            //    - имя;
            //    - возраст;
            //    - рост;
            //    - баллы по трем предметам: история, математика, русский язык;

            // 2. Реализовать в системе автоматический подсчёт среднего балла по трем предметам, 
            //    указанным в пункте 1.

            // 3. Реализовать возможность печатки информации на консоли при помощи 
            //    - обычного вывода;
            //    - форматированного вывода;
            //    - использования интерполяции строк;

            // 4. Весь код должен быть откомментирован с использованием обычных и хml-комментариев

            // **
            // 5. В качестве бонусной части, за дополнительную оплату $50, заказчик просит реализовать 
            //    возможность вывода данных в центре консоли.

            Console.WriteLine("Записная книжка");
            List<User> userList = new List<User>();
            for (int i = 1; i < 4; i++)
            {
                Console.WriteLine($"Ввести данные {i} пользователя");

                var user = new User();
                user.SetName();
                user.SetAge();
                user.SetHeight();
                user.SetRating(Subject.History);
                user.SetRating(Subject.Maths);
                user.SetRating(Subject.Russian);
                userList.Add(user);
            }
            
            Console.WriteLine("Ввод завершен, для продолжения нажимите любую клавишу");
            //Ждем нажатия клавиши
            Console.ReadKey();
            //очищаем консоль
            Console.Clear();
            
            foreach (var user in userList)
            {
                //Обычный вывод
                user.GetNormalOutput();
                //Форматированный вывод
                user.GetFormattedOutput();
                //Интерполяция строк
                user.GetStringInterpolation();
                //Пустая строка
                Console.WriteLine();
            }
        }
    }
}
