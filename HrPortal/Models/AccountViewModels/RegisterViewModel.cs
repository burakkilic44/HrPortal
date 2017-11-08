using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(30)]
        [Display(Name = "Ad")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [Display(Name = "Herhangi Bir Firmada Çalışıyor musunuz?")]
        public bool IsCompany { get; set; }


        [Display(Name = "Firma Adı")]
        public string CompanyName { get; set; }



        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "  Şifre {0} en az {2} karakter olmalıdır.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = " password")]
        [Compare("Password", ErrorMessage = "Şifreler eşleştirilemedi !")]
        public string ConfirmPassword { get; set; }
    }
}