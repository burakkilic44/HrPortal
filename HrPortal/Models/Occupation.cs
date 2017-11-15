using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public class Occupation:BaseEntity
    {
        [Required(ErrorMessage = "Ad alanı gereklidir")]
        [Display(Name = "Ad")]
        [StringLength(200)]
        public string Name { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
        public ICollection<Resume> Resumes { get; set; }
        public ICollection<Job> Jobs { get; set; }
    }
}
