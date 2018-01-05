using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public class Message: BaseEntity
    {
        [Display(Name = "Firma")]
        public string CompanyId { get; set; }
        [Display(Name = "Firma")]
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        [Display(Name = "Kullanıcı")]
        public string ApplicationUserId { get; set; }
        [Display(Name = "Kullanıcı")]
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [StringLength(200)]
        [Display(Name = "Konu")]
        public string Subject { get; set; }

        [Display(Name = "İçerik")]
        public string Body { get; set; }

        [Display(Name = "Okundu mu?")]
        public bool IsRead { get; set; }
        [Display(Name = "Okunma Tarihi")]
        public DateTime ReadDate { get; set; }

        [Display(Name = "Özgeçmiş")]
        public string ResumeId { get; set; }
        [Display(Name = "Özgeçmiş")]
        [ForeignKey("ResumeId")]
        public Resume Resume { get; set; }

       
    }
}
