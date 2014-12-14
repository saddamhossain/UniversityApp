using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityManagementSystemMVCApp.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [DisplayName("Course Code")]
        [StringLength(35)]
        [Required(ErrorMessage = "Course Code is required")]
        [Remote("CheckCourseCode", "Courses", ErrorMessage = "This Code already exits in System")]
        public string Code { get; set; }
        [DisplayName("Credit")]
        [StringLength(35)]
        [Required(ErrorMessage = "Credit is required")]
        
        public string Credit { get; set; }
        [DisplayName("Course Name")]
        [StringLength(50)]
        [Required(ErrorMessage = "Course Name is required")]
        public string Name { get; set; }
        [DisplayName("Course Description")]
        [StringLength(50)]
        [Required(ErrorMessage = "Course Description is required")]
        [Remote("CheckCourseName", "Courses", ErrorMessage = "This Name already exits in System")]
        public string Description { get; set; }

        [DisplayName("Department")]

        [Required(ErrorMessage = "Department is required")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        [DisplayName("Semester")]
      
        [Required(ErrorMessage = "Semester is required")]
        public int SemesterId { get; set; }
        public virtual Semester Semester{ get; set; }

        public virtual String AssignTo { get; set; }

        //public virtual CourseAssign CourseAssign { set; get; }

    }
}