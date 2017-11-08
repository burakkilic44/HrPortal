using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Mail Alanı Gereklidir!")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage ="Şifre Alanı Gereklidir!")]
        [DataType(DataType.Password)]
        [Display(Name ="Şifre")]
        public string Password { get; set; }

        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
