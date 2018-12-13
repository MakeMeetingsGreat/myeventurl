using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyEventURL.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            this.getUser();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            this.getUser();
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            this.getUser();
            return View();
        }

        private void getUser()
        {
            string[] emailarray = null;
            ViewBag.Email = User.Identity.Name;
            if (ViewBag.Email != "")
            {
                if (ViewBag.Email.Contains("#"))
                {
                    emailarray = ViewBag.Email.Split('#');
                    ViewBag.Email = emailarray[emailarray.Length - 1];
                }
                emailarray = ViewBag.Email.Split('@');
                ViewBag.UserName = emailarray[0];
                ViewBag.Domain = emailarray[1];
            }

        }

    }
}