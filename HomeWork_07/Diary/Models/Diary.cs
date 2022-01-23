using System;
using System.Collections.Generic;

namespace Diary
{
    /// <summary>
    /// Элемент ежедневника
    /// </summary>
    public struct Diary
    {
        /// <summary>
        /// 
        /// </summary>
        private int Id { get; set; }
        private DateTime CreationDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private string FullName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private int Age { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private double Height { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private DateTime BirthDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private string BirthPlace { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        public Diary(string str)
        {
            var stringArray = str.Split('#');
            Id = SetIntValue(stringArray[0]);
            CreationDate = SetDateValue(stringArray[1]);
            FullName = stringArray[2];
            Age = SetIntValue(stringArray[3]);
            Height = SetDoubleValue(stringArray[4]);
            BirthDate = SetDateValue(stringArray[5]);
            BirthPlace = stringArray[6];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateString"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private static DateTime SetDateValue(string dateString)
        {
            try
            {
                return Convert.ToDateTime(dateString);
            }
            catch (Exception e)
            {
                return DateTime.Now;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IntString"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private static int SetIntValue(string IntString)
        {
            try
            {
                return Convert.ToInt32(IntString);
            }
            catch (Exception e)
            {
                throw GetException();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="doubleString"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private static double SetDoubleValue(string doubleString)
        {
            try
            {
                return Convert.ToDouble(doubleString);
            }
            catch (Exception e)
            {
                throw GetException();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static Exception GetException()
        {
            return new Exception("Входная строка имеет неверный формат");
        }
    }
}