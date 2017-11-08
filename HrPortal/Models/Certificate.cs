using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public class Certificate:BaseEntity
    {
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Issuer { get; set; }
        public DateTime IssueDate { get; set; }
        [StringLength(200)]
        public string CertificateFile { get; set; }
        public string ResumeId { get; set; }
        public Resume Resume { get; set; }
    }
}
