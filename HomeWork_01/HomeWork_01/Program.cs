﻿namespace Homework_01
{
    class Program
    {
        static void Main()
        {
            int employeeCount = 50;
            int maxSalary = 30000;
            int maxEmployeCount = 30;
            // Создание базы данных из 20 сотрудников
            Repository repository = new Repository(employeeCount);
            
            // Печать в консоль всех сотрудников
            repository.Print("База данных до преобразования");
            
            int i = 0;
            while (employeeCount > maxEmployeCount)
            {
                i++;
                if (i == 1)
                {
                    //Увольняем всех работников с ЗП более указанного значения
                    repository.DeleteWorkerBySalary(maxSalary);
                }
                else
                {
                    // Увольнение всех работников со случайным именем
                    repository.DeleteWorkerByName();
                }
                // Печать в консоль сотрудников, которые не попали под увольнение
                employeeCount = repository.Print(string.Format("База данных после {0} преобразования", i));
            }
            
            #region Домашнее задание

            // Уровень сложности: просто
            // Задание 1. Переделать программу так, чтобы до первой волны увольнени в отделе было не более 20 сотрудников

            // Уровень сложности: средняя сложность
            // * Задание 2. Создать отдел из 40 сотрудников и реализовать несколько увольнений, по результатам
            //              которых в отделе болжно остаться не более 30 работников

            // Уровень сложности: сложно
            // ** Задание 3. Создать отдел из 50 сотрудников и реализовать увольнение работников
            //               чья зарплата превышает 30000руб
            #endregion

        }
    }
}
