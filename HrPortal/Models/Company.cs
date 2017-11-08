using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "LocationId")]
        public string LocationId { get; set; }
        public Location Location { get; set; }

        public EmployeeCount EmployeeCount { get; set; }


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

        [Display(Name = "GooglePlus")]
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

        [Display(Name = "Linkedin")]
        [StringLength(200)]
        public string Linkedin { get; set; }

        [Display(Name = "Hakkımızda")]
        public string About { get; set; }

        [Display(Name = "IsApproved")]
        public bool IsApproved { get; set; }

        [Display(Name = "Onay Tarihi")]
        public DateTime? ApproveDate { get; set; }

        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }



    }
}
