using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrPortal.Models
{
    public class CompanySearchViewModel
    {
        public CompanySearchViewModel()

        {
            Page = 1;
        }

        public int Page { get; set; }
        public string Keywords { get; set; }
        public string LocationId { get; set; }
        public string SectorId { get; set; }
        public int SortBy { get; set; }
        public ReflectionIT.Mvc.Paging.PagingList<HrPortal.Models.Company> SearchResults { get; set; }
    }
}
