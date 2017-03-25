using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstateMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Current = "Home";

            users currentUser = null;

            if ((users)Session["User"] != null)
            {
                currentUser = (users)Session["User"];

                string text = "";

                if (currentUser.type == "Seller")
                {
                    text = "Start selling houses. Click <a href=# class=btn btn-primary btn-lg>here</a> to add a new house to our great list of homes!";
                }
                else
                {
                    text = "Start buying a hous. Click <a href=# class=btn btn-primary btn-lg>here</a>"
                        + "to search for your dream home!";
                }

                ViewBag.Message = "<div class=jumbotron>"
                                    + "<h3>Welcome, " + currentUser.first_name + "</h3>"
                                    + "<p class=lead>" + text + "</p>"
                                    + "</div>";
            }
            else
            {
                ViewBag.Message = "<div class=jumbotron>"
                                    + "<h1>ASP.NET</h1>"
                                    + "<p class=lead>ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS and JavaScript.</p>"
                                    + "<p><a href=http://asp.net class=btn btn-primary btn-lg>Learn more &raquo;</a></p>"
                                    + "</div>";
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.Current = "About";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.Current = "Contact";

            return View();
        }
    }
}