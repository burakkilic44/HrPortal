using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public class Message:BaseEntity
    {
        [Required]
        [Display(Name ="Gönderen Adı")]
        [StringLength(200)]
        public string SenderName { get; set; }

        [Required]
        [Display(Name = "Gönderen Email")]
        [StringLength(200)]
        public string SenderEmail { get; set; }

        [Required]
        [Display(Name = "Gönderen Telefon")]
        [StringLength(200)]
        public string  SenderPhone { get; set; }

        [Required]
        [Display(Name = "Mesaj")]
        [StringLength(4000)]
        public string Message { get; set; }
       


    }
}
