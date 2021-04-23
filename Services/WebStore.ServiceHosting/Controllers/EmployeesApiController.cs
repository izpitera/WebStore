using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<EmployeesApiController> _Logger;

        public EmployeesApiController(
            IEmployeesData EmployeesData, 
            ILogger<EmployeesApiController> Logger)
        {
            _EmployeesData = EmployeesData;
            _Logger = Logger;
        }

        [HttpGet]
        public IEnumerable<Employee> Get() => _EmployeesData.Get();

        [HttpGet("{id}")]
        public Employee Get(int id) => _EmployeesData.Get(id);

        [HttpPost]
        public int Add(Employee employee)
        {
            _Logger.LogInformation("Добавление сотрудника {0}", employee);
            return _EmployeesData.Add(employee);
        }

        [HttpPut]
        public void Update(Employee employee)
        {
            _Logger.LogInformation("Редактирование сотрудника {0}", employee);
            _EmployeesData.Update(employee);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            _Logger.LogInformation("Удаление сотрудника id: {0}", id);
            var result = _EmployeesData.Delete(id);
            _Logger.LogInformation("Удаление сотрудника id: {0} {1}",
                id, result ? "выполнено" : "не выполнено");
            return result;
        }
    }
}
