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
        [Required (ErrorMessage="Ad alanı gereklidir.")]
        [Display(Name="Ad")]
        public string Name { get; set; }
        [Display(Name = "Üst Konum")]
        public string ParentLocationId { get; set; }
        [Display(Name = "Üst Konum")]
        [ForeignKey("ParentLocationId")]
        public Location ParentLocation { get; set; }
        public ICollection<JobLocation> JobLocations { get; set; }
    }
}
