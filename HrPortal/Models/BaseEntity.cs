using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdatedBy { get; set; }

    }

    
}
