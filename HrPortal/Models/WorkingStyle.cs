using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public enum WorkingStyle 
    {
        [Display(Name = "Tam Zamanlı")]
        FullTime = 1,
        [Display(Name = "Yarı Zamanlı")]
        PartTime = 2,
        [Display(Name = "Dönemsel/Proje Bazlı")]
        Seasonal = 3,
        [Display(Name = "Stajyer")]
        Intern = 4,
        [Display(Name = "Serbest Zamanlı")]
        Freelance = 5
    }
  
}
