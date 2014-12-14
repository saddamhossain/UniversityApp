using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemMVCApp.Models
{
    public class EnrollCourse
    {
        [Key]
        public int EnrollCourseId { get; set; }
        [DisplayName("Student Reg No")]
        [Required(ErrorMessage = "Student Registration Number is required")]
        public int StudentRegistrationId { get; set; }
        public virtual StudentRegistration StudentRegistration { get; set; }
        [DisplayName("Name")]
        [Required(ErrorMessage = "Name is required")]

        public string Name { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Department Name")]
        [Required(ErrorMessage = "Department Name is required")]
        public string Department { get; set; }
        [DisplayName("Select Course")]
        [Required(ErrorMessage = "Select Course is required")]
        public int CourseId { get; set; }
        public virtual List<Course>Courses  { get; set; }

        public virtual Course Course { get; set; }
        public IList<StudentRegistration> StudentRegistrations { get; set; }
        [DisplayName("Enrollment Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EnrollDate { get; set; }

    }
}