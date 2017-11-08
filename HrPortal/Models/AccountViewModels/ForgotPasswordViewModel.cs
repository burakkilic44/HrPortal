using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage ="Lüften Geçerli Bir Mail Adresi giriniz!")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
