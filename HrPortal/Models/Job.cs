using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public class Job:BaseEntity
    {

        [StringLength(200)]
        [Required(ErrorMessage = "Başlık alanı gereklidir")]
        [Display(Name ="Başlık")]
        public string Title { get; set; }

        
        public string CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        [StringLength(4000)]
        [Display(Name ="Kısa Açıklama")]
        public string ShortDescription { get; set; }

        [StringLength(200)]
        [Display(Name ="Web Adresi")]
        public string WebAddress { get; set; }

        public ICollection <JobLocation> JobLocations { get; set; }

        public WorkingStyle WorkingStyle { get; set; }

        [Display(Name ="Çalışma Saati")]
        public int? WorkingHours { get; set; }

        [Display(Name = "Tecrübe")]
        public int? Experience { get; set; }

        [Display(Name = "Askerlik Durumu")]
        public MilitaryStatus MilitaryStatus { get; set; }

        [Display(Name = "Eğitim Seviyesi")]
        public EducationLevel EducationLevel { get; set; }

        [Display(Name = "İlan Detayı")]
        [Required(ErrorMessage = "Bu alan gereklidir")]
        public string Details { get; set; }

    }
}
