using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using System.Data.Entity;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private AppEntities db = new AppEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authorize(WebApp.Models.UserLogin userLogin)
        {
            var loginDetails = db.UserLogins.Where(x => x.Username == userLogin.Username && x.Password == userLogin.Password).FirstOrDefault();
            if (loginDetails == null)
            {
                return RedirectToAction("Index", "Login");
           
            }
            else
            {
                Session["LoginId"] = loginDetails.Id;
                Session["LoginName"] = loginDetails.Name;
                Session["LoginUserName"] = loginDetails.Username;
               
                return RedirectToAction("Index", "Customers"); 
            }

        }

        public ActionResult Logout()
        {
            //int Login = (int)Session["LoginId"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        
        }
    }
}