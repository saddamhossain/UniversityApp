using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemMVCApp.Models
{
    public class CourseAssign
    {
        [Key]
        public int CourseAssignId { get; set; }

        [Required(ErrorMessage = "Department is needed")]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        [Required(ErrorMessage = "Teacher is needed")]
        public string TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        public string CreditToBeTaken { get; set; }

        public string RemainingToBeTaken { get; set; }

        [Required(ErrorMessage = "Course is needed")]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        public string Name { get; set; }

        public string Credit { get; set; }

      
       
       
    }
}