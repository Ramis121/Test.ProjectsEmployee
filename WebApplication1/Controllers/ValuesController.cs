using Domain.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> _logger;
        private readonly IEmployees _employees;
        public ValuesController(IEmployees employees, ILogger<ValuesController> logger)
        {
            _employees = employees;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IEnumerable<Employees>> Get()
        {
            return await _employees.GetEmployees();
        }

        [HttpGet("{id}")]
        public async Task<Employees> Get(int id)
        {
            return await _employees.GetEmployees(id);
        }

        [HttpPost]
        public void Post([FromBody] Employees employees)
        {
            if (employees is not null)
            {
                _employees.AddEmployees(employees);
            }
        }

        [HttpPut("{id}")]
        public void Update([FromBody] Employees employees)
        {
            _employees.UpdateEmployees(employees);
        }

        [HttpGet("json")]
        public string JsonConv()
        {
            return _employees.JsonConverts();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
