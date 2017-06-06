using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(ConnexionViewModel _v)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Error = "Il semble que votre compte soit inexistant";
                return View(_v);
            }
            _v.ToString();
            return RedirectToAction("Index", controllerName: "Home");
        }
    }
}