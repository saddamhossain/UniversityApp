using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemMVCApp.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        [DisplayName("Teacher Name")]
        [StringLength(35)]
        [Required(ErrorMessage = "Teacher Name  is required")]
        public string Name { get; set; }
        
        [StringLength(35)]
        [Required(ErrorMessage = "Address  is required")]
        public string Address { get; set; }
        [StringLength(35)]
        [Required(ErrorMessage = "Email  is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [StringLength(35)]
        [Required(ErrorMessage = "Contact No  is required")]
        public string ContactNo { get; set; }
        [DisplayName("Credit To Be Taken")]
        [Required(ErrorMessage = "Credit is required")]
        public string CreditToBeTaken { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public int DesignationId { get; set; }
        public virtual Designation Designation { get; set; }

    }
}