using AdditionalUser1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdditionalUser1.Abstractions
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();

        Employee GetEmployeeById(int employeeId);

        public bool RemoveById(int employeeId);

        string GetFullName(int employeeId);

        bool CreateEmployee(string firstName, string lastName, string phone, string jobTitle, string userId);
    }
}
