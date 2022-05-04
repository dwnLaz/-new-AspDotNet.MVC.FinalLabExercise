using System;
using System.Linq;
using EmployeeData.Data;
using EmployeeData.Models;
using EmployeeData.Repositories;
using EmployeeWeb.Models;

namespace EmployeeWeb.Services
{
    public interface IEmployeeService
    {
        public PagedResult<Employee> GetEmployeePage(int currentPage);
    }

    public class EmployeeService : GenericService, IEmployeeService
    {
        private IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, EmployeeDbContext context) : base(context)
        {
            this.employeeRepository = employeeRepository;
        }

        public PagedResult<Employee> GetEmployeePage(int currentPage)
        {
            return GetPaged<Employee>(employeeRepository.Context.Employees.Where(e => e.Active.Equals(true)), currentPage, 10);
        }
    }
}
