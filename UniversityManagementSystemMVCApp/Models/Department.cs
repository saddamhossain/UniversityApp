using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityManagementSystemMVCApp.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [DisplayName("Department Code")]
        [StringLength(35)]
        [Required(ErrorMessage = "Department Code is required")]
        [Remote("CheckDepartmentCode","Departments",ErrorMessage = "This Code already exits in System")]
        public string Code { get; set; }
        [DisplayName("Department Name")]
        [StringLength(60)]
        [Required(ErrorMessage = "Department Name is required")]
        [Remote("CheckDepartmentName", "Departments", ErrorMessage = "This Name already exits in System")]
        public string Name { get; set; }
    }
}