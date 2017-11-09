using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public enum EmployeeCount
    { 
        [Display(Name = "0-9")]
        ZeroToNine  = 1,
        [Display(Name = "10-99")]
        TenToNinetyNine = 2,
        [Display(Name = "100-999")]
        OneHundredToNineHundredsNinetyNine = 3,
        [Display(Name = "1000-9999")]
        OneThousandToNineThousandsNineHundredsNinetyNine = 4,
        [Display(Name = "10000-99999")]
        TenThousandsToNineThousandsNineHundredsNinetyNine = 5,
        [Display(Name = "100000-999999")]
        OneHundredThousandsToNineHundredsNinetyNineThousandsNineHundredsNinetyNine = 6
    }
}
