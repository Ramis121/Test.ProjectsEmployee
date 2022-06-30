using Domain.Interface;
using Domain.Models;
using JWT.Projectstwo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace JWT.Projectstwo.Repositories
{
    public class EmployeesRepository : IEmployees
    {
        private readonly ILogger<EmployeesRepository> _logger;
        public readonly ApplicationDbContext context;
        public EmployeesRepository(ApplicationDbContext context, ILogger<EmployeesRepository> logger)
        {
            this.context = context;
            _logger = logger;
        }
        public void AddEmployees(Employees employees)
        {
            if (employees is not null)
            {
                _logger.LogInformation($"User added UserId {employees.EmployeeID}");
                context.Employees.Add(employees);
                context.SaveChanges();
            }
            _logger.LogError($"User under userid {employees.EmployeeID} cannot be added");
        }

        public Employees DeleteEmployees(int id)
        {
            var res = context.Employees.FirstOrDefault(a => a.EmployeeID == id);
            if (res is not null)
            {
                _logger.LogInformation($"User remove UserId {id}");
                context.Employees.Remove(res);
                context.SaveChanges();
                return res;
            }
            _logger.LogError($"User under userid {id} cannot be remove");
            return null;
        }

        public async Task<IEnumerable<Employees>> GetEmployees()
        {
            return await context.Employees.ToListAsync();
        }

        public async Task<Employees> GetEmployees(int id)
        {
            return await context.Employees.FirstOrDefaultAsync(a => a.EmployeeID == id);
        }

        public void UpdateEmployees(Employees employees)
        {
            try
            {
                context.Entry(employees).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch
            {

                throw;
            }
        }

        public string JsonConverts()
        {
            var employee = new Employees()
            {
                 BirthDate = DateTime.UtcNow,
                 EmployeeID = 777,
                 LoginID = "1111",
                 NationalIDNumber = "87075995295",
                 EmployeeName = "Ramis",
                 JobTitle = "Beckend-Developer Senior Team-Lead Apple)"
            };
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(employee, options);
            return json;    
        }
    }
}
