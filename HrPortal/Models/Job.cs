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
        [Required(ErrorMessage = "Firma alanı gereklidir")]
        [Display(Name = "Firma")]
        public string CompanyId { get; set; }
        [Display(Name = "Firma")]
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        [Display(Name = "Meslek")]
        public string OccupationId { get; set; }
        [Display(Name = "Meslek")]
        [ForeignKey("OccupationId")]
        public Occupation Occupation { get; set; }
        [StringLength(4000)]
        [Display(Name ="Kısa Açıklama")]
        public string ShortDescription { get; set; }

        [StringLength(200)]
        [Display(Name ="Web Adresi")]
        public string WebAddress { get; set; }
        [Display(Name = "İşin Konumu")]
        public ICollection <JobLocation> JobLocations { get; set; }
        [Display(Name = "Çalışma Şekli")]
        public WorkingStyle WorkingStyle { get; set; }

        [Display(Name ="Çalışma Saati")]
        public int WorkingHours { get; set; }

        [Display(Name = "Minimum Deneyim")]
        public int Experience { get; set; }

        [Display(Name = "Askerlik Durumu")]
        public MilitaryStatus MilitaryStatus { get; set; }

        [Display(Name = "Eğitim Seviyesi")]
        public EducationLevel EducationLevel { get; set; }

        [Display(Name = "İlan Detayı")]
        [Required(ErrorMessage = "Bu alan gereklidir")]
        public string Details { get; set; }

        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Bu alan gereklidir")]
        [Display(Name = "Yayın Tarihi")]
        public DateTime PublishDate { get; set; }

        [Display(Name = "Bitiş Tarihi")]
        public DateTime EndDate { get; set; }

        [NotMapped]
         public string[] LocationId { get; set; }
       

        public ICollection<JobApplication> JobApplications { get; set; }
    }
}
