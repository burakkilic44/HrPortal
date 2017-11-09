using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required (ErrorMessage = "Ad Alanı Gereklidir!")]
        [StringLength(200)]
        [Display(Name = "Ad")]
        public string FirstName { get; set; }


        [Required (ErrorMessage = "Soyad Alanı Gereklidir!")]
        [StringLength(200)]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }
       
        
        
        [Display(Name = "İşveren misiniz?")]
        public bool IsEmployer { get; set; }

        
        [Display(Name = "Firma Adı")]
        [StringLength(200)]
        public string CompanyName { get; set; }
        
        
        [Required (ErrorMessage = "Mail Alanı Gereklidir!")]
        [StringLength(200)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required ]
        [StringLength(100,ErrorMessage = "Şifre  en az {2} karakter olmalıdır.",MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Şifre Doğrula")]
        [Compare("Password", ErrorMessage = "Şifreler eşleştirilemedi !")]
        public string ConfirmPassword { get; set; }
    }
}
