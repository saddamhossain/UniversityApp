using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemMVCApp.Models
{
    public class ResultEntryView
    {
        [Key]
        public int ViewResultId { get; set; }

        public int StudentRegistrationId { get; set; }


        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }

        public virtual StudentRegistration StudentRegistration { get; set; }
    }
}