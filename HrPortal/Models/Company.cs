using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public class Company:BaseEntity
    {

        [Required]
        [Display(Name = "Ad")]
        [StringLength(200)]
        public string Name { get; set; }
       
        [Display(Name = "Başlık")]
        [StringLength(200)]
        public string Title { get; set; }

        [Display(Name = "Açıklama")]
        [StringLength(4000)]
        public string ShortDescription { get; set; }

        [Display(Name = "Fotoğraf")]
        [StringLength(200)]
        public string Photo { get; set; }

        [Display(Name = "Konum")]
        public string LocationId { get; set; }
        [ForeignKey("LocationId")]
        public Location Location { get; set; }
        [Display(Name="Çalışan Sayısı")]
        public EmployeeCount EmployeeCount { get; set; }
        [Display(Name = "Sektör")]
        public string SectorId { get; set; }
        [Display(Name = "Sektör")]
        [ForeignKey("SectorId")]
        public Sector Sector { get; set; }

        [Display(Name = "Web Adresi")]
        [StringLength(200)]
        public string WebAddress { get; set; }

        [Display(Name = "Kuruluş Yılı")]
        public int? EstablishYear { get; set; }

        [Display(Name = "Telefon")]
        [StringLength(200)]
        public string Phone { get; set; }

        [Display(Name = "Mail Adresi")]
        [StringLength(200)]
        public string Email { get; set; }

        [Display(Name = "Facebook")]
        [StringLength(200)]
        public string Facebook { get; set; }

        [Display(Name = "Twitter")]
        [StringLength(200)]
        public string Twitter { get; set; }

        [Display(Name = "Google+")]
        [StringLength(200)]
        public string GooglePlus { get; set; }

        [Display(Name = "Dribbble")]
        [StringLength(200)]
        public string Dribbble { get; set; }

        [Display(Name = "Pinterest")]
        [StringLength(200)]
        public string Pinterest { get; set; }

        [Display(Name = "GitHub")]
        [StringLength(200)]
        public string GitHub { get; set; }

        [Display(Name = "Instagram")]
        [StringLength(200)]
        public string Instagram { get; set; }

        [Display(Name = "YouTube")]
        [StringLength(200)]
        public string YouTube { get; set; }

        [Display(Name = "LinkedIn")]
        [StringLength(200)]
        public string Linkedin { get; set; }

        [Display(Name = "Hakkımızda")]
        public string About { get; set; }

        [Display(Name = "Onaylandı Mı?")]
        public bool IsApproved { get; set; }

        [Display(Name = "Onay Tarihi")]
        public DateTime? ApproveDate { get; set; }

        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; }
        [Display(Name = "Gizli Mi?")]
        public bool IsHidden { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }

        [NotMapped]
        [DataType(DataType.Upload)]
        public IFormFile AvatarImage { get; set; }

    }
}
