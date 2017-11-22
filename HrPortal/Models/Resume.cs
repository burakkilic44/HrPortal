using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public class Resume:BaseEntity
    {
        public Resume() : base()
        {
            EducationInfos = new HashSet<EducationInfo>();
            Experiences = new HashSet<Experience>();
            Skills = new HashSet<Skill>();
            Certificates = new HashSet<Certificate>();
            LanguageInfos = new HashSet<LanguageInfo>();
            BirthDate = DateTime.Now;

        }
        [Required(ErrorMessage = "CV adı gereklidir.")]
        [StringLength(200)]
        [Display(Name = "CV Adı")]
        public string ResumeName { get; set; }
        [Required(ErrorMessage = "Ad Soyad alanı gereklidir")]
        [StringLength(200)]
        [Display(Name = "Ad Soyad")]
        public string FullName { get; set; }
        [StringLength(200)]
        [Display(Name = "Başlık")]
        public string Title { get; set; }
        [StringLength(200)]
        [Display(Name = "Fotoğraf")]
        public string Photo { get; set; }
        [StringLength(4000)]
        [Display(Name = "Notlar")]
        public string Notes { get; set; }
        [Display(Name = "Konum")]
        public string LocationId { get; set; }
        [Display(Name = "Konum")]
        [ForeignKey("LocationId")]
        public Location Location { get; set; }
        [StringLength(200)]
        [Display(Name = "Web Adresi")]
        public string WebAddress { get; set; }
        [Display(Name = "Doğum Tarihi")]
        public DateTime? BirthDate { get; set; }
        [Required(ErrorMessage = "Telefon alanı gereklidir")]
        [StringLength(200)]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "E-posta alanı gereklidir")]
        [StringLength(200)]
        [Display(Name = "E-posta")]
        public string Email { get; set; }
        [StringLength(4000)]
        [Display(Name = "Etiketler")]
        public string Tags { get; set; }
        [StringLength(200)]
        [Display(Name = "Özgeçmiş Dosyası")]
        public string ResumeFile { get; set; }
        [StringLength(200)]
        public string Facebook { get; set; }
        [StringLength(200)]
        public string Twitter { get; set; }
        [StringLength(200)]
        [Display(Name = "Google+")]
        public string GooglePlus { get; set; }
        [StringLength(200)]
        public string Dribbble { get; set; }
        [StringLength(200)]
        public string Pinterest { get; set; }
        [StringLength(200)]
        public string Github { get; set; }
        [StringLength(200)]
        public string Instagram { get; set; }
        [StringLength(200)]
        public string Youtube { get; set; }
        [StringLength(200)]
        public string LinkedIn { get; set; }
        [Display(Name = "Askerlik Durumu")]
        public MilitaryStatus MilitaryStatus { get; set; }
        [Display(Name = "Eğitim Bilgisi")]
        public ICollection<EducationInfo> EducationInfos { get; set; }
        [Display(Name = "Deneyim")]
        public ICollection<Experience> Experiences { get; set; }
        [Display(Name = "Yetkinlikler")]
        public ICollection<Skill> Skills { get; set; }
        [Display(Name = "Yabancı Dil Bilgisi")]
        public ICollection<LanguageInfo> LanguageInfos { get; set; }
        [Display(Name = "Sertifikalar")]
        public ICollection<Certificate> Certificates { get; set; }
        [Required(ErrorMessage = "Özgeçmiş Dili alanı  gereklidir")]
        [Display(Name = "Özgeçmiş Dili")]
        public string LanguageId { get; set; }
        [ForeignKey("LanguageId")]
        [Display(Name = "Özgeçmiş Dili")]
        public Language Language { get; set; }
        [Display(Name = "İlgi Alanları")]
        public string Hobbies { get; set; }
        [Display(Name = "Sigara Kullanımı")]
        public SmokingStatus SmokingStatus { get; set; }
        [Display(Name = "Ehliyet")]
        public string DrivingLicense { get; set; }
        [Display(Name = "Seyahat Engeli Var Mı?")]
        public bool IsTravelDisabled { get; set; }
        [Display(Name = "Onaylandı Mı?")]
        public bool IsApproved { get; set; }
        [Display(Name = "Onay Tarihi")]
        public DateTime? ApproveDate { get; set; }
        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; }
        [Display(Name = "Teşvikli Mi?")]
        public bool IsEncouraged { get; set; }
        [Display(Name = "Meslek")]
        public string OccupationId { get; set; }
        [Display(Name = "Meslek")]
        [ForeignKey("OccupationId")]
        public Occupation Occupation { get; set; }


        public ICollection<JobApplication> JobApplications { get; set; }




    }
}
