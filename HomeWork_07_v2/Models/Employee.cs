using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_07_v2.Models
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Id
        /// </summary>
        internal int Id { get; set; }

        /// <summary>
        /// Дата и время добавления записи 
        /// </summary>
        internal DateTime CreationDate { get; set; }

        /// <summary>
        /// Ф.И.О.
        /// </summary>
        internal string? FullName { get; set; }

        /// <summary>
        /// Возраст
        /// </summary>
        internal int? Age { get; set; }

        /// <summary>
        /// Рост
        /// </summary>
        internal double? Height { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        internal DateTime? BirthDate { get; set; }

        /// <summary>
        /// Место рождения
        /// </summary>
        internal string? BirthPlace { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateString"></param>
        /// <param name="currentDate"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private static DateTime? SetDateValue(string? dateString, bool currentDate = false)
        {
            try
            {
                return Convert.ToDateTime(dateString);
            }
            catch
            {
                return currentDate ? DateTime.Now : null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intString"></param>
        /// <param name="isId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private static int? SetIntValue(string? intString, bool isId = false)
        {
            try
            {
                return Convert.ToInt32(intString);
            }
            catch
            {
                return isId ? -1 : null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="doubleString"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private static double? SetDoubleValue(string? doubleString)
        {
            try
            {
                return Convert.ToDouble(doubleString);
            }
            catch
            {
                return null;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        internal static string EmployeeToString(Employee employee)
        {
            return string.Join("#", new string?[]
            {
                employee.Id.ToString(), employee.CreationDate.ToString(CultureInfo.InvariantCulture),
                employee.FullName,
                employee.Age.ToString(), employee.Height.ToString(),
                employee.BirthDate.ToString(), employee.BirthPlace
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        internal void StringToEmployee(string str)
        {
            string?[] stringArray = str.Split('#');
            // ReSharper disable once PossibleInvalidOperationException
            Id = SetIntValue(stringArray[0], true)!.Value;
            // ReSharper disable once PossibleInvalidOperationException
            CreationDate = SetDateValue(stringArray[1], true)!.Value;
            FullName = stringArray[2];
            Age = SetIntValue(stringArray[3]);
            Height = SetDoubleValue(stringArray[4]);
            BirthDate = SetDateValue(stringArray[5]);
            BirthPlace = stringArray[6];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        public Employee(string str)
        {
            StringToEmployee(str);
        }

        public Employee()
        {

        }
    }
}
