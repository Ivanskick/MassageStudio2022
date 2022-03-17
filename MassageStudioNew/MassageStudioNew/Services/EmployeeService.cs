using MassageStudioApp.Abstractions;
using MassageStudioApp.Data;
using MassageStudioApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassageStudioApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateEmployee(string firstName, string lastName, string phone, string jobTitle, string userId)
        {
            if (_context.Employees.Any(p => p.UserId == userId))
            {
                throw new InvalidOperationException("Employee already exist.");
                }
            Employee employeeForDb = new Employee()
            {
                FirstName = firstName,
                LastName = lastName,
                Phone = phone,
                JobTitle = jobTitle,
                UserId = userId
            };
            _context.Employees.Add(employeeForDb);

            return _context.SaveChanges() != 0;
        }
        public Employee GetEmployeeById(int employeeId)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = _context.Employees.ToList();

            return employees;
        }

        public string GetFullName(int employeeId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveById(int employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
