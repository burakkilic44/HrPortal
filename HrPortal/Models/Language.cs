using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public class Language:BaseEntity
    {
        [StringLength(200)]
        public string Name { get; set; }
        public ICollection<LanguageInfo> LanguageInfos { get; set; }
    }
}
