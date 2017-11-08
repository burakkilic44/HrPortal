using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public class LanguageInfo
    {
        public string ResumeId { get; set; }
        public Resume Resume { get; set; }
        public string LanguageId { get; set; }
        public Language Language { get; set; }
        public int SpeakingLevel { get; set; }
        public int ReadingLevel { get; set; }
        public int WritingLevel { get; set; }

    }
}
