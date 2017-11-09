using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public class Skill:BaseEntity
    {

        [Required(ErrorMessage = "Ad alanı gereklidir")]
        [StringLength(200)]
        [Display(Name = "Ad")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Seviye alanı gereklidir")]
        [Display(Name = "Seviye")]
        public int Level { get; set; }
        [Display(Name = "Özgeçmiş")]
        public string ResumeId { get; set; }
        [ForeignKey("ResumeId")]
        [Display(Name = "Özgeçmiş")]
        public Resume Resume { get; set; }

    }
}
