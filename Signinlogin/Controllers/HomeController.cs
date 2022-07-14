using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Signinlogin.Models;

namespace Signinlogin.Controllers
{
    public class HomeController : Controller
    {
        UserSignuploginEntities db = new UserSignuploginEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.Userinfoes.ToList());
        }
        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(Userinfo userinfo)
        {
            if (db.Userinfoes.Any(x => x.username == userinfo.username))
            {
                ViewBag.Notification = "This account has already existed";
                return View();
            }
            else
            {
                db.Userinfoes.Add(userinfo);
                db.SaveChanges();

                Session["useridSS"] = userinfo.userid.ToString();
                Session["usernameSS"] = userinfo.username.ToString();
                return RedirectToAction("Index", "Home");

            }


        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View()
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Userinfo userinfo)
        {
          
           var checkLogin = db.Userinfoes.Where(x => x.username.Equals(userinfo.username) && x.password.Equals(userinfo.password)).FirstOrDefault();
            if(checkLogin != null)
            {
                Session["useridSS"] = userinfo.userid.ToString();
                Session["usernameSS"] = userinfo.username.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Notification = "incorrect username password";
            }
            return View();
        }


    }
}