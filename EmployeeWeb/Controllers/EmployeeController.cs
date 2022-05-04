using EmployeeData.Models;
using EmployeeData.Repositories;
using Microsoft.AspNetCore.Mvc;
using EmployeeWeb.Services;

namespace EmployeeWeb.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeRepository employeeRepository, IEmployeeService employeeService)
        {
            this.employeeRepository = employeeRepository;
            this.employeeService = employeeService;
        }

        public IActionResult Index(int page = 1)
        {
            //var employeeList = this.employeeRepository.FindAll();
            return View(employeeService.GetEmployeePage(page));
        }

        public IActionResult Edit(int id)
        {
            ViewData["Action"] = "Edit";
            var employee = this.employeeRepository.FindByPrimaryKey(id);
            return View("Form", employee);
        }

        public IActionResult Delete(int id, int page)
        {
            var employee = this.employeeRepository.FindByPrimaryKey(id);
            employee.Active = false;
            employeeRepository.Update(employee);
            employeeRepository.Save();
            return RedirectToAction("Index", new { page = page });
        }
        public IActionResult Save(string action, Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (action.ToLower().Equals("new"))
                {
                    employeeRepository.Insert(employee);
                }
                else if (action.ToLower().Equals("edit"))
                {
                    employeeRepository.Update(employee);
                }
                employeeRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Form", employee);
            }
        }
    }
}
