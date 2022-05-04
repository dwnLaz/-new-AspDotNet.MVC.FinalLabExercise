﻿using EmployeeData.Models;
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
            ViewBag.skills = this.employeeRepository.GetSkills(id);
            return View("Form", employee);
        }
        public IActionResult Save(string action, Employee employee, string? addSkill)
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
                    //if (!string.IsNullOrEmpty(addSkill))
                    //{
                    //    var skill = new Skill
                    //    {
                    //        Description = addSkill,
                    //    };
                    //    Skill addedSkill = skillRepository.Insert(skill);
                    //    skillRepository.Save();
                    //    var employeeSkill = new EmployeeSkill
                    //    {
                    //        EmployeeId = employee.EmployeeId,
                    //        SkillId = addedSkill.SkillId
                    //    };
                    //    employeeSkillRepository.Insert(employeeSkill);
                    //    employeeSkillRepository.Save();
                    //}                    
                    employeeRepository.Update(employee);
                    //return RedirectToAction("Edit", new { id = employee.EmployeeId });
                }
                employeeRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["Action"] = action;
                return View("Form", employee);
            }
        }

        public IActionResult AddNewSkill(string action, Employee employee, string? addSkill)
        {

            if (!string.IsNullOrEmpty(addSkill))
            {
                var skill = new Skill
                {
                    Description = addSkill,
                };
                Skill addedSkill = skillRepository.Insert(skill);
                skillRepository.Save();
                var employeeSkill = new EmployeeSkill
                {
                    EmployeeId = employee.EmployeeId,
                    SkillId = addedSkill.SkillId
                };
                employeeSkillRepository.Insert(employeeSkill);
                employeeSkillRepository.Save();
            }
            return RedirectToAction("Edit", new { id = employee.EmployeeId });
        }
    }
}