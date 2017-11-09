using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public class Language:BaseEntity
    {
        [Required(ErrorMessage = "Ad alanı gereklidir")]
        [StringLength(200)]
        [Display(Name = "Ad")]
        public string Name { get; set; }
        [Display(Name = "Dil Bilgisi")]
        public ICollection<LanguageInfo> LanguageInfos { get; set; }
    }
}
