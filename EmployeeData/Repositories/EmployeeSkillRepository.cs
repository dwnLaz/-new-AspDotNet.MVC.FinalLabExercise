using EmployeeData.Data;
using EmployeeData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeData.Repositories
{
    public interface IEmployeeSkillRepository : IBaseRepository<EmployeeSkill>
    {
    }
    public class EmployeeSkillRepository : GenericRepository<EmployeeSkill>, IEmployeeSkillRepository
    {
        public EmployeeSkillRepository(EmployeeDbContext context) : base(context)
        {
        }
    }
}
