using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemMVCApp.Models
{
    public class ResultEntry
    {
        [Key]
        public int ResultEntryId { get; set; }

        public int StudentRegistrationId { get; set; }
        public virtual StudentRegistration StudentRegistration { get; set; }

        public string Name { set; get; }

        [Required]
         [DataType(DataType.EmailAddress)]
        public string Email { set; get; }

        public string Department { set; get; }

        [Required(ErrorMessage = "Course is needed")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        [Required(ErrorMessage = "Grade is needed")]
        public int GradeId { get; set; }
        public virtual Grade Grade { get; set; }
       
    }
}