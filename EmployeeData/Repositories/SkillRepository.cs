using EmployeeData.Data;
using EmployeeData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeData.Repositories
{
    public interface ISkillRepository : IBaseRepository<Skill>
    {
    }
    public class SkillRepository : GenericRepository<Skill>, ISkillRepository
    {
        public SkillRepository(EmployeeDbContext context) : base(context)
        {
        }
    }
}
