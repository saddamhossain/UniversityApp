using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemMVCApp.Models
{
    public class Semester
    {
        [Key]
        public int SemesterId { get; set; }
        [DisplayName("Semester Code")]
        [StringLength(50)]
        [Required(ErrorMessage = "Semester Code is required")]
        public string Code { get; set; }
    }
}