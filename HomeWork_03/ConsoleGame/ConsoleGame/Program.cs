using System;
using System.Collections.Generic;

namespace Game_Task_01
{
    /// <summary>
    /// Константы
    /// </summary>
    internal class Constants
    {
        /// <summary>
        /// Начальное значение для игры
        /// </summary>
        public static readonly int StartNumber = 12;
        
        /// <summary>
        /// Конечное значение для игры
        /// </summary>
        public static readonly int EndNumber = 120;
        
        /// <summary>
        /// Минимальное значение хода
        /// </summary>
        public static readonly int MinPlayerTryNumber = 1;
        
        /// <summary>
        /// Максимальное значение хода
        /// </summary>
        public static readonly int MaxPlayerTryNumber = 4;
    }
    
    internal static class Program
    {
        /// <summary>
        /// Инициализация рандомайзера
        /// </summary>
        public static Random NewRandom = new Random();
        
        static void Main()
        {
            //Сложность, если true - сложно
            bool complicated = false;
            
            //Получение случайного числа для игры
            var gameNumber = NewRandom.Next(Constants.StartNumber, Constants.EndNumber);
            //
            var playerList = new List<Player>();
            
            //Правила
            Console.WriteLine("Игра рассчитана на произвольное количество игроков");
            Console.WriteLine(
                $"Система загадывает случайное число от {Constants.StartNumber} до {Constants.EndNumber}");
            Console.WriteLine("Необходимо последовательно вводить число от 1 до 4");
            Console.WriteLine("Каждое введенное число будет вычитаться из загаданного системой числа,");
            Console.WriteLine("до тех пор, пока разница не станет равна нулю");
            Console.WriteLine("В случае если введенное число будет меньше остатка, текущий игрок пропускает ход.");
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Введите количество игроков");
            var playerNumber = ConvertStrToInt();
            
            Console.WriteLine("Введите количество игроков компьютеров");
            var pcNumber = GetNumber(0, playerNumber);

            if (pcNumber > 0)
            {
                Console.WriteLine("Введите 1 если хотите сложный уровень, 0, если простой");
                complicated = GetNumber(0, 1) == 1;
            }
            
            //Создание игроков пользователей
            for (int i = 1; i <= playerNumber - pcNumber; i++)
            {
                Console.WriteLine($"Введите имя {i} игрока");
                playerList.Add(new Player()
                {
                    PlayerName = Console.ReadLine(),
                    PlayerType = PlayerType.User
                });
            }
            
            //Создание игроков компьютеров
            for (int i = playerNumber - pcNumber; i < playerNumber; i++)
            {
                playerList.Add(new Player()
                {
                    PlayerName = $"Игрок компьютер №{i + 1}",
                    PlayerType = PlayerType.Pc
                });
            }
            
            
            Console.WriteLine("Ожидайте, система определяет очерёдность хода...");
            
            //Перемешиваем список игроков
            for (int i = playerList.Count - 1; i >= 1; i--)
            {
                int j = NewRandom.Next(i + 1);
                var temp = playerList[j];
                playerList[j] = playerList[i];
                playerList[i] = temp;
            }
            System.Threading.Thread.Sleep(2000);
            Player currentPlayer = null;

            //Логика игры
            do
            {
                //По каждому игроку
                foreach (var player in playerList)
                {
                    Console.WriteLine($"Осталось {gameNumber}");
                    currentPlayer = player;
                    int playerTry;
                    //Если игрок компьютер
                    if (currentPlayer.PlayerType == PlayerType.Pc)
                    {
                        Console.WriteLine($"Ходит компьютер, {currentPlayer.PlayerName}");
                        if (complicated)
                        {
                            playerTry = ComplicatedPcTurn(gameNumber);
                        }
                        else
                        {
                            //Получаем число для хода компьютера
                            playerTry = new Random().Next(Constants.MinPlayerTryNumber, Constants.MaxPlayerTryNumber);
                        }
                        Console.WriteLine($"{playerTry}");
                        System.Threading.Thread.Sleep(1000);
                    }
                    else//Игрок реальный
                    {
                        Console.WriteLine($"{currentPlayer.PlayerName}, Ваш ход");
                        //Ввод числа с клавиатуры
                        playerTry = GetNumber(Constants.MinPlayerTryNumber, Constants.MaxPlayerTryNumber);
                    }
                    //Логика сравнения остатка с введенным числом
                    if (gameNumber < playerTry)
                    {
                        Console.WriteLine(
                            $"Число {playerTry} меньше остатка, {currentPlayer.PlayerName} пропускает ход.");
                    }
                    else if (gameNumber == playerTry)
                    {
                        gameNumber -= playerTry;
                        break;
                    }
                    else
                    {
                        gameNumber -= playerTry;
                    }
                }
            } while (gameNumber != 0);

            if (currentPlayer != null) Console.WriteLine($"{currentPlayer.PlayerName}, поздравляем, Вы победили!");
            else Console.WriteLine("Непредвиденная ошибка");
        }
        
        /// <summary>
        /// Метод вычисления введенного числа
        /// </summary>
        /// <returns>Возвращает число типа Int32</returns>
        public static int GetNumber(int minValue, int maxValue)
        {
            bool error;
            int intNumber;
            do
            {
                Console.WriteLine($"Введите число от {minValue} до {maxValue}: ");
                error = true;
                intNumber = ConvertStrToInt();
                if (intNumber < minValue || intNumber > maxValue)
                {
                    Console.WriteLine($"Число не может быть {intNumber}, укажите число от {minValue} до {maxValue}");
                }
                else
                {
                    error = false;
                }
            } while (error);

            return intNumber;
        }
        
        /// <summary>
        /// Конвертирование строки в число
        /// </summary>
        /// <returns></returns>
        public static int ConvertStrToInt()
        {
            bool error;
            int intNumber;
            do
            {
                string stringValue = Console.ReadLine();
                error = true;
                if (!Int32.TryParse(stringValue, out intNumber))
                {
                    Console.WriteLine("Строка имеет не верный формат, попробуйте снова");
                }
                else
                {
                    error = false;
                }
            } while (error);

            return intNumber;
        }

        public static int ComplicatedPcTurn(int gameNumber)
        {
            switch (gameNumber)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    return gameNumber;
                case 5: return 4;//По любому проиграл
                case 6: return 1;
                case 7: return 2;
                case 8: return 3;
                case 9: return 4;
                case 10: return NewRandom.Next(Constants.MinPlayerTryNumber, Constants.MaxPlayerTryNumber);
                case 11: return NewRandom.Next(Constants.MinPlayerTryNumber, Constants.MaxPlayerTryNumber);
                case 12: return NewRandom.Next(Constants.MinPlayerTryNumber, Constants.MaxPlayerTryNumber);
                default: return 4;
            }
        }
        
        /// <summary>
        /// Тип игрока
        /// </summary>
        public enum PlayerType
        {
            User,
            Pc
        }
        
        /// <summary>
        /// Класс описывающий игрока
        /// </summary>
        public class Player
        {
            /// <summary>
            /// Тип игрока
            /// </summary>
            public PlayerType PlayerType { get; set; }
            
            /// <summary>
            /// Имя игрока
            /// </summary>
            public string PlayerName { get; set; }
        }
    }
}