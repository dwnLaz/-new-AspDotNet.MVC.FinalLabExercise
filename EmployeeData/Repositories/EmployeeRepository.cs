using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeData.Models;
using EmployeeData.Data;

namespace EmployeeData.Repositories
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {

    }

    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeDbContext context) : base(context)
        {

        }
    }
}
