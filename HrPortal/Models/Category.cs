using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public class Category:BaseEntity
    {
        [StringLength(200)]
        [Required(ErrorMessage ="Kategori alanı gereklidir")]
        [Display(Name = "Kategori Adı")]
        public string Name { get; set; }
    }
}
