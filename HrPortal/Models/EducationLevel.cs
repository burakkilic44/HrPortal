using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public enum EducationLevel
    {
        [Display(Name = "Ön Lisans")]
        Associate=1,
        [Display(Name = "Lisans")]
        Bachelor =2,
        [Display(Name = "Yüksek Lisans")]
        Master =3,
        [Display(Name = "Doktora")]
        Doctorate =4
    }
}
