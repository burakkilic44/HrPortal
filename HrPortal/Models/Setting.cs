using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public class Setting:BaseEntity
    {
        [Display(Name = "MapLat")]
        [StringLength(200)]
        public string MapLat { get; set; }
        [Display(Name = "MapLng")]
        [StringLength(200)]
        public string MapLng { get; set; }
        [Display(Name = "Adres")]
        [StringLength(200)]
        public string Address { get; set; }
        [Display(Name = "Telefon")]
        [StringLength(200)]
        public string Phone { get; set; }
        [Display(Name = "Faks")]
        [StringLength(200)]
        public string Fax { get; set; }
        [Display(Name = "Email")]
        [StringLength(200)]
        public string Email { get; set; }
        [Display(Name = "SmtpUserName")]
        [StringLength(200)]
        public string SmtpUserName { get; set; }
        [Display(Name = "SmtpPassword")]
        [StringLength(200)]
        public string SmtpPassword { get; set; }
        [Display(Name = "SmtpHost")]
        [StringLength(200)]
        public string SmtpHost { get; set; }
        [Display(Name = "Smtpport")]
        [StringLength(200)]
        public string SmtpPort { get; set; }
        public bool SmptpSSLEnabled { get; set; }
        public bool UseSSL { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Linkedin { get; set; }
        public string Instagram { get; set; }
        public string Youtube { get; set; }
        [Display(Name = "FooterText")]
        [StringLength(4000)]
        public string FooterText { get; set; }
        [Display(Name = "MetaTitle")]
        [StringLength(200)]
        public string MetaTitle { get; set; }
        [Display(Name = "MetaDescription")]
        [StringLength(200)]
        public string MetaDescription { get; set; }
        public string CustomHtml { get; set; }
        public string About { get; set; }
        public string PrivacyPolicy { get; set; }
        public string TermsOfUse { get; set; }
        public string MembershipAgreement { get; set; }
        public string HowItWorks { get; set; }
        public string Faq { get; set; }

    }
}
