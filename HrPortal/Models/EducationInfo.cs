using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public class EducationInfo:BaseEntity
    {
        public EducationLevel EducationLevel{ get; set; }
        [Required]
        [StringLength(200)]
        public string Department { get; set; }
        [Required]
        [StringLength(200)]
        public string SchoolName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [StringLength(4000)]
        public string Notes { get; set; }
        [StringLength(200)]
        public string Photo { get; set; }
        public string ResumeId { get; set; }
        public Resume Resume { get; set; }
    }
}
