using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public class Sector:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Company> Companies { get; set; }
    }
}
