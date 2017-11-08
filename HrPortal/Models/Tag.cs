using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public class Tag:BaseEntity
    
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        public ICollection<ResumeTag> ResumeTags { get; set; }
    }
}
