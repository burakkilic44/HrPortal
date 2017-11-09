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
        [StringLength(100, ErrorMessage = "Şifre {0} en az  {2} en fazla {1} karakter uzunluğunda olmalıdır.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Yeni Şifre")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Yeni Şifreyi Doğrula")]
        [Compare("NewPassword", ErrorMessage = "Yeni şifre ve onay şifresi uyuşmuyor.")]
        public string ConfirmPassword { get; set; }

        public string StatusMessage { get; set; }
    }
}
