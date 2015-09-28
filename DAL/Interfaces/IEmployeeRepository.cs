using System.Collections.Generic;
using DAL.Model;

namespace DAL.Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll();
    }
}