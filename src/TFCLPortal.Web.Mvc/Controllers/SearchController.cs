using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using TFCLPortal.Controllers;
using TFCLPortal.Web.Models.Search;

namespace TFCLPortal.Web.Controllers
{
    public class SearchController : TFCLPortalControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Search(SearchModel search)
        {
            if(search.SearchType== "Application Number")
            {

            }
            else if (search.SearchType == "Sequence Number")
            {

            }
            else if(search.SearchType == "CNIC Number")
            {

            }
            else if (search.SearchType == "Applicant Name")
            {

            }

            return View();
        }
    }
}
