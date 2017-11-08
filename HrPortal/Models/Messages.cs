using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public class Messages:BaseEntity
    {
        [Display(Name ="Gönderen Adı")]
        [StringLength(200)]
        public string SenderName { get; set; }
        [Display(Name = "Gönderen Email")]
        [StringLength(200)]
        public string SenderEmail { get; set; }
        [Display(Name = "Gönderen Telefon")]
        [StringLength(200)]
        public string  SenderPhone { get; set; }
        [Display(Name = "Mesaj")]
        [StringLength(4000)]
        public string Message { get; set; }
       


    }
}
