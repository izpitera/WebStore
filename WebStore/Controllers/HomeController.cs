using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        private static readonly List<Employee> __Employees = new()
        {
            new Employee {Id = 1, LastName = "Иванов", FirstName = "Иван", Patronymic = "Иванович", Age = 37, Sex = "Мужской", Citizenship = "Россия", Salary = 56000},
            new Employee {Id = 2, LastName = "Петров", FirstName = "Пётр", Patronymic = "Петрович", Age = 27, Sex = "Мужской", Citizenship = "Киргизия", Salary = 47000 },
            new Employee { Id = 3, LastName = "Васечкина", FirstName = "Изольда", Patronymic = "Станиславовна", Age = 23, Sex = "Женский", Citizenship = "Россия", Salary = 45000 },
            new Employee {Id = 4, LastName = "Васечкин", FirstName = "Василий", Patronymic = "Васильевич", Age = 25, Sex = "Мужской", Citizenship = "Россия", Salary = 38000}
        };
        public IActionResult Index() => View();
 
        public IActionResult Employee(int id)
        {
            ViewData["Employee"] = id;
            return View(__Employees);
        }

        public IActionResult Employees()
        {
            return View(__Employees);
        }
    }
}
