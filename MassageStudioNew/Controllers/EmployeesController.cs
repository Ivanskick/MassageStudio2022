using MassageStudioApp.Abstractions;
using MassageStudioApp.Entities;
using MassageStudioApp.Models.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassageStudioApp.Controllers
{
    
    public class EmployeesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmployeeService _employeeService;

        public EmployeesController(UserManager<ApplicationUser> userManager, IEmployeeService employeeService)
        {
            _userManager = userManager;
            _employeeService = employeeService;
        }

        // GET: EmployeesController
        public ActionResult Index()
        {
            var users = _employeeService.GetEmployees()
                   .Select(u => new EmployeeListingVM
                   {
                       Id = u.Id,
                       FirstName = u.FirstName,
                       LastName = u.LastName,
                       Email = u.User.Email,
                       Phone = u.Phone,
                       JobTitle = u.JobTitle
                   }).ToList();

            return this.View(users);
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            Employee item = _employeeService.GetEmployeeById(id);
            if (item == null)
            {
                return NotFound();
            }
            EmployeeDetailsVM employee = new EmployeeDetailsVM()
            {
                Id = item.Id,
                Email = item.User.Email,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Phone = item.Phone,
                JobTitle = item.JobTitle
            };
            return View(employee);
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateEmployeeVM employee)
        {
           if (!ModelState.IsValid)
            {
                return View(employee);
            }
           if (await _userManager.FindByNameAsync (employee.Username) == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = employee.Username;
                user.Email = employee.Email;

                var result = await _userManager.CreateAsync(user, "Employee123!");
 
                if (result.Succeeded)
                {
                    var created = _employeeService.CreateEmployee(employee.FirstName, employee.LastName, employee.Phone, employee.JobTitle, user.Id);
                    if (created)
                    {
                        _userManager.AddToRoleAsync(user, "Employee").Wait();
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError(string.Empty, "The employee exists.");
            return View();

        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            Employee item = _employeeService.GetEmployeeById(id);
            {
                return View(item);
            }
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditEmployeeVM bindingModel)
        {
            if (ModelState.IsValid)
            {
                var updated = _employeeService.UpdateEmployee(id, bindingModel.FirstName, bindingModel.LastName, bindingModel.Phone,  bindingModel.JobTitle);
                if (updated)
                {
                    return this.RedirectToAction("Index");
                }
            }
            return View(bindingModel);
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
