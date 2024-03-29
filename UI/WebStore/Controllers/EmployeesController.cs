﻿using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;
using WebStore.Domain.Entities.Identity;
using WebStore.Domain.Models;
using WebStore.Domain.ViewModels;
using WebStore.Interfaces.Services;

namespace WebStore.Controllers
{
    //[Route("staff")]
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly IEmployeesData _EmployeesData;
        public EmployeesController(IEmployeesData EmployeesData)
        {
            _EmployeesData = EmployeesData;
        }

        //[Route("all")]
        public IActionResult Index() => View(_EmployeesData.Get());

        // http://localhost:5000/employees/5
        // if instead of int id, int name -> http://localhost:5000/employees?name=5

        //[Route("info(id-{id})")]
        public IActionResult Details(int id)
        {
            var employee = _EmployeesData.Get(id);
            if (employee is not null)
                return View(employee);
            return NotFound();
        }

        public IActionResult Create() => View("Edit", new EmployeeViewModel());

        #region Edit

        [Authorize(Roles = Role.Administrator)]
        public IActionResult Edit(int? id)
        {
            if (id is null) return View(new EmployeeViewModel());
            if (id <= 0) return BadRequest();
            var employee = _EmployeesData.Get((int)id);
            if (employee is null) return NotFound();

            return View(new EmployeeViewModel
            {
                Id = employee.Id,
                LastName = employee.LastName,
                Name = employee.FirstName,
                MiddleName = employee.Patronymic,
                Age = employee.Age,
                Sex = employee.Sex,
                Citizenship = employee.Citizenship,
                Salary = employee.Salary
            });
        }

        [HttpPost] //Name can be same if it has method => httpPost
        [Authorize(Roles = Role.Administrator)] // can be several roles comma delimited or several lines with dif. roles
        public IActionResult Edit(EmployeeViewModel model)
        {
            if (model is null) throw new ArgumentNullException(nameof(model));

            if (model.Name == "Петрушка") ModelState.AddModelError("", "Не проходит это имя!");

            if (!ModelState.IsValid) return View(model);

            var employee = new Employee
            {
                Id = model.Id,
                LastName = model.LastName,
                FirstName = model.Name,
                Patronymic = model.MiddleName,
                Age = model.Age,
                Sex = model.Sex,
                Citizenship = model.Citizenship,
                Salary = model.Salary
            };

            if (employee.Id == 0)
                _EmployeesData.Add(employee);
            else
               _EmployeesData.Update(employee);

            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        [Authorize(Roles = Role.Administrator)]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest();
            var employee = _EmployeesData.Get(id);
            if (employee is null) return NotFound();

            return View(new EmployeeViewModel
            {
                Id = employee.Id,
                LastName = employee.LastName,
                Name = employee.FirstName,
                MiddleName = employee.Patronymic,
                Age = employee.Age,
                Sex = employee.Sex,
                Citizenship = employee.Citizenship,
                Salary = employee.Salary
            });
        }

        [HttpPost]
        [Authorize(Roles = Role.Administrator)]
        public IActionResult DeleteConfirmed(int id)
        {
            _EmployeesData.Delete(id);
            return RedirectToAction("Index");
        }
        #endregion
    }

}
