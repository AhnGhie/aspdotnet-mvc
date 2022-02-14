using LogInRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogInRegister.Controllers
{
    public class UserController : Controller
    { 
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserModel user)
        {
            if (ModelState.IsValid)
            {
                using (AppDbContext db = new AppDbContext())
                {
                    db.user.Add(user);
                    db.SaveChanges();
                }
              
                ModelState.Clear();

                using (AppDbContext db = new AppDbContext())
                {
                    var userVerify = db.user.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
                    Session["UserId"] = userVerify.UserId.ToString();
                    Session["Email"] = userVerify.Email.ToString();
                    Session["FirstName"] = userVerify.FirstName.ToString();
                    Session["LastName"] = userVerify.LastName.ToString();

                    return RedirectToAction("LoggedIn");
                }
            }

            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }


        [HttpPost]
        public ActionResult LogIn(UserModel user)
        {
            using (AppDbContext db = new AppDbContext())
            {
                var userVerify = db.user.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
                if(userVerify != null)
                {
                    Session["UserId"] = userVerify.UserId.ToString();
                    Session["Email"] = userVerify.Email.ToString();
                    Session["FirstName"] = userVerify.FirstName.ToString();
                    Session["LastName"] = userVerify.LastName.ToString();
                    return RedirectToAction("LoggedIn");

                }
                else
                {
                    ModelState.AddModelError("", "Incorrect Email or Password. Please try again.");
                }
            }

            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
            {   

                return View();
            }
            else
            {
                return RedirectToAction("LogIn");
            }
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("LogIn");
        }
    }
}