using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public class Feedback:BaseEntity
    {
        [Required(ErrorMessage = "Tam Ad alanı gereklidir")]
        [Display(Name ="Tam Ad")]
        [StringLength(200)]
        public string SenderName { get; set; }

        [Required(ErrorMessage = "E-posta alanı gereklidir")]
        [Display(Name = "E-posta")]
        [StringLength(200)]
        public string SenderEmail { get; set; }

        [Required(ErrorMessage = "Telefon alanı gereklidir")]
        [Display(Name = "Telefon")]
        [StringLength(200)]
        public string  SenderPhone { get; set; }

        [Required(ErrorMessage = "Mesaj alanı gereklidir")]
        [Display(Name = "Mesaj")]
        [StringLength(4000)]
        public string Content { get; set; }
       
    }
}
