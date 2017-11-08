using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public class JobLocation
    {
        public string JobId { get; set; }
        public Job Job { get; set; }

        public string LocationId { get; set; }
        public Location Location { get; set; }

    }
}
