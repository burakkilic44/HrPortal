using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrPortal.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [StringLength(200)]
        [Display(Name = "Ad")]
        public string FirstName { get; set; }
        [StringLength(200)]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }
        [StringLength(200)]
        [Display(Name = "Fotoğraf")]
        public string Photo { get; set; }
        [Display(Name = "Meslek")]
        public string OccupationId { get; set; }
        [Display(Name = "Meslek")]
        [ForeignKey("OccupationId")]
        public Occupation Occupation { get; set; }
        [Display(Name = "Konum")]
        public string LocationId { get; set; }
        [ForeignKey("LocationId")]
        [Display(Name = "Konum")]
        public Location Location { get; set; }
        [Display(Name = "İşveren Mi?")]
        public bool IsEmployer { get; set; }
        [StringLength(200)]
        [Display(Name = "Firma Adı")]
        public string CompanyName { get; set; }
        [Display(Name = "Onaylandı Mı?")]
        public bool IsApproved { get; set; }
        [Display(Name = "Onay Tarihi")]
        public DateTime? ApproveDate { get; set; }
        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; }
        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime CreateDate { get; set; }
        [Display(Name = "Güncellenme Tarihi")]
        public DateTime UpdateDate { get; set; }
        
    }
}
