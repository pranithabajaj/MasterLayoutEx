using MasterLayoutEx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterLayoutEx.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult LoginPage(tbl_login C)
        {
            if (ModelState.IsValid)
            {
                string uname = Request.Form["username"];
                string pwd = Request.Form["password"];
                if (DBOperations.GetDetails(uname, pwd))
                    return RedirectToAction("Index");
                else
                {
                    ViewBag.L = "Invalid Details";
                    return View("Login");
                }
            }
            else
            return View("Login");
        }
        public ActionResult Login()
        {
            return View();
        }
        
    }
}