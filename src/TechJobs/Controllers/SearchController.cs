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

        [HttpGet]
        public IActionResult Results(string searchType, string searchTerm)
        {
            if (searchType == "all")
            {
                List<Dictionary<string, string>> Jobs = JobData.FindByValue(searchTerm);
                ViewBag.jobs = Jobs;
                ViewBag.columns = ListController.columnChoices;
                ViewBag.title = "Jobs with " + searchType + "containing " + searchTerm;

            }
            else {
                List<Dictionary<string, string>> Jobs = JobData.FindByColumnAndValue(searchType,searchTerm);
                ViewBag.jobs = Jobs;
                ViewBag.columns = ListController.columnChoices;
                ViewBag.title = "Jobs with " + searchType + "containing " + searchTerm;

            }



            return View("Index");
            // TODO #1 - Create a Results action method to process 
            // search request and display results
        }



    }
}
