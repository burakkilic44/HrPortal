using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public class Resume:BaseEntity
    {
        [StringLength(200)]
        public string FullName { get; set; }
        [StringLength(200)]
        public string Title { get; set; }
        [StringLength(200)]
        public string Photo { get; set; }
        [StringLength(4000)]
        public string Notes { get; set; }
        public string LocationId { get; set; }
        public Location Location { get; set; }
        [StringLength(200)]
        public string WebAddress { get; set; }
        public DateTime? BirthDate { get; set; }
        [StringLength(200)]
        public string Phone { get; set; }
        [Required]
        [StringLength(200)]
        public string Email { get; set; }
        public ICollection<ResumeTag> ResumeTags { get; set; }
        [StringLength(200)]
        public string ResumeFile { get; set; }
        [StringLength(200)]
        public string Facebook { get; set; }
        [StringLength(200)]
        public string Twitter { get; set; }
        [StringLength(200)]
        public string GooglePlus { get; set; }
        [StringLength(200)]
        public string Dribbble { get; set; }
        [StringLength(200)]
        public string Pinterest { get; set; }
        [StringLength(200)]
        public string Github { get; set; }
        [StringLength(200)]
        public string Instagram { get; set; }
        [StringLength(200)]
        public string Youtube { get; set; }
        [StringLength(200)]
        public string LinkedIn { get; set; }
        public ICollection<EducationInfo> EducationInfos { get; set; }
        public ICollection<Experience> Experiences { get; set; }
        public ICollection<Skill> Skills { get; set; }
        public ICollection<LanguageInfo> LanguageInfos { get; set; }
        public ICollection<Certificate> Certificates { get; set; }
        public string LanguageId { get; set; }
        public Language Language { get; set; }
        public string Hobbies { get; set; }
        public SmokingStatus SmokingStatus { get; set; }
        public string DrivingLicense { get; set; }
        public bool IsTravelDisabled { get; set; }
        public bool IsApproved { get; set; }
        public DateTime? ApproveDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsEncouraged { get; set; }








    }
}
