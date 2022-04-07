using MassageStudioApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassageStudioApp.Abstractions
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();

        Employee GetEmployeeById(int employeeId);
        Employee GetEmployeeByUserId(string userId);

        public bool RemoveById(int employeeId);

        string GetFullName(int employeeId);

        bool CreateEmployee(string firstName, string lastName, string phone, string jobTitle, string userId);

        public bool UpdateEmployee(int employeeId, string firstName, string lastName, string phone, string jobTitle);
    }
}
