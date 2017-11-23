using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public class Audit:BaseEntity
    {
        [StringLength(200)]
        public string EntityId { get; set; }
        [StringLength(200)]
        public string Area { get; set; }
        [StringLength(200)]
        public string Controller { get; set; }
        [StringLength(200)]
        public string Action { get; set; }
        public string Url { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        [StringLength(200)]
        public string Ip { get; set; }
        public string UserAgent { get; set; }
        [StringLength(200)]
        public string UserName { get; set; }
    }
}
