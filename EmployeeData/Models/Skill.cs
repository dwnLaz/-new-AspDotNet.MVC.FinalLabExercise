using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EmployeeData.Models
{
    public partial class Skill
    {
        public Skill()
        {
            EmployeeSkills = new HashSet<EmployeeSkill>();
        }

        [Key]
        [Column("SkillID")]
        public int SkillId { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        public bool RequiresTicket { get; set; }

        [InverseProperty(nameof(EmployeeSkill.Skill))]
        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }
    }
}
