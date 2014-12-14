using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemMVCApp.Models
{
    public class Designation
    {
        [Key]
        public int DesignationId { get; set; }
        [DisplayName("Designation")]
        [StringLength(35)]
        [Required(ErrorMessage = "Designation is required")]
        public string DesignationType { get; set; }
    }
}