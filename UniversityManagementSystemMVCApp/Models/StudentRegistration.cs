using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemMVCApp.Models
{
    public class StudentRegistration
    {
        [Key]
        [DisplayName("Student Registration Number")]

        public int  StudentRegistrationId { get; set; }
        [DisplayName("Name")]
        [StringLength(35)]
        [Required(ErrorMessage = "Name is required")]
  
        public string Name { get; set; }
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(35)]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [DisplayName("Contact No")]
        [StringLength(35)]
        [Required(ErrorMessage = "Contact No is required")]
        public string Contact { get; set; }
        [DisplayName("Registration Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RegistrationDate { get; set; }
        [DisplayName("Address")]
        [StringLength(35)]
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Department is needed")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public string RegistrationNumber { get; set; }

        public virtual EnrollCourse EnrollCourse { get; set; }
    }
}