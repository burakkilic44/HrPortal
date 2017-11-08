using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public class Location:BaseEntity
    {       
        [StringLength(200)]
        [Required (ErrorMessage="İsim alanı gereklidir.")]
        [Display(Name="İsim")]
        public string Name { get; set; }
        public string ParentLocationId { get; set; }
        [ForeignKey("ParentLocationId")]
        [Display(Name = "Ana Konum")]
        public Location ParentLocation { get; set; }
    }
}
