using System;
using System.Linq;

namespace HomeWork_04
{
    public static class Matrix
    {
        /// <summary>
        /// Метод получения матрицы из консоли
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        internal static int[,] GetMatrix()
        {
            Console.Write($"Введите количество строк матрицы : ");
            var rows = int.Parse(Console.ReadLine());
            if (rows <= 0)
            {
                Console.WriteLine("Ошибка!!! Число строк не может быть меньше или равно нулю");
                return null;
            }

            Console.Write($"Введите количество столбцов матрицы : ");
            var columns = int.Parse(Console.ReadLine());
            if (columns <= 0)
            {
                Console.WriteLine("Ошибка!!! Число столбцов не может быть меньше или равно нулю");
                return null;
            }

            Random rnd = new Random();
            var matrix = InitializationMatrix(rows, columns);
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    matrix[i, j] = rnd.Next(0, 100);
                }
            }

            Print(matrix);
            
            return matrix;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matr"></param>
        /// <returns></returns>
        public static int GetSumMatrixElements(int[,] matr)
        {
            return matr.Cast<int>().Sum();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        private static int[,] InitializationMatrix(int rows, int columns)
        {
            return new int[rows, columns];
        }

        /// <summary>
        /// Метод для печати результата
        /// </summary>
        /// <param name="inputMatrix"></param>
        private static void Print(int[,] inputMatrix)
        {
            Console.WriteLine($"Печать матрицы");
            for (var i = 0; i < inputMatrix.GetLength(0); i++)
            {
                for (var j = 0; j < inputMatrix.GetLength(1); j++)
                {
                    Console.Write(inputMatrix[i, j].ToString().PadLeft(6));
                }

                Console.WriteLine();
            }

            Console.WriteLine($"Сумма элемтов матрицы: {GetSumMatrixElements(inputMatrix)}");

            Console.WriteLine("--------------------");
        }
    }
}