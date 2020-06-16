using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using DataFromControllerToView.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataFromControllerToView.Controllers
{
    public class Default1Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult ViewDataDemo()
        {
            ViewData["myData2"] = "Hello World! from ViewData";
            return View();
        }


        public IActionResult TempDataDemoSend()
        {
            TempData["myData3"] = "Hello World! from TempData";
            return RedirectToAction("TempDataDemoGet", "Default2");
        }

        [HttpGet]
        public IActionResult SetSession()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SetSession(string name)
        {
            HttpContext.Session.SetString("sessionuser", name);
            return RedirectToAction("GetSession", "Default2");
        }

        //usefull reference: https://asp.mvc-tutorial.com/httpcontext/cookies/ 
        public IActionResult ReadWriteCookie()
        {
            if (!HttpContext.Request.Cookies.ContainsKey("first_request"))
            {
                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = new DateTimeOffset(DateTime.Now.AddDays(7));
                HttpContext.Response.Cookies.Append("first_request", DateTime.Now.ToString(), cookieOptions);
                return Content("Welcome, new visitor!");
            }
            else
            {
                DateTime firstRequest = DateTime.Parse(HttpContext.Request.Cookies["first_request"]);
                return Content("Welcome back, user! You first visited us on: " + firstRequest.ToString());
            }
        }

        public IActionResult ViewBagObject()
        {
            dynamic myDynamicData = new ExpandoObject();
            myDynamicData.id = 1;
            myDynamicData.stringValue = "Some Text Sample";
            ViewBag.sendDynamicData = myDynamicData;

            MyUser myUser = new MyUser()
            {
                age = 20,
                firstName = "Reza",
                lastName = "Razavi"
            };
            ViewBag.sendUser = myUser;
            return View();
        }





    }
}