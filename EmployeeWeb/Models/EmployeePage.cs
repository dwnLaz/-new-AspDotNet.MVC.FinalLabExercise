using EmployeeData.Models;
using System;
using System.Collections.Generic;

namespace EmployeeWeb.Models
{
    public class EmployeePage
    {
        public List<Employee> EmployeeList { get; set; }

        public int CurrentPageIndex { get; set; }

        public int PageCount { get; set; }
    }
}
