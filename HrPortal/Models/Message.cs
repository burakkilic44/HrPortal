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
        [Display(Name = "Gönderen Kullanıcı")]
        public string From { get; set; }
        [Display(Name = "Alıcı Kullanıcı")]
        public string To { get; set; }

        [Display(Name = "Gönderen Firma")]
        public string FromCompanyId { get; set; }
        [Display(Name = "Gönderen Firma")]
        [ForeignKey("FromCompanyId")]
        public Company FromCompany { get; set; }
        [Display(Name = "Alıcı Firma")]
        public string ToCompanyId { get; set; }
        [Display(Name = "Alıcı Firma")]
        [ForeignKey("ToCompanyId")]
        public Company ToCompany { get; set; }

        [Display(Name = "Gönderen Özgeçmiş")]
        public string FromResumeId { get; set; }
        [Display(Name = "Gönderen Özgeçmiş")]
        [ForeignKey("FromResumeId")]
        public Resume FromResume { get; set; }
        [Display(Name = "Alıcı Özgeçmiş")]
        public string ToResumeId { get; set; }
        [Display(Name = "Alıcı Özgeçmiş")]
        [ForeignKey("ToResumeId")]
        public Resume ToResume { get; set; }

        [StringLength(200)]
        [Display(Name = "Konu")]
        public string Subject { get; set; }

        [Display(Name = "İçerik")]
        public string Body { get; set; }

        [Display(Name = "Okundu mu?")]
        public bool IsRead { get; set; }
        [Display(Name = "Okunma Tarihi")]
        public DateTime ReadDate { get; set; }

        public DateTime SendDate { get; set; }       
    }
}
