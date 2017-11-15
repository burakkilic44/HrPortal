using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace HrPortal.Models.ManageViewModels
{
    public class IndexViewModel

    {
        [Display(Name = "Fotoğraf")]
        public string Photo { get; set; }


        [Display(Name ="Kullanıcı Adı")]
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }
        [Required (ErrorMessage ="Ad alanı gereklidir.")]
        [Display(Name = "Ad")]
        public String FirstName { get; set; }
        [Required(ErrorMessage = "Soyad alanı gereklidir.")]
        [Display(Name = "Soyad")]
        public String LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Telefon Numarası")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }
       
    }
}
