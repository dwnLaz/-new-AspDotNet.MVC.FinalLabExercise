using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

#nullable disable

namespace EmployeeData.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeSkills = new HashSet<EmployeeSkill>();
        }

        [Key]
        [Column("EmployeeID")]
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name length must not exceed 50 characters")]
        [MinLength(2, ErrorMessage = "First Name should contain atleast 2 characters")]
        [RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "First name must not contain special characters")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Last name length must not exceed 50 characters")]
        [MinLength(2, ErrorMessage = "Last Name should contain atleast 2 characters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last name must not contain special characters")]
        public string LastName { get; set; }
        [Required]
        [StringLength(12, ErrorMessage = "Phone must not exceed 12 characters")]
        [RegularExpression("([0-9 ]+)", ErrorMessage = "Phone must only contain numbers")]
        public string HomePhone { get; set; }
        public bool Active { get; set; }

        [InverseProperty(nameof(EmployeeSkill.Employee))]
        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }
    }
}
