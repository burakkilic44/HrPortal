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
        [Required]
        public string Name { get; set; }
        public string ParentLocationId { get; set; }
        [ForeignKey("ParentLocationId")]
        public Location ParentLocation { get; set; }
    }
}
