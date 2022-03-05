using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Int64;

namespace HomeWork_08
{
    internal class DictionaryWork
    {
        /// <summary>
        /// 
        /// </summary>
        private static Dictionary<string, string>? PhoneDictionary { get; set; }

        public static void RunDictionaryWork()
        {
            Console.WriteLine("Введите номер телефона и ФИО или Введите пробел, чтобы закончить ввод");
            PhoneDictionary = new Dictionary<string, string>();
            while (true)
            {
                string fioString = "";
                string phoneNumberString = "";
                Console.WriteLine("Введите номер телефона");
                Console.WriteLine("Номер телефона состоит только из цифр");
                phoneNumberString = Console.ReadLine();
                if (phoneNumberString == " ")
                    break;
                
                if (!TryParse(phoneNumberString, out long phoneNumber))
                {
                    continue;
                }

                if (FindPhoneDictionary(phoneNumberString).Any())
                {
                    Console.WriteLine($"Номер телефона {phoneNumberString} уже существует");
                    continue;
                }
                while (true)
                {
                    Console.WriteLine("Введите ФИО");
                    fioString = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(fioString))
                    {
                        Console.WriteLine("ФИО не может быть пустым");
                        continue;
                    }
                    break;
                }

                SetItem(phoneNumberString, fioString);
            }
            
            while (true)
            {
                Console.WriteLine("Введите номер телефона для поиска владельца");
                Console.WriteLine("Номер телефона состоит только из цифр");
                var phoneNumberString = Console.ReadLine();
                if (phoneNumberString == " ")
                    break;
                if (!TryParse(phoneNumberString, out long phoneNumber))
                {
                    continue;
                }
                var fioList = FindPhoneDictionary(phoneNumberString);
                if (fioList.Any())
                {
                    Console.WriteLine(fioList.First());
                }
                else
                {
                    Console.WriteLine("Владелец не найден");
                }
                break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        private static void SetItem(string key, string value)
        {
            PhoneDictionary.Add(key, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        private static List<string> FindPhoneDictionary(string phoneNumber)
        {
            return PhoneDictionary.Where(c => c.Key == phoneNumber).Select(c => c.Value).ToList();
        }
    }
}
