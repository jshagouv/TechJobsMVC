using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Dictionary<string, string>> jobs = new List<Dictionary<string, string>>();
            if (searchType == "all")
            {
                jobs = JobData.FindByValue(searchTerm);
            }
            else
             {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
             }
  
            ViewBag.jobs = jobs;
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search Results";
            return View("Index");
        }

    }


}
