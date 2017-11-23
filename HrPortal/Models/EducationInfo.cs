using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public class EducationInfo:BaseEntity
    {
       public EducationInfo():base()
        {
            StartDate= DateTime.Now;
            EndDate = DateTime.Now;
        }
        [Required(ErrorMessage = "Eğitim Seviyesi alanı gereklidir.")]
        [Display(Name = "Eğitim Seviyesi")]
        public EducationLevel EducationLevel{ get; set; }
        [Required(ErrorMessage = "Bölüm alanı gereklidir")]
        [StringLength(200)]
        [Display(Name = "Bölüm")]
        public string Department { get; set; }
        [Required(ErrorMessage = "Okul Adı alanı  gereklidir")]
        [StringLength(200)]
        [Display(Name = "Okul Adı")]
        public string SchoolName { get; set; }
        [Display(Name = "Başlangıç Tarihi")]
        public DateTime? StartDate { get; set; }
        [Display(Name = "Bitiş Tarihi")]
        public DateTime? EndDate { get; set; }
        [Display(Name = "Notlar")]
        [StringLength(4000)]
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
