using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public class Audit:BaseEntity
    {
        [StringLength(200)]
        public string EntityId { get; set; }
        [StringLength(200)]
        [Display(Name = "Alan")]
        public string Area { get; set; }
        [StringLength(200)]
        public string Controller { get; set; }
        [StringLength(200)]
        [Display(Name = "Hareket")]
        public string Action { get; set; }
        public string Url { get; set; }
        [Display(Name = "Eski Değer")]
        public string OldValue { get; set; }
        [Display(Name = "Yeni Değer")]
        public string NewValue { get; set; }
        [StringLength(200)]
        public string Ip { get; set; }
        [Display(Name = "Tarayıcı")]
        public string UserAgent { get; set; }
        [StringLength(200)]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }
    }
}
