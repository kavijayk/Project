using EasyHousingSolutions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyHousingSolutions.Controllers
{
    public class LoginUserController : Controller
    {
        Training_12Dec18_BangaloreEntities1 ehs = new Training_12Dec18_BangaloreEntities1();
        // GET: LoginUser
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RedirectToRegister(User user)
        {
            if (user.UserType.Equals("UserSeller"))
            {
                return RedirectToAction("RegisterSeller", "Registration");
            }
            else if (user.UserType.Equals("UserBuyer"))
            {
                return RedirectToAction("RegisterBuyer", "Registration");
            }
            return View();
        }

        public ActionResult LoginUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginUser(User user)
        {
            List<User> userlist = ehs.Users.ToList();
            List<User> loginUser = userlist.Where(u => u.UserName == user.UserName
            && u.Pasword == user.Pasword && u.UserType == user.UserType).ToList();
            if (loginUser.Count == 1)
            {
                Session["userName"] = user.UserName;
                Session["userType"] = user.UserType;
                if (user.UserType.Equals("Admin"))
                {
                    return RedirectToAction("Index", "Home");
                }
                if (user.UserType.Equals("Seller"))
                {
                    return RedirectToAction("Index", "Home");
                }
                if (user.UserType.Equals("Buyer"))
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                TempData["Message"] = "Invalid Credentials";
                ModelState.Clear();
                return View();

            }
            return View();
        }
        public ActionResult LogoutUser()
        {
            Session["userType"] = null;
            Session["userName"] = null;
            return RedirectToAction("Home", "Home");
        }
      
    }
}