using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IEmployees
    {
        Task<IEnumerable<Employees>> GetEmployees();
        Task<Employees> GetEmployees(int id);
        void AddEmployees(Employees employees);
        void UpdateEmployees(Employees employees);
        Employees DeleteEmployees(int id);
        string JsonConverts();
    }
}
