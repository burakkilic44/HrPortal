using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public class Experience:BaseEntity
    {
        [Required(ErrorMessage = "Firma Adı alanı gereklidir")]
        [StringLength(200)]
        [Display(Name = "Firma Adı")]
        public string CompanyName { get; set; }
        [StringLength(200)]
        [Display(Name = "Pozisyon")]
        [Required(ErrorMessage = "Pozisyon alanı gereklidir")]
        public string Position { get; set; }
        [Required(ErrorMessage = "Başlangıç Yılı alanı gereklidir")]
        [Display(Name = "Başlangıç Yılı")]
        public int StartYear { get; set; }
        [Display(Name = "Bitiş Yılı")]
        public int? EndYear { get; set; }
        [StringLength(4000)]
        [Display(Name = "Notlar")]
        public string Notes { get; set; }
        [StringLength(200)]
        [Display(Name = "Fotoğraf")]
        public string Photo { get; set; }
        [Display(Name = "Özgeçmiş")]
        public string ResumeId { get; set; }
        [Display(Name = "Özgeçmiş")]
        [ForeignKey("ResumeId")]
        public Resume Resume { get; set; }

    }
}
