using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public enum SmokingStatus
    {
        [Display(Name = "Kullanıyorum")]
        Yes =1,
        [Display(Name = "Mesai Saatleri Dışında Kullanıyorum")]
        OutOfWork =2,
        [Display(Name = "Kullanmıyorum")]
        No = 3
    }
}
