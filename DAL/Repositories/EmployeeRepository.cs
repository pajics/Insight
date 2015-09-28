using System.Collections.Generic;
using DAL.Interfaces;
using DAL.Model;

namespace DAL
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public List<Employee> GetAll()
        {
            var employees = new List<Employee> {
                   new Employee { FirstName = "Srdjan", LastName = "Pajic" },
                   new Employee { FirstName = "Jelena", LastName = "Stankov" }
                    };
            return employees;
        }
    }
}
