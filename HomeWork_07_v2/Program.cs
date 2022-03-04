using System.Threading.Channels;
using HomeWork_07_v2.Components;
using HomeWork_07_v2.Models;

var rnd = new Random();

var employeeData = new EmployeeData();
//Получить список сотрудников
var empList = employeeData.GetEmployeeList();
//Посмотреть все записи сотрудников
employeeData.ViewAllRecord(empList);
Console.WriteLine("=======================");
var index = rnd.Next(1, 100);

//Создание записи
employeeData.CreateEmployee($"ФИО-{index}", index.ToString(), index.ToString(),
    DateTime.Now.AddDays(index).ToShortDateString(), $"город {index}");
employeeData.ViewAllRecord(employeeData.GetEmployeeList());

Console.WriteLine("=======================");
//Загрузка записей в выбранном диапазоне дат
employeeData.LoadSelectedDateRange(Entity.BirthDate, DateTime.Today.AddDays(index-1), DateTime.Today.AddDays(index+1));
employeeData.ViewAllRecord(employeeData.GetEmployeeListDateRange());

index = rnd.Next(1, 100);

//Изменение записи
employeeData.UpdateEmployee(3, $"ФИО-{index}", index.ToString(), index.ToString(),
    DateTime.Now.AddDays(index).ToShortDateString(), $"город {index}");

// Сортировка
Console.WriteLine("=======================");
employeeData.ViewAllRecord(employeeData.SortData(SortType.asc, Entity.BirthDate));

//Получение сотрудника по Id
Console.WriteLine("=======================");
int empId = 3;
var emp = employeeData.GetEmployeeById(empId);
if (emp != null)
{
    employeeData.ViewRecord(emp);
}
else
{
    Console.WriteLine($"Сотрудник с Id={empId} не найден");
}

//Удаление сотрудника
Console.WriteLine("=======================");
employeeData.DeleteEmployee(empId);
employeeData.ViewAllRecord(employeeData.GetEmployeeList());

FileMethods.WriteFile(employeeData.GetEmployeeList().Select(c => Employee.EmployeeToString(c)).ToArray());





Console.ReadKey();
