using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwoFactor.Models;
using System.Security.Cryptography;
using System.Web.Helpers;
using System.Web.Security;
using Google.Authenticator;
using TwoFactor.Helpers;

namespace TwoFactor.Controllers
{
    public class LoginController : Controller
    {
        LoginFac login = new LoginFac();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Setup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Scan(Login user)
        {
            user.Generate = login.CreateTwo(user.email);

            return View(user);
        }

        public ActionResult Validate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Check(Login user)
        {
            if (login.Validate(user.email, user.pin))
            {
                ViewBag.msg = "korrekt";
            }
            else
            {
                ViewBag.msg = "forkert";
            }

            return View();
        }
    }
    
}