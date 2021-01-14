using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileManagers.Models
{
    public class VisitorModel
    {
        public VisitorModel(string pageName, string browser, string country, DateTime visitDate)
        {
            PageName = pageName;
            Browser = browser;
            Country = country;
            VisitDate = visitDate;
        }

        public string PageName { get; set; }
        public string Browser { get; set; }
        public string Country { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
