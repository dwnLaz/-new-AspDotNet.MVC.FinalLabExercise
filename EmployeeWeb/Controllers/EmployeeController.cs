using EmployeeData.Models;
using EmployeeData.Repositories;
using Microsoft.AspNetCore.Mvc;
using EmployeeWeb.Services;

namespace EmployeeWeb.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly ISkillRepository skillRepository;
        private readonly IEmployeeSkillRepository employeeSkillRepository;
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeRepository employeeRepository, 
            IEmployeeService employeeService,
            ISkillRepository skillRepository,
            IEmployeeSkillRepository employeeSkillRepository)
        {
            this.employeeRepository = employeeRepository;
            this.employeeSkillRepository = employeeSkillRepository;
            this.skillRepository = skillRepository;
            this.employeeService = employeeService;
        }

        public IActionResult Index(int page = 1)
        {
            //var employeeList = this.employeeRepository.FindAll();
            return View(employeeService.GetEmployeePage(page));
        }

        public IActionResult New()
        {
            ViewData["Action"] = "New";
            return View("Form", new Employee());
        }

        public IActionResult Edit(int id)
        {
            ViewData["Action"] = "Edit";
            var employee = this.employeeRepository.FindByPrimaryKey(id);
            ViewBag.existingSkills = this.skillRepository.FindAll();
            ViewBag.skills = this.employeeRepository.GetSkills(id);
            return View("Form", employee);
        }
        public IActionResult Delete(int id, int page)
        {
            var employee = this.employeeRepository.FindByPrimaryKey(id);
            employee.Active = false;
            employeeRepository.Update(employee);
            return RedirectToAction("Index", new { page = page });
        }
        public IActionResult Save(string action, Employee employee)
        {            
            if (ModelState.IsValid)
            {
                if (action.ToLower().Equals("new"))
                {
                    employee.Active = true;
                    employeeRepository.Insert(employee);
                }
                else if (action.ToLower().Equals("edit"))
                {            
                    employeeRepository.Update(employee);
                }
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["Action"] = action;
                ViewBag.existingSkills = this.skillRepository.FindAll();
                ViewBag.skills = this.employeeRepository.GetSkills(employee.EmployeeId);
                return View("Form", employee);
            }
        }
        //public IActionResult AddNewSkill(int employeeId, int skillId)
        //{

        //    var employeeSkill = new EmployeeSkill
        //    {
        //        EmployeeId = employeeId,
        //        SkillId = skillId
        //    };
        //    employeeSkillRepository.Insert(employeeSkill);

        //    ViewData["Action"] = "Edit";
        //    var entity = this.employeeRepository.FindByPrimaryKey(employeeId);
        //    ViewBag.existingSkills = this.skillRepository.FindAll();
        //    ViewBag.skills = this.employeeRepository.GetSkills(employeeId);
        //    return View("Form", entity);
        //}

        public IActionResult AddNewSkill(string action, Employee employee, int addSkill)
        {
                var employeeSkill = new EmployeeSkill
                {
                    EmployeeId = employee.EmployeeId,
                    SkillId = addSkill
                };
                employeeSkillRepository.Insert(employeeSkill);
            
            //return RedirectToAction("Edit", new { id = employee.EmployeeId });
            ViewData["Action"] = "Edit";
            ViewBag.existingSkills = this.skillRepository.FindAll();
            var entity = this.employeeRepository.FindByPrimaryKey(employee.EmployeeId);
            ViewBag.skills = this.employeeRepository.GetSkills(employee.EmployeeId);
            return View("Form", entity);
        }
    }
}
