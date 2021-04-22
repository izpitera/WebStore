﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Models;
using WebStore.Interfaces;
using WebStore.Interfaces.Services;

namespace WebStore.ServiceHosting.Controllers
{
    [Route(WebAPI.Employees)]
    [ApiController]
    public class EmployeesApiController : ControllerBase, IEmployeesData
    {
        private readonly IEmployeesData _EmployeesData;

        public EmployeesApiController(IEmployeesData EmployeesData) => _EmployeesData = EmployeesData;

        [HttpGet]
        public IEnumerable<Employee> Get() => _EmployeesData.Get();

        [HttpGet("{id}")]
        public Employee Get(int id) => _EmployeesData.Get(id);

        [HttpPost]
        public int Add(Employee employee) => _EmployeesData.Add(employee);

        [HttpPut]
        public void Update(Employee employee) => _EmployeesData.Update(employee);

        [HttpDelete("{id}")]
        public bool Delete(int id) => _EmployeesData.Delete(id);
    }
}
