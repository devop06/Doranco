using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models.Entity;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private List<User> ListeUser;

        public AccountController()
        {
            ListeUser = new List<Models.Entity.User>();
            ListeUser.Add( new User() { id = 1, pseudo = "toto", password = "test" }  );
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_v"></param>
        /// <param name="returnUrl">Url désiré avant la redirection sur page de log</param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(ConnexionViewModel _v, string ReturnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(_v);
            }
            else
            {
                if (_v.Identifiant == ListeUser[0].pseudo && _v.Password == ListeUser[0].password)
                {
                    FormsAuthentication.SetAuthCookie(_v.Identifiant, false);
                    if (!string.IsNullOrWhiteSpace(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                        return Redirect(ReturnUrl);
                    else
                        return RedirectToAction("Index", controllerName: "Home");
                }
                else
                {
                    ViewBag.Error = "Il semble que votre compte soit inexistant";
                    return View(_v);
                }
            }    
        }
            
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", controllerName: "Home");
        }

        [Authorize]
        public ActionResult Profil()
        {
            string _pseudo = HttpContext.User.Identity.Name;
            User _u =  ListeUser.FirstOrDefault(u => u.pseudo == _pseudo);
            if (_u == null)
                 return View("~/Views/Shared/Error.cshtml");
            else
            {
                UserViewModel _uViewModel = new UserViewModel()
                {
                    Nom = _u.nom,
                    Ville = _u.ville,
                    Adresse = _u.adresse,
                    CodePostale = _u.codePostale,
                    Mail = _u.mail,
                    Pseudo = _u.pseudo,
                    Prenom = _u.prenom

                };
                return View(_uViewModel);
            }
                
        }
    }
}