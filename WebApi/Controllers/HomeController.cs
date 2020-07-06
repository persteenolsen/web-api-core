using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
//using CoreTwoZeroJS.Models;

namespace WebApi.Controllers
{

  //  [AllowAnonymous]
    public class HomeController : Controller
    {

       
        [AllowAnonymous]
        [Route("/")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
                      
    }
}
