using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public class ResumeTag
    {
        public string ResumeId { get; set; }
        public Resume Resume { get; set; }
        public string TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
