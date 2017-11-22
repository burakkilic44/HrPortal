using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public class ApplicationSearchViewModel
    {
        public ApplicationSearchViewModel()
        {
            Page = 1;
        }
        public EducationLevel? EducationLevel { get; set; }
        public MilitaryStatus? MilitaryStatus { get; set; }
        public int Page { get; set; }
        public string Keywords { get; set; }
        public string LocationId { get; set; }
        public int SortBy { get; set; }
        public string OccupationId { get; set; }
        public string JobId { get; set; }
        public ReflectionIT.Mvc.Paging.PagingList<HrPortal.Models.JobApplication> SearchResults { get; set; }
        
    }
}
