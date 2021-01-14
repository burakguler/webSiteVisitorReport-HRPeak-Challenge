using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webSiteVisitorReport.Models
{
    public class VisitorPageModel
    {
        public int TotalVisitor { get; set; }
        public string  MostVisitedCountry { get; set; }
        public List<PageVisitModel> TotalPageVisits { get; set; }
        public List<DateVisitModel> DateVisits { get; set; }
    }
}
