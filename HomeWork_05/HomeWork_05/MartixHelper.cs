using System;

namespace HomeWork_05
{
    /// <summary>
    /// Задание 1. Создание методов, которые производят вычисления с матрицами
    /// </summary>
    public class MatrixHelper
    {
        /// <summary>
        /// Запуск задания
        /// </summary>
        internal static void MatrixHelperRun()
        {
            int[,] inputMatrix1;
            int[,] inputMatrix2;
            
            //------------------------------------------//
            Console.WriteLine("Умножение матрицы на число");
            inputMatrix1 = GetMatrix(1);//Получение матрицы 1
            Console.WriteLine("Введите число: ");
            if (!int.TryParse(Console.ReadLine(), out var number))
            {
                Console.WriteLine("Ошибка ввода числа");
                return;
            }  
            Console.WriteLine("Печать результата");
            Print(MartixMuxByNumber(inputMatrix1, number));
            Console.WriteLine("--------------------");

            //------------------------------------------//
            Console.WriteLine("Умножение матриц");
            inputMatrix1 = GetMatrix(1);//Получение матрицы 1
            inputMatrix2 = GetMatrix(2);//Получение матрицы 2
            Console.WriteLine("Печать результата");
            Print(MatrixMux(inputMatrix1, inputMatrix2));
            Console.WriteLine("--------------------");
            
            //------------------------------------------//
            Console.WriteLine("Сложение матриц");
            inputMatrix1 = GetMatrix(1);//Получение матрицы 1
            inputMatrix2 = GetMatrix(2);//Получение матрицы 2
            Console.WriteLine("Печать результата");
            Print(MatrixSum(inputMatrix1, inputMatrix2));
            Console.WriteLine("--------------------");

            //------------------------------------------//
            Console.WriteLine("Вычитание матриц");
            inputMatrix1 = GetMatrix(1);//Получение матрицы 1
            inputMatrix2 = GetMatrix(2);//Получение матрицы 2
            Console.WriteLine("Печать результата");
            Print(MatrixSubstract(inputMatrix1, inputMatrix2));
            Console.WriteLine("--------------------");
        }

        /// <summary>
        /// Метод получения матрицы из консоли
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static int[,] GetMatrix(int matrixIndex)
        {
            Console.Write($"Введите количество строк матрицы № {matrixIndex}: ");
            var rows = int.Parse(Console.ReadLine());
            if (rows <= 0)
            {
                Console.WriteLine("Ошибка!!! Число строк не может быть меньше или равно нулю");
                return null;
            }
            Console.Write($"Введите количество столбцов матрицы № {matrixIndex}: ");
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

            Console.WriteLine($"Печать матрицы № {matrixIndex}");
            Print(matrix);
            Console.WriteLine("--------------------");
            return matrix;
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
        private static void Print(int [,] inputMatrix)
        {
            for (var i = 0; i < inputMatrix.GetLength(0); i++)
            {
                for (var j = 0; j < inputMatrix.GetLength(1); j++)
                {
                    Console.Write(inputMatrix[i, j].ToString().PadLeft(6));
                }

                Console.WriteLine();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputMatrix1"></param>
        /// <param name="inputMatrix2"></param>
        /// <param name="operationName"></param>
        /// <returns></returns>
        private static bool MatrixLenghtError(int[,] inputMatrix1, int[,] inputMatrix2, string operationName)
        {
            if (inputMatrix1.GetLength(0) == inputMatrix2.GetLength(0) &&
                inputMatrix1.GetLength(1) == inputMatrix2.GetLength(1)) return true;
            Console.WriteLine($"{operationName} матриц с разным размером не возможно!");
            return false;
        }

        /// <summary>
        /// Умножение матрицы на число
        /// </summary>
        /// <param name="inputMatrix">Входящая матрица</param>
        /// <param name="number">Входящее число</param>
        /// <returns>Возвращает матрицу равную входящей матрице умноженной на входящее число</returns>
        private static int[,] MartixMuxByNumber(int [,] inputMatrix, int number)
        {
            int[,] outputMatrix = InitializationMatrix(inputMatrix.GetLength(0), inputMatrix.GetLength(1));
            for (int i = 0; i < inputMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < inputMatrix.GetLength(1); j++)
                {
                    outputMatrix[i, j] += inputMatrix[i, j] * number;
                }
            }

            return outputMatrix;
        }
        
        /// <summary>
        /// Умножение двух матриц
        /// </summary>
        /// <param name="inputMatrix1"></param>
        /// <param name="inputMatrix2"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private static int[,] MatrixMux(int[,] inputMatrix1, int[,] inputMatrix2)
        {       
            if (!MatrixLenghtError(inputMatrix1, inputMatrix2, "Умножение"))
            {
                throw new Exception();
            }

            int[,] outputMatrix = InitializationMatrix(inputMatrix1.GetLength(0), inputMatrix2.GetLength(1));


            for (var i = 0; i < inputMatrix1.GetLength(0); i++)
            {
                for (var j = 0; j < inputMatrix2.GetLength(1); j++)
                {
                    outputMatrix[i, j] = 0;

                    for (var k = 0; k < inputMatrix1.GetLength(1); k++)
                    {
                        outputMatrix[i, j] += inputMatrix1[i, k] * inputMatrix2[k, j];
                    }
                }
            }

            return outputMatrix;
        }

        /// <summary>
        /// Сложение двух матриц
        /// </summary>
        /// <param name="inputMatrix1">Первая матрица</param>
        /// <param name="inputMatrix2">Вторая матрица</param>
        /// <returns>Вазвращает результат умножения двух матриц</returns>
        private static int[,] MatrixSum(int[,] inputMatrix1, int[,] inputMatrix2)
        {
            if (!MatrixLenghtError(inputMatrix1, inputMatrix2, "Сложение"))
            {
                throw new Exception();
            }

            int[,] outputMatrix = InitializationMatrix(inputMatrix1.GetLength(0), inputMatrix2.GetLength(1));

            for (var i = 0; i < inputMatrix1.GetLength(0); i++)
            {
                for (var j = 0; j < inputMatrix2.GetLength(1); j++)
                {
                    outputMatrix[i, j] = inputMatrix1[i, j] + inputMatrix2[i, j];
                }
            }

            return outputMatrix;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputMatrix1"></param>
        /// <param name="inputMatrix2"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private static int[,] MatrixSubstract(int[,] inputMatrix1, int[,] inputMatrix2)
        {
            if (!MatrixLenghtError(inputMatrix1, inputMatrix2, "Вычитание"))
            {
                throw new Exception();
            }

            var outputMatrix = InitializationMatrix(inputMatrix1.GetLength(0), inputMatrix2.GetLength(1));

            for (var i = 0; i < inputMatrix1.GetLength(0); i++)
            {
                for (var j = 0; j < inputMatrix2.GetLength(1); j++)
                {
                    outputMatrix[i, j] = inputMatrix1[i, j] - inputMatrix2[i, j];
                }
            }

            return outputMatrix;
        }
    }
}