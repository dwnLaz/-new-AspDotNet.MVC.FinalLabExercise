using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EmployeeData.Models
{
    [Index(nameof(EmployeeId), Name = "IX_EmployeeSkills_EmployeeID")]
    [Index(nameof(SkillId), Name = "IX_EmployeeSkills_SkillID")]
    public partial class EmployeeSkill
    {
        [Key]
        [Column("EmployeeSkillID")]
        public int EmployeeSkillId { get; set; }
        [Column("EmployeeID")]
        public int EmployeeId { get; set; }
        [Column("SkillID")]
        public int SkillId { get; set; }
        public int Level { get; set; }
        public int? YearsOfExperience { get; set; }
        [Column(TypeName = "money")]
        public decimal HourlyWage { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty("EmployeeSkills")]
        public virtual Employee Employee { get; set; }
        [ForeignKey(nameof(SkillId))]
        [InverseProperty("EmployeeSkills")]
        public virtual Skill Skill { get; set; }
    }
}
