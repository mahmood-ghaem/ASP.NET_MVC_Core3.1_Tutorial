using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DataFromControllerToView.Controllers
{
    public class Default2Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TempDataDemoGet()
        {
            return View();
        }
        public IActionResult GetSession()
        {
            return View();
        }
    }
}