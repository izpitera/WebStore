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
            new Employee {Id = 1, LastName = "Иванов", FirstName = "Иван", Patronymic = "Иванович", Age = 37},
            new Employee {Id = 2, LastName = "Петров", FirstName = "Пётр", Patronymic = "Петрович", Age = 27},
            new Employee {Id = 3, LastName = "Васечкин", FirstName = "Василий", Patronymic = "Васильевич", Age = 25}
        };
        public IActionResult Index() => View();
 
        public IActionResult SecondAction()
        {
            return Content("Second controller action");
        }

        public IActionResult Employees()
        {
            return View(__Employees);
        }
    }
}
