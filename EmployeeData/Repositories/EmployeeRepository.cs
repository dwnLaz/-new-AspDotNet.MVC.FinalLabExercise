using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeData.Models;
using EmployeeData.Data;
using EmployeeData.DataObjectTransfer;

namespace EmployeeData.Repositories
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        public IEnumerable<EmployeeSkillDTO> GetSkills(int id);
    }

    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeDbContext context) : base(context)
        {

        }

        public IEnumerable<EmployeeSkillDTO> GetSkills(int id)
        {
            var skills = this.Context.EmployeeSkills.Join(
                this.Context.Skills,
                e => e.SkillId,
                s => s.SkillId,
                (e, s) => new EmployeeSkillDTO
                {
                    EmployeeId = e.EmployeeId,
                    SkillId = s.SkillId,
                    Description = s.Description
                }
                ).Where(e => e.EmployeeId.Equals(id)).ToList();
            return skills;
        }
    }
}
