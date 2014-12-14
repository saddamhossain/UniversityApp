using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemMVCApp.Models
{
    public class Grade
    {
        [Key]
        public int GradeId { get; set; }
        [DisplayName("Grade")]
        public string GradeDescription { get; set; }
    }
}