using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models.ManageViewModels
{
    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage ="Şifre en az {2} karakter olmalıdır.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Yeni Şifre")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Şifre Doğrula")]
        [Compare("NewPassword", ErrorMessage = "Şifreler eşleştirilemedi!")]
        public string ConfirmPassword { get; set; }

        public string StatusMessage { get; set; }
    }
}
