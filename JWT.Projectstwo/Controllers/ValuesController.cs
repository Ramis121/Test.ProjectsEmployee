using Domain.Interface;
using Domain.Models;
using JWT.Projectstwo.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWT.Projectstwo.Controllers
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
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IEnumerable<Employees>> Get()
        {
            return await _employees.GetEmployees();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
