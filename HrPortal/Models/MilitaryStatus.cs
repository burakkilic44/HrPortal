using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public enum MilitaryStatus
    {
        [Display(Name="Yapıldı")]
        Completed = 1,
        [Display(Name = "Muaf")]
        Exempt = 2,
        [Display(Name = "Tecilli")]
        Postponed = 3,
        [Display(Name = "Yok")]
        NA = 4
    }

}