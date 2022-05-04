using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeData.DataObjectTransfer
{
    public class EmployeeSkillDTO
    {
        public int EmployeeSkillId { get; set; }
        public int EmployeeId { get; set; }
        public int SkillId { get; set; }
        public string Description { get; set; }
    }
}
