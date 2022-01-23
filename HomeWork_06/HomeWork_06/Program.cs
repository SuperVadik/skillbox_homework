using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;

namespace HomeWork_06
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = ReadNumber("Number.txt");
            if (!number.HasValue)
            {
                ErrorMessage();
                return;
            }
            ClearFile("ResultFile.txt");
            DeleteFile("ResultFile.zip");
            while (true)
            {
                int choice;
                Console.WriteLine("Выбирете действие указав число:");
                Console.WriteLine("Вывести количество групп на экран: Число 1 ");
                Console.WriteLine("Записать группы в файл: число 2");
                var str = Console.ReadLine();
                if (int.TryParse(str, out choice))
                {
                    Stopwatch sw = Stopwatch.StartNew();
                    var gna = GroupsNumbersArr(number.Value);
                    sw.Stop();
                    Console.WriteLine($"Время выполнения = {sw.Elapsed.TotalSeconds}");
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine($"Количество групп = {gna.Count}");
                            break;
                        case 2:
                            if (gna.Any())
                            {
                                WriteFile(gna);
                            }
                            while (true)
                            {
                                Console.WriteLine("Заархивировать файл Yes/No");
                                var archiveChoice = Console.ReadLine();
                                if (archiveChoice.ToLower() == "yes")
                                {
                                    CompressFile("ResultFile.txt", "ResultFile.zip");
                                    return;
                                }

                                if (archiveChoice.ToLower() != "no")
                                {
                                    Console.WriteLine("Ошбка ввода");
                                }
                            }
                            break;
                        default:
                            ErrorMessage();
                            break;
                    }
                    return;
                }
                Console.WriteLine("Указанное число не верное");
            }
        }

        /// <summary>
        /// Вычисление групп
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static List<List<int>> GroupsNumbersArr(int number)
        {
            List<List<int>> groups = new List<List<int>>();
            var groupNumber = (int) Math.Log(number, 2) + 1;
            groups.Add(new List<int>() { 1 });
            for (int i = 1; i < groupNumber; i++)
            {
                var startIndex = (int) Math.Pow(2, i);
                var startIndexX2 = startIndex * 2;
                var count = Math.Min(startIndexX2, number) - startIndex + (startIndexX2 >= number ? 1 : 0);
                var itemList = Enumerable.Range(startIndex, count).ToList();
                groups.Add(itemList);
            }
            return groups;
        }

        /// <summary>
        /// Чтение числа
        /// </summary>
        /// <returns></returns>
        private static int? ReadNumber(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("Файл отсутствует");
                return null;
            }
            int number;
            using StreamReader sr = new StreamReader(path, Encoding.Unicode);
            var str = sr.ReadToEnd();
            if (int.TryParse(str, out number)) return number;
            Console.WriteLine("Файл пустой или число имеет не верный формат");
            return null;
        }

        /// <summary>
        /// Запись файла
        /// </summary>
        /// <param name="outputString"></param>
        private static void WriteFile(List<List<int>> gna)
        {
            using StreamWriter sw = new StreamWriter("ResultFile.txt", true, Encoding.Unicode);
            foreach (var itemList in gna)
            {
                sw.WriteLine($"Группа {gna.IndexOf(itemList) + 1}: {string.Join("; ", itemList)}");
            }
        }

        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        private static void ErrorMessage()
        {
            Console.WriteLine("Программа завершена с ошибкой");
        }

        /// <summary>
        /// Сжатие
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="compressedFile"></param>
        private static void CompressFile(string sourceFile, string compressedFile)
        {
            using FileStream sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate);
            using FileStream targetStream = File.Create(compressedFile);
            using GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress);
            sourceStream.CopyTo(compressionStream);
            Console.WriteLine(
                $"Сжатие файла {sourceFile} завершено. Исходный размер: {sourceStream.Length}  сжатый размер: {targetStream.Length}.");
        }

        /// <summary>
        /// Очистка текста
        /// </summary>
        /// <param name="path"></param>
        private static void ClearFile(string path)
        {
            File.WriteAllText(path, string.Empty);
        }

        /// <summary>
        /// Удаление файла
        /// </summary>
        /// <param name="path"></param>
        private static void DeleteFile(string path)
        {
            File.Delete(path);
        }
    }
}