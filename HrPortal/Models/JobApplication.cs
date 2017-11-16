using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public class JobApplication : BaseEntity
    {

        public string JobId { get; set; }
        public Job Job { get; set; }

        public string ResumeId { get; set; }
        public Resume Resume { get; set; }
        [Display(Name = "Mesaj")]
        public string Message { get; set; }
    }

    public class JobApplicationSearchViewModel 
    {
        public JobApplicationSearchViewModel()

        {
            Page = 1;
        }

    
        public int Page { get; set; }
        public string Keywords { get; set; }
        
        public ReflectionIT.Mvc.Paging.PagingList<HrPortal.Models.JobApplication> SearchResults { get; set; }
    }



}
