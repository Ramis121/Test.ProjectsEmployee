using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Employees
    {
        [Key]
        public int EmployeeID { get; set; }
        public string NationalIDNumber { get; set; }
        public string EmployeeName { get; set; }
        public string LoginID { get; set; }
        public string JobTitle { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
