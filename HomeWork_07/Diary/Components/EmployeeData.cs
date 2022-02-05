using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeData.Models;

namespace EmployeeData.Components
{
    /// <summary>
    /// 
    /// </summary>
    internal class EmployeeData
    {
        /// <summary>
        /// 
        /// </summary>
        private static List<Employee> _employeeList;

        /// <summary>
        /// 
        /// </summary>
        private int _currentId;

        /// <summary>
        /// 
        /// </summary>
        public int Count => _employeeList.Count;

        /// <summary>
        /// 
        /// </summary>
        private readonly string[] _titles = new[]
            {"Id", "Дата и время добавления", "Ф.И.О.", "Возраст", "Рост", "Дата рождения", "Место рождения"};

        public EmployeeData()
        {
            GetEmployeList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputRecord"></param>
        public static void ViewRecord(string inputRecord)
        {

            Console.WriteLine(inputRecord.Split('#', ' '));
        }

        public static void CreateRecord(string inputRecord)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private void GetEmployeList()
        {
            _employeeList = new List<Employee>();

            foreach (var stringData in FileMethods.ReadFile())
            {
                AddStringData(stringData);
            }

            _currentId = _employeeList.Max(c => c.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="age"></param>
        /// <param name="height"></param>
        /// <param name="birthDate"></param>
        /// <param name="birthPlace"></param>
        internal void SetNewEmploye(string fullName, string age, string height, string birthDate, string birthPlace)
        {
            _currentId++;
            var stringData = string.Join("#", new string[]
            {
                _currentId.ToString(), DateTime.Now.ToString(CultureInfo.InvariantCulture), fullName, age, height,
                birthDate, birthPlace
            });
            AddStringData(stringData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stringData"></param>
        private static void AddStringData(string stringData)
        {
            _employeeList.Add(new Employee(stringData));
        }
    }
}
