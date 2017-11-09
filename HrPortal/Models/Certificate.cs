using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public class Certificate:BaseEntity
    {
        [Display(Name="Ad")]
        [Required(ErrorMessage ="Ad alanı gereklidir")]
        [StringLength(200)]
        public string Name { get; set; }
        [Required(ErrorMessage ="Alındığı Kurum alanı gereklidir")]
        [StringLength(200)]
        [Display(Name = "Alındığı Kurum")]
        public string Issuer { get; set; }
        [Required(ErrorMessage = "Alındığı Tarih alanı gereklidir")]
        [Display(Name = "Alındığı Tarih")]
        public DateTime IssueDate { get; set; }
        [StringLength(200)]
        [Display(Name = "Sertifika Dosyası")]
        public string CertificateFile { get; set; }
        [Display(Name = "Özgeçmiş")]
        public string ResumeId { get; set; }
        [Display(Name = "Özgeçmiş")]
        [ForeignKey("ResumeId")]
        public Resume Resume { get; set; }
    }
}
