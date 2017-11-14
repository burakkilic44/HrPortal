using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public class JobResume
    {
        public string JobId { get; set; }
        public Job Job { get; set; }

        public string ResumeId { get; set; }
        public Resume Resume { get; set; }
    }
}
