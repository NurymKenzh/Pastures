using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pastures.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ActionResult Index()
        {
            ViewBag.Moderator = false;
            ViewBag.Admin = false;
            ViewBag.Authenticated = false;
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Authenticated = true;
                if (UserManager.IsInRole(User.Identity.GetUserId(), "Admin"))
                {
                    ViewBag.Admin = true;
                }
                if (UserManager.IsInRole(User.Identity.GetUserId(), "Moderator"))
                {
                    ViewBag.Moderator = true;
                }
            }
            ViewBag.Index = true;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "О сайте.";
            ViewBag.About = true;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Контакты.";
            ViewBag.Contact = true;
            return View();
        }

        public ActionResult Instruction()
        {
            ViewBag.Instruction = true;
            return View();
        }
    }
}