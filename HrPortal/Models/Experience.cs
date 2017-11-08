using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public class Experience:BaseEntity
    {
        [StringLength(200)]
        public string CompanyName { get; set; }
        [StringLength(200)]
        public string Position { get; set; }
        public int StartYear { get; set; }
        public int? EndYear { get; set; }
        [StringLength(4000)]
        public string Notes { get; set; }
        [StringLength(200)]
        public string Photos { get; set; }
        public string ResumeId { get; set; }
        public Resume Resume { get; set; }

    }
}
