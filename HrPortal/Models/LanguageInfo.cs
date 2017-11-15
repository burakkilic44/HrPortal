using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public class LanguageInfo:BaseEntity
    {
        public string ResumeId { get; set; }
        public Resume Resume { get; set; }
        public string LanguageId { get; set; }
        public Language Language { get; set; }
        [Display(Name = "Konuşma")]
        public int SpeakingLevel { get; set; }
        [Display(Name = "Okuma")]
        public int ReadingLevel { get; set; }
        [Display(Name = "Yazma")]
        public int WritingLevel { get; set; }

    }
}
