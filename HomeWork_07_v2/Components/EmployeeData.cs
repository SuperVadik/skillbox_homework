using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork_07_v2.Models;

namespace HomeWork_07_v2.Components
{
    /// <summary>
    /// 
    /// </summary>
    internal class EmployeeData
    {
        /// <summary>
        /// Список сотрудников
        /// </summary>
        private static List<Employee> _employeeList;

        /// <summary>
        /// Список сотрудников в выбранном диапазоне дат
        /// </summary>
        private static List<Employee> _employeeListDateRange;

        /// <summary>
        /// Последний Id
        /// </summary>
        private int _currentId;

        /// <summary>
        /// Количество сотрудников в базе
        /// </summary>
        public int Count => _employeeList.Count;

        /// <summary>
        /// Заголовки
        /// </summary>
        private readonly string[] _titles = new[]
            {"Id", "Дата и время добавления", "Ф.И.О.", "Возраст", "Рост", "Дата рождения", "Место рождения"};

        /// <summary>
        /// Инициализация класса
        /// </summary>
        public EmployeeData()
        {
            GetEmployeList();
        }

        /// <summary>
        /// 
        /// </summary>
        public EmployeeData(Entity ent, DateTime startDate, DateTime endDate)
        {
            new EmployeeData();
            LoadSelectedDateRange(ent, startDate, endDate);
        }

        /// <summary>
        /// Получить список сотрудников
        /// </summary>
        public List<Employee> GetEmployeeList()
        {
            return _employeeList;
        }

        /// <summary>
        /// Получить список сотрудников
        /// </summary>
        public List<Employee> GetEmployeeListDateRange()
        {
            return _employeeListDateRange;
        }

        /// <summary>
        /// Посмотреть запись по сотруднику
        /// </summary>
        /// <param name="inputRecord"></param>
        private void ViewRecord(string inputRecord)
        {
            Console.WriteLine(inputRecord.Replace('#', ' '));
        }

        /// <summary>
        /// Просмотреть запись по сотруднику
        /// </summary>
        /// <param name="emp"></param>
        public void ViewRecord(Employee emp)
        {
            var empString = Employee.EmployeeToString(emp);
            ViewRecord(empString);
        }

        /// <summary>
        /// Просмотреть все аписи
        /// </summary>
        /// <param name="emp"></param>
        public void ViewAllRecord(List<Employee> empList)
        {
            foreach (var emp in empList)
            {
                var empString = Employee.EmployeeToString(emp);
                ViewRecord(empString);
            }
        }

        /// <summary>
        /// Создать список сотрудников
        /// </summary>
        /// <returns></returns>
        private void GetEmployeList()
        {
            _employeeList = new List<Employee>();
            foreach (var stringData in FileMethods.ReadFile())
            {
                AddEmployee(stringData);
            }
            _currentId = _employeeList.Max(c => c.Id);
        }

        /// <summary>
        /// Загрузка записей в выбранном диапазоне дат
        /// </summary>
        /// <param name="ent"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        internal void LoadSelectedDateRange(Entity ent, DateTime startDate, DateTime endDate)
        {
            switch (ent)
            {
                case Entity.BirthDate:
                    _employeeListDateRange = _employeeList.Where(c => c.BirthDate.Value.Date >= startDate.Date && c.BirthDate.Value.Date <= endDate.Date)
                        .ToList();
                    break;
                case Entity.CreationDate:
                    _employeeListDateRange = _employeeList.Where(c => c.CreationDate.Date <= startDate.Date && c.CreationDate.Date >= endDate.Date)
                        .ToList();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(ent), ent, null);
            }
            
        }

        /// <summary>
        /// Создание сотрудника
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="age"></param>
        /// <param name="height"></param>
        /// <param name="birthDate"></param>
        /// <param name="birthPlace"></param>
        internal void CreateEmployee(string fullName, string age, string height, string birthDate, string birthPlace)
        {
            _currentId++;
            var stringData = string.Join("#", new string[]
            {
                _currentId.ToString(), DateTime.Now.ToString(CultureInfo.InvariantCulture), fullName, age, height,
                birthDate, birthPlace
            });
            AddEmployee(stringData);
        }

        /// <summary>
        /// Обновление сотрудника
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fullName"></param>
        /// <param name="age"></param>
        /// <param name="height"></param>
        /// <param name="birthDate"></param>
        /// <param name="birthPlace"></param>
        internal void UpdateEmployee(int id, string fullName, string age, string height, string birthDate, string birthPlace)
        {
            var emp = _employeeList.FirstOrDefault(c => c.Id == id);
            if (emp == null)
            {
                Console.WriteLine("Сотрудник не найден");
                return; 
            }
            if (!string.IsNullOrEmpty(birthDate))
                emp.BirthDate = Convert.ToDateTime(birthDate);
            if (!string.IsNullOrEmpty(birthPlace))
                emp.BirthPlace = birthPlace;
            if (!string.IsNullOrEmpty(fullName))
                emp.FullName = fullName;
            if (!string.IsNullOrEmpty(age))
                emp.Age = Convert.ToInt32(age);
            if (!string.IsNullOrEmpty(height))
                emp.Height = Convert.ToDouble(height);

        }

        /// <summary>
        /// Сортировка по дате
        /// </summary>
        /// <param name="sortType"></param>
        /// <param name="sortEntity"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        internal List<Employee> SortData(SortType sortType, Entity sortEntity)
        {
            return sortEntity switch
            {
                Entity.BirthDate => sortType == SortType.asc
                    ? _employeeList.OrderBy(c => c.BirthDate).ToList()
                    : _employeeList.OrderByDescending(c => c.BirthDate).ToList(),
                Entity.CreationDate => sortType == SortType.asc
                    ? _employeeList.OrderBy(c => c.CreationDate).ToList()
                    : _employeeList.OrderByDescending(c => c.CreationDate).ToList(),
                _ => throw new ArgumentOutOfRangeException(nameof(sortEntity), sortEntity, null)
            };
        }

        /// <summary>
        /// Удаление записи
        /// </summary>
        /// <param name="id">Идентификатор сотрудника</param>
        internal void DeleteEmployee(int id)
        {
            var emp = _employeeList.FirstOrDefault(c => c.Id == id);
            _employeeList.Remove(emp);
        }

        /// <summary>
        /// Добавить сотрудника в список
        /// </summary>
        /// <param name="stringData"></param>
        private static Employee AddEmployee(string stringData)
        {
            var emp = new Employee(stringData);
            _employeeList.Add(emp);
            return emp;
        }
    }

    /// <summary>
    /// Тип сортировки
    /// </summary>
    enum SortType
    {
        /// <summary>
        /// По возрастанию
        /// </summary>
        asc,
        /// <summary>
        /// По убыванию
        /// </summary>
        desc
    }

    /// <summary>
    /// Свойство для сортировки
    /// </summary>
    enum Entity
    {
        /// <summary>
        /// По дате рождения
        /// </summary>
        BirthDate,
        /// <summary>
        /// По дате создания
        /// </summary>
        CreationDate
    }
}
