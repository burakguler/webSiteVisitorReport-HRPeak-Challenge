using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FileManagers;
using FileManagers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webSiteVisitorReport.Models;

namespace webSiteVisitorReport.Controllers
{
    public class HomeController : Controller
    {

        public static List<VisitorModel> visitorLogs = new List<VisitorModel>();
        private readonly ILogger<HomeController> _logger;
        public HomeController(IFileService fileService,ILogger<HomeController> logger)
        {
            _logger = logger;
            visitorLogs = fileService.GetVisitors();
        }

        public IActionResult Index()
        {
            VisitorPageModel visitorModel = new VisitorPageModel();
            visitorModel.TotalVisitor = visitorLogs.Count;
            visitorModel.MostVisitedCountry = (from p in visitorLogs
                                               group p by p.Country into g
                                               select new { PageName = g.Key, VisitCount = g.Count() }).OrderByDescending(x => x.VisitCount).FirstOrDefault().PageName;
            visitorModel.TotalPageVisits= (from p in visitorLogs
                    group p by p.PageName into g
                    select new PageVisitModel{  PageName= g.Key, VisitCount = g.Count() }).ToList();
            visitorModel.DateVisits = (from p in visitorLogs
                                            group p by p.VisitDate.ToShortDateString() into g
                                            select new DateVisitModel { VisitDate = Convert.ToDateTime(g.Key), VisitCount = g.Count() }).ToList();
            return View(visitorModel);
        }


        public PartialViewResult MakeFilter(DateTime startDate,DateTime endDate)
        {
            var DateVisits = (from p in visitorLogs
                                       group p by p.VisitDate.ToShortDateString() into g
                                       select new DateVisitModel { VisitDate = Convert.ToDateTime(g.Key), VisitCount = g.Count() }).Where(x => x.VisitDate >= startDate || startDate == null && x.VisitDate <= endDate || endDate == null).ToList();
            return PartialView("~/Views/Shared/VisitPageTable.cshtml", DateVisits);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
